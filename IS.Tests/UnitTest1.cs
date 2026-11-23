using IS;
using Xunit;

namespace IS.Tests
{
    public class DocParserTests
    {
        [Fact]
        public void Parse_ValidLine_ReturnsCorrectDoc()
        {
            string input = @"""Иван Иванов"" 2000.12.12 2020.05.09 1200000 2000000";

            Doc doc = DocParser.Parse(input);

            Assert.Equal("Иван Иванов", doc.Owner.Name);
            Assert.Equal(new DateTime(2000, 12, 12), doc.Owner.BirthDate);
            Assert.Equal(new DateTime(2020, 5, 9), doc.Date);
            Assert.Equal(1200000, doc.Cost.GovCost);
            Assert.Equal(2000000, doc.Cost.MarketCost);
        }

        [Fact]
        public void Parse_SingleWordName_ReturnsCorrectDoc()
        {
            string input = @"""Иван"" 2000.12.12 2020.05.09 1200000 2000000";

            Doc doc = DocParser.Parse(input);

            Assert.Equal("Иван", doc.Owner.Name);
        }

        [Fact]
        public void Parse_LessThanFourFieldsAfterName_ThrowsFormatException()
        {
            string input = @"""Иван Иванов"" 2000.12.12 2020.05.09 1200000";

            Assert.Throws<FormatException>(() => DocParser.Parse(input));
        }

        [Fact]
        public void Parse_EmptyString_ThrowsFormatException()
        {
            string input = "";

            Assert.Throws<FormatException>(() => DocParser.Parse(input));
        }

        [Fact]
        public void Parse_NullString_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => DocParser.Parse(null));
        }

        [Theory]
        [InlineData(@"""Иван Иванов"" 2000.12.12 2020.05.09 abc 2000000")]
        [InlineData(@"""Иван Иванов"" 2000.12.12 2020.05.09 1200000 xyz")]
        public void Parse_InvalidCost_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => DocParser.Parse(input));
        }

        [Theory]
        [InlineData(@"""Иван Иванов"" 2000.12.12 2020.05.09 -1200000 2000000")]
        [InlineData(@"""Иван Иванов"" 2000.12.12 2020.05.09 1200000 -2000000")]
        public void Parse_NegativeCost_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => DocParser.Parse(input));
        }

        [Theory]
        [InlineData(@"""Иван Иванов"" 2000-12-12 2020.05.09 1200000 2000000")]
        [InlineData(@"""Иван Иванов"" 2000.12.12 2020/05/09 1200000 2000000")]
        [InlineData(@"""Иван Иванов"" 2000.13.12 2020.05.09 1200000 2000000")]
        [InlineData(@"""Иван Иванов"" 2000.12.12 2020.05.32 1200000 2000000")]
        public void Parse_InvalidDate_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => DocParser.Parse(input));
        }

        [Fact]
        public void Parse_ExtraSpaces_ReturnsCorrectDoc()
        {
            string input = @"""Иван Иванов""    2000.12.12    2020.05.09    1200000    2000000";

            Doc doc = DocParser.Parse(input);

            Assert.Equal("Иван Иванов", doc.Owner.Name);
            Assert.Equal(new DateTime(2000, 12, 12), doc.Owner.BirthDate);
            Assert.Equal(new DateTime(2020, 5, 9), doc.Date);
            Assert.Equal(1200000, doc.Cost.GovCost);
            Assert.Equal(2000000, doc.Cost.MarketCost);
        }

        [Fact]
        public void Parse_MultipleWordsInName_ReturnsFullName()
        {
            string input = @"""Иван Иванович Иванов"" 2000.12.12 2020.05.09 1200000 2000000";

            Doc doc = DocParser.Parse(input);

            Assert.Equal("Иван Иванович Иванов", doc.Owner.Name);
        }
    }
}
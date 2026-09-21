using IS;
namespace IS.Tests;

public class DocParserTests
{
    [Theory]
    [InlineData("\"Иван Иванов\" 2000.12.12 2020.05.09 1200000 2000000")]
    [InlineData("\"Петр Сидоров\" 1995.01.01 2021.03.15 850000 1100000")]
    [InlineData("Анна Смирнова 1988.07.20 2019.11.30 2300000 3100000")]
    public void Parse_ValidInput_ReturnsDoc(string input)
    {
        var doc = DocParser.Parse(input);

        Assert.NotNull(doc);
        Assert.False(string.IsNullOrWhiteSpace(doc.Owner.Name));
        Assert.False(string.IsNullOrWhiteSpace(doc.Date));
        Assert.False(string.IsNullOrWhiteSpace(doc.Cost.GovCost));
        Assert.False(string.IsNullOrWhiteSpace(doc.Cost.MarketCost));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("только одно слово")]
    [InlineData("\"Имя\" 2000.01.01")]
    [InlineData("\"Имя\" 2000.01.01 2020.01.01 abc 2000000")]
    [InlineData("\"Имя\" 2000.01.01 2020.01.01 1200000 xyz")]
    public void Parse_InvalidInput_Throws(string input)
    {
        Assert.ThrowsAny<Exception>(() => DocParser.Parse(input));
    }

    [Fact]
    public void Parse_CorrectlyExtractsMultiWordName()
    {
        var doc = DocParser.Parse("\"Иван Иванович Иванов\" 1990.05.15 2022.08.10 1500000 2500000");

        Assert.Equal("Иван Иванович Иванов", doc.Owner.Name);
        Assert.Equal("1990.05.15", doc.Owner.BirthDate);
        Assert.Equal("2022.08.10", doc.Date);
        Assert.Equal("1500000", doc.Cost.GovCost);
        Assert.Equal("2500000", doc.Cost.MarketCost);
    }
}
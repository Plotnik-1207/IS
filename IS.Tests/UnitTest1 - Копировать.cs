using IS;
using System.Drawing;
namespace IS.Tests;

public class PaintTest
{
    [Theory]
    [InlineData("###...##|" +
                "#****..#|" +
                "..#***##|" +
                "*.#.**.#|" +
                "##**..##|" +
                " (2,4) .")]
    public void Is_Painted(string input)
    {
        var parsedInput = parse(input);

        Matrix inputMatrix = new Matrix(parsedInput[0]);

        inputMatrix = paint.fill(inputMatrix, (2, 4), ".");

        Assert.Equal(inputMatrix,
                "###...##" +
                "#......#" +
                "..#...##" +
                "*.#....#" +
                "##**..##");
    }
}
using System;
using DiamondKata;

namespace DiamondKata.Tests;

public class DiamondKataTests
{
    [Fact]
    public void TestCreateDiamondString_A_Line()
    {
            // Arrange
            int length = 5;
            int midpoint = 3;

            // Act
            var result = Program.CreateDiamondString(length, midpoint);

            // Assert
            Assert.Equal("  A  ", result);
    }

    [Fact]
    public void TestCreateDiamondStringWithChar_Correct_Line()
    {
        // Arrange
        int length = 7;
        int leftMidpoint = 2;
        int rightMidpoint = 6;
        char inputChar = 'C';

        // Act
        var result = Program.CreateDiamondStringWithChar(length, leftMidpoint, rightMidpoint, inputChar);

        // Assert
        Assert.Equal(" C   C ", result);
    } 

    [Fact]
    public void TestGenerateDiamond_Line()
    {
        // Arrange
        var expectedOutput = new List<string>
        {
            "  A  ",
            " B B ",
            "C   C"
        };

        // Act
        var result = Program.GenerateOutput('C');

        // Assert
        Assert.Equal(expectedOutput, result);
    }

    [Fact]
    public void TestGenerateDiamond_ForC()
    {
        // Arrange
        // Arrange
        int length = 7;
        int leftMidpoint = 2;
        int rightMidpoint = 6;
        char inputChar = 'C';

        // Act
        var result = Program.CreateDiamondLine(length, leftMidpoint, rightMidpoint, inputChar);

        // Assert
        Assert.Equal(" C   C ", result);
    }
}
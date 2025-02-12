

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.X86;

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]

    public void SingleDigit(string numbers, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    //It can take a string with two integers, separated by a comma. So `Add("1,2")` would produce 3.
    public void AddingTwoStrings(string numbers, int expected)
    {
        //string[] values = numbers.Split(',');
        var calculator = new Calculator();
        var result = calculator.AddNumbers(numbers);
        Assert.Equal(expected, result);
    }

    //It can take an arbitrary length string, so:
    //- `Add("1,2") => 3`
    //- `Add("1,2,3") => 6`
    //- `Add("1,2,3,4,5,6,7,8,9") => 45`
    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    public void AddingArbitraryLengthOfStrings(string numbers, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.AddNumbers(numbers);
        Assert.Equal(expected, result);
    }

    //We can "mix" delimeters.Where before you could only separate numbers with a comma, now you can use a newline. (in C#, a newline is represented with the `\n` escape sequence).
    //- `Add("1\n2") => 3`
    //- `Add("1\n2,3") => 6`
    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("1\n2,3", 6)]
    
    public void AddingArbitraryLengthOfStringsWithMixOfDelimeters(string numbers, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.AddNumbersWithMixDelimiters(numbers);
        Assert.Equal(expected, result);
    }
}
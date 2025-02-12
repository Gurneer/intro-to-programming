using System.Runtime.Serialization;

namespace Todos.Tests;


public class UnitTest1

{

    [Fact] // Attributes (@Fact())

    public void CanFormatAName()

    {

        // Given

        string firstName = "Bob", lastName = "Smith", fullName;
        var formatter = new Formatters();

        // When

        fullName = formatter.FormatName(firstName, lastName);

        // Then 

        Assert.Equal("Smith, Bob", fullName);

    }

    [Theory]

    [InlineData("Bob", "Smith", "Smith, Bob")]
    [InlineData("Luke", "Skywalker", "Skywalker, Luke")]
    public void CanFormatAnyName(string firstName, string lastName, string expecting)
    {
        var formatter = new Formatters();
        var fullName = formatter.FormatName(firstName, lastName);

        Assert.Equal(expecting, fullName);
    }

}


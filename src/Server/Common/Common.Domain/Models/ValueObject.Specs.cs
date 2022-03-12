namespace BettingSystem.Domain.Common.Models;

using FluentAssertions;
using Xunit;

public class ValueObjectSpecs
{
    [Fact]
    public void ValueObjectsWithEqualPropertiesShouldBeEqual()
    {
        // Arrange
        var first = new TestValueObject();
        var second = new TestValueObject();

        // Act
        var result = first == second;

        // Arrange
        result.Should().BeTrue();
    }

    [Fact]
    public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
    {
        // Arrange
        var first = new TestValueObject();
        var second = new TestValueObject2();

        // Act
        var result = first == second;

        // Arrange
        result.Should().BeFalse();
    }

    private class TestValueObject : ValueObject
    {
    }

    private class TestValueObject2 : ValueObject
    {
        public string Test { get; } = default!;
    }
}
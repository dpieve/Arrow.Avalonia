using Arrow.Avalonia.Helpers;

namespace Arrow.Avalonia.Tests.Unit;

public sealed class GetHeadPointsTests
{
    [Fact]
    public void CalculateSlope_ShouldCalculateSlope_WhenDeltaXIsZero()
    {
        // Arrange
        double deltaY = 3;
        double deltaX = 0;

        // Act
        double slope = GetHeadPoints.CalculateSlope(deltaY, deltaX);

        // Assert
        Assert.True(double.IsPositiveInfinity(slope));
    }

    [Fact]
    public void CalculateSlope_ShouldCalculateSlope_WhenDeltaYIsZero()
    {
        // Arrange
        double deltaY = 0;
        double deltaX = 3;

        // Act
        double slope = GetHeadPoints.CalculateSlope(deltaY, deltaX);

        // Assert
        Assert.Equal(0, slope);
    }

    [Fact]
    public void CalculateSlope_ShouldCalculateSlope_WhenDeltasAreNotZero()
    {
        // Arrange
        double deltaY = 6;
        double deltaX = 3;

        // Act
        double slope = GetHeadPoints.CalculateSlope(deltaY, deltaX);

        // Assert
        Assert.Equal(2, slope);
    }

    [Fact]
    public void CalculatePerpendicularSlope_ShouldCalculatePerpendicularSlope_WhenSlopeIsZero()
    {
        // Arrange
        double slope = 0;

        // Act
        double perpendicularSlope = GetHeadPoints.CalculatePerpendicularSlope(slope);

        // Assert
        Assert.Equal(-1 / slope, perpendicularSlope);
    }

    [Fact]
    public void GetDirection_ShouldGetNegativeDirection_WhenDeltaXIsPositive()
    {
        // Arrange
        double deltaX = 4;

        // Act
        int direction = GetHeadPoints.GetDirection(deltaX);

        // Assert
        Assert.Equal(-1, direction);
    }

    [Fact]
    public void GetDirection_ShouldGetPositiveDirection_WhenDeltaXIsNegative()
    {
        // Arrange
        double deltaX = -4;

        // Act
        int direction = GetHeadPoints.GetDirection(deltaX);

        // Assert
        Assert.Equal(1, direction);
    }
}

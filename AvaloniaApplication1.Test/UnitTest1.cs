using AvaloniaApplication1.DLL;

namespace AvaloniaApplication1.Test;

public class UnitTest1
{
    [Fact]
    public void CalculateTotalWeight_ReturnsCorrectSum_ForSeveralValues()
    {
        var service = new Class1();

        var result = service.CalculateTotalWeight(new List<decimal> { 1.5m, 2.0m, 3.0m });

        Assert.Equal(6.5m, result);
    }

    [Fact]
    public void CalculateTotalWeight_ReturnsZero_ForEmptyList()
    {
        var service = new Class1();

        var result = service.CalculateTotalWeight(new List<decimal>());

        Assert.Equal(0m, result);
    }

    [Fact]
    public void CalculateTotalWeight_ReturnsSameValue_ForOneElement()
    {
        var service = new Class1();

        var result = service.CalculateTotalWeight(new List<decimal> { 4.5m });

        Assert.Equal(4.5m, result);
    }

    [Fact]
    public void CalculateTotalWeight_ReturnsCorrectSum_WithZeroValues()
    {
        var service = new Class1();

        var result = service.CalculateTotalWeight(new List<decimal> { 0m, 2.5m, 0m });

        Assert.Equal(2.5m, result);
    }

    [Fact]
    public void CalculateTotalWeight_ThrowsArgumentNullException_WhenListIsNull()
    {
        var service = new Class1();

        Assert.Throws<ArgumentNullException>(() => service.CalculateTotalWeight(null));
    }
}
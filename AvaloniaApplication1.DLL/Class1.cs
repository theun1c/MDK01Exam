namespace AvaloniaApplication1.DLL;

public class Class1
{
    public decimal CalculateTotalWeight(List<decimal> weights)
    {
        if (weights == null)
            throw new ArgumentNullException(nameof(weights));

        decimal sum = 0;

        foreach (var weight in weights)
        {
            sum += weight;
        }

        return sum;
    }
}
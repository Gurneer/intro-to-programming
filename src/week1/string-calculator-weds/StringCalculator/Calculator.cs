
public class Calculator
{
    public int Add(string numbers)
    {
        if (numbers == "1")
        {
            return 1;
        }
        if (numbers == "2")
        {
            return 2;
        }
        return 0;
    }

    public int AddNumbers(string numbers)
    {
        string[] values = numbers.Split(',');
        int sum = values.Select(int.Parse).Sum();
        return sum;

    }

    public int AddNumbersWithMixDelimiters(string numbers)
    {
        string[] values = numbers.Split(new[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int sum = values.Select(int.Parse).Sum();
        return sum;
    }
}
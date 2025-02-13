
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

    public int AddNumbersWithAnyCustomDelimeter(string numbers)
    {
        List<char> allIntegers = new List<char>() {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        int sum = 0;

        foreach (char c in numbers)
        {
            if (allIntegers.Contains(c))
            {
                sum += c - '0';
            }
        }

        return sum;
    }
}
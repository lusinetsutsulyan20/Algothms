public class Program
{
    public static void Main()
    {
        List<int> numbers = new();

        numbers.Add(0);
        numbers.Add(5);
        numbers.Add(6);
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(9);
        numbers.Add(3);
        numbers.Add(8);
        numbers.Add(8);
        numbers.Add(7);

        Bubble_Sort<int>(numbers);

        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }

    public static void Bubble_Sort<T>(List<T> items) where T : IComparable
    {
        T tmp;

        for (int i = 0; i < items.Count - 1; i++)
        {
            for (int j = 0; j < items.Count - i - 1; j++)
            {
                if (items[j].CompareTo(items[j + 1]) > 0)
                {
                    tmp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = tmp;
                }
            }
        }
    }
}

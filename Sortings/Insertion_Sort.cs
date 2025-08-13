public class Program
{
    public static void Main()
    {
        List<int> numbers = new();

        numbers.Add(0);
        numbers.Add(1);
        numbers.Add(7);
        numbers.Add(3);
        numbers.Add(8);
        numbers.Add(5);
        numbers.Add(6);
        numbers.Add(6);
        numbers.Add(2);
        numbers.Add(4);

        Insertion_Sort<int>(numbers);

        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }
    public static void Insertion_Sort<T>(List<T> items) where T : IComparable
    {
        for (int i = 1; i < items.Count; ++i)
        {
            T val = items[i];
            int j = i - 1;

            while (j >= 0 && val.CompareTo(items[j]) < 0)
            {
                items[j + 1] = items[j];
                --j;
            }
            items[j + 1] = val;
        }
    }
}

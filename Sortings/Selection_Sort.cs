using System.Diagnostics;

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

        Selection_Sort<int>(numbers);

        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }

    public static void Selection_Sort<T>(List<T> items) where T : IComparable
    {
        int index = 0, tmpIndex;
        T tmp;

        while(index < items.Count - 1)
        {
            tmpIndex = MinimumItem<T> (items, index);
            
            tmp = items[index];
            items[index] = items[tmpIndex];
            items[tmpIndex] = tmp;

            ++index;
        }
    }

    private static int MinimumItem<T>(List<T> items, int left) where T : IComparable
    {
        T min = items[left];
        for (int i = left + 1; i < items.Count; i++)
        {
            if (min.CompareTo(items[i]) > 0)
            {
                min = items[i];
                left = i;
            }
        }
        return left;
    }

    
}

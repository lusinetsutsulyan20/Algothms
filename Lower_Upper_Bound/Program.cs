public class Program
{
    public static void Main()
    {
        List<int> numbers = new();
        numbers.Add(0);
        numbers.Add(2);
        numbers.Add(2);
        numbers.Add(2);
        numbers.Add(2);
        numbers.Add(2);
        numbers.Add(2);
        numbers.Add(7);
        numbers.Add(8);
        numbers.Add(9);

        Console.WriteLine(LowerBound<int>(numbers, 9));
        Console.WriteLine(UpperBound<int>(numbers, 9));
    }
    public static int LowerBound<T>(List<T> items, T target) where T : IComparable
    {
        int left = 0, right = items.Count - 1, middle;

        while (right >= left)
        {
            middle = left + (right - left) / 2;

             if (target.CompareTo(items[middle]) <= 0)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return left;
    }

    public static int UpperBound<T>(List<T> items, T target) where T : IComparable
    {
        int left = 0, right = items.Count - 1, middle;

        while (right >= left)
        {
            middle = left + (right - left) / 2;

            if (items[middle].CompareTo(target) <= 0)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }
        return right + 1;
    }
}

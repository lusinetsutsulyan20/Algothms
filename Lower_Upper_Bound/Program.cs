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

        Console.WriteLine(LowerBound<int>(numbers, 2));
        Console.WriteLine(UpperBound<int>(numbers, 2));
    }
    public static int LowerBound<T>(List<T> items, T target) where T : IComparable
    {
        if (target.CompareTo(items[0]) == 0)
        {
            return 0;
        }

        int left = 0, right = items.Count - 1, middle;

        while (right >= left)
        {
            middle = left + ((right - left) / 2);

            if (target.CompareTo(items[middle]) == 0 && target.CompareTo(items[middle - 1]) > 0)
            {
                return middle;
            }
            else if (target.CompareTo(items[middle]) <= 0)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }
        return -1;
    }

    public static int UpperBound<T>(List<T> items, T target) where T : IComparable
    {
        if (target.CompareTo(items[items.Count - 1]) == 0)
        {
            return items.Count - 1;
        }
        
        int left = 0, right = items.Count - 1, middle;

        while (right >= left)
        {
            middle = left + ((right - left) / 2);

            if (target.CompareTo(items[middle]) == 0 && target.CompareTo(items[middle + 1]) < 0)
            {
                return middle;
            }
            else if (target.CompareTo(items[middle]) >= 0)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }
        return -1;
    }
}

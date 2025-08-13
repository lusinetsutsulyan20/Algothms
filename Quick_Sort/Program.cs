public class Program
{
    public static void Main()
    {
        List<int> numbers = new List<int> { 7, 14, 2, 9};

        Quick_Sort_Last(numbers, 0, numbers.Count - 1);

        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }

    public static void Quick_Sort_Last<T>(List<T> items, int left, int right) where T : IComparable
    {
        if (left >= right) return;

        int mid = Partition(items, left, right);
        Quick_Sort_Last(items, left, mid - 1);
        Quick_Sort_Last(items, mid + 1, right);
    }
    
    public static int Partition<T>(List<T> items, int left, int right) where T : IComparable
    {
        T pivot = items[right];
        int i = left, j = right - 1;

        while (i <= j)
        {
            while (i < j && items[i].CompareTo(pivot) < 0) ++i;
            while (j > i && items[j].CompareTo(pivot) > 0) --j;
            if (items[j].CompareTo(items[i]) <= 0)
            {
                T tmp = items[i];
                items[i] = items[j];
                items[j] = tmp;
            }
        }
        T tmp1 = items[i];
        items[i] = items[right];
        items[right] = tmp1;

        return i;
    }
}

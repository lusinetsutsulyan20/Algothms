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

        Merge_Sort<int>(numbers, 0, numbers.Count - 1);

        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }

    public static void Merge_Sort<T>(List<T> items, int left, int right) where T : IComparable
    {
        if (left >= right) return;

        int middle = left + (right - left) / 2;

        Merge_Sort<T>(items, left, middle);
        Merge_Sort<T>(items, middle + 1, right);

        Merge<T>(items, left, middle, right);

    }
    private static void Merge<T>(List<T> items, int left, int middle, int right) where T : IComparable
    {
        int left1 = left, right1 = middle;
        int left2 = middle + 1, right2 = right;
        List<T> tmp = new();

        while (left1 <= right1 && left2 <= right2)
        {
            if (items[left1].CompareTo(items[left2]) <= 0)
            {
                tmp.Add(items[left1]);
                ++left1;
            }
            else
            {
                tmp.Add(items[left2]);
                ++left2;
            }
        }

        while (left1 <= right1)
        {
            tmp.Add(items[left1]);
            ++left1;
        }
        while (left2 <= right2)
        {
            tmp.Add(items[left2]);
            ++left2;
        }

        for (int i = 0; i < tmp.Count; i++)
        {
            items[left] = tmp[i];
            ++left;
        }
    }
}

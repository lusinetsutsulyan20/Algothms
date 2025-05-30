using System.Collections.Generic;
namespace ProgramNamespace
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = new();
            numbers.Add(1);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(6);
            numbers.Add(9);

            Console.WriteLine(MyBinarySearch<int>(numbers, 7));
        }

        public static int MyBinarySearch<T>(List<T> items, T target) where T : IComparable<T>
        {
            int left = 0, right = items.Count - 1, middle;


            // int result = item1.CompareTo(item2);

            // result < 0 → item1 is less than item2

            // result == 0 → they are equal

            // result > 0 → item1 is greater than item2


            while (right >= left)
            {
                middle = left + ((right - left) / 2);
                if (target.CompareTo(items[middle]) == 0)
                {
                    return middle;
                }
                if (target.CompareTo(items[middle]) < 0)
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
    }
}

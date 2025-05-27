namespace MyclProgramNamespace
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

            Console.WriteLine(MyBinarySearch<int>(numbers, 5, 0, numbers.Count - 1));
        }

        public static int MyBinarySearch<T>(List<T> items, T target, int left, int right) where T : IComparable<T>
        {
            if (left > right)
            {
                return -1;
            }
            int middle = left + ((right - left) / 2);
            if (target.CompareTo(items[middle]) == 0)
            {
                return middle;
            }
            else if (target.CompareTo(items[middle]) < 0)
            {
                return MyBinarySearch<T>(items, target, left, middle - 1);
            }
            else 
            {
                return MyBinarySearch<T>(items, target, middle + 1, right);
            }
        }
    }
}
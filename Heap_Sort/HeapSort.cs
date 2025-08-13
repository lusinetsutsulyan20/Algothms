namespace HeapSortNamespace
{
    public static class HeapSort
    {
        public static void MyHeapSort<T>(List<T> _items) where T : IComparable<T>
        {
            for (int i = (_items.Count / 2 - 1); i >= 0; i--)
            {
                Heapify(_items, i, _items.Count);
            }

            for (int i = _items.Count - 1; i > 0; i--)
            {
                (_items[0], _items[i]) = (_items[i], _items[0]);
                Heapify(_items, 0, i);
            }
        }

        private static void Heapify<T>(List<T> _items, int i, int n) where T : IComparable<T>
        {
            int largest = i;
            int left = GetLeftIndex(i);
            int right = GetRightIndex(i);

            if (left < n && _items[largest].CompareTo(_items[left]) < 0)
            {
                largest = left;
            }
      
            if (right < n && _items[largest].CompareTo(_items[right]) < 0)
            {
                largest = right;
            }
            if (largest != i)
            {
                (_items[i], _items[largest]) = (_items[largest], _items[i]);
                Heapify(_items, largest, n);
            }
        }

        private static int GetLeftIndex(int i) => (i * 2 + 1);

        private static int GetRightIndex(int i) => (i * 2 + 2);

    }
}

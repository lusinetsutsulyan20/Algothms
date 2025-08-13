namespace MaxHeapNamespace
{
    public class MaxHeap<T> where T : IComparable<T>
    {
        private List<T> _items;
        private int _size = 0;
        public int Size
        {
            get
            {
                return _size;
            }
        }

        public MaxHeap()
        {
            _items = new List<T>();
        }

        public MaxHeap(List<T> values)
        {
            _size = values.Count;
            _items = new List<T>(values);
            BuildMaxHeap();
        }


        //public methods

        public void Push(T value)
        {
            _items.Add(value);
            ++_size;
            int index = _size - 1;

            while (index > 0)
            {
                int parent = GetParenthIndex(index);
                if (_items[parent].CompareTo(_items[index]) < 0)
                {
                    (_items[parent], _items[index]) = (_items[index], _items[parent]);
                    index = parent;
                }
                else break;
            }
        }


        public void Pop() // TValue return max; 
        {
            if (_size == 0)
                throw new InvalidOperationException("Heap is empty.");

            _items[0] =_items[_size - 1];
            _items.RemoveAt(_size - 1);
            --_size;
            Heapify(0, _size);
        }

        public T Top()
        {
            if (_size == 0)
                throw new InvalidOperationException("Heap is empty.");

            return _items[0];
        }

        public bool IsEmpty() => _size == 0;



        //private mehods

        private void BuildMaxHeap()
        {
            for (int i = (_size / 2 - 1); i >= 0; i--)
                Heapify(i, Size);
        }

        private void Heapify(int i, int n)
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
                Heapify(largest, n);
            }
        }
        private int GetLeftIndex(int i) => (i * 2 + 1);

        private int GetRightIndex(int i) => (i * 2 + 2);

        private int GetParenthIndex(int i) => (i - 1) / 2;
    }
}

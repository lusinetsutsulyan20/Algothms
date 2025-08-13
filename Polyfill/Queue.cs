using ListNamespace;
namespace QueueNamespace
{
    public class MyQueue<T> where T : ICloneable
    {

        private readonly int _capacity;
        private int _size;
        public int Size => _size;
        private int _front = 0;
        private int _rear = 0;
        private MyList<T> _items;


        public MyQueue(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be positive.", nameof(capacity));

            _capacity = capacity;
            _items = new MyList<T>(_capacity);
        }

        public void Enqueue(T value)
        {
            if (IsFull())
                throw new InvalidOperationException("Queue is full.");

            _items[_rear] = value;
            _rear = (_rear + 1) % _capacity;
            ++_size;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            T tmp = (T)_items[_front].Clone();

            _items[_front] = default!;
            _front = (_front + 1) % _capacity;
            --_size;

            return tmp;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            return _items[_front];
        }
        public bool IsEmpty() => _size == 0;
        public bool IsFull() => _size == _capacity;
    }
}
using System.Collections;
using ListNamespace;

namespace StackNamespace
{
    public class MyStack<T> where T : ICloneable
    {
        private int _size;
        public int Size
        {
            get { return _size; }
        }

        private MyList<T> _items;


        public MyStack()
        {
            _items = new MyList<T>();
        }


        public void Push(T value)
        {
            _items.Add(value);
            ++_size;
        }

        public T Pop()
        {
            if (_size == 0)
                throw new InvalidOperationException("Stack is empty.");

            T tmp = _items[_size - 1];
            _items.RemoveLast();
            --_size;
            return (T)tmp.Clone();
        }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Stack is empty.");

            return _items[_size - 1];
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        
    }

    public class MyEnumerator<T> : IEnumerator<T>
    {
        private T[] _items;
        private int _position = -1;
        private int _size;

        public MyEnumerator(T[] items, int size)
        {
            _items = items;
            _size = size;
        }

        public T Current => _items[_position];

        object IEnumerator.Current
        {
            get
            {
                if (_position < 0 || _position >= _size)
                    throw new ArgumentOutOfRangeException(nameof(_position));
        
                return Current!;
            }
        }

        public bool MoveNext()
        {
            ++_position;
            return _position < _size;
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose() { } 
    }
}   
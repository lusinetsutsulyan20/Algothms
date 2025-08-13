using System.Collections;

namespace ListNamespace
{
    public class MyList<T> : IEnumerable<T> where T :    ICloneable
    {
        private int _capacity = 0;
        private int _size;
        public int Size => _size;
        private T[] _items = new T[0];



        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _size)
                    return _items[index];

                throw new IndexOutOfRangeException("Index is out of range.");
            }
            set
            {
                if (index >= 0 && index < _size)
                    _items[index] = value;
                else
                    throw new IndexOutOfRangeException("Index is out of range.");
            }
        }



        public MyList(int capacity = 0)
        {
            _capacity = capacity;
            _items = new T[_capacity];
        }

        private void MyResize()
        {
            _capacity = _capacity == 0 ? 1 : _capacity * 2;

            T[] tmp = new T[_capacity];

            for (int i = 0; i < _size; i++)
                tmp[i] = _items[i];

            _items = tmp;
        }

        public void Add(T value, int count = 1)
        {
            while (_capacity < count + _size) MyResize();

            while (count-- > 0)
                _items[_size++] = (T)value.Clone();
        }

        public void Insert(T value, int position, int count = 1)
        {
            if (position < 0 || position > _size)
                throw new ArgumentOutOfRangeException(nameof(position));

            if (position == _size)
            {
                Add(value, count);
                return;
            }

            while (_capacity < count + _size) MyResize();

            for (int i = _size - 1; i >= position; i--)
                _items[i + count] = _items[i];

            for (int i = position; i < position + count; i++)
                _items[i] = (T)value.Clone();

            _size += count;
        }

        public void Insert(int position, MyList<T> values)
        {
            if (position < 0 || position > _size)
                throw new ArgumentOutOfRangeException(nameof(position));

            int count = values._size;

            while (_capacity < count + _size) MyResize();

            for (int i = _size - 1; i >= position; i--)
                _items[i + count] = _items[i];

            int index = 0;

            for (int i = position; i < position + count; i++)
                _items[i] = (T)values[index++].Clone();

            _size += count;

        }

        public void RemoveLast()
        {
            if (Size == 0)
                throw new InvalidOperationException("List is empty.");

            --_size;
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position >= _size)
                throw new ArgumentOutOfRangeException(nameof(position));

            for (int i = position; i < _size - 1; i++)
                _items[i] = _items[i + 1];

            --_size;
        }

        public void ShrinkToFit()
        {
            if (_size == _capacity) return;

            T[] tmp = new T[_size];

            for (int i = 0; i < _size; i++)
                tmp[i] = _items[i];

            _items = tmp;
            _capacity = _size;
        }

        public void Resize(int count, T value)
        {
            if (_size == count) return;

            if (count < _size)
            {
                T[] tmp1 = new T[count];

                for (int i = 0; i < count; i++)
                    tmp1[i] = _items[i];

                _items = tmp1;
                _size = count;
                _capacity = count;
                return;
            }

            T[] tmp = new T[count];

            for (int i = 0; i < _size; i++)
                tmp[i] = _items[i];

            for (int i = _size; i < count; i++)
                tmp[i] = (T)value.Clone();

            _items = tmp;
            _size = count;
            _capacity = count;;
        }

        public void Clear()
        {
            if (_size == 0) return;
            _size = 0;
            // _capacity = 0;
            // _items = new T[0];
        }

        public bool Empty()
        {
            return _size == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(_items, _size);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
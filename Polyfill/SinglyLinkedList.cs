namespace SLLNamespace
{
    public class Node<T>
    {
        public T? Value { get; set; }
        public Node<T>? Next { get; set; } // internal set

        public Node(T? value, Node<T>? next = null)
        {
            Value = value;
            Next = next;
        }
    }

    public class SLL<T> : IEnumerable<T> where T : IComparable<T>
    {
        private int _count;
        public int Count => _count;
        private Node<T> _head; // internal head

        public SLL()
        {
            _head = new Node<T>(default, null);
        }


        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value, _head.Next);
            _head.Next = node;
            ++_count;
        }
        public void AddFirst(SLL<T> values)
        {
            if (values._count == 0) return;

            Node<T> tail = values._head;
            while (tail.Next != null)
                tail = tail.Next;

            tail.Next = _head.Next;
            _head.Next = values._head.Next;
            _count += values._count;
        }
        public void RemoveFirst()
        {
            if (_count == 0)
                throw new InvalidOperationException("SLL is empty.");

            _head.Next = _head.Next!.Next;
            --_count;
        }



        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value);
            Node<T> tmp = _head;

            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }

            tmp.Next = newNode;
            ++_count;
        }
        public void AddLast(SLL<T> values)
        {
            if (values._count == 0) return;

            Node<T> tmp = _head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }

            tmp.Next = values._head.Next;
            _count += values._count;

        }
        public void RemoveLast()
        {
            if (_count == 0)
                throw new InvalidOperationException("SLL is empty.");

            if (_count == 1)
            {
                _head.Next = null;
                --_count;
                return;
            }

            Node<T> tmp = _head;
            while (tmp.Next!.Next != null)
            {
                tmp = tmp.Next;
            }
            tmp.Next = null;
            --_count;
        }

        public void Remove(int position)
        {
            if (position < 0 || position >= _count)
                throw new ArgumentOutOfRangeException(nameof(position));

            Node<T> tmp = _head;

            for (int i = 0; i < position; i++)
            {
                tmp = tmp.Next!;
            }

            tmp.Next = tmp.Next!.Next;


            --_count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = _head.Next;

            while (current != null)
            {
                yield return current.Value!;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
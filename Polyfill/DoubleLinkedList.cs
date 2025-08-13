namespace DLLNamespace
{
    public class Node<T>
    {
        public T? Value { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Prev { get; set; }

        public Node(T? value, Node<T>? next = null, Node<T>? prev = null)
        {
            Value = value;
            Next = next;
            Prev = prev;
        }
    }

    public class SLL<T>
    {
        private int _count;
        public int Count => _count;
        private Node<T>? Head;

        public SLL()
        {
            Head = new Node<T>(default, null);
        }

    }
}

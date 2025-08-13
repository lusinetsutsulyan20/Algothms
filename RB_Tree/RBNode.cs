namespace NodeNamspace
{
    public class Node<T>
    {
        public T Value;
        public Node<T>? left = null;
        public Node<T>? right = null;
        public Node<T>? parenth = null;
        public bool isRed;

        public Node(T value, bool isRed = true)
        {
            Value = value;
            this.isRed = isRed;
        }
    }
}
namespace NodeNamespace
{
    public class Node<T>
        {
            public  T val;
            public Node<T> left;
            public Node<T> right;

            public Node(Node<T> left = null!, Node<T> right = null!, T val = default!)
            {
                this.left = left;
                this.right = right;
                this.val = val;
            }
            public Node (T val)
            {
                this.left = null!;
                this.right = null!;
                this.val = val;   
            }
        }
}

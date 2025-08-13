namespace RBTreeNamespace
{
    using System.Reflection;
    using NodeNamspace;
    public class RBTree<T> where T : IComparable<T>
    {
        private Node<T>? root;
        private readonly Node<T>? NIL;

        public RBTree()
        {
            NIL = new Node<T>(default!)
            {
                isRed = false,
                left = null,
                right = null,
                parenth = null
            };

            root = NIL;
        }

        public void LeftRotate(Node<T> node)
        {
            Node<T>? y = node.right;
            node.right = y!.left;

            if (y.left != NIL)
                y.left!.parenth = node;

            y.parenth = node.parenth;

            if (node.parenth == NIL)
                root = y;
            else if (node == node.parenth!.left)
                node.parenth!.left = y;
            else
                node.parenth!.right = y;

            y.left = node;
            node.parenth = y;
        }

        public void RightRotate(Node<T> node)
        {
            Node<T>? y = node.left;
            node.left = y!.right;

            if (y.right != NIL)
                y.right!.parenth = node;

            y.parenth = node.parenth;

            if (node.parenth == NIL)
                root = node;
            else if (node == node.parenth!.left)
                node.parenth.left = y;
            else
                node.parenth.right = y;

            y.right = node;
            node.parenth = y;
        }

        public void Insert(T val)
        {
            Node<T> node = new Node<T>(val);

            Node<T> curr = root!;
            Node<T> prev = NIL!;

            while (curr != NIL)
            {
                prev = curr;
                if (node.Value.CompareTo(curr.Value) < 0)
                    curr.left = node;
                else
                    curr.right = node;

                node.left = NIL;
                node.right = NIL;
                node.isRed = true;

                InsertFixUp(node);
            }
        }

        public void InsertFixUp(Node<T> node)
        {
            while (node.parenth!.isRed)
            {
                if (node.parenth == node.parenth.parenth!.left)
                {
                    Node<T> uncle = node.parenth.parenth.right!;

                    if (uncle.isRed)
                    {
                        node.parenth.isRed = false;
                        uncle.isRed = false;
                        node.parenth.parenth.isRed = true;
                        node = node.parenth.parenth;
                    }
                    else
                    {
                        if (node == node.parenth.right)
                        {
                            node = node.parenth;
                            LeftRotate(node);
                        }

                        node.parenth!.isRed = false;
                        node.parenth.parenth!.isRed = true;
                        RightRotate(node.parenth.parenth);
                    }
                }
                else
                {
                    Node<T> uncle = node.parenth.parenth.left!;

                    if (uncle.isRed)
                    {
                        node.parenth.isRed = false;
                        uncle.isRed = false;
                        node.parenth.parenth.isRed = true;
                        node = node.parenth.parenth;
                    }
                    else
                    {
                        if (node == node.parenth.left)
                        {
                            node = node.parenth;
                            RightRotate(node);
                        }

                        node.parenth!.isRed = false;
                        node.parenth.parenth!.isRed = true;
                        LeftRotate(node.parenth.parenth);
                    }

                    root!.isRed = false;
                }
            }
        }
    }
}
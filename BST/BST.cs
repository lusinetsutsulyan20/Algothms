namespace BSTNamespace
{
    using System.Reflection.Metadata.Ecma335;
    using NodeNamespace;
    public class BinarySearchTree
    {
        public class Tree<T> where T : IComparable
        {
            Node<T> root;

            public Tree()
            {
                root = null!;
            }

            //traversals

            public void PreOrder(Node<T> root)
            {
                if (root == null) return;

                Console.WriteLine(root.val);
                PreOrder(root.left);
                PreOrder(root.right);
            }
            public void InOrder(Node<T> root)
            {
                if (root == null) return;

                InOrder(root.left);
                Console.WriteLine(root.val);
                InOrder(root.right);
            }
            public void PostOrder(Node<T> root)
            {
                if (root == null) return;

                PostOrder(root.left);
                PostOrder(root.right);
                Console.WriteLine(root.val);
            }


            //recursive methods

            public bool Search(T val)
            {
                return SearchHelper(root, val);
            }
            private bool SearchHelper(Node<T> root, T val)
            {
                if (root == null) return false;

                if ((root.val).CompareTo(val) == 0) return true;
                if ((root.val).CompareTo(val) > 0)
                    return SearchHelper(root.left, val);
                else
                    return SearchHelper(root.right, val);
            }


            public bool Insert(T val)
            {
                if (SearchHelper(root, val))
                    return false;

                root = InsertHelper(root, val);
                return true;
            }
            private Node<T> InsertHelper(Node<T> node, T val)
            {
                if (node == null) return new Node<T>(val);

                if ((node.val).CompareTo(val) > 0)
                    node.left = InsertHelper(node.left, val);
                else
                    node.right = InsertHelper(node.right, val);

                return node;
            }

            public void Delete(T val) => root = DeleteHelper(root, val);

            private Node<T> DeleteHelper(Node<T> node, T val)
            {
                if (node == null) return null!;

                if (node.val.CompareTo(val) > 0)
                {
                    node.left = DeleteHelper(node.left, val);
                }
                else if (node.val.CompareTo(val) < 0)
                {
                    node.right = DeleteHelper(node.right, val);
                }
                else
                {
                    if (node.left == null) return node.right;
                    if (node.right == null) return node.left;
                    Node<T> tmp = GetMin(node.right);
                    node.val = tmp.val;
                    node.right = DeleteHelper(node.right, node.val);
                }

                return node;
            }

            public int GetHeight() => GetHeight(root);
            private int GetHeight(Node<T> node)
            {
                int depth = 0, res = 0;
                GetMaxDepth(node, ref depth, ref res);
                return res;
            }

            private void GetMaxDepth(Node<T> node, ref int depth, ref int res)
            {
                if (node == null)
                {
                    res = Math.Max(depth, res);
                    return;
                }

                ++depth;

                GetMaxDepth(node.left, ref depth, ref res);
                GetMaxDepth(node.right, ref depth, ref res);

                --depth;
            }



            //iterative methods

            public bool SearchIterative(T val)
            {
                Node<T> curr = root;

                while (curr != null)
                {
                    if ((curr.val).CompareTo(val) == 0)
                        return true;

                    if ((curr.val).CompareTo(val) > 0)
                        curr = curr.left;
                    else
                        curr = curr.right;
                }
                return false;
            }

            public bool InsertIterative(T val)
            {
                if (root == null)
                {
                    root = new Node<T>(val);
                    return true;
                }

                if (SearchHelper(root, val))
                    return false;

                Node<T> curr = root;
                Node<T> prev = null!;

                while (curr != null)
                {
                    prev = curr;

                    if ((curr.val).CompareTo(val) > 0)
                        curr = curr.left;
                    else
                        curr = curr.right;
                }

                if ((prev.val).CompareTo(val) > 0)
                    prev.left = new Node<T>(val);
                else
                    prev.right = new Node<T>(val);

                return true;
            }

            private Node<T> GetMin(Node<T> node)
            {
                if (node == null) return node!;
                Node<T> curr = node;
                while (curr.left != null)
                    curr = curr.left;

                return curr;
            }

            private Node<T> GetMax(Node<T> node)
            {
                if (node == null) return node!;
                Node<T> curr = node;
                while (curr.right != null)
                    curr = curr.right;

                return curr;
            }

            private Node<T> GetSuccessor(Node<T> node, T target)
            {
                if (node.right != null) return GetMin(node.right);

                Node<T> curr = node;
                Node<T> res = node;

                while (curr!.val.CompareTo(target) != 0)
                {
                    if (curr.val.CompareTo(target) > 0)
                    {
                        if (curr.val.CompareTo(res.val) < 0)
                            res = curr;
                        curr = curr.left;
                    }
                    else
                        curr = curr.right!;
                }
                return res;
            }
            

            private Node<T> GetPredecessor(Node<T> node, T target)
            {
                if (node.left != null) return GetMin(node.left);

                Node<T> curr = node;
                Node<T> res = node;

                while (curr!.val.CompareTo(target) != 0)
                {
                    if (curr.val.CompareTo(target) < 0)
                    {
                        curr = curr.right;
                        if (curr.val.CompareTo(res.val) > 0)
                            res = curr;
                    }
                    else
                        curr = curr.left!;
                }
                return res;
            }
        }
    }
}
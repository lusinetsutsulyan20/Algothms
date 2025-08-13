namespace AVLNamespace
{
    using System.Net.NetworkInformation;
    using NodeNamespace;
    public class AVLTree
    {
        public class Tree<T> where T : IComparable
        {
            Node<T>? root;

            public Tree()
            {
                root = null;
            }

            //traversals

            public void PreOrder() => PreOrder(root!);
            public void InOrder() => InOrder(root!);
            public void PostOrder() => PostOrder(root!);


            private void PreOrder(Node<T> root)
            {
                if (root == null) return;

                Console.WriteLine(root.val);
                PreOrder(root.left);
                PreOrder(root.right);
            }
            private void InOrder(Node<T> root)
            {
                if (root == null) return;

                InOrder(root.left);
                Console.WriteLine(root.val);
                InOrder(root.right);
            }
            private void PostOrder(Node<T> root)
            {
                if (root == null) return;

                PostOrder(root.left);
                PostOrder(root.right);
                Console.WriteLine(root.val);
            }


            //recursive methods

            public bool Search(T val)
            {
                return SearchHelper(root!, val);
            }
            private bool SearchHelper(Node<T>? root, T val)
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
                if (SearchHelper(root!, val))
                    return false;

                root = InsertHelper(root!, val);
                return true;
            }
            private Node<T> InsertHelper(Node<T> node, T val)
            {
                if (node == null) return new Node<T>(val);

                if ((node.val).CompareTo(val) > 0)
                    node.left = InsertHelper(node.left, val);
                else
                    node.right = InsertHelper(node.right, val);
                    

                //LL  ->  RightRotate
                if (BalanceFactor(node) > 1 && node.left.val.CompareTo(val) > 0)
                {
                    return RightRotate(node);
                }

                //LR  ->  LeftRotate, LeftRotate
                else if (BalanceFactor(node) > 1 && node.left.val.CompareTo(val) < 0)
                {
                    node.left = LeftRotate(node.left);
                    return RightRotate(node);
                }

                //RL  ->  c, LeftRotate
                else if (BalanceFactor(node) < -1 && node.right.val.CompareTo(val) > 0)
                {
                    node.right = RightRotate(node.right);
                    return LeftRotate(node);
                }

                //RR  ->  LeftRotate
                else if (BalanceFactor(node) < -1 && node.right.val.CompareTo(val) < 0)
                {
                    return LeftRotate(node);
                }


                return node;
            }

            private Node<T> RightRotate(Node<T> node)
            {
                Node<T> tmpRoot = node.left;
                Node<T> tail = tmpRoot.right;

                tmpRoot.right = node;
                node.left = tail;

                return tmpRoot;
            }

            private Node<T> LeftRotate(Node<T> node)
            {
                Node<T> tmpRoot = node.right;
                Node<T> tail = tmpRoot.left;

                tmpRoot.left = node;
                node.right = tail;

                return tmpRoot;
            }

            private int BalanceFactor(Node<T> node)
            {
                return GetHeight(node.left) - GetHeight(node.right);
            }

            public void Delete(T val) => root = DeleteHelper(root!, val);

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

                if (BalanceFactor(node) < -1 && BalanceFactor(node.left) <= 0)
                {
                    return LeftRotate(node);
                }
                if (BalanceFactor(node) < -1 && BalanceFactor(node.left) < 0)
                {
                    node.left = RightRotate(node.left);
                    return LeftRotate(node);
                }
                if (BalanceFactor(node) > 1 && BalanceFactor(node.right) >= 0)
                {
                    return RightRotate(node);
                }
                if (BalanceFactor(node) > 1 && BalanceFactor(node.right) < 0)
                {
                    node.right = LeftRotate(node.right);
                    return RightRotate(node);
                }

                return node;
            }

            public int GetHeight() => GetHeight(root!);
            private int GetHeight(Node<T> node)
            {
                if (node == null) return 0;
                return 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
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

                Node<T> curr = root!;
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
            

            private Node<T>? GetPredecessor(Node<T>? node, T target)
            {
                if (node!.left != null) return GetMax(node.left);

                Node<T>? curr = root!;
                Node<T>? res = null;

                while (curr != null)
                {
                    if (curr.val.CompareTo(target) < 0)
                    {
                        curr = curr!.right!;
                        if (curr!.val.CompareTo(res!.val) > 0)//not need
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
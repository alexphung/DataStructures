using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructures.libraries.BinarySearchTree
{
    #region BST Node Object
    /// <summary>
    /// Define the BST Node Object
    /// </summary>
    public class Node
    {
        public char ndata;
        public Node left;
        public Node right;

        public Node(char value)
        {
            this.ndata = value;
            this.left = null;
            this.right = null;
        }
    }

    #endregion

    public class BinarySearchTree : IAdapter
    {
        private Node root;
        private int count;

        #region BST Structure Methods

        public BinarySearchTree()
        {
            root = null;
            count = 0;
        }
        
        private Node AddNode(char newData)
        {
            Node curNode = new Node(newData);
            if (root == null)
            {
                root = curNode;
                count++;
            }
            return curNode;
        }

        public void Insert(char item)
        {
            Node newNode = AddNode(item);

            if (newNode.ndata < root.ndata)
            {
                if (root.left == null)
                    root.left = newNode;
                else
                    Traverse(ref root.left, newNode);

                count++;
            }

            if (newNode.ndata > root.ndata)
            {
                if (root.right == null)
                    root.right = newNode;
                else
                    Traverse(ref root, newNode);

                count++;
            }
        }

        #region Delete function required two private helper method to process the node replace and deletion.

        public void Delete(Node curNode, char searchKey, ref bool success)
        {
            if(curNode == null)
            {
                success = false;
            }
            else if (searchKey == curNode.ndata)
            {
                DeleteNodeItem(ref curNode);
            }
            else if (searchKey < curNode.ndata)
            {
                Delete(curNode.left, searchKey, ref success);
            }
            else
            {
                Delete(curNode.right, searchKey, ref success);
            }
        }

        private void DeleteNodeItem(ref Node curNode)
        {
            Node delNode = null;
            char replacementItem = '0';

            // There are 4 cases to consider
            // 1. The root is a leaf
            // 2. The root has no left child
            // 3. The root has no right child
            // 4. The root has two children

            // case 1
            if((curNode.left == null) && (curNode.right == null))
            {
                curNode = null;
            }
            // case 2
            else if (curNode.left == null)
            {
                delNode = curNode;
                curNode = curNode.right;
                delNode.right = null;
            }
            // case 3
            else if (curNode.right == null)
            {
                delNode = curNode;
                curNode = curNode.left;
                delNode.left = null;
            }
            // case 4
            else
            {
                ProcessLeftMost(ref curNode.right, ref replacementItem);
                curNode.ndata = replacementItem;
            }
        }

        private void ProcessLeftMost(ref Node curNode, ref char replacementItem)
        {
            if(curNode.left == null)
            {
                replacementItem = curNode.ndata;
                Node delNode = curNode;
                curNode = curNode.right;
                delNode.right = null;
            }
            else
            {
                ProcessLeftMost(ref curNode.left, ref replacementItem);
            }
        }

        #endregion

        public void ShowPreOrderTree(Node curRoot)
        {
            Console.Write(curRoot.ndata + " ");

            if (curRoot.left != null)
                ShowPreOrderTree(curRoot.left);

            if (curRoot.right != null)
                ShowPreOrderTree(curRoot.right);
        }
        
        public void ShowInOrderTree(Node curRoot)
        {
            if (curRoot.left != null)
                ShowInOrderTree(curRoot.left);

            Console.Write(curRoot.ndata + " ");

            if (curRoot.right != null)
                ShowInOrderTree(curRoot.right);
        }

        public void ShowPostOrderTree(Node curRoot)
        {
            if (curRoot.left != null)
                ShowPostOrderTree(curRoot.left);

            if (curRoot.right != null)
                ShowPostOrderTree(curRoot.right);

            Console.Write(curRoot.ndata + " ");
        }

        private void Traverse(ref Node curNode, Node newNode)
        {
            // Could be a left or right node
            if (curNode == null)
            {
                curNode = newNode;
            }

            if (newNode.ndata < curNode.ndata)
            {
                Traverse(ref curNode.left, newNode);
            }

            if (newNode.ndata > curNode.ndata)
            {
                Traverse(ref curNode.right, newNode);
            }
        }
        
        #endregion

        #region BST Properties

        public Node Root
        {
            get { return this.root; }
        }

        public int Size
        {
            get { return count; }
        }

        #endregion

        #region implementation of IAdapter Method

        public void ShowMessagLog(string message)
        {
            Console.WriteLine(message);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.libraries.List
{
    #region Node Definition - use for constructing a list node.

    public class Node
    {
        public int item;
        public Node nextPtr;

        public Node(int pItem)
        {
            item = pItem;
            nextPtr = null;
        }
    }

    #endregion

    public class LinkList
    {
        // Always reference or point to the beginning of the list
        private Node headPtr;   
        
        private int count;

        // Constructor for creating instantiating the list.
        public LinkList()
        {
            this.count = 0;
            this.headPtr = null;
        }

        public void Add(int pItem)
        {
            if (this.headPtr == null)
            {
                this.headPtr = new Node(pItem);
            }
            else
            {
                Node tempPtr = this.headPtr;

                for (int i = 0; i < this.count; i++)
                {
                    if (tempPtr.nextPtr == null)
                        tempPtr.nextPtr = new Node(pItem);
                    else
                        tempPtr = tempPtr.nextPtr;
                }
            }

            this.count++;
        }

        public int GetListItemAt(int position)
        {
            int retItem = -1;

            Node tempPtr = this.headPtr;
            if(position > 0 && position <= this.count)
            { 
                for (int i = 0; i < (position - 1); i++)
                {
                    tempPtr = tempPtr.nextPtr;
                }

                retItem = tempPtr.item;
            }

            return retItem;
        }

        #region Properties of the List

        public int Count
        {
            get { return this.count; }
        }

        public override string ToString()
        {
            string retStr = "[HEAD]";

            for (Node curPtr = this.headPtr;
                        curPtr != null; 
                            curPtr = curPtr.nextPtr)
            {
                retStr += "-->[" + curPtr.item + "]";
            }

            retStr += "-->[TAIL]";

            return retStr;
        }

        #endregion

    }
}

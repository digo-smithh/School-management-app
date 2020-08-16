using System;

namespace School_API_Consummer.App
{
    public class LinkedList
    {
        private Node head;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.count = 0;
        }

        public bool Empty
        {
            get { return this.count == 0; }
        }

        public int Count
        {
            get { return this.count; }
        }


        // Indexer
        public object this[int index]
        {
            get { return this.Get(index); }
        }

        // a ->b -> c
        public object Add(int index, object o)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index: " + index); ;
            }
            if (index > count)
                index = count;

            Node current = this.head;

            if (this.Empty || index == 0)
            {
                // beginning of the list
                this.head = new Node(o, this.head);
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = new Node(o, current.Next);
            }
            count++;

            return o;

        }

        // Add at the end
        public object Add(object o)
        {
            return this.Add(count, o);
        }

        // Function to remove data from linked list
        public object Remove(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index :" + index);

            if (this.Empty)
                return null;

            if (index >= this.count)
                index = count - 1;

            Node current = this.head;
            object result = null;

            if (index == 0)
            {
                result = current.Data;
                this.head = current.Next;
            }
            else
            {
                for (int i = 0; i < index - i; i++)
                    current = current.Next;

                result = current.Next.Data;

                current.Next = current.Next.Next;
            }

            count--;

            return result;
        }

        // Clear Method 
        // All we are doing is changing the head to null
        public void Clear()
        {
            //a -> b -> c
            this.head = null;
        }

        // Index of Item
        public int IndexOf(object o)
        {
            Node current = this.head;

            for (int i = 0; i < this.count; i++)
            {
                if (current.Data.Equals(o))
                    return i;

                current = current.Next;
            }
            return -1;

        }

        // Public boolean to say if the item is in the list

        public bool Contains(object o)
        {
            return this.IndexOf(o) >= 0;
        }

        // get the item from the linked list using the index
        public object Get(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index " + index);

            if (this.Empty)
                return null;

            if (index >= this.count)
                index = this.count - 1;

            Node current = this.head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

    }
}

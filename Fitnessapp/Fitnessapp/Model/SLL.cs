//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace Fitnessapp.Model
//{
//    public  class SLL<T> where T : IComparable<T>
//    {
//        class Node<T> where T : IComparable<T>
//        {
//            private T data;
//            private Node<T> next;

//            public T GetData()
//            {
//                return data;
//            }

//            public void SetData(T data)
//            {
//                this.data = data;
//            }

//            public Node<T> GetNext()
//            {
//                return next;
//            }

//            public void SetNext(Node<T> next)
//            {
//                this.next = next;
//            }

//            public Node(T data)
//            {
//                this.data = data;
//            }
//        }

//        private Node<T> head;
//        private Node<T> tail;


//        public SLL()
//        {
//            head = null;
           
//        }
//        public bool isEmpty()
//        {
//            return (head == null && tail == null);
//        }

//        public void addHead(T data)
//        {
//           Node<T> toAdd = new Node<T>(data);
//            if(isEmpty())
//            {
//                head = toAdd;
//                tail = toAdd;
//            }
//            else
//            {
//                toAdd.SetNext(head);
//                head = toAdd;
//            }
//        }

//        public void addTail(T data)
//        {
//            Node<T> toAdd = new Node<T>(data);

//            if (isEmpty())
//            {
                
//                addHead(data);
//            }
//            else
//            {
                
//                tail.SetNext(toAdd);
//                tail = toAdd;
//            }

//        }
//        private int compare(T o1, T o2)
//        {
           
//                return o1.CompareTo(o2);
//        }
//        public void addInOrder(T data)
//        {

//            Node<T> toAdd = new Node<T>(data);

//            if (isEmpty() || compare(toAdd.GetData(), head.GetData()) < 0)
//            {
//                addHead(data);

//                return;
//            }
//            else if (compare(data, tail.GetData()) > 0)
//            {

//                addTail(data);


//            }
//            else
//            {
//                Node<T> current = head;
//                while (current != null)
//                {
//                    if (compare(data, current.GetNext().GetData()) < 0)
//                    {
//                        toAdd.SetNext(current.GetNext());
//                        current.SetNext(toAdd);
//                        return;
                 
//                    }
//                    else if (compare(data, current.GetNext().GetData()) > 0)
//                    {
//                        current = current.GetNext();
//                    }
//                }
//            }


//        }


//    }
//}

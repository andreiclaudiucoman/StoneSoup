using StoneSoupAssessment.LinkedList.Exceptions;
using System;
using System.Text;

namespace StoneSoupAssessment.LinkedList
{
    public class MyLinkedList<T>
    {
        public MyNode<T> head;

        public void Insert(int index, T data)
        {
            MyNode<T> newNode = new MyNode<T>(data);

            if (head == null)
            {
                head = newNode;
                return;
            }

            MyNode<T> currentNode = head;

            if (index == 0)
            {
                head = newNode;
                newNode.next = currentNode;
                return;
            }

            MyNode<T> lastNode = null;

            for (int i = 1; currentNode != null && i <= index; i++)
            {
                lastNode = currentNode;
                currentNode = currentNode.next;
            }

            lastNode.next = newNode;
            newNode.next = currentNode;
        }

        public void Delete(int index)
        {
            if (head == null)
            {
                throw new DeleteLinkedListNodeException("The list is empty.");
            }

            MyNode<T> currentNode = head;

            if (index == 0)
            {
                head = currentNode.next;
                return;
            }

            for (int i = 0; currentNode != null && i < index - 1; i++)
            {
                currentNode = currentNode.next;
            }

            if (currentNode == null || currentNode.next == null)
            {
                throw new DeleteLinkedListNodeException($"There is no node at position {index}");
            }

            MyNode<T> next = currentNode.next.next;

            currentNode.next = next;
        }

        public void PrintList()
        {
            MyNode<T> node = head;

            if (head == null)
            {
                Console.WriteLine("The list is empty");
                return;
            }

            StringBuilder listNodes = new StringBuilder();

            while (node != null)
            {
                listNodes.Append(node.ToString());
                listNodes.Append("->");

                node = node.next;
            }

            listNodes.Append("null");

            Console.WriteLine(listNodes);
        }
    }
}

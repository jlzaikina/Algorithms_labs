using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp15.LinkedList;

namespace ConsoleApp15
{
    class Node<T>
    {
        public T Data;
        public Node<T> Next;
        public Node<T> Previous;

        public Node(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    class LinkedList<T>
    {
        public Node<T> head;
        private Node<T> tail;

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        public Node<T> CopyList()
        {
            if (head == null)
            {
                return null;
            }

            // Дублируем каждый узел и вставляем его после оригинального узла
            Node<T> node = head;
            while (node != null)
            {
                Node<T> copy = new Node<T>(node.Data);
                copy.Next = node.Next;
                if (node.Next != null)
                {
                    node.Next.Previous = copy;
                }
                node.Next = copy;
                copy.Previous = node;
                node = copy.Next;
            }

            // Устанавливаем указатели Prev для копий узлов
            node = head;
            Node<T> newHead = head.Next;
            while (node != null)
            {
                node.Next.Previous = node.Next;
                node = node.Next.Next;
            }

            // Отделяем копии узлов от оригинального списка
            node = head;
            while (node != null && node.Next != null)
            {
                Node<T> temp = node.Next;
                node.Next = temp.Next;
                if (temp.Next != null)
                {
                    temp.Next.Previous = node;
                }
                node = temp;
            }

            return newHead;
        }
        public void PrintList(Node<T> head)
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine("Value: " + current.Data);
                current = current.Next;
            }
        }
    }
}


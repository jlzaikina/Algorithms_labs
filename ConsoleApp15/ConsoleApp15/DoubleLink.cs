using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp15
{
    public class Node
    {
        public int element;
        public Node Next { get; set; }
        public Node Random { get; set; }
        public Node()
        { }
        public Node(int element)
        {
            this.element = element;
        }
    }
    internal class DoubleLink
    {
        public Node head;
        public int count;
        public override string ToString()
        {
            Node cur = head;
            string str = " ";
            while (cur.Next != null)
            {
                cur = cur.Next;
                str = str + ' ' + cur.element.ToString();
            }
            return str;
        }
        //добаляем элемент списка
        public void Add(int el)
        {
            if (head != null)
            {
                Node node = head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = new Node(el);
            }
            else
            {
                head = new Node(el);
            }
            count++;
            Rand();
        }
        public void Rand()  //добавляем рандомную ссылку для каждого элемента
        {
            Random rand = new Random();
            Node node = head;
            while (node != null)
            {
                Node cur = head;
                int k = 1;
                int search = rand.Next(1, count);
                while (k != search)
                {
                    cur = cur.Next;
                    k++;
                }
                node.Random = cur;
                node = node.Next;
            }
        }
        public Node CopyList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            // Проходим по исходному списку
            Node current = head;
            while (current != null)
            {
                // Создаем копию текущего узла
                Node newNode = new Node(current.element);
                // Вставляем копию между текущим и следующим узлом исходного списка
                newNode.Next = current.Next;
                current.Next = newNode;
                // Переходим к следующему узлу в исходном списке
                current = newNode.Next;
            }
            // Связываем указатели копий узлов
            current = head;
            while (current != null)
            {
                current.Next.Random = current.Random.Next;
                // Переходим к следующему узлу исходного списка
                current = current.Next.Next;
            }

            current = head;
            // Устанавливаем указатель на начало копии списка
            Node newHead = head.Next;
            // Разделяем исходный список и его копию
            while (current.Next != null)
            {
                Node temp = current.Next;
                current.Next = temp.Next;
                current = temp;
            }
            return newHead;
        }
        public void PrintList(Node head)
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine("Значение: " + current.element);
                current = current.Next;
            }
        }
    }
}

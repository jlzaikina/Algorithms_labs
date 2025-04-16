using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class LinkedList
    {
        public class Node
        {
            public Node(int el)
            {
                El = el;
            }
            public int El { get; set; }
            public Node Next { get; set; }
        }
        public Node head;
        public override string ToString()
        {
            Node node = head;
            string str = "";
            while (node != null)
            {
                str = str + node.El + "\t";
                node = node.Next;
            }
            return str;
        }
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
        }
        // Задание 1. Дан однонаправленный список с петлёй. Его «последний» элемент содержит указатель на
        // один из элементов этого же списка, причём не обязательно на первый.Найдите начальный
        // узел петли.Элементы списка менять нельзя, память должна быть константна.
        public Node Find(Node head)         //поиск начала петли, сложность O(n)
        {
            Node slow = head;
            Node fast = head;
  
            while (slow.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast)
                    break;
            }

            slow = head;
            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
            return fast;
        }
        //Задание 3. Удалите дубликаты из несортированного связного списка.Память должна быть константна.
        public void Delete(Node head)          //удаление дубликатов, сложность O(n^2)
        {  
            Node cur = head;
            while (cur != null)
            { 
                Node run = cur;
                while (run.Next != null)
                {
                    if (run.Next.El == cur.El)
                    {
                        run.Next = run.Next.Next;
                    }
                    else
                    {
                        run = run.Next;
                    }
                }
                cur = cur.Next;
            }
        }
    }
}

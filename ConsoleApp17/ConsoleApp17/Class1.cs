using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
        //Задание 2. Реализуйте «вручную» стек со стандартными функциями push/pop и дополнительной функцией min, возвращающей минимальный
        //элемент стека. Все эти функции должны работать за O(1). Память должна быть оптимальна.
        class MinStack
        {
            private Stack<int> stack = new Stack<int>();
            private Stack<int> minStack = new Stack<int>(); // хранит минимальные элементы

            public void Push(int value)
            {
                stack.Push(value);

                if (minStack.Count == 0 || value <= Min())
                {
                    minStack.Push(value); // добавляем в минимальный стек, если элемент меньше или равен текущему минимуму
                }
            }

            public int Pop()
            {
                int value = stack.Pop();

                if (value == Min())
                {
                    minStack.Pop(); // если удаляемый элемент равен текущему минимуму, удаляем его из минимального стека
                }

                return value;
            }

            public int Min()
            {
                return minStack.Peek(); // возвращаем минимальный элемент
            }
        }
   }

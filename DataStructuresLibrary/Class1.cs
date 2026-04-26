using System.Collections;

namespace DataStructuresLibrary
{
    /// <summary>
    /// Вузол односпрямованого списку.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Значення елемента.
        /// </summary>
        public float Value { get; set; }
        /// <summary>
        /// Посилання на наступний елемент.
        /// </summary>
        public Node Next { get; set; }

        public Node(float value)
        {
            Value = value;
            Next = null;
        }
    }

    /// <summary>
    /// Реалізація односпрямованого зв'язаного списку.
    /// </summary>
    public class MyFloatList : IEnumerable<float>
    {
        private Node head;
        private int count;

        /// <summary>
        /// Кількість елементів у списку.
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Додавання елемента в кінець списку.
        /// </summary>
        /// <param name="value">Значення для додавання.</param>
        public void Add(float value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }

        /// <summary>
        /// Індексатор для доступу до елементів на читання.
        /// </summary>
        public float this[int index]
        {
            get
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                Node current = head;
                for (int i = 0; i < index; i++) current = current.Next;
                return current.Value;
            }
        }

        /// <summary>
        /// Видалення елемента за номером (індексом).
        /// </summary>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count) throw new IndexOutOfRangeException();

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++) current = current.Next;
                current.Next = current.Next.Next;
            }
            count--;
        }

        /// <summary>
        /// 1. Знайти перший елемент більший за задане значення.
        /// </summary>
        public float? FindFirstGreaterThan(float threshold)
        {
            foreach (var item in this)
            {
                if (item > threshold) return item;
            }
            return null;
        }

        /// <summary>
        /// 2. Знайти суму елементів, значення яких менші за значення першого знайденого від'ємного елементу.
        /// </summary>
        public float GetSumConditionedByFirstNegative()
        {
            float? firstNegative = null;
            foreach (var item in this)
            {
                if (item < 0)
                {
                    firstNegative = item;
                    break;
                }
            }

            if (firstNegative == null) return 0;

            float sum = 0;
            foreach (var item in this)
            {
                if (item < firstNegative.Value) sum += item;
            }
            return sum;
        }

        /// <summary>
        /// 3. Отримати новий список зі значень елементів більших за задане значення.
        /// </summary>
        public MyFloatList GetNewListGreaterThan(float threshold)
        {
            MyFloatList newList = new MyFloatList();
            foreach (var item in this)
            {
                if (item > threshold) newList.Add(item);
            }
            return newList;
        }

        public IEnumerator<float> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

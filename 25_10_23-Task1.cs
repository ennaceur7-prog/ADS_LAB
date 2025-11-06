using System;
using System.Collections.Generic;

namespace LabTask1_FIFOUsingStacks
{
    class FifoUsingStacks<T>
    {
        private Stack<T> inStack = new Stack<T>();
        private Stack<T> outStack = new Stack<T>();

        public void Enqueue(T item) => inStack.Push(item);

        private void MoveInToOut()
        {
            while (inStack.Count > 0)
                outStack.Push(inStack.Pop());
        }

        public T Dequeue()
        {
            if (outStack.Count == 0)
            {
                if (inStack.Count == 0) throw new InvalidOperationException("Queue is empty");
                MoveInToOut();
            }
            return outStack.Pop();
        }

        public T Peek()
        {
            if (outStack.Count == 0)
            {
                if (inStack.Count == 0) throw new InvalidOperationException("Queue is empty");
                MoveInToOut();
            }
            return outStack.Peek();
        }

        public int Count => inStack.Count + outStack.Count;
        public bool IsEmpty => Count == 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var q = new FifoUsingStacks<int>();
            Console.WriteLine("=== Task 1: FIFO using two Stacks ===");

            Console.WriteLine("Enqueue 5, 10, 15");
            q.Enqueue(5);
            q.Enqueue(10);
            q.Enqueue(15);

            Console.WriteLine("Count: " + q.Count);
            Console.WriteLine("Dequeue -> " + q.Dequeue()); // 5
            Console.WriteLine("Peek -> " + q.Peek());       // 10
            Console.WriteLine("Dequeue -> " + q.Dequeue()); // 10
            Console.WriteLine("Dequeue -> " + q.Dequeue()); // 15

            Console.WriteLine("IsEmpty -> " + q.IsEmpty);

            Console.WriteLine("\nTask 1 complete. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}

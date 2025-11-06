using System;
using System.Collections.Generic;

namespace LabTask2_StackAndQueue
{
    class StackDemo
    {
        public static void Run()
        {
            var stack = new Stack<int>();
            Console.WriteLine("=== Stack demo (LIFO) ===");
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine("Pushed: 1, 2, 3");
            Console.WriteLine("Pop -> " + stack.Pop());   // 3
            Console.WriteLine("Peek -> " + stack.Peek()); // 2
            Console.WriteLine("Pop -> " + stack.Pop());   // 2
            Console.WriteLine();
        }
    }

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

            StackDemo.Run();

            var q = new FifoUsingStacks<int>();
            Console.WriteLine("=== FIFO (using two stacks) demo ===");
            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);
            Console.WriteLine("Enqueued: 10, 20, 30");
            Console.WriteLine("Dequeue -> " + q.Dequeue()); // 10
            Console.WriteLine("Peek -> " + q.Peek());       // 20
            Console.WriteLine("Dequeue -> " + q.Dequeue()); // 20
            Console.WriteLine("Dequeue -> " + q.Dequeue()); // 30
            Console.WriteLine();

            q.Enqueue(100);
            q.Enqueue(200);
            var stack = new Stack<int>();
            Console.WriteLine("Moving items from queue into a Stack to show interplay:");
            while (!q.IsEmpty)
            {
                int x = q.Dequeue();
                Console.WriteLine("Dequeued -> " + x + " ; pushing into stack");
                  stack.Push(x);
            }

            Console.WriteLine("Now popping from stack (LIFO order):");
            while (stack.Count > 0)
            {
                Console.WriteLine("Pop -> " + stack.Pop());
            }

            Console.WriteLine();
            Console.WriteLine("Task 2 complete. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}

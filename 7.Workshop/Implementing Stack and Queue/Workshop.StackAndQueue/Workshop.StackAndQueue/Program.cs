namespace Workshop.StackAndQueue;

class Program
{
    static void Main(string[] args)
    {
        MyStack();
        MyLinkedStack();
        MyQueue();
        MyLinkedQueue();
    }

    private static void MyStack()
    {
        MyStack<int> stack = new MyStack<int>();
        for (int i = 0; i < 10; i++)
        {
            stack.Push(Random.Shared.Next(0, 100));
            Console.WriteLine($"The last element is: {stack.Peek()}");
        }

        for (int i = 0; i < 10; i++)
            Console.WriteLine($"The last element is: {stack.Pop()}");

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                stack.Push(Random.Shared.Next(0, 100));
                Console.WriteLine($"Pushed: {stack.Peek()}");
                Console.WriteLine(string.Join(", ", stack.ToArray()));
            }

            for (int j = 0; j <= i; j++)
            {
                Console.WriteLine($"Popped: {stack.Pop()}");
                Console.WriteLine(string.Join(", ", stack.ToArray()));
            }
        }
    }

    private static void MyLinkedStack()
    {
        MyLinkedStack<int> linkedStack = new MyLinkedStack<int>();
        for (int i = 0; i < 10; i++)
        {
            linkedStack.Push(Random.Shared.Next(0, 100));
            Console.WriteLine($"The last element is: {linkedStack.Peek()}");
        }

        for (int i = 0; i < 10; i++)
            Console.WriteLine($"The last element is: {linkedStack.Pop()}");

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                linkedStack.Push(Random.Shared.Next(0, 100));
                Console.WriteLine($"Pushed: {linkedStack.Peek()}");
                Console.WriteLine(string.Join(", ", linkedStack.ToArray()));
            }

            for (int j = 0; j <= i; j++)
            {
                Console.WriteLine($"Popped: {linkedStack.Pop()}");
                Console.WriteLine(string.Join(", ", linkedStack.ToArray()));
            }
        }
    }

    private static void MyQueue()
    {
        MyQueue<int> queue = new MyQueue<int>();
        
        for (int t = 0; t < 3; t++)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int newVal = Random.Shared.Next(0, 100);
                    queue.Enqueue(newVal);
                    Console.WriteLine($"Enqueue {newVal}");
                    Console.WriteLine(string.Join(", ", queue.ToArray()));
                }

                Console.WriteLine($"Peeked: {queue.Peek()}");
                for (int j = 0; j <= i; j++)
                {
                    Console.WriteLine($"Dequeue {queue.Dequeue()}");
                    Console.WriteLine(string.Join(", ", queue.ToArray()));
                }
            }
        }
        
        for (int i = 0; i < 10; i++) queue.Enqueue (Random. Shared. Next(0, 100));
        
        for (int i = 0; i < 100; i++) queue.Enqueue(queue.Dequeue());
    }

    private static void MyLinkedQueue()
    {
        MyLinkedQueue<int> linkedQueue = new MyLinkedQueue<int>();

        for (int t = 0; t < 3; t++)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int newVal = Random.Shared.Next(0, 100);
                    linkedQueue.Enqueue(newVal);
                    Console.WriteLine($"Enqueue {newVal}");
                    Console.WriteLine(string.Join(", ", linkedQueue.ToArray()));
                }

                Console.WriteLine($"Peeked: {linkedQueue.Peek()}");
                for (int j = 0; j <= i; j++)
                {
                    Console.WriteLine($"Dequeue {linkedQueue.Dequeue()}");
                    Console.WriteLine(string.Join(", ", linkedQueue.ToArray()));
                }
            }
        }
        
        for (int i = 0; i < 10; i++) linkedQueue.Enqueue (Random. Shared. Next(0, 100));
        
        for (int i = 0; i < 100; i++) linkedQueue.Enqueue(linkedQueue.Dequeue());
    }
}

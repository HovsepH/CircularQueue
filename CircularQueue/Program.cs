CircularQueue<int> queue = new(5);

queue.enQueue(1);
queue.enQueue(2);
queue.enQueue(3);
queue.DisplayQueue();

Console.WriteLine(queue.deQueue());
Console.WriteLine(queue.deQueue());
Console.WriteLine(queue.deQueue());

queue.DisplayQueue();



public class CircularQueue<T>
{
    private readonly T[] queue;
    public int front { get; private set; }
    public int rear { get; private set; }
    public int length { get; private set; }
    public CircularQueue(int length)
    {
        this.length = length;
        queue = new T[length];
        front = rear = -1;
    }

    public void enQueue(T value)
    {
        if ((front == 0 && rear == length - 1) || (rear == (front - 1) % length - 1))
        {
            Console.WriteLine("Queue is full.");
        }
        else if (front == -1)
        {
            front = rear = 0;
            queue[front] = value;
        }
        else if (rear == length - 1 && front != 0)
        {
            rear = 0;
            queue[rear] = value;
        }
        else
        {
            rear++;
            queue[rear] = value;
        }
    }

    public T deQueue()
    {
        T item;

        if (front == -1)
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }

        item = queue[front];

        if (front == rear)
        {
            front = -1;
            rear = -1;
        }
        else if (front == length - 1)
        {
            front = 0;
        }
        else
        {
            front++;
        }

        return item;
    }

    public void DisplayQueue()
    {
        if (front == -1)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        if (rear >= front)
        {
            int index = front;
            while (index <= rear)
            {
                Console.Write(queue[index] + " ");
                index++;
            }
            Console.WriteLine("\n");
        }
        else
        {
            int index = front;

            while (index < length)
            {
                Console.Write(queue[index] + " ");
                index++;
            }

            Console.WriteLine("\n");
            index = 0;

            while (index <= rear)
            {
                Console.Write(queue[index] + " ");
                index++;
            }

            Console.WriteLine("\n");
        }
    }
}
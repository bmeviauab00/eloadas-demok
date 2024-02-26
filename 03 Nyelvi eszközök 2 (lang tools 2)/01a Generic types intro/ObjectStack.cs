namespace Generic;

public class Stack
{
    readonly int size;
    int current = 0;
    object[] items;

    public Stack()
        : this(100)
    { }

    public Stack(int size)
    {
        this.size = size;
        items = new object[size];
    }

    public void Push(object item)
    {
        if (current >= size)
            throw new InvalidOperationException("The stack is full.");

        items[current++] = item;
    }

    public object Pop()
    {
        current--;
        if (current >= 0)
            return items[current];
        else
            throw new InvalidOperationException("The stack is empty.");
    }
}

class Program1
{
    static void Main(string[] args)
    {
        Stack objectStack = new Stack();
        objectStack.Push(1);
        objectStack.Push("sss");
        int x = (int)objectStack.Pop();
    }
}
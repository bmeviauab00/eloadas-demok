﻿namespace Generic;

public class Stack<T>
{
    readonly int size;
    int current = 0;
    T[] items;

    public Stack()
        : this(100)
    { }

    public Stack(int size)
    {
        this.size = size;
        items = new T[size];
    }

    public void Push(T item)
    {
        if (current >= size)
            throw new InvalidOperationException("The stack is full.");

        items[current++] = item;
    }

    public T Pop()
    {
        if (current == 0)
            throw new InvalidOperationException("The stack is empty.");

        return items[current--];
    }
}

class Program2
{
    static void Main2(string[] args)
    {
        Stack<int> intsstack = new Stack<int>();
        intsstack.Push(1);
        // intsstack.Push("ss"); // would result in a compilation error
        int i = intsstack.Pop();
    }
}

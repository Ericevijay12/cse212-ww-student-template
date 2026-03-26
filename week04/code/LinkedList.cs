using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new(value);
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head; 
            _head.Prev = newNode; 
            _head = newNode; 
        }
    }

    /// <summary>
    /// Problem 1: Insert a new node at the back (tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new(value);
        if (_head is null) // If empty, head and tail are the same
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail;
            _tail!.Next = newNode;
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head.Next!.Prev = null; 
            _head = _head.Next; 
        }
    }

    /// <summary>
    /// Problem 2: Remove the last node (the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        if (_head == _tail) // Covers empty and single-item lists
        {
            _head = null;
            _tail = null;
        }
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // Disconnect the second-to-last node from the last node
            _tail = _tail.Prev; // Update the tail pointer
        }
    }

    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; 
                    newNode.Next = curr.Next; 
                    curr.Next!.Prev = newNode; 
                    curr.Next = newNode; 
                }
                return; 
            }
            curr = curr.Next; 
        }
    }

    /// <summary>
    /// Problem 3: Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _head)
                {
                    RemoveHead();
                }
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    // "Stitch" the neighboring nodes together
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return; // Exit after the first match is removed
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Problem 4: Search for all instances of 'oldValue' and replace them with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }
            curr = curr.Next; // Keep going until the end of the list
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; 
        while (curr is not null)
        {
            yield return curr.Data; 
            curr = curr.Next; 
        }
    }

    /// <summary>
    /// Problem 5: Iterate backward through the Linked List starting from the tail.
    /// </summary>
    public IEnumerable Reverse()
    {
        var curr = _tail; // Start at the end
        while (curr is not null)
        {
            yield return curr.Data; // Return data moving backward
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    public Boolean HeadAndTailAreNull() => _head is null && _tail is null;
    public Boolean HeadAndTailAreNotNull() => _head is not null && _tail is not null;
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}

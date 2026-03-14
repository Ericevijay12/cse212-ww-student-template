using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) 
        {
            // Requirement: Must throw InvalidOperationException with this exact message
            throw new InvalidOperationException("The queue is empty.");
        }

        var highPriorityIndex = 0;
        // FIX: Loop through the entire list to find highest priority
        for (int index = 1; index < _queue.Count; index++)
        {
            // FIX: Use > instead of >= to preserve FIFO for ties
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
                highPriorityIndex = index;
        }

        var value = _queue[highPriorityIndex].Value;
        
        // FIX: Actually remove the item from the queue
        _queue.RemoveAt(highPriorityIndex);
        
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            // Requirement: Must throw InvalidOperationException with this exact message
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove
        var highPriorityIndex = 0;
        
        // FIX 1: Loop through the entire list (index < _queue.Count)
        for (int index = 1; index < _queue.Count; index++)
        {
            // FIX 2: Use > instead of >= to preserve FIFO for ties
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
                highPriorityIndex = index;
        }

        // Save the value to return it later
        var value = _queue[highPriorityIndex].Value;
        
        // FIX 3: Actually remove the item from the queue
        _queue.RemoveAt(highPriorityIndex);
        
        return value;
    }

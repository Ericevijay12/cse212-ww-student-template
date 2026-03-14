    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // 1. Dequeue the next person
        Person person = _people.Dequeue();

        // 2. Determine if they should stay in the queue
        // Requirement: 0 or less is infinite turns.
        if (person.Turns <= 0) 
        {
            // They have infinite turns, so just put them back
            _people.Enqueue(person);
        }
        else if (person.Turns > 1) 
        {
            // They have finite turns left, subtract one and put them back
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // If they had exactly 1 turn, we don't re-enqueue them.

        return person;
    }

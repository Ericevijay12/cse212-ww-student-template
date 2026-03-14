using System;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            // Requirement: Throw exception if empty
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Requirement: 0 or less is infinite turns
        if (person.Turns <= 0) 
        {
            _people.Enqueue(person);
        }
        else if (person.Turns > 1) 
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}

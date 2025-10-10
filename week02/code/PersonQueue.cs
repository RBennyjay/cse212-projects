/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue (FIFO)
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        // Add to the end of the list
        _queue.Add(person);
    }

    /// <summary>
    /// Remove and return the person at the front of the queue (FIFO)
    /// </summary>
    /// <returns>The next person in line</returns>
    public Person Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("No one in the queue.");

        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    /// <summary>
    /// Check if the queue is empty
    /// </summary>
    /// <returns>True if empty, otherwise false</returns>
    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

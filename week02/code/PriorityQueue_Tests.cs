using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities (A:1, B:3, C:2). Dequeue should remove the one with the highest priority, which is B.
    // Expected Result: The Dequeue() method returns "B". The queue remaining is {A, C}.
    // Defect(s) Found: The for loop in Dequeue() is off-by-one, failing to check the last element. The condition _queue[index].Priority >= _queue[highPriorityIndex].Priority should be >=, not just > to handle ties correctly. The code also fails to remove the dequeued item from the list.
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        var result = pq.Dequeue();
        Assert.AreEqual("B", result);
        Assert.AreEqual("[A (Pri:1), C (Pri:2)]", pq.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue three items, where two have the same highest priority (A:2, B:3, C:3). Dequeue should return the first one enqueued with that priority (B).
    // Expected Result: The Dequeue() method returns "B". The queue remaining is {A, C}.
    // Defect(s) Found: The logic in Dequeue() for tie-breaking is incorrect. The for loop condition needs to be adjusted, and the tie-breaker should find the first occurrence, not the last. The original code's >= condition incorrectly prioritizes later entries with the same priority.
    public void TestPriorityQueue_Tiebreaker()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();
        Assert.AreEqual("B", result);
        Assert.AreEqual("[A (Pri:2), C (Pri:3)]", pq.ToString());
    }

    [TestMethod]
    // Scenario: Call Dequeue on an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: No defects found. This test case passes with the existing code.
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue(), "The queue is empty.");
    }
}
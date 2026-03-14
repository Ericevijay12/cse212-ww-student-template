using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and ensure the highest is returned.
    // Expected Result: "A" (Pri:5)
    // Defect(s) Found: The loop condition was stopping at index Count-1, missing the last item if it had the highest priority.
    // Test Results: PASSED - Changing loop to index < _queue.Count ensures all items are checked.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("C", 1);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Enqueue two items with the same high priority.
    // Expected Result: The first one added ("First") should be dequeued first (FIFO).
    // Defect(s) Found: The use of the >= operator caused the code to pick the last person with that priority instead of the first.
    // Test Results: PASSED - Changing comparison to > ensures only strictly higher priorities trigger a swap, preserving FIFO.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with "The queue is empty."
    // Defect(s) Found: No original defect, but ensured the exception message matches requirements exactly.
    // Test Results: PASSED - Correct exception and message are thrown when queue is empty.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex) {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}

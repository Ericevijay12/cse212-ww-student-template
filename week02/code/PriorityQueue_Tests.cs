[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and ensure the highest is returned.
    // Expected Result: "A" (Pri:5)
    // Defect(s) Found: Loop boundary was missing the last item in the list.
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
    // Defect(s) Found: The >= operator was incorrectly picking the last item added instead of the first.
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
    // Defect(s) Found: None (This logic was already correct).
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

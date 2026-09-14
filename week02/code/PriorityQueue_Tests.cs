using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them.
    // Ensure highest priority item is dequeued first.
    // Expected Result: Dequeue returns "Bob" (priority 10), then "Tim" (priority 5), then "Sue" (priority 3).
    // Defect(s) Found: Dequeue does not actually remove the item, so it returns the highest priority item ("Bob") forever. Also, loop misses the last item if it has highest priority.
    public void TestPriorityQueue_HighestPriorityRemoved()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Sue", 3);
        priorityQueue.Enqueue("Bob", 10);
        priorityQueue.Enqueue("Tim", 5);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same high priority.
    // Ensure the first one enqueued is dequeued first (FIFO).
    // Expected Result: Dequeue returns "Alice" (priority 5) first, then "Bob" (priority 5).
    // Defect(s) Found: Same highest priority doesn't follow FIFO because >= is used instead of >. Dequeue also doesn't remove items.
    public void TestPriorityQueue_SameHighestPriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alice", 5);
        priorityQueue.Enqueue("Sue", 3);
        priorityQueue.Enqueue("Bob", 5);

        Assert.AreEqual("Alice", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Sue", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown with message "The queue is empty."
    // Defect(s) Found: None. The empty queue exception works correctly.
    public void TestPriorityQueue_EmptyQueueThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}
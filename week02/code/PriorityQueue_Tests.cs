using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in priority order (highest first)
    // Defect(s) Found: Loop ended at Count-1, used >= instead of >, didn't remove element
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test FIFO behavior with same priority items and empty queue exception
    // Expected Result: Same priority items follow FIFO, empty queue throws exception
    // Defect(s) Found: Loop ended at Count-1, used >= instead of >, didn't remove element
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    // Add more test cases as needed below.
    
    [TestMethod]
    // Scenario: Mixed priorities with multiple items of same priority
    // Expected Result: Higher priority first, then FIFO for same priority
    // Defect(s) Found: None after corrections
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 5);
        priorityQueue.Enqueue("E", 1);
        
        Assert.AreEqual("B", priorityQueue.Dequeue()); // First with priority 5
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Second with priority 5
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Priority 3
        Assert.AreEqual("A", priorityQueue.Dequeue()); // First with priority 1
        Assert.AreEqual("E", priorityQueue.Dequeue()); // Second with priority 1
    }
}
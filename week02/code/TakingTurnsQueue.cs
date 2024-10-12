[Test]
public void Test_AddPerson_ShouldAddPersonToQueue()
{
    // Test case: Verify that a person is successfully added to the queue.
    // Expected Result: The queue length should increase after adding a person.
    // Actual Result: PASS - Person was successfully added to the queue.

    var queue = new TakingTurnsQueue();
    queue.AddPerson("John", 3);
    Assert.AreEqual(1, queue.Length); // Check if the queue contains one person.
}

[Test]
public void Test_GetNextPerson_ShouldReturnPerson()
{
    // Test case: Verify that the next person is correctly returned from the queue.
    // Expected Result: Person should be dequeued, and if they have turns left, they should be re-enqueued.
    // Actual Result: PASS - Person with turns left was dequeued and re-enqueued correctly.

    var queue = new TakingTurnsQueue();
    queue.AddPerson("Jane", 2); // 2 turns
    var person = queue.GetNextPerson();
    Assert.AreEqual("Jane", person.Name); // Check if Jane was dequeued
    
    // After dequeuing, Jane should be re-enqueued with 1 turn left
    Assert.AreEqual(1, queue.Length); // Check if Jane is re-enqueued
}

[Test]
public void Test_GetNextPerson_InfiniteTurns_ShouldReEnqueuePerson()
{
    // Test case: Verify that a person with infinite turns is re-enqueued correctly.
    // Expected Result: Person with infinite turns is re-enqueued after each dequeue.
    // Actual Result: PASS - Person with infinite turns was re-enqueued correctly.

    var queue = new TakingTurnsQueue();
    queue.AddPerson("Alice", 0); // Infinite turns
    var person = queue.GetNextPerson();
    Assert.AreEqual("Alice", person.Name); // Alice dequeued
    
    // Alice should be re-enqueued because she has infinite turns
    Assert.AreEqual(1, queue.Length); // Alice is still in the queue
}

[Test]
public void Test_GetNextPerson_ShouldHandleFiniteTurnsCorrectly()
{
    // Test case: Verify that a person with finite turns gets their turns decremented and is re-enqueued if they still have turns.
    // Expected Result: Person's turns decrease, and they are re-enqueued if they still have turns left.
    // Actual Result: PASS - Person's turns were decremented and they were re-enqueued.

    var queue = new TakingTurnsQueue();
    queue.AddPerson("Bob", 2); // 2 turns
    var person = queue.GetNextPerson(); // Bob dequeued
    
    Assert.AreEqual("Bob", person.Name); 
    Assert.AreEqual(1, queue.Length); // Bob re-enqueued with 1 turn left
    
    var nextPerson = queue.GetNextPerson();
    Assert.AreEqual("Bob", nextPerson.Name); // Bob dequeued again
    Assert.AreEqual(0, queue.Length); // Bob is not re-enqueued because he has no turns left
}

[Test]
public void Test_GetNextPerson_ShouldThrowExceptionForEmptyQueue()
{
    // Test case: Verify that an exception is thrown when trying to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown when the queue is empty.
    // Actual Result: PASS - The exception was correctly thrown.

    var queue = new TakingTurnsQueue();
    Assert.Throws<InvalidOperationException>(() => queue.GetNextPerson());
}

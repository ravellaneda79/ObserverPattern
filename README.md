# Observer Pattern implementation

Here I've created a basic design pattern implementation, with some difference:

- It's using a SubjectBag. It's an intermediate between the observer and the obsercable that support the relation between both objects. The idea is any of them needs to know about each other. Both know the bag and the obsercable set itself as observable and the observer attach to observe.
- It's using Weak References to Observable and Observers. Check code for more details.

## To know more about the deatils...

Please, check the tests, so you can see how use both and go deeper into details by peering inside what has been done.

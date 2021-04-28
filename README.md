# Room Assignment 

# How do you document your code?
I document my code using the standard best practise in c# which is the XML documentation comments.
It is actually part of me. 

# What are your thought about unit testing?
Unit testing is inevitable in good software design.
It helps to detect bugs early. It is part of me. I am not use i can write any code without unit-testing.

# What design pattern have you used in your project?
I used clean architecture for the project architecture. I am a fan of CQRS and mediator design pattern which helps to leverage all the design principles:
Dependency Inversion, separation of corcerns, single responsibility principle, DRY, Persistence Ignorance etc. 

# What are the most importance performance issues in ASP.NET, Web application?
The common know issues are:
# 1 Overuse of Thread Synchronization and Locking
# 2 Frequent Garbage Collection Pauses, etc


# Project Structure When Opened in Visual Studio
```src
    ```Api
        ``` Api Project
    ```Core
        ```Application
        ```Domain
    ```Infrastructure
        ```Identity
        ```Persistence
 ```Test
    ```Api Integration Test
    ```Unit Test
    ```Persistence
    


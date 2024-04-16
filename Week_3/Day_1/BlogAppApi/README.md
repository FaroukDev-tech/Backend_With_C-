# Blogging Application using EF Core

## Introduction
This project aims to develop a minimalistic blogging application using Entity Framework Core (EF Core). The application allows users to perform CRUD operations on blog posts and comments. Below is a summary of what was accomplished and learned during the development process.

## Project Overview
The project follows a structured approach to fulfill the requirements and tasks outlined:

### Entity and Database Setup
- Defined `Post` and `Comment` classes as entities with appropriate properties and relationships.
- Set up the `DbContext` to include `DbSet` properties for `Post` and `Comment` entities.
- Performed the initial migration to create the database schema.

### CRUD Operations for BlogPosts
- Implemented logic to create, read, update, and delete blog posts.
- Added methods for CRUD operations on blog posts.
- Tested each CRUD operation to ensure functionality.
- Wrote unit tests for the `PostManager` class to validate business logic.

### CRUD Operations for Comments
- Implemented logic to create, read, update, and delete comments.
- Added methods for CRUD operations on comments.
- Tested each CRUD operation for comments.
- Wrote unit tests for the `CommentManager` class to validate business logic.

### Displaying Blog Posts and Comments
- Created methods to display a list of blog posts with titles and summaries.
- Implemented a method to show the details of a specific blog post, including its comments.
- Ensured correct display of comments associated with each blog post.

### Error Handling and Exception Handling
- Implemented error handling for various scenarios, such as resource not found or operation failure.
- Implemented exception handling to gracefully handle unexpected errors and display appropriate messages.

### Unit Testing
- Wrote unit tests using the xUnit testing framework.
- Ensured test coverage for critical parts of the application, including services and utility functions.
- Covered different scenarios and edge cases to validate application functionality.

## Learnings
Throughout the project, several key learnings were gained:
- **EF Core Usage**: Understanding and implementing EF Core for database operations.
- **Unit Testing**: Developing robust unit tests to ensure application reliability and functionality.
- **Error Handling**: Implementing error and exception handling to improve user experience.
- **CRUD Operations**: Gained proficiency in creating, reading, updating, and deleting data entities.
- **Dependency Management**: Managing dependencies effectively within the application architecture.


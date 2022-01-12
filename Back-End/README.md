# SentiTweet

### Requirements
.NET 5

### How to run
`dotnet run --project WebAPI`

### Branching strategy:
1. We will create a branch for every main feature. (e.g. "story").
2. From it, for each task needed for the feature to be implemented, the assigned person will create a new branch.
3. There will be a .gitignore file in which the folders that do not contain our code.
4. When the task is implemented and tested, the user will create a pull request to the story branch and it will be merged only after the code is reviewed by another person.
5. We will check the comments in the pull request and they will be discussed.
6. When merging the branch, we will still keep the branch in case of future alterations of the code relating the task.
7. When the story is finished, we will merge it to the main branch.

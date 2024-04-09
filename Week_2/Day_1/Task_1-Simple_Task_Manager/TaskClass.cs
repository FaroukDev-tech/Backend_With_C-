using System;

namespace task_component{
    public enum TaskCategory{
        Personal,
        Work,
        Meetings,
        Gym,
        Learning
    }
    public class Tasks{
        public required string? Name {get; set;}
        public required string? Description {get; set;}
        public required TaskCategory Category {get; set;}
        public bool IsCompleted {get; set;}
    }
}
using System;

namespace StudyPlannerUI2
{
    /// Represents an individual study task or assignment with tracking properties.
    public class TaskItem
    {
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public int Difficulty { get; set; }
        public bool IsCompleted { get; set; }

        /// Default constructor for serialization (e.g., JSON or XML saving).
        public TaskItem() { }

        /// Initializes a new instance of a task with specific details.
        public TaskItem(string title, string subject, DateTime deadline, int priority, int difficulty)
        {
            Title = title;
            Subject = subject;
            Deadline = deadline;
            Priority = priority;
            Difficulty = difficulty;
            IsCompleted = false;
        }
    }
}

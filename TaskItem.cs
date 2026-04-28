using System;

namespace StudyPlannerUI2
{
    public class TaskItem
    {
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public int Difficulty { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem() { }

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
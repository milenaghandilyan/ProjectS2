using System;
using System.Collections.Generic;
using System.IO;

namespace StudyPlannerUI2
{
    // Handles saving and loading task data to local text files.
    // Each user has their own dedicated storage file.
    public class FileManager
    {
        public void Save(List<TaskItem> tasks, string username)
        {
            string fileName = $"{username}_tasks.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var t in tasks)
                {
                    writer.WriteLine($"{t.Title}|{t.Subject}|{t.Deadline}|{t.Priority}|{t.Difficulty}|{t.IsCompleted}");
                }
            }
        }

        // Reads the user's task file and reconstructs the TaskItem objects.
        public List<TaskItem> Load(string username)
        {
            string fileName = $"{username}_tasks.txt";
            List<TaskItem> tasks = new List<TaskItem>();
            if (!File.Exists(fileName)) return tasks;

            foreach (var line in File.ReadAllLines(fileName))
            {
                var parts = line.Split('|');
                if (parts.Length < 6) continue;

                var task = new TaskItem(parts[0], parts[1], DateTime.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]));
                task.IsCompleted = bool.Parse(parts[5]);
                tasks.Add(task);
            }
            return tasks;
        }
    }
}

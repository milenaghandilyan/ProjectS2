using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyPlannerUI2
{
    public class PlannerOptimizer
    {
        //Implementation of the Weighted Entropy Heuristic
        private double CalculateEntropyWeight(TaskItem task)
        {
            return (task.Priority * 0.5) + (task.Difficulty * 0.3);
        }

        public List<TaskItem> GenerateIntelligentSchedule(List<TaskItem> tasks)
        {
            return tasks.OrderByDescending(t => CalculateEntropyWeight(t)).ToList();
        }
    }
}

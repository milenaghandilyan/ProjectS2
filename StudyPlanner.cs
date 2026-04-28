using System.Collections.ObjectModel;

namespace StudyPlannerUI2
{
    public class StudyPlanner
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();
    }
}
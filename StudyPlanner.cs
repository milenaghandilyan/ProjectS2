using System.Collections.ObjectModel;

namespace StudyPlannerUI2
{
    /// Acts as the central data store for the application,managing the collection of study tasks.
    public class StudyPlanner
    {
        /// Gets or sets the collection of tasks. 
        /// Uses ObservableCollection to enable automatic UI updates when the list changes.
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();
    }
}

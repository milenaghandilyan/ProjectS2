using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace StudyPlannerUI2
{
    /// Interaction logic for the Study Planner main window.
    /// Handles Authentication, Task Management, and UI State switching.
    public partial class MainWindow : Window
    {
        // Data and Configuration
        private List<User> _users = new List<User>();
        private string userFile = "users.txt";
        private string _currentUsername = "";

        // Core logic components
        StudyPlanner planner = new StudyPlanner();
        FileManager fileManager = new FileManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(TxtUser.Text) || string.IsNullOrWhiteSpace(TxtPass.Password))
            {
                MessageBox.Show("Please enter both a username and a password.");
                return;
            }

            if (TxtPass.Password.Length < 8)
            {
                MessageBox.Show("Security Alert: Password must be at least 8 characters long.");
                return;
            }
            
            // Save user to text file using simple pipe-delimited format
            File.AppendAllText(userFile, $"{TxtUser.Text}|{TxtPass.Password}{Environment.NewLine}");
            MessageBox.Show("Registration successful! You can now login.");

            TxtUser.Clear();
            TxtPass.Clear();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Load users from file if it exists
            if (File.Exists(userFile))
            {
                var lines = File.ReadAllLines(userFile);
                _users = lines.Where(l => l.Contains("|")).Select(l => new User
                {
                    Username = l.Split('|')[0],
                    Password = l.Split('|')[1]
                }).ToList();
            }

            // Credential verification
            var user = _users.FirstOrDefault(u => u.Username == TxtUser.Text && u.Password == TxtPass.Password);
            if (user != null)
            {
                _currentUsername = user.Username;

                // Load existing tasks for this specific user
                planner.Tasks.Clear();
                var userTasks = fileManager.Load(_currentUsername);
                foreach (var t in userTasks) planner.Tasks.Add(t);

                // Update UI State
                TaskGrid.ItemsSource = planner.Tasks;
                LblWelcome.Text = $"Welcome, {_currentUsername}";

                // Toggle UI back to login screen
                AuthPanel.Visibility = Visibility.Collapsed;
                MainPlannerPanel.Visibility = Visibility.Visible;
            }
            else MessageBox.Show("Invalid login credentials.");
        }

        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            _currentUsername = "";
            planner.Tasks.Clear();
            TaskGrid.ItemsSource = null;
            TxtUser.Clear();
            TxtPass.Clear();

            MainPlannerPanel.Visibility = Visibility.Collapsed;
            AuthPanel.Visibility = Visibility.Visible;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create new task from form input
                var task = new TaskItem(
                    TxtTitle.Text,
                    TxtSubject.Text,
                    DateDeadline.SelectedDate ?? DateTime.Today,
                    int.Parse(TxtPriority.Text),
                    int.Parse(TxtDifficulty.Text)
                );

                planner.Tasks.Add(task);
                fileManager.Save(planner.Tasks.ToList(), _currentUsername);

                // Reset input fields
                TxtTitle.Clear();
                TxtSubject.Clear();
                TxtPriority.Text = "1";
                TxtDifficulty.Text = "1";
            }
            catch { MessageBox.Show("Please check that Priority and Difficulty are numbers."); }
        }

        private void BtnDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the specific task associated with the clicked button
            var task = (sender as Button)?.DataContext as TaskItem;
            if (task != null)
            {
                planner.Tasks.Remove(task);
                fileManager.Save(planner.Tasks.ToList(), _currentUsername);
            }
        }

        private void BtnOptimize_Click(object sender, RoutedEventArgs e)
        {
            // Apply sorting/optimization algorithm to the view
            PlannerOptimizer optimizer = new PlannerOptimizer();
            TaskGrid.ItemsSource = optimizer.GenerateIntelligentSchedule(planner.Tasks.ToList());
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            // Revert view to the original collection order
            TaskGrid.ItemsSource = planner.Tasks;
        }
    }
}

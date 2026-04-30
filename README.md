
# SmartPath: Smart Study & Exam Optimizer 🎓

**SmartPath** is a C#-based desktop application built with WPF (Windows Presentation Foundation). It is designed to help university students manage their academic workload using mathematical optimization. Instead of a basic to-do list, SmartPath uses a **Weighted Entropy Heuristic** to rank your tasks by their true priority and impact on your semester.

## 🛠️ Prerequisites
To run this project, you need:
* **Operating System:** Windows 10 or 11 (Required for WPF).
* **SDK:** [.NET 8.0 SDK](https://dotnet.microsoft.com/download) (or higher).

---

## 🚀 How to Run the Project

You can run SmartPath using either **Visual Studio Code** or the full **Visual Studio 2022**. Choose the method that fits your setup:

### Option 1: Visual Studio 2022 (Recommended)
This is the easiest method as it handles the UI designer and dependencies automatically.
1.  **Clone:** Open Visual Studio 2022 and select **"Clone a repository"**.
2.  **Link:** Paste: `[https://github.com/milenaghandilyan/ProjectS2.git](https://github.com/milenaghandilyan/ProjectS2.git)`.
3.  **Open:** Once cloned, double-click the `StudyPlannerUI2.sln` file.
4.  **Run:** Press **F5** or click the green **Start** button at the top.

### Option 2: Visual Studio Code
Ideal for a lightweight experience using the command line.
1.  **Clone:** Open your terminal and run:
    ```bash
    git clone https://github.com/milenaghandilyan/ProjectS2.git
    cd ProjectS2
    ```
2.  **Open:** Open the folder in VS Code (`code .`).
3.  **Extension:** Ensure the **"C# Dev Kit"** extension is installed.
4.  **Run:** Open the VS Code terminal (**Ctrl + `**) and type:
    ```bash
    dotnet run
    ```

---

## 📖 Key Features
* **Multi-User System:** Secure login and registration for individual students.
* **Intelligent Optimization:** Automatically ranks tasks based on the following heuristic:
  $$Weight = (Priority \times 0.5) + (Difficulty \times 0.3)$$
* **Data Persistence:** Your tasks are saved locally and reloaded every time you log in.

---

## 🔬 Technical Details
* **Language:** C#.
* **Framework:** .NET 8.0 Windows (WPF).
* **Architecture:** Implements file-based storage and heuristic ranking algorithms.

---

### **Troubleshooting**
If you encounter a `CS0103` error (The name 'InitializeComponent' does not exist), follow these steps in your terminal:
1. `dotnet clean`
2. `dotnet build`
3. `dotnet run`

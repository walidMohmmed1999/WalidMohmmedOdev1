using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace WalidMohmmedOdev1;

public partial class YapilacaklarPage : ContentPage
{
    ObservableCollection<TaskModel> tasks;
    public YapilacaklarPage()
	{
		InitializeComponent();

        tasks = new ObservableCollection<TaskModel>();
        TasksListView.ItemsSource = tasks;
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        string taskName = TaskEntry.Text;
        if (!string.IsNullOrWhiteSpace(taskName))
        {
            tasks.Add(new TaskModel { TaskName = taskName });
            TaskEntry.Text = string.Empty; 
            DisplayMessage("Etkinlik baþarýyla eklendi\r\n!");
        }
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
       
        var task = (TaskModel)((ImageButton)sender).CommandParameter;
        tasks.Remove(task);
        DisplayMessage("Etkinlik baþarýyla silindi!");
    }

    

    private async void ModifyButton_Clicked(object sender, EventArgs e)
    {
    
        var task = (TaskModel)((ImageButton)sender).CommandParameter;

        string newTaskName = await DisplayPromptAsync("Modify Task", "Enter the new task name", "OK", "Cancel", task.TaskName);

        
        if (newTaskName != null)
        {
           
            task.TaskName = newTaskName;

            TasksListView.ItemsSource = null;
            TasksListView.ItemsSource = tasks;

            DisplayMessage("Etkinlik baþarýyla deðiþtirildi!");
        }
    }




    private void DisplayMessage(string message)
    {
      
        MessageLabel.Text = message;
        Device.StartTimer(TimeSpan.FromSeconds(2), () =>
        {
            MessageLabel.Text = "";
            return false;
        });
    }
}


public class TaskModel
{
    public string TaskName { get; set; }
}


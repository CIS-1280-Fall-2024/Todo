using System.Diagnostics;
using Todo.Entitities.Models;

namespace Todo
{    
    public partial class MainPage : ContentPage
    {
        private List<ToDoItem> items = new List<ToDoItem>();
        ToDoPage page;

        public MainPage()
        {
            InitializeComponent();
            items.Add(new ToDoItem()
            {
                Title = "Test item 1",
                Description = "Test item 1 Description",
                IsDone = false,
                CompletionDate = null
            });
            items.Add(new ToDoItem()
            {
                Title = "Test item 2",
                Description = "Test item 2 Description",
                IsDone = false,
                CompletionDate = null
            });
            items.Add(new ToDoItem()
            {
                Title = "Test item 3",
                Description = "Test item 3 Description",
                IsDone = true,
                CompletionDate = DateTime.Now
            });
            ToDoListView.ItemsSource = items;
        }

        private async void AddToDoButton_ClickedAsync(object sender, EventArgs e)
        {
            page = new ToDoPage(AddToDoToList);
            await Navigation.PushModalAsync(page);
        }

        public void AddToDoToList()
        {
            items.Add(page.ToDoItem);
            ToDoListView.ItemsSource = null;
            ToDoListView.ItemsSource = items;
        }
    }
}

using System.Diagnostics;
using Todo.Entitities.DALs;
using Todo.Entitities.Models;

namespace Todo
{    
    public partial class MainPage : ContentPage
    {
        ToDoDAL dal = new ToDoDAL();
        private List<ToDoItem> items = new List<ToDoItem>();
        ToDoPage todoItemDialog;

        public MainPage()
        {
            InitializeComponent();
            items = dal.GetToDoItems();
            ToDoListView.ItemsSource = items;
        }

        private async void AddToDoButton_ClickedAsync(object sender, EventArgs e)
        {
            todoItemDialog = new ToDoPage(AddToDoToList);
            await Navigation.PushModalAsync(todoItemDialog);
        }

        public void AddToDoToList()
        {
            //Add new item to database
            dal.AddToDoItem(todoItemDialog.ToDoItem);
            //Add new item to local list
            items.Add(todoItemDialog.ToDoItem);
            ToDoListView.ItemsSource = null;
            ToDoListView.ItemsSource = items;
        }
    }
}

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

            RefreshView();
        }

        public void UpdateToDoItem()
        {
            //Update item in database
            dal.UpdateToDoItem(todoItemDialog.ToDoItem);

            //Don't need to add new item in local list, it's already there!
            RefreshView();
        }

        public void DeleteToDoItem()
        {
            //Delete item in database
            dal.DeleteToDoItem(todoItemDialog.ToDoItem);

            //Remove from local item list
            items.Remove(todoItemDialog.ToDoItem);

            RefreshView();
        }

        private void RefreshView()
        {
            //Refresh ToDoListView
            ToDoListView.ItemsSource = null;
            ToDoListView.ItemsSource = items;
        }

        private async void ToDoListView_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            ToDoItem item = (ToDoItem)e.Item;
            todoItemDialog = new ToDoPage(UpdateToDoItem, DeleteToDoItem, item);
            await Navigation.PushModalAsync(todoItemDialog);
        }
    }
}

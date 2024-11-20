using System.Diagnostics;
using Todo.Entitities.DALs;
using Todo.Entitities.Models;

namespace Todo
{    
    public partial class MainPage : ContentPage
    {
        ToDoDAL dal = new ToDoDAL();
        private List<ToDoItem> items = new List<ToDoItem>();
        ToDoPage page;

        public MainPage()
        {
            InitializeComponent();
            items = dal.GetToDoItems();
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

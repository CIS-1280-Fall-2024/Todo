using Todo.Entitities.Models;

namespace Todo;

public partial class ToDoPage : ContentPage
{
    public ToDoItem ToDoItem { get; set; }
    private Action _addItemMethod;

    public ToDoPage(Action addItemMethod)
	{
        ToDoItem = new ToDoItem();
        _addItemMethod = addItemMethod;
		InitializeComponent();
	}

    private async void OnSubmitClickedAsync(object sender, EventArgs e)
    {
        // Create a new ToDoItem object from the form data
        ToDoItem.Id = Guid.NewGuid();
        ToDoItem.Title = entryTitle.Text;
        ToDoItem.Description = editorDescription.Text;
        ToDoItem.IsDone = checkBoxIsDone.IsChecked;
        ToDoItem.CompletionDate = datePickerCompletionDate.Date;

        //Show todo in results label
        labelResults.Text = ToDoItem.ToString();

        //Call action method
        _addItemMethod();

        //Close page
        await Navigation.PopModalAsync();
    }
}
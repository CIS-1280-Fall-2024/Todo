using Todo.Entitities.Models;

namespace Todo;

public partial class ToDoPage : ContentPage
{
    public ToDoItem ToDoItem { get; set; }
    private Action _submitMethod;

    public ToDoPage(Action submitMethod, ToDoItem toDoItem)
    {
        InitializeComponent();
        ToDoItem = toDoItem;
        entryTitle.Text = ToDoItem.Title;
        editorDescription.Text = ToDoItem.Description ;
        checkBoxIsDone.IsChecked = ToDoItem.IsDone;
        if (ToDoItem.CompletionDate != null)
        {
            datePickerCompletionDate.Date = (DateTime)ToDoItem.CompletionDate;
        }
        _submitMethod = submitMethod;
    }

    public ToDoPage(Action submitMethod):this(submitMethod,new ToDoItem())
	{
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
        _submitMethod();

        //Close page
        await Navigation.PopModalAsync();
    }
}
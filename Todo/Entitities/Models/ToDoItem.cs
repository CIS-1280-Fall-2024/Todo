// File: ToDoItem.cs
// Purpose: Represents a single item in a ToDo list.
// Created: 2019-12-14
// Programmer: Rob Garner (rgarner7@cnm.edu)
namespace Todo.Entitities.Models
{
    /// <summary>
    /// Represents a single item in a ToDo list.
    /// </summary>
    public class ToDoItem
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime? CompletionDate { get; set; }

        public override string ToString()
        {
            return $"{Title} - {IsDone}";
        }
    }
}

using Todo.Entitities.Models;

namespace Todo
{
    public class SharedObjects
    {
        private static SharedObjects? instance;

        public static SharedObjects? Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new SharedObjects();
                }
                return instance;
            }
        }

        public List<ToDoItem>? ToDoItems { get; set; }


    }
}

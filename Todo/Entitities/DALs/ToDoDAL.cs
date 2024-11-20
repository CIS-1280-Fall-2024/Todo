using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entitities.Models;

namespace Todo.Entitities.DALs
{
    public class ToDoDAL
    {
        public ToDoDAL()
        {
            
        }

        public List<ToDoItem> GetToDoItems()
        {
            List<ToDoItem> items = new List<ToDoItem>();

            string connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rob011235\\source\\repos\\Tutorials\\Todo\\Todo\\ToDoDB.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string commStr = "SELECT * FROM ToDoItem";
                SqlCommand cmd = new SqlCommand(commStr, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                items.Clear();
                while (dr.Read())
                {
                    ToDoItem item = new ToDoItem();
                    item.Id = Guid.Parse(dr.GetSqlGuid(0).ToString());
                    item.Title = dr.GetString(1);
                    item.Description = dr.GetString(2); 
                    item.IsDone = dr.GetBoolean(3);
                    item.CompletionDate = dr.GetDateTime(4);
                    items.Add(item);
                }
            }

            return items;
        }
    }
}

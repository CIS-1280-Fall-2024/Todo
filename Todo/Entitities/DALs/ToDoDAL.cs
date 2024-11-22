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

            string connStr = Preferences.Get("ConnectionString","");
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
                    item.CompletionDate = (DateTime?)dr.GetSqlDateTime(4);
                    items.Add(item);
                }
            }

            return items;
        }

        public void AddToDoItem(ToDoItem item)
        {
            string connStr = Preferences.Get("ConnectionString", "");
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string commStr = $"INSERT INTO ToDoItem VALUES (@Id, @Title, @Description, @IsDone, @CompletionDate);";
                SqlCommand cmd = new SqlCommand(commStr, conn);
                cmd.Parameters.AddWithValue("Id", item.Id);
                cmd.Parameters.AddWithValue ("Title", item.Title??"");
                cmd.Parameters.AddWithValue ("Description", item.Description??"");
                cmd.Parameters.AddWithValue("IsDone",item.IsDone);
                cmd.Parameters.AddWithValue("CompletionDate", item.CompletionDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateToDoItem(ToDoItem item)
        {
            string connStr = Preferences.Get("ConnectionString", "");
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string commStr = "UPDATE ToDoItem SET Title = @Title, Description = @Description, IsDone = @IsDone, CompletionDate = @CompletionDate WHERE Id = @Id;";
                SqlCommand cmd = new SqlCommand(commStr, conn);
                cmd.Parameters.AddWithValue("Id", item.Id);
                cmd.Parameters.AddWithValue("Title", item.Title);
                cmd.Parameters.AddWithValue("Description", item.Description);
                cmd.Parameters.AddWithValue("IsDone", item.IsDone);
                cmd.Parameters.AddWithValue("CompletionDate", item.CompletionDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteToDoItem(ToDoItem item)
        {
            string connStr = Preferences.Get("ConnectionString", "");
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string commStr = "DELETE FROM ToDoItem WHERE Id = @Id;";
                SqlCommand cmd = new SqlCommand(commStr, conn);
                cmd.Parameters.AddWithValue("Id", item.Id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

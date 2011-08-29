using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Tasks.Models
{
    public class TaskModel
    {
        public int? Id { get; set; }
        public DateTime DueDate { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string User { get; set; }

        public static List<TaskModel> GetByUser(string search_user)
        {
            List<TaskModel> task_list = new List<TaskModel>();
                        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["tasks"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetTasksByUser", connection);
                command.Parameters.Add("@user", SqlDbType.VarChar).Value = search_user;

                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        TaskModel task = new TaskModel();
                        task.Id = int.Parse(reader["id"].ToString());
                        task.DueDate = DateTime.Parse(reader["due_date"].ToString());
                        task.Priority = int.Parse(reader["priority"].ToString());
                        task.User = reader["user"].ToString();
                        task.Name = reader["name"].ToString();
                        task_list.Add(task);
                    }
                }
                return task_list;
            }
        }

        public void Save()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["tasks"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("InsertTask", connection);
                command.Parameters.Add("@due_date", SqlDbType.DateTime).Value = this.DueDate;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = this.Name;
                command.Parameters.Add("@priority", SqlDbType.Int).Value = this.Priority;
                command.Parameters.Add("@user", SqlDbType.VarChar).Value = this.User;
                this.Id = int.Parse(command.ExecuteScalar().ToString());

            }
        }

    }
}
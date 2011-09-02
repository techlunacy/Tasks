using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Tasks.Models
{
    public class TaskModel
    {
        public const int HighestPriority = 10;
        public const int LowestPriority = 1;
        public const int NormalPriority = 5;

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter a date", AllowEmptyStrings = false)]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "Please enter a name", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [UIHint("PriorityDropDown")]
        public int Priority { get; set; }

        public string User { get; set; }

        public bool IsDueToday
        {
            get { return DueDate.Date == DateTime.Now.Date; }
        }


        public static List<TaskModel> GetByUser(string searchUser)
        {
            List<TaskModel> task_list = new List<TaskModel>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["tasks"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetTasksByUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@user", SqlDbType.VarChar).Value = searchUser;

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
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
                connection.Dispose();
                return task_list;
            }
        }

        public void Save()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["tasks"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("InsertTask", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@due_date", SqlDbType.DateTime).Value = this.DueDate;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = this.Name;
                command.Parameters.Add("@priority", SqlDbType.Int).Value = this.Priority;
                command.Parameters.Add("@user", SqlDbType.VarChar).Value = this.User;
                connection.Open();
                this.Id = int.Parse(command.ExecuteScalar().ToString());
                connection.Dispose();

            }
        }

    }
}
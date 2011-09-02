using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tasks.Models;

namespace Tasks.Helpers
{
    public class TaskHelper
    {
        public static List<SelectListItem> PriorityDropDownListPopulation()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = TaskModel.LowestPriority; i <= TaskModel.HighestPriority; i++)
            {
                string textValue = i.ToString() + " ";
                switch (i)
                {
                    case TaskModel.LowestPriority:
                        textValue += "Lowest";
                        break;
                    case TaskModel.NormalPriority:
                        textValue += "Normal";
                        break;
                    case TaskModel.HighestPriority:
                        textValue += "Highest";
                        break;
                }
                SelectListItem selectListItem = new SelectListItem { Text = textValue, Value = i.ToString(), Selected = (i == TaskModel.NormalPriority) };
                items.Add(selectListItem);
            }
            return items;
        }
    }
}
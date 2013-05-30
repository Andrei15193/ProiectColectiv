using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class TasksViewModel
    {
        public TasksViewModel()
        {
            TeamViewModel = ViewModelFactory.TeamViewModel;
            SelectClassRoomViewModel = ViewModelFactory.SelectClassRoomViewModel;
            SelectEquipmentsViewModel = ViewModelFactory.SelectEquipmentsViewModel;
            TaskTypeSelectedIndex = 0;
        }

        public string[] TaskTypes
        {
            get
            {
                return taskTypes;
            }
        }

        public int TaskTypeSelectedIndex { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string[] Currency
        {
            get
            {
                return currency;
            }
        }

        public int MobilityCostSelectedIndex { get; set; }

        public int MobilityCost { get; set; }

        public int LaborCostSelectedIndex { get; set; }

        public int LaborCost { get; set; }

        public int LogisticalCostSelectedIndex { get; set; }

        public int LogisticalCost { get; set; }

        public SelectEquipmentsViewModel SelectEquipmentsViewModel { get; set; }

        public TeamViewModel TeamViewModel { get; set; }

        public SelectClassRoomViewModel SelectClassRoomViewModel { get; private set; }

        private string[] taskTypes = Enum.GetNames(typeof(TaskType)).Select((typeName) => typeName.Replace('_', ' ')).ToArray();
        private string[] currency = Enum.GetNames(typeof(Currency)).Select((currencyName) => currencyName.Replace('_', ' ')).ToArray();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Database;
using DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class ImportScheduleViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportScheduleViewModel"/> class.
        /// </summary>
        public ImportScheduleViewModel()
        {
            this.imports = new Imports();
        }

        /// <summary>
        /// The imports
        /// </summary>
        private IImports imports;

        /// <summary>
        /// Gets or sets the semester start.
        /// </summary>
        /// <value>
        /// The semester start.
        /// </value>
        public DateTime SemesterStart
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the semester end.
        /// </summary>
        /// <value>
        /// The semester end.
        /// </value>
        public DateTime SemesterEnd { get; set; }

        /// <summary>
        /// Gets or sets the holidays.
        /// </summary>
        /// <value>
        /// The holidays.
        /// </value>
        public List<KeyValuePair<DateTime, DateTime>> Holidays { get; set; }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public List<byte[]> Files { get; set; }

        public bool TrySave(out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                this.imports.Schedule(this.Files, this.SemesterStart, this.SemesterEnd, this.Holidays);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }

            return true;
        }
    }
}

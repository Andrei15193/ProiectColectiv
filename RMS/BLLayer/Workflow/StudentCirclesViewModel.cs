using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class StudentCirclesViewModel
    {
        public StudentCirclesViewModel(IAllStudentCircles allStudentCircles)
        {
            if (allStudentCircles != null)
            {
                this.allStudentCircles = allStudentCircles;
            }
            else
                throw new ArgumentNullException("The provided value for allStudentCircles cannot be null!");
        }

        public String Title { get; set; }


        public String Description { get; set; }

		
        public String StartDate { get; set; }


        public String EndDate { get; set; }
 
		public StudyProgram StudyProgram { get; set; }

        private DateTime? ParseDate(string date)
        {
            int day;
            int month;
            int year;

            if (date.Split('-').Length == 3)
            {
                if (!int.TryParse(date.Split('-')[0], out day))
                {
                    return null;
                }

                if (!int.TryParse(date.Split('-')[1], out month))
                {
                    return null;
                }
                if (!int.TryParse(date.Split('-')[2], out year))
                {
                    return null;
                }
                return new DateTime(year, month, day);
            }

            return null;
        }

        public bool TryAddStudentCircles(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                DateTime? start = ParseDate(StartDate);
                DateTime? end = ParseDate(EndDate);
                if(start!=null && end!=null)
                {
                allStudentCircles.Add(new StudentCircle(Title, Description, start.Value, end.Value, StudyProgram));
                return true;}
                else
                    return false;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return false;
            }
        }

        public IEnumerable<StudentCircle> TryGetAll(out string errorMessage)
        {
            try
            {
                errorMessage = null;
                return allStudentCircles.AsEnumerable;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return null;
            }
        }

        private IAllStudentCircles allStudentCircles;

    }
}

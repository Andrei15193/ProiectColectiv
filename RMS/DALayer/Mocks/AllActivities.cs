using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;

namespace ResourceManagementSystem.DataAccess.Mocks
{
    public class AllActivities : IAllActivities
    {
        public AllActivities()
        {
            activities = new HashSet<AbstractActivity>();
            activities.Add(new DidacticActivity(CourseType.Course, "Algoritmica grafelor", "Ceva linii si cercuri", "I2", DateTime.Now.AddDays(-10), DateTime.Now, new Teacher(TeachingPosition.Professor, "Andrei", "fair1064@scs.ubbcluj.ro", "123456", "Stuff")));
        }

        public IEnumerable<AbstractActivity> AsEnumerable
        {
            get
            {
                return activities;
            }
        }

        private ICollection<AbstractActivity> activities;
    }
}

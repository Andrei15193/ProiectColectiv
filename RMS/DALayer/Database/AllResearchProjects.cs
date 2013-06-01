using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALayer.Database
{
    class AllResearchProjects : IAllResearchProjects
    {
        internal ResourceManagementSystem.BusinessLogic.Entities.ResearchProject getByPhase(int p)
        {
            throw new NotImplementedException();
        }

        public void Add(ResourceManagementSystem.BusinessLogic.Entities.ResearchProject researchProject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResourceManagementSystem.BusinessLogic.Entities.ResearchProject> AsEnumerable
        {
            get { throw new NotImplementedException(); }
        }
    }
}

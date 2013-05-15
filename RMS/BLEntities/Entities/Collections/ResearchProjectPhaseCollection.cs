using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class ResearchProjectPhaseCollection : ICollection<Phase>
    {
        public ResearchProjectPhaseCollection(ResearchProject researchProject)
        {
        }

        public void Add(Phase item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Phase item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Phase[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Phase item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Phase> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public ResearchProject ResearchProject { get; private set; }
    }
}

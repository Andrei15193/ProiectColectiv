using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace DAOInterface.DAOInterface
{
    interface IStudyPrograms
    {
        bool addStudyProgram(StudyProgram studyProgram);
        //bool updateMember(string email, ResourceManagementSystem.BusinessLogic.Entities.Member newMember);
        //bool deleteMember(string email);
    }
}

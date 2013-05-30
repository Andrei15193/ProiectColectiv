using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace ResourceManagementSystem.DataAccess.DAOInterface
{
    public interface IStudyPrograms
    {
        bool AddStudyProgram(StudyProgram studyProgram);

        StudyProgram GetByPrimaryKey(string educationalProgramme, StudyDegree studyDegree, string domain, int yearLength, int totalEctsCredits, TypeOfStudy studyType);

        List<StudyProgram> GetAll();
    }
}

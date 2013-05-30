using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.Database;
using ResourceManagementSystem.DAlayer.Database;
using System.Diagnostics;

namespace DATest
{
    [TestClass]
    public class StudyProgramsTest
    {
        [TestMethod]
        public void AddStudyProgrammeTest()
        {
            StudyProgram studyProgram = new StudyProgram()
            {
                AreaOfExpertise = "Info",
                ContactPerson ="Ionut",
                DegreeOfStudy = StudyDegree.Bachelor,
                DescriptionOfStudy = "description",
                Domain = "CS",
                EducationalProgramme = "edProg",
                EMail="test@test.com",
                EntranceConditions = "sa fii bun!",
                ExtraPeculiarities = "good communication skills",
                Faculty = "UBB M-I",
                Fax = "2342324032534",
                FinalExaminations = "final examinations",
                FurtherEducationPossibilities = "da bun tss",
                GainedAbilitiesAndSkills = "bum bum bum",
                HigherEducationInstitution = "h ed inst",
                Phone = "0543435345345",
                PotentialFieldOfProfessionalActivity = "pot field of activ",
                PracticalTraining = "prac training",
                ProfileOfTheDegreeProgramme= "prof of degree programme",
                PurposesOfTheProgramme = "purpose",
                StudyTime= WorkTime.Full_Time,
                TargetGroups = "target gr",
                TotalEctsCredits = 5,
                YearLength = 3
            };

            try
            {
                Studyprograms studyPrograms = new Studyprograms();
                studyPrograms.AddStudyProgram(studyProgram);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetByPrimaryKeyTest()
        {
            StudyProgram studyProgram = new StudyProgram()
            {
                AreaOfExpertise = "Info",
                ContactPerson = "Ionut",
                DegreeOfStudy = StudyDegree.Bachelor,
                DescriptionOfStudy = "description",
                Domain = "CS",
                EducationalProgramme = "edProg",
                EMail = "test@test.com",
                EntranceConditions = "sa fii bun!",
                ExtraPeculiarities = "good communication skills",
                Faculty = "UBB M-I",
                Fax = "2342324032534",
                FinalExaminations = "final examinations",
                FurtherEducationPossibilities = "da bun tss",
                GainedAbilitiesAndSkills = "bum bum bum",
                HigherEducationInstitution = "h ed inst",
                Phone = "0543435345345",
                PotentialFieldOfProfessionalActivity = "pot field of activ",
                PracticalTraining = "prac training",
                ProfileOfTheDegreeProgramme = "prof of degree programme",
                PurposesOfTheProgramme = "purpose",
                StudyTime = WorkTime.Full_Time,
                TargetGroups = "target gr",
                TotalEctsCredits = 5,
                YearLength = 3
            };

            try
            {
                Studyprograms studyPrograms = new Studyprograms();
                studyPrograms.AddStudyProgram(studyProgram);
            }
            catch (Exception)
            {
            }

            Studyprograms studyProg = new Studyprograms();
            StudyProgram studProgram = studyProg.GetByPrimaryKey(studyProgram.EducationalProgramme, studyProgram.DegreeOfStudy, studyProgram.Domain, studyProgram.YearLength, studyProgram.TotalEctsCredits, studyProgram.StudyTime);

            Assert.IsNotNull(studProgram);
        }

        [TestMethod]
        public void GetAllStudyProgramsTest()
        {
            StudyProgram studyProgram = new StudyProgram()
            {
                AreaOfExpertise = "Info",
                ContactPerson = "Ionut",
                DegreeOfStudy = StudyDegree.Bachelor,
                DescriptionOfStudy = "description",
                Domain = "CS",
                EducationalProgramme = "edProg",
                EMail = "test@test.com",
                EntranceConditions = "sa fii bun!",
                ExtraPeculiarities = "good communication skills",
                Faculty = "UBB M-I",
                Fax = "2342324032534",
                FinalExaminations = "final examinations",
                FurtherEducationPossibilities = "da bun tss",
                GainedAbilitiesAndSkills = "bum bum bum",
                HigherEducationInstitution = "h ed inst",
                Phone = "0543435345345",
                PotentialFieldOfProfessionalActivity = "pot field of activ",
                PracticalTraining = "prac training",
                ProfileOfTheDegreeProgramme = "prof of degree programme",
                PurposesOfTheProgramme = "purpose",
                StudyTime = WorkTime.Full_Time,
                TargetGroups = "target gr",
                TotalEctsCredits = 5,
                YearLength = 3
            };

            try
            {
                Studyprograms studyPrograms = new Studyprograms();
                studyPrograms.AddStudyProgram(studyProgram);
            }
            catch (Exception)
            {
            }

            Studyprograms studyProgRep = new Studyprograms();
            List<StudyProgram> studyProgramsList = studyProgRep.GetAll();

            Assert.IsTrue(studyProgramsList.Count > 0);
        }
    }
}

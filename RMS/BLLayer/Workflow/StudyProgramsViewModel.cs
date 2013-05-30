using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class StudyProgramsViewModel
    {
        public StudyProgramsViewModel(IStudyPrograms allPrograms)
        {
            if (allPrograms != null)
            {
                textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
                this.allPrograms = allPrograms;
                StudyDegreeSelectedIndex = 0;
                StudyTimeSelectedIndex = 0;
            }
            else
                throw new ArgumentNullException("The provided value for allPrograms cannot be null!");
        }

        public string EducationalProgramme { get; set; }

        public string Domain { get; set; }

        public int YearLength { get; set; }

        public int TotalEctsCredits { get; set; }

        public string HigherEducationInstitution { get; set; }

        public string Faculty { get; set; }

        public string ContactPerson { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string EMail { get; set; }

        public string ProfileOfTheDegreeProgramme { get; set; }

        public string TargetGroups { get; set; }

        public string EntranceConditions { get; set; }

        public string FurtherEducationPossibilities { get; set; }

        public string DescriptionOfStudy { get; set; }

        public string PurposesOfTheProgramme { get; set; }

        public string AreaOfExpertise { get; set; }

        public string ExtraPeculiarities { get; set; }

        public string PracticalTraining { get; set; }

        public string FinalExaminations { get; set; }

        public string GainedAbilitiesAndSkills { get; set; }

        public string PotentialFieldOfProfessionalActivity { get; set; }

        public string[] StudyDegrees { get { return studyDegrees; } }

        public int StudyDegreeSelectedIndex { get; set; }

        public string[] WorkTimes { get { return studyTime; } }

        public int StudyTimeSelectedIndex { get; set; }

        public bool TryAddProgramme(out string errorMessage)
        {
            errorMessage = null;
            try
            {
                allPrograms.AddStudyProgram
                (
                    new StudyProgram()
                    {
                        AreaOfExpertise = AreaOfExpertise,
                        ContactPerson = ContactPerson,
                        DegreeOfStudy = (StudyDegree)StudyDegreeSelectedIndex,
                        DescriptionOfStudy = DescriptionOfStudy,
                        Domain = Domain,
                        EducationalProgramme = EducationalProgramme,
                        EMail = EMail,
                        EntranceConditions = EntranceConditions,
                        ExtraPeculiarities = ExtraPeculiarities,
                        Faculty = Faculty,
                        Fax = Fax,
                        FinalExaminations = FinalExaminations,
                        FurtherEducationPossibilities = FurtherEducationPossibilities,
                        GainedAbilitiesAndSkills = GainedAbilitiesAndSkills,
                        HigherEducationInstitution = HigherEducationInstitution,
                        Phone = Phone,
                        PotentialFieldOfProfessionalActivity = PotentialFieldOfProfessionalActivity,
                        PracticalTraining = PracticalTraining,
                        ProfileOfTheDegreeProgramme = ProfileOfTheDegreeProgramme,
                        PurposesOfTheProgramme = PurposesOfTheProgramme,
                        StudyTime = (WorkTime)StudyTimeSelectedIndex,
                        TargetGroups = TargetGroups,
                        TotalEctsCredits = TotalEctsCredits,
                        YearLength = YearLength
                    }

                );
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return false;
            }
        }

        public IEnumerable<StudyProgram> TryGetAll(out string errorMessage)
        {
            try
            {
                errorMessage = null;
                return allPrograms.GetAll();
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return null;
            }
        }

        TextInfo textInfo;
        private IStudyPrograms allPrograms;
        private static readonly string[] studyDegrees = Enum.GetNames(typeof(StudyDegree)).Select((studyDegrees) => studyDegrees.Replace('_', ' ')).ToArray();
        private static readonly string[] studyTime = Enum.GetNames(typeof(WorkTime)).Select((studyTime) => studyTime.Replace('_', ' ')).ToArray();
    }
}

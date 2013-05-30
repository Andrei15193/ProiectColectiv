namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class StudyProgram
    {
        public string EducationalProgramme { get; set; }

        public StudyDegree DegreeOfStudy { get; set; }

        public string Domain { get; set; }

        public int YearLength { get; set; }

        public int TotalEctsCredits { get; set; }

        public TypeOfStudy StudyTime { get; set; }

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

        public override string ToString()
        {
            // E.g.: Databases (Master in Computer Science) - 2 years Full-Time
            return string.Format("{0} ({1} in {2}) - {3} years {4}", EducationalProgramme, DegreeOfStudy, Domain, YearLength, StudyTime.ToString().Replace('_', '-'));
        }
    }
}

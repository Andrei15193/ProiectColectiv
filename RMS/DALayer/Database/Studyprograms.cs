using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess;
using ResourceManagementSystem.DataAccess.DAOInterface;

namespace ResourceManagementSystem.DataAccess.Database
{
    public class Studyprograms : IStudyPrograms
    {
        public bool AddStudyProgram(ResourceManagementSystem.BusinessLogic.Entities.StudyProgram studyProgram)
        {
            SqlConnection connection = DatabaseConstants.SqlConnection;

            SqlCommand cmd = new SqlCommand(@"insert into StudyPRogrammes (educationalProgramme, degreeOfStudy, domain, yearLength, ectsCredits, 
                                                                           typeOfStudy, higherEducationInstitution, faculty, contactPerson, phone, 
                                                                           fax, eMail, profileOfTheDegreeProgramme, targetGroups, entranceConditions, 
                                                                           furtherEducationPossibilities, descriptionOfStudy, purposesOfTheProgramme,
							                                               areaOfExpertise, extraPeculiarities, practicalTraining, finalExaminations, 
                                                                           gainedAbilitiesAndSkills, potentialFieldOfProfessionalActivity
                                                                           ) VALUES
							                                               (
							                                                   @edProgramme, @degreeOfStudy, @domain, @yearLength, @ectsCredits,
                                                                               @typeOfStudy, @higherEducationInstitution, @faculty, @contactPerson, @phone,
                                                                               @fax, @email, @profileOfTheDegreeProgramme, @targetGroups, @entranceConditions,
						                                                       @furtherEducationPossibilities, @descriptionOfStudy, @purposesOfTheProgramme, 
                                                                               @areaOfExpertise, @extraPeculiaritie, @practicalTraining, @finalExaminations,
								                                               @gainedAbilitiesAndSkills, @potentialFieldOfProfessionalActivity
                                                                           )", connection);
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@edProgramme",
                Value = studyProgram.EducationalProgramme
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@degreeOfStudy",
                Value = (int)studyProgram.DegreeOfStudy
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@domain",
                Value = studyProgram.Domain
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@yearLength",
                Value = studyProgram.YearLength
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@ectsCredits",
                Value = studyProgram.TotalEctsCredits
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@typeOfStudy",
                Value = (int)studyProgram.StudyTime
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@higherEducationInstitution",
                Value = studyProgram.HigherEducationInstitution
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@faculty",
                Value = studyProgram.Faculty
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@contactPerson",
                Value = studyProgram.ContactPerson
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@phone",
                Value = studyProgram.Phone
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@fax",
                Value = studyProgram.Fax
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@email",
                Value = studyProgram.EMail
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@profileOfTheDegreeProgramme",
                Value = studyProgram.ProfileOfTheDegreeProgramme
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@targetGroups",
                Value = studyProgram.TargetGroups
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@entranceConditions",
                Value = studyProgram.EntranceConditions
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@furtherEducationPossibilities",
                Value = studyProgram.FurtherEducationPossibilities
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@descriptionOfStudy",
                Value = studyProgram.DescriptionOfStudy
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@purposesOfTheProgramme",
                Value = studyProgram.PurposesOfTheProgramme
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@areaOfExpertise",
                Value = studyProgram.AreaOfExpertise
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@extraPeculiaritie",
                Value = studyProgram.ExtraPeculiarities
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@practicalTraining",
                Value = studyProgram.PracticalTraining
            });

            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@finalExaminations",
                Value = studyProgram.FinalExaminations
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@gainedAbilitiesAndSkills",
                Value = studyProgram.GainedAbilitiesAndSkills
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@potentialFieldOfProfessionalActivity",
                Value = studyProgram.PotentialFieldOfProfessionalActivity
            });
            try
            {
                connection.Open();

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

                throw ex;
            }

            return true;
        }

        public ResourceManagementSystem.BusinessLogic.Entities.StudyProgram GetByPrimaryKey(string educationalProgramme, ResourceManagementSystem.BusinessLogic.Entities.StudyDegree studyDegree, string domain, int yearLength, int totalEctsCredits, TypeOfStudy studyType)
        {
            SqlConnection connection = DatabaseConstants.SqlConnection;
            SqlCommand cmd = new SqlCommand(@"select educationalProgramme, degreeOfStudy, domain, yearLength, ectsCredits, typeOfStudy,
							 higherEducationInstitution, faculty, contactPerson, phone, fax, eMail, profileOfTheDegreeProgramme,
							 targetGroups, entranceConditions, furtherEducationPossibilities, descriptionOfStudy, purposesOfTheProgramme,
							 areaOfExpertise, extraPeculiarities, practicalTraining, finalExaminations, gainedAbilitiesAndSkills,
							 potentialFieldOfProfessionalActivity
		
                            from StudyProgrammes where educationalProgramme = @edProgramme and degreeOfStudy = @degreeOfStudy and domain = @domain and yearLength = @year and ectsCredits = @credits and typeOfStudy = @studyType", 
                            connection);

            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@edProgramme",
                Value = educationalProgramme
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@degreeOfStudy",
                Value = (int)studyDegree
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@domain",
                Value = domain
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@year",
                Value = yearLength
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@credits",
                Value = totalEctsCredits
            });
            cmd.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@studyType",
                Value = (int)studyType
            });

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            List<StudyProgram> studyPrograms = ReadStudyPrograms(reader);

            reader.Close();

            connection.Close();

            if (studyPrograms == null || studyPrograms.Count == 0)
            {
                return null;
            }
            else
            {
                return studyPrograms[0];
            }
        }

        private List<StudyProgram> ReadStudyPrograms(SqlDataReader reader)
        {
            List<StudyProgram> studyPrograms = new List<StudyProgram>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    StudyProgram sp = new StudyProgram()
                    {
                        EducationalProgramme = reader["educationalProgramme"].ToString(),
                        DegreeOfStudy = (StudyDegree)Convert.ToInt32(reader["degreeOfStudy"]),
                        Domain = reader["domain"].ToString(),
                        YearLength = Convert.ToInt32(reader["yearLength"].ToString()),
                        TotalEctsCredits = Convert.ToInt32(reader["ectsCredits"].ToString()),
                        StudyTime = (TypeOfStudy)Convert.ToInt32(reader["typeOfStudy"].ToString()),
                        HigherEducationInstitution = reader["higherEducationInstitution"].ToString(),
                        Faculty = reader["faculty"].ToString(),
                        ContactPerson  = reader["contactPerson"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Fax = reader["fax"].ToString(),
                        EMail = reader["eMail"].ToString(),
                        ProfileOfTheDegreeProgramme = reader["profileOfTheDegreeProgramme"].ToString(),
                        TargetGroups = reader["targetGroups"].ToString(),
                        EntranceConditions = reader["entranceConditions"].ToString(),
                        FurtherEducationPossibilities = reader["furtherEducationPossibilities"].ToString(),
                        DescriptionOfStudy = reader["descriptionOfStudy"].ToString(),
                        PurposesOfTheProgramme = reader["purposesOfTheProgramme"].ToString(),
                        AreaOfExpertise = reader["areaOfExpertise"].ToString(),
                        ExtraPeculiarities = reader["extraPeculiarities"].ToString(),
                        PracticalTraining = reader["practicalTraining"].ToString(),
                        FinalExaminations = reader["finalExaminations"].ToString(),
                        GainedAbilitiesAndSkills = reader["gainedAbilitiesAndSkills"].ToString(),
                        PotentialFieldOfProfessionalActivity = reader["potentialFieldOfProfessionalActivity"].ToString()
                    };

                    studyPrograms.Add(sp);
                }
            }
            
            return studyPrograms;
        }

        public List<ResourceManagementSystem.BusinessLogic.Entities.StudyProgram> GetAll()
        {
            SqlConnection connection = DatabaseConstants.SqlConnection;
            SqlCommand cmd = new SqlCommand(@"select educationalProgramme, degreeOfStudy, domain, yearLength, ectsCredits, typeOfStudy,
							 higherEducationInstitution, faculty, contactPerson, phone, fax, eMail, profileOfTheDegreeProgramme,
							 targetGroups, entranceConditions, furtherEducationPossibilities, descriptionOfStudy, purposesOfTheProgramme,
							 areaOfExpertise, extraPeculiarities, practicalTraining, finalExaminations, gainedAbilitiesAndSkills,
							 potentialFieldOfProfessionalActivity
                             from StudyProgrammes",
                            connection);

            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            List<StudyProgram> studyPrograms = ReadStudyPrograms(reader);

            reader.Close();

            connection.Close();

            return studyPrograms;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAOInterface;
using HtmlAgilityPack;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.Database;

namespace DALayer.Database
{
    class ScheduleDetails
    {
        public string ProfessorName { get; set; }
        public string Day { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public int Frequency { get; set; }
        public string ClassRoomName { get; set; }
        public MemberType MemberType { get; set; }
        public TeachingPosition TeachingPosition { get; set; }
        /// <summary>
        /// Gets or sets the year.
        /// This is currently not used
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public string Year { get; set; }
        public string Formation { get; set; }
        public CourseType CourseType { get; set; }
        public string Lecture { get; set; }
        public State State { get; set; }
    }

    public class Imports : IImports
    {
        public bool Schedule(List<byte[]> files, DateTime semesterStart, DateTime semesterEnd, IEnumerable<KeyValuePair<DateTime, DateTime>> vacations)
        {
            List<ScheduleDetails> schedules = new List<ScheduleDetails>();

            foreach (byte[] file in files)
            {
                try
                {
                    HtmlDocument document = new HtmlDocument();
                    document.Load(new MemoryStream(file));

                    HtmlNode centerNode = document.DocumentNode.ChildNodes["html"].ChildNodes["body"].ChildNodes["center"];

                    HtmlNode professorNode = centerNode.ChildNodes["h1"];

                    HtmlNode tableNode = centerNode.ChildNodes.FirstOrDefault(m => m.Name == "table");
                    if (tableNode != null)
                    {
                        IEnumerable<HtmlNode> tableRows = tableNode.ChildNodes.Where(f => f.Name == "tr");
                        for (int i = 1; i < tableRows.Count(); i++)
                        {
                            ScheduleDetails schedule = new ScheduleDetails();
                            schedule.ProfessorName = extractProfessorName(professorNode.InnerText);

                            extractType(professorNode.InnerText, schedule);

                            IEnumerable<HtmlNode> tableCells = tableRows.ElementAt(i).ChildNodes.Where(n => n.Name == "td");

                            schedule.Day = WebUtility.HtmlDecode(tableCells.ElementAt(0).InnerText).Trim();
                            string hours = WebUtility.HtmlDecode(tableCells.ElementAt(1).InnerText).Trim();

                            if (hours.Split('-').Length != 2)
                                continue;
                            int hour;
                            if (!int.TryParse(hours.Split('-')[0].Trim(), out hour))
                            {
                                continue;
                            }
                            schedule.StartHour = hour;

                            if (!int.TryParse(hours.Split('-')[1].Trim(), out hour))
                            {
                                continue;
                            }
                            schedule.EndHour = hour;

                            string frequency = WebUtility.HtmlDecode(tableCells.ElementAt(2).InnerText);
                            frequency = frequency.Replace("sapt.", "").Trim();
                            int freq;
                            if (!int.TryParse(frequency, out freq))
                            {
                                freq = 0;
                            }

                            schedule.Frequency = freq;

                            string room = WebUtility.HtmlDecode(tableCells.ElementAt(3).InnerText).Trim();
                            schedule.ClassRoomName = room;

                            HtmlNode reference = tableCells.ElementAt(4).ChildNodes.FirstOrDefault(m => m.Name == "a");
                            /*
                            string year1 = string.Empty;
                            string year2 = string.Empty;


                            string year = WebUtility.HtmlDecode(tableCells.ElementAt(4).InnerText).Trim();


                            if (reference != null)
                            {
                                string innerText = reference.Attributes["href"].Value;
                                int lastBackslash = innerText.LastIndexOf('/');
                                int lastDot = innerText.LastIndexOf('.');
                                if (lastBackslash < lastDot)
                                {
                                    year = innerText.Substring(lastBackslash + 1, lastDot - lastBackslash - 1);
                                }
                                year1 = year;
                            }
                            */
                            string formation = WebUtility.HtmlDecode(tableCells.ElementAt(5).InnerText).Trim();
                            schedule.Formation = formation;
                            string type = WebUtility.HtmlDecode(tableCells.ElementAt(6).InnerText).Trim();
                            schedule.CourseType = GetCourseType(type);
                            string lecture = WebUtility.HtmlDecode(tableCells.ElementAt(7).InnerText);
                            schedule.Lecture = lecture;

                            schedules.Add(schedule);
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            try
            {
                AddDidacticActivities(schedules, semesterStart, semesterEnd, vacations);
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        private void extractType(string p, ScheduleDetails schedule)
        {
            List<string> wordsToEliminate = new List<string>()
            {
                "Drd.",//doct
                "Prof.",//teacher
                "Lect.",//teacher
                "Conf.",//teacher
                "Asist."//teacher
            };

            if (p.Contains(wordsToEliminate[0]))
            {
                schedule.MemberType = MemberType.PhD_Student;
            }
            else
            {
                schedule.MemberType = MemberType.Teacher;
                if (p.Contains(wordsToEliminate[1]))
                {
                    schedule.TeachingPosition = TeachingPosition.Professor;
                }
                if (p.Contains(wordsToEliminate[2]))
                {
                    schedule.TeachingPosition = TeachingPosition.Lecturer;
                }
                if (p.Contains(wordsToEliminate[3]))
                {
                    schedule.TeachingPosition = TeachingPosition.Conferentiar;
                }
                if (p.Contains(wordsToEliminate[4]))
                {
                    schedule.TeachingPosition = TeachingPosition.Assistant;
                }
            }
        }

        private void AddDidacticActivities(List<ScheduleDetails> schedules, DateTime semesterStart, DateTime semesterEnd, IEnumerable<KeyValuePair<DateTime, DateTime>> vacations)
        {
            AllDidacticActivities allDidacticActivities = new AllDidacticActivities();

            List<DidacticActivity> didacticActivitiesToAdd = new List<DidacticActivity>();

            string errorMessage = string.Empty;

            foreach (ScheduleDetails schedule in schedules)
            {
                int week = 1;
                for (DateTime date = semesterStart; date < semesterEnd; date = NextWeek(date), week++)
                {
                    if (schedule.Frequency != 0 && ( week % 2 ) != schedule.Frequency)
                    {
                        continue;
                    }

                    DateTime? activityDate = date;
                    activityDate = GetCorrectDate(date, schedule.Day);

                    if (activityDate == null)
                    {
                        continue;
                    }

                    DateTime startDate = new DateTime(activityDate.Value.Year, activityDate.Value.Month, activityDate.Value.Day,
                                                      schedule.StartHour, 0, 0);

                    DateTime endDate = new DateTime(activityDate.Value.Year, activityDate.Value.Month, activityDate.Value.Day,
                                                    schedule.EndHour, 0, 0);

                    Member member = null;

                    if (schedule.MemberType == MemberType.PhD_Student)
                    {
                        member = new PhDStudent(schedule.ProfessorName, string.Format("{0}@cs.ubbcluj.ro", schedule.ProfessorName.Replace(" ", "")), "123456");
                    }
                    else
                    {
                        member = new Teacher(schedule.TeachingPosition, schedule.ProfessorName, string.Format("{0}@cs.ubbcluj.ro", schedule.ProfessorName.Replace(" ", "")), "123456", "Mate-Info");
                    }

                    DidacticActivity didacticActivity = new DidacticActivity(schedule.CourseType, schedule.Lecture, string.Empty, schedule.Formation, startDate, endDate, member);
                    didacticActivity.ClassRooms = new List<ClassRoom>()
                    {
                        new ClassRoom(schedule.ClassRoomName)
                    };

                    didacticActivitiesToAdd.Add(didacticActivity);
                }
            }

            try
            {
                AllDidacticActivities didacticActivitiesDB = new AllDidacticActivities();
                AllMembers allMembers = new AllMembers();
                List<Member> members = allMembers.AsEnumerable.ToList();

                foreach (DidacticActivity didacticActivity in didacticActivitiesToAdd)
                {
                    try
                    {
                        if (members.Count(m => m.EMail == didacticActivity.ToList()[0].EMail) == 0)
                        {
                            if (didacticActivity.ToList()[0].Type == MemberType.Teacher)
                            {
                                allMembers.Add(didacticActivity.ToList()[0] as Teacher);
                            }
                            else
                            {
                                allMembers.Add(didacticActivity.ToList()[0] as PhDStudent);
                            }
                        }

                        didacticActivitiesDB.Add(didacticActivity);
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                    }
                }
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new Exception(errorMessage);
            }
        }

        private DateTime NextWeek(DateTime date)
        {
            date = date.AddDays(1);
            while (DayOfWeek[date.DayOfWeek.ToString().ToLower()] != 0)
            {
                date = date.AddDays(1);
            }

            return date;
        }

        private Dictionary<string, int> dayOfWeek = null;

        private Dictionary<string, int> DayOfWeek
        {
            get
            {
                if (dayOfWeek == null)
                {
                    dayOfWeek = new Dictionary<string, int>()
                    {
                        { "luni", 0 },
                        { "marti", 1 },
                        { "miercuri", 2},
                        { "joi", 3 },
                        { "vineri", 4 },
                        { "sambata", 5 },
                        { "duminica", 6 },
                        { "monday", 0 },
                        { "tuesday", 1 },
                        { "wednesday", 2 },
                        {  "thursday", 3 },
                        { "friday", 4 },
                        { "saturday", 5 },
                        { "sunday", 6 }
                    };
                }
                return dayOfWeek;
            }
        }

        private DateTime? GetCorrectDate(DateTime date, string day)
        {
            string weekDay = day.ToLower().Trim();

            if (DayOfWeek[date.DayOfWeek.ToString().ToLower()] > DayOfWeek[weekDay])
            {
                return null;
            }
            else
            {
                int difference = DayOfWeek[weekDay] - DayOfWeek[date.DayOfWeek.ToString().ToLower()];
                DateTime correct = new DateTime(date.Year, date.Month, date.Day);
                correct.AddDays(difference);

                return correct;
            }
        }

        private CourseType GetCourseType(string type)
        {
            Dictionary<string, int> transformDictionary = new Dictionary<string, int>()
            {
                { "Laborator", (int)CourseType.Laboratory },
                { "Seminar", (int)CourseType.Seminar },
                { "Curs", (int)CourseType.Course }
            };

            return (CourseType)transformDictionary[type];
        }

        private string extractProfessorName(string p)
        {
            List<string> wordsToEliminate = new List<string>()
            {
                "Orar",
                "Drd.",
                "Prof.",
                "Lect.",
                "Conf.",
                "Asist."
            };

            string newP = p;
            foreach (string word in wordsToEliminate)
            {
                newP = newP.Replace(word, string.Empty).Trim();
            }

            return newP;
        }
    }
}

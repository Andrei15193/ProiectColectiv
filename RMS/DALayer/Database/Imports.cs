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

                            IEnumerable<HtmlNode> tableCells = tableRows.ElementAt(i).ChildNodes.Where(n => n.Name == "td");

                            schedule.Day = WebUtility.HtmlDecode(tableCells.ElementAt(0).InnerText).Trim();
                            string hours = WebUtility.HtmlDecode(tableCells.ElementAt(1).InnerText).Trim();

                            if(hours.Split('-').Length != 2)
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
                                continue;
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

            return true;
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

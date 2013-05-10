using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Course
    {
        public string name
        {
            get { return name; }
            set { name = value; }
        }

        public string description
        {
            get { return description; }
            set { description = value; }
        }

        public uint credits
        {
            get { return credits; }
            set { credits = value; }
        }

        public Language language
        {
            get { return language; }
            set { language = value; }
        }

        public ApplicationDomain domain
        {
            get { return domain; }
            set { domain = value; }
        }

        public DidacticTaskSet didacticTasks
        {
            get { return didacticTasks; }
            set { didacticTasks = value; }
        }

        public StudyProgramSet studyPrograms
        {
            get { return studyPrograms; }
            set { studyPrograms = value; }
        }

        public Formation formation
        {
            get { return formation; }
            set { formation = value; }
        }

        public Course()
        {
            this.name = "";
            this.description = "";
            this.credits = 0;
            this.language = Language.Romanian;
            this.domain = ApplicationDomain.ComputerScience;
            this.didacticTasks = new DidacticTaskSet();
            this.studyPrograms = new StudyProgramSet();
            this.formation = new Formation();
        }

        public Course(string name, string description, uint credits, Language language)
        {
            this.name = name;
            this.description = description;
            this.credits = credits;
            this.language = language;
            this.domain = ApplicationDomain.ComputerScience;
            this.didacticTasks = new DidacticTaskSet();
            this.studyPrograms = new StudyProgramSet();
            this.formation = new Formation();
        }

        public Course(string name, string description, uint credits, Language language, ApplicationDomain domain,
            DidacticTaskSet didacticTasks, StudyProgramSet studyPrograms, Formation formation)
        {
            this.name = name;
            this.description = description;
            this.credits = credits;
            this.language = language;
            this.domain = domain;
            this.didacticTasks = didacticTasks;
            this.studyPrograms = studyPrograms;
            this.formation = formation;
        }
    }
}

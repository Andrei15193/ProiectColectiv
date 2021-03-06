﻿using DAOInterface;
using ResourceManagementSystem.BusinessLogic.Workflow;
using ResourceManagementSystem.DAOInterface;
using ResourceManagementSystem.DataAccess.Database;
using ResourceManagementSystem.DataAccess.Mocks;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public static class ViewModelFactory
    {
        public static HumanResourcesViewModel HumanResourcesViewModel
        {
            get
            {
                return new HumanResourcesViewModel(Repositories.AllMembers);
            }
        }

        public static TeamViewModel TeamViewModel
        {
            get
            {
                return new TeamViewModel(Repositories.AllMembers);
            }
        }
        public static ActivitiesViewModel ActivitiesViewModel
        {
            get
            {
                return new ActivitiesViewModel(Repositories.AllActivities);
            }
        }
        public static SelectClassRoomViewModel SelectClassRoomViewModel
        {
            get
            {
                return new SelectClassRoomViewModel(Repositories.AllClassRooms);
            }
        }
        public static SelectEquipmentsViewModel SelectEquipmentsViewModel
        {
            get
            {
                return new SelectEquipmentsViewModel(Repositories.AllEquipments);
            }
        }
        
        public static MemberViewModel MemberViewModel
        {
            get
            {
                return new MemberViewModel(Repositories.AllMembers);

            }
        }

        public static FinancialResourcesViewModel FinancialResourcesViewModel
        {
            get
            {
                return new FinancialResourcesViewModel(Repositories.AllFinancialResources);
            }
        }
        public static EquipmentsViewModel EquipmentsViewModel
        {
            get
            {
                return new EquipmentsViewModel(Repositories.AllEquipments);
            }
        }

        public static ClassRoomViewModel ClassRoomViewModel
        {
            get
            {
                return new ClassRoomViewModel(Repositories.AllClassRooms);
            }
        }

        public static StudyProgramsViewModel StudyProgramsViewModel
        {
            get
            {
                return new StudyProgramsViewModel(Repositories.StudyPrograms);
            }
        }

        public static TasksViewModel TasksViewModel
        {
            get
            {
                return new TasksViewModel();
            }

        }

        public static ResearchProjectViewModel ResearchProjectViewModel
        {
            get
            {
                return new ResearchProjectViewModel(Repositories.AllMembers, Repositories.AllResearchProjects, Repositories.AllEquipments, Repositories.AllClassRooms);
            }
        }
        public static StudentCirclesViewModel StudentCirclesViewModel
        {
            get
            {
                return new StudentCirclesViewModel(Repositories.StudentCircles);
            }
        }

        public static ImportScheduleViewModel ImportScheduleViewModel
        {
            get
            {
                return new ImportScheduleViewModel(Repositories.ImportsDB);
            }
        }

        public static AdministrativeEventViewModel AdministrativeEventViewModel
        {
            get
            {
                return new AdministrativeEventViewModel(Repositories.AllMembers, Repositories.AllAdministrativeEvents);
            }
        }

        private static class Repositories
        {
            public static readonly IAllMembers AllMembers = new AllMembers();

            public static readonly IAllFinancialResources AllFinancialResources = new DALayer.Database.AllFinancialResources();

            public static readonly IAllEquipments AllEquipments = new DALayer.Database.AllEquipments();

            public static readonly IAllClassRooms AllClassRooms = new DALayer.Database.AllClassRooms();

            public static readonly IStudyPrograms StudyPrograms = new Studyprograms();

            public static readonly IAllStudentCircles StudentCircles = new DALayer.Database.AllStudentCircles();

            public static readonly IAllResearchProjects AllResearchProjects = new DALayer.Database.AllResearchProjects();

            public static readonly IAllActivities AllActivities = new DALayer.Database.AllActivities();

            public static readonly IAllAdministrativeActivities AllAdministrativeActivity;

            public static readonly IAllAdministrativeActivities AllAdministrativeEvents = null;

	        public static readonly IImports ImportsDB = new DALayer.Database.Imports();        
       }
    }
}

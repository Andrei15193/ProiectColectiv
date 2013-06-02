﻿using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class ResearchProjectViewModel
    {
        public ResearchProjectViewModel(IAllMembers allMembers, IAllResearchProjects allProjects, IAllEquipments allEquipments, IAllClassRooms allClassRooms)
        {
            CurrentPhase = null;
            this.allMembers = allMembers;
            this.allProjects = allProjects;
            this.allEquipments = allEquipments;
            this.allClassRooms = allClassRooms;
            ResearchProject = null;
            Title = string.Empty;
            Description = string.Empty;
            StartDate = DateTime.Now.ToString("dd/MM/yyyy");
            EndDate = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");
            LaborCost = 0;
            LogisticalCost = 0;
            MobilityCost = 0;
            LogisticalCostSelectedIndex = 0;
            LaborCostSelectedIndex = 0;
            MobilityCostSelectedIndex = 0;
            SelectedClassRooms = null;
            SelectedEquipments = null;
            IsConfidential = false;
        }

        public IEnumerable<ResearchProject> TryGetAll(out string errorMessage)
        {
            try
            {
                errorMessage = null;
                return allProjects.AsEnumerable;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return null;
            }
        }

        public bool TryGetAllHumanResources(out string errorMessage, out IEnumerable<Member> members)
        {
            try
            {
                errorMessage = string.Empty;
                members = localAllMembers = allMembers.AsEnumerable;
                return true;
            }
            catch (Exception exception)
            {
                members = null;
                errorMessage = exception.Message;
                return false;
            }
        }

        public bool TryGetAllEquipments(out string errorMessage, out IEnumerable<Equipment> equipments)
        {
            try
            {
                errorMessage = string.Empty;
                equipments = localAllEquipments = allEquipments.AsEnumerable;
                return true;
            }
            catch (Exception exception)
            {
                equipments = null;
                errorMessage = exception.Message;
                return false;
            }
        }

        public bool TryGetAllClassRooms(out string errorMessage, out IEnumerable<ClassRoom> classRooms)
        {
            try
            {
                errorMessage = string.Empty;
                classRooms = localAllClassRooms = allClassRooms.AsEnumerable;
                return true;
            }
            catch (Exception exception)
            {
                classRooms = null;
                errorMessage = exception.Message;
                return false;
            }
        }

        public bool TrySaveResearchProject(out string errorMessage,bool aproved)
        {
            try
            {
                if (aproved == true)
                {
                    ResearchProject.State = State.Aproved;
                    foreach(ResearchPhase phase in ResearchProject.AsEnumerable())
                    {
                        phase.State = State.Aproved;
                        foreach (ResearchActivity activ in phase.AsEnumerable())
                        {
                            activ.State = State.Aproved;
                        }
                    }

                }
                else
                {
                    ResearchProject.State = State.Proposed;
                    foreach (ResearchPhase phase in ResearchProject.AsEnumerable())
                    {
                        phase.State = State.Proposed;
                        foreach (ResearchActivity activ in phase.AsEnumerable())
                        {
                            activ.State = State.Proposed;
                        }
                    }
                }
                allProjects.Add(ResearchProject);
                errorMessage = null;
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return false;
            }
        }

        public bool TryCreateResearchProject(out string errorMessage)
        {
            try
            {
                ResearchProject = new ResearchProject(
                    Title,
                    Description,
                    DateTime.ParseExact(
                        StartDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ),
                    DateTime.ParseExact(
                        EndDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddDays(1).AddMilliseconds(-1),
                    new Team(
                        localAllMembers.Where(
                            (localMember) => SelectedTeamEmails.Contains(localMember.EMail)
                        )
                    )
                );
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return false;
            }
        }

        public bool TryCreatePhase(out string errorMessage)
        {
            try
            {
                CurrentPhase = ResearchProject.Add(
                    Title,
                    Description,
                    DateTime.ParseExact(
                        StartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddMilliseconds(ResearchProject.Count),
                    DateTime.ParseExact(EndDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddDays(1).AddMilliseconds(-1)
                );
                errorMessage = null;
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return false;
            }
        }

        public bool TryCreateActivity(out string errorMessage)
        {
            try
            {
                ResearchActivity researchActivity = CurrentPhase.Add(
                    Title,
                    Description,
                    DateTime.ParseExact(
                        StartDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddMilliseconds(ResearchProject.Count + CurrentPhase.Count),
                    DateTime.ParseExact(
                        EndDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddMilliseconds(ResearchProject.Count + CurrentPhase.Count + 1),
                    ResearchProject.Team.Where((teamMember) => SelectedTeamEmails.Contains(teamMember.EMail)),
                    new FinancialResource(MobilityCost, (Currency)MobilityCostSelectedIndex),
                    new FinancialResource(LaborCost, (Currency)LaborCostSelectedIndex),
                    new FinancialResource(LogisticalCost, (Currency)LogisticalCostSelectedIndex),
                    IsConfidential
                );
                foreach (ClassRoom classRoom in localAllClassRooms.Where((room) => SelectedClassRooms.Contains(room.Name)))
                    researchActivity.ClassRooms.Add(classRoom);
                foreach (Equipment equipment in localAllEquipments.Where((equip) => SelectedEquipments.Contains(equip.SerialNumber)))
                    researchActivity.Equipments.Add(equipment);
                errorMessage = null;
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return false;
            }
        }

        public ResearchProject ResearchProject { get; private set; }

        public ResearchPhase CurrentPhase { get; private set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public IEnumerable<string> SelectedTeamEmails { get; set; }

        public IEnumerable<string> SelectedClassRooms { get; set; }

        public IEnumerable<string> SelectedEquipments { get; set; }

        public string[] Currency
        {
            get
            {
                return currency;
            }
        }

        public int MobilityCost { get; set; }

        public int LogisticalCost { get; set; }

        public int LaborCost { get; set; }

        public int MobilityCostSelectedIndex { get; set; }

        public int LaborCostSelectedIndex { get; set; }

        public int LogisticalCostSelectedIndex { get; set; }

        public bool IsConfidential { get; set; }

        public bool HasPhases
        {
            get
            {
                return (ResearchProject != null && ResearchProject.Count > 0);
            }
        }

        public IEnumerable<ResearchPhase> ResearchPhases
        {
            get
            {
                return ResearchProject;
            }
        }

        private IAllMembers allMembers;
        private IEnumerable<Member> localAllMembers;
        private IEnumerable<Equipment> localAllEquipments;
        private IEnumerable<ClassRoom> localAllClassRooms;
        private IAllResearchProjects allProjects;
        private IAllEquipments allEquipments;
        private IAllClassRooms allClassRooms;
        private readonly string[] currency = Enum.GetNames(typeof(Currency)).Select((currency) => currency.Replace('_', ' ')).ToArray();
    }
}

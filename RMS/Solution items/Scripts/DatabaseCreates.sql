create table Members(
    type int not null,
    name nvarchar(100) not null,
    email nvarchar(100) not null,
    password nvarchar(100) not null,
    teachingPosition int null,
    hasPhd bit null,
    telephone nvarchar(20) null,
    website nvarchar(200) null,
    address nvarchar(max) null,
    domainsOfInterest nvarchar(max) null,
    constraint pkMembers primary key (email)
)

create table FinancialResources(
    operationId int identity(1, 1) not null,
    value int not null,
    currency int not null,
    status int not null,
    constraint pkFinancialResources primary key (operationId)
)

create table Equipments(
    brand nvarchar(100) not null,
    model nvarchar(100) not null,
    serialNumber nvarchar(100) not null,
    description nvarchar(100) not null,
    constraint pkEquipments primary key (serialNumber)
)

create table ClassRooms(
    name nvarchar(100) not null,
    description nvarchar(100) not null,
    constraint pkClassRooms primary key (name)
)

create table ClassRoomEquipment(
    classRoom nvarchar(100) not null,
    equipment nvarchar(100) not null,
    constraint pkClassRoomEquipment primary key (classRoom, equipment),
    constraint fkClassRoomEquipmentToClassRoom foreign key (classRoom) references ClassRooms(name),
    constraint fkClassRoomEquipmentToEquipment foreign key (equipment) references Equipments(serialNumber)
)

create table StudyProgrammes(
    id int identity(1, 1) not null,
    educationalProgramme nvarchar(100) not null,
    degreeOfStudy int not null,
    domain nvarchar(100) not null,
    yearLength int not null,
    ectsCredits int not null,
    typeOfStudy int not null,
    higherEducationInstitution nvarchar(max) not null,
    faculty nvarchar(max) not null,
    contactPerson nvarchar(max) not null,
    phone nvarchar(max) not null,
    fax nvarchar(max) not null,
    eMail nvarchar(max) not null,
    profileOfTheDegreeProgramme nvarchar(max) not null,
    targetGroups nvarchar(max) not null,
    entranceConditions nvarchar(max) not null,
    furtherEducationPossibilities nvarchar(max) not null,
    descriptionOfStudy nvarchar(max) not null,
    purposesOfTheProgramme nvarchar(max) not null,
    areaOfExpertise nvarchar(max) not null,
    extraPeculiarities nvarchar(max) not null,
    practicalTraining nvarchar(max) not null,
    finalExaminations nvarchar(max) not null,
    gainedAbilitiesAndSkills nvarchar(max) not null,
    potentialFieldOfProfessionalActivity nvarchar(max) not null,
    constraint pkStudyProgrammes primary key(id),
    constraint unique1 unique (educationalProgramme, degreeOfStudy, domain, typeOfStudy,  yearLength, ectsCredits)
)

create table Teams(
    name nvarchar(100) null,
    id int identity(1, 1) not null,
    constraint pkTeams primary key (id)
)

create table TeamMembers(
    team int not null,
    member nvarchar(100) not null,
    constraint pkTeamMebers primary key (team, member),
    constraint fkTeamToTeamId foreign key (team) references Teams(id),
    constraint fkMemberToMembersEmail foreign key (member) references Members(email)
)

create table Activities(
    id int identity(1, 1) not null,
    type int not null,
    title nvarchar(100) not null,
    description nvarchar(max) not null,
    startDate datetime not null,
    endDate datetime not null,
    state int not null,
    constraint pkActivities primary key (id),
    constraint checkActivitiesDateIntegrity check (datediff(day, startDate, endDate) > 0)
)

create table ActivityClassRooms(
    activity int not null,
    classRoom nvarchar(100) not null,
    constraint pkActivityClassRooms primary key (activity),
    constraint fkActivityClassRoomsToActivity foreign key (activity) references Activities(id),
    constraint fkActivityClassRoomsToClassRoom foreign key (classRoom) references ClassRooms(name)
)

create table ActivityEquipments(
    activity int not null,
    equipment nvarchar(100),
    constraint pkActivityEquipments primary key (activity, equipment),
    constraint fkActivityEquipmentsToActivity foreign key (activity) references Activities(id),
    constraint fkActivityEquipmentsToEquipment foreign key (equipment) references Equipments(serialNumber)
)

create table ResearchProjects(
    activity int not null,
    team int not null,
    constraint pkResearchProjects primary key (activity),
    constraint fkResearchProjectToActivityTypeAndTitle foreign key (activity) references Activities(id),
    constraint fkResearchProjectToTeamId foreign key (team) references Teams(id)
)

create table ResearchProjectPhases(
    activity int not null,
    researchProject int not null,
    constraint pkResearchProjectPhases primary key (activity, researchProject),
    constraint fkResearchProjectPhasesToActivity foreign key (activity) references Activities(id),
    constraint fkResearchProjectPhasesToResearchProject foreign key (researchProject) references ResearchProjects(activity)
)

create table ResearchActivities(
    activity int not null,
    phase int not null,
    researchProject int not null,
    laborCosts int not null,
    logisticalCosts int not null,
    mobilityCosts int not null,
    isConfidential bit not null,
    constraint pkResearchProjectActivities primary key (activity, phase, researchProject),
    constraint fkResearchProjectActivitiesToResearchProjectPhase foreign key (phase, researchProject) references ResearchProjectPhases(activity, researchProject),
    constraint fkResearchProjectActivitiesToActivity foreign key (activity) references Activities(id),
    constraint fkResearchActivityLaborCostsToFinancialResource foreign key (laborCosts) references FinancialResources(operationId),
    constraint fkResearchActivityLogisticalCostsToFinancialResource foreign key (logisticalCosts) references FinancialResources(operationId),
    constraint fkResearchActivityMobilityCostsToFinancialResource foreign key (mobilityCosts) references FinancialResources(operationId)
)

create table DidacticActivities(
    activity int not null,
    team int,
    constraint pkDidacticActivities primary key (activity, team),
    constraint fkDidacticActivityToActivity foreign key (activity) references Activities(id),
    constraint fkDidacticActivityToTeam foreign key (team) references Teams(id)
)

create table StudentCircles(
    activity int not null,
    studyProgram int not null,
    constraint pkStudentCircles primary key (activity, studyProgram),
    constraint fkStudentCircleToActivity foreign key (activity) references Activities(id),
    constraint fkStudentCircleToStudyProgram foreign key (studyProgram) references StudyProgrammes(id)
)

create table AdministrativeActivities(
    activity int not null,
    team int not null,
    constraint pkAdministrativeActivities primary key (activity, team),
    constraint fkAdministrativeActivityToActivity foreign key (activity) references Activities(id),
    constraint fkAdministrativeActivityToTeams foreign key (team) references Teams(id)
)

create table Tasks(
    activity int not null,
    id int identity(1, 1) not null,
    team int not null,
    type int not null,
    title nvarchar(100) not null,
    description nvarchar(max) not null,
    startDate datetime not null,
    endDate datetime not null,
    state int not null,
    laborCosts int not null,
    logisticalCosts int not null,
    mobilityCosts int not null,
    constraint pkTasks primary key (id),
    constraint fkTasksToActivity foreign key (activity) references Activities(id),
    constraint checkTasksDateIntegrity check (datediff(day, startDate, endDate) > 0),
    constraint fkTaskLaborCostsToFinancialResource foreign key (laborCosts) references FinancialResources(operationId),
    constraint fkTaskLogisticalCostsToFinancialResource foreign key (logisticalCosts) references FinancialResources(operationId),
    constraint fkTaskMobilityCostsToFinancialResource foreign key (mobilityCosts) references FinancialResources(operationId)
)

create table TaskClassRooms(
    activity int not null,
    classRoom nvarchar(100) not null,
    constraint pkTaskClassRooms primary key (activity),
    constraint fkTaskClassRoomsToTask foreign key (activity) references Activities(id),
    constraint fkTaskClassRoomsToClassRoom foreign key (classRoom) references ClassRooms(name)
)

create table TaskEquipments(
    task int not null,
    equipment nvarchar(100),
    constraint pkTaskEquipments primary key (task, equipment),
    constraint fkTaskEquipmentsToTask foreign key (task) references Tasks(id),
    constraint fkTaskEquipmentsToEquipment foreign key (equipment) references Equipments(serialNumber)
)

-- Triggers

-- Trigger for activity overlap
-- Trigger for financial resource (can't exceed bounds)
-- Trigger for logistical resource [can't be used by two activities at the same time (check for time interval intersection)] {both class room and equipment!}

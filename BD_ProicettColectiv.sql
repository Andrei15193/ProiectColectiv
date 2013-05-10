if not exists (select * from sys.objects where name = 'Users' and type = 'U')
	create table dbo.Users  (username varchar(30) not null,
							 firstname varchar(20) null, 
							 lastname varchar(20) null, 
							 passwd varchar(30) null,
							 email varchar(30) not null,
							 constraint PK_Users primary key(email) with (fillfactor = 90))
go

if not exists (select * from sys.objects where name = 'Roles' and type = 'U')
	create table dbo.Roles (name varchar(30) not null,
							roleDescription nvarchar(max) null,
							constraint PK_Roles primary key(name) with (fillfactor = 90))
go

if not exists (select * from sys.objects where name = 'Features' and type = 'U')
	create table dbo.Features	(name varchar(60) not null, 
								 featureDescription nvarchar(max) null,
								 constraint PK_Features primary key(name) with (fillfactor = 90))
go

if not exists (select * from sys.objects where name = 'RoleFeatures' and type = 'U')
	create table dbo.RoleFeatures  (featureName varchar(60) not null,
									roleName varchar(30) not null,
									constraint PK_RoleFeatures primary key(featureName, roleName),
									constraint FK_RoleFeatures_Roles foreign key (roleName) references dbo.Roles(name),
									constraint FK_RoleFeatures_Features foreign key (featureName) references dbo.Features(name))
go

if not exists (select * from sys.objects where name = 'UsersRoles' and type = 'U')
	create table dbo.UsersRoles  (email varchar(30) not null,
								 roleName varchar(30) not null, 
								 constraint PK_UsersRoles primary key(email, roleName),
								 constraint FK_UsersRoles_Users foreign key (email) references dbo.Users (email),
								 constraint FK_UsersRoles_Roles foreign key (roleName) references dbo.Roles (name))
go

if not exists (select * from sys.objects where name = 'FinancialResource')		
	create table dbo.FinancialResource (id int not null,
										value int not null,
										currency int not null,
										transactionType int not null,
										constraint PK_FinancialResource primary key(id) with (fillfactor = 90),
										constraint CK_FinancialResource_currency check(currency = 1),
										constraint CK_FinancialResource_transactionType check(transactionType = -1 or transactionType = 1))
go

if not exists (select * from sys.objects where name = 'ClassRooms' and type = 'U')
	create table dbo.ClassRooms(id int identity(1,1),
								classRoomDescription nvarchar(max) null,
								buildingName varchar(25) not null,
								classFloor int not null,
								number int not null,
								constraint PK_ClassRooms primary key (id),
								constraint XA_1 unique(buildingName, classFloor, number))

if not exists (select * from sys.objects where name = 'Equipments' and type = 'U')
	create table dbo.Equipments	   (equipmentDescription nvarchar(max) null,
									brand varchar(50) null,
									modelName varchar(50)null,
									serialNumber varchar(30) not null,
									isBroken bit not null default(0),
									classRoomId int,
									constraint PK_Equipments primary key(serialNumber) with(fillfactor = 90),
									constraint FK_Equipments_ClassRooms foreign key(classRoomId) references dbo.ClassRooms(id))
go

if not exists (select * from sys.objects where name = 'ResearchProjects' and type = 'U')
	create table dbo.ResearchProjects (name varchar(60) not null,
									   summary varchar(255) null,
									   projectDescription nvarchar(max) null,
									   domain int not null, 
									   projectState int not null,
									   constraint PK_ResearchProjects primary key(name) with(fillfactor = 90),
									   constraint CK_ResearchProjects_Domain check(domain >=1 and domain <=2),
									   constraint CK_ResearchProjects_ProjectState check(projectState >=1 and projectState<=6))
go

if not exists (select * from sys.objects where name = 'UsersResearchProjects' and type = 'U')
	create table dbo.UsersResearchProjects (email varchar(30) not null,
											projectName varchar(60) not null,
											constraint PK_UsersResearchProjects primary key(email, projectName) with(fillfactor = 90),
											constraint FK_UsersResearchProjects_Users foreign key (email) references dbo.Users(email),
											constraint FK_UsersResearchProjects_ResearchProjects foreign key (projectName) references dbo.ResearchProjects(name))
go

if not exists (select * from sys.objects where name = 'Tasks' and type = 'U')
	create table dbo.Tasks (id int identity(1,1),
							startDate datetime not null,
							endDate datetime not null,
							taskState int not null,
							periodicity int not null,
							number int,
							duration int,
							summary varchar(255) null,
							taskDescription nvarchar(max) null,
							idActivity int null,
							idFinancialResource int null,
							constraint PK_Tasks primary key (id),
							constraint CK_Tasks_ValidateDuration check(convert(datetime, startDate, 105) <= convert(datetime, endDate, 105)),
							constraint CK_Tasks_TaskState check(taskState >= 1 and taskState <= 8),
							constraint CK_Tasks_Periodicity check(periodicity >= 1 and periodicity <= 4),
							constraint FK_Tasks_Activity foreign key (idActivity) references dbo.Tasks (id),
							constraint FK_Tasks_FinancialResource foreign key (idFinancialResource) references dbo.FinancialResource (id))
go

if not exists (select * from sys.objects where name = 'TasksResearchProjects' and type = 'U')
	create table dbo.TasksResearchProjects (projectName varchar(60) not null,
										   taskId int not null,
										   constraint PK_TasksResearchProjects primary key(projectName, taskid) with(fillfactor = 90),
										   constraint FK_TasksResearchProjects_ResearchProjects foreign key (projectName) references dbo.ResearchProjects (name),
										   constraint FK_TasksResearchProjects_Tasks foreign key (taskId) references dbo.Tasks(id))
go					   
										   
if not exists (select * from sys.objects where name = 'UsersTasks' and type = 'U')
	create table dbo.UsersTasks(email varchar(30) not null,
								taskId int not null,
								constraint PK_UsersTasks primary key (email, taskid) with(fillfactor = 90),
								constraint FK_UsersTasks_Users foreign key (email) references dbo.Users(email),
								constraint FK_UsersTasks_Tasks foreign key (taskId) references dbo.Tasks(id))
go

if not exists (select * from sys.objects where name = 'TasksEquipments' and type = 'U')
	create table dbo.TasksEquipments	(serialNumber varchar(30) not null,
										 taskId int not null,
										 constraint PK_TasksEquipments primary key (serialNumber, taskId) with(fillfactor = 90),
										 constraint FK_TasksEquipments_Equipments foreign key (serialNumber) references dbo.Equipments (serialNumber),
										 constraint FK_TasksEquipments_Tasks foreign key (taskId) references dbo.Tasks (id))
go

if not exists (select * from sys.objects where name = 'TasksClassRooms' and type = 'U')
	create table dbo.TasksClassRooms	(classRoomId int not null,
										 taskId int not null,
										 constraint PK_TasksClassRooms primary key (classRoomId, taskId) with(fillfactor = 90),
										 constraint FK_TasksClassRooms_ClassRooms foreign key (classRoomId) references dbo.ClassRooms (id),
										 constraint FK_TasksClassRooms_Tasks foreign key (taskId) references dbo.Tasks (id))
go

if not exists (select * from sys.objects where name = 'TaskReports' and type = 'U')
	create table dbo.TaskReports (reportDate datetime not null,
								  taskId int not null,
								  reportMessage nvarchar(max) null,
								  cost int,
								  constraint PK_TaskReports primary key (reportDate, taskId) with(fillfactor = 90),
								  constraint FK_TaskRaports_Tasks foreign key (taskId) references dbo.Tasks(id))
										 
if not exists (select * from sys.objects where name = 'StudyPrograms' and type = 'U')
	create table dbo.StudyPrograms (specialization int not null constraint PK_StudyPrograms primary key with (fillfactor = 90),
								    constraint CK_StudyPrograms_Specialization check(specialization >= 1 and specialization <= 4))
go


						
if not exists (select * from sys.objects where name = 'Courses' and type = 'U')
	create table dbo.Courses	(id int identity(1,1),
								 name varchar(60) not null,
								 credits int not null,
								 courseLanguage int not null,
								 domain int not null,
								 constraint PK_Courses primary key(id),
								 constraint XA_2 unique(name, credits, domain),
								 constraint CK_Courses_CourseLanguage check(courseLanguage >= 1 and courseLanguage <= 2),
								 constraint CK_Courses_Domain check(domain >= 1 and domain <= 2))
go

if not exists (select * from sys.objects where name = 'CoursesStudyPrograms' and type = 'U')
	create table dbo.CoursesStudyPrograms (id int not null,
										   specialization int not null,
										   constraint PK_CoursesStudyPrograms primary key(specialization, id) with(fillfactor = 90),
										   constraint FK_CoursesStudyPrograms_Courses foreign key (id) references dbo.Courses(id),
										   constraint FK_CoursesStudyPrograms_StudyPrograms foreign key (specialization) references dbo.StudyPrograms(specialization))
										   
go


			
if not exists (select * from sys.objects where name = 'Formations' and type = 'U')
	create table dbo.Formations (id int identity(1,1),
								 formationType int not null,
								 specialization int not null,
								 studyYear int not null,
								 studyGroup int not null,
								 isFirstSemigroup bit not null,
								 constraint PK_Formations primary key (id),
								 constraint CK_Formations_Specialization check(specialization >= 1 and specialization <= 4),
								 constraint CK_Formations_FormationType check(formationType >=1 and formationType <= 3),
								 constraint XA_3 unique(formationType, specialization, studyYear, studyGroup, isFirstSemigroup))				  								
go

if not exists (select * from sys.objects where name = 'DidacticTasks' and type = 'U')
	create table dbo.DidacticTasks (didacticTaskType int not null,
								   taskId int not null constraint PK_DidacticTasks primary key,
								   constraint FK_DidacticTasks_Tasks foreign key (taskId) references dbo.Tasks (id))
go

if not exists (select * from sys.objects where name = 'DidacticActivity' and type = 'U')
	create table dbo.DidacticActivity  (semester int not null,
										taskId int not null constraint PK_DidacticActivity primary key,
										constraint FK_DidacticActivity_Tasks foreign key (taskId) references dbo.Tasks (id))
go								   


if not exists (select * from sys.objects where name = 'DidacticActivityStudyPrograms' and type = 'U')
	create table dbo.DidacticActivityStudyPrograms (specialization int not null,
													taskId int not null,
													constraint PK_DidacticActivityStudyPrograms primary key(specialization, taskId) with(fillfactor = 90),
													constraint FK_DidacticActivityStudyPrograms_DidacticActivity foreign key (taskId) references dbo.DidacticActivity(taskId),
													constraint FK_DidacticActivityStudyPrograms_StudyPrograms foreign key (specialization) references dbo.StudyPrograms(specialization))
go

if not exists (select * from sys.objects where name = 'DidacticTasksCourses' and type = 'U')
	create table dbo.DidacticTasksCourses	(courseId int not null,
											taskId int not null,
									 constraint PK_DidacticTasksCourses primary key(courseId, taskId) with(fillfactor = 90),
									 constraint FK_DidacticTasksCourses_Tasks foreign key (taskId) references dbo.DidacticTasks(taskId),
									 constraint FK_DidacticTasksCourses_Courses foreign key (courseId) references dbo.Courses(id))
go


if not exists (select * from sys.objects where name = 'DidacticTasksFormations' and type = 'U')
	create table dbo.DidacticTasksFormations	(formationId int not null,
											 taskId int not null,
										     constraint PK_DidacticTasksFormations primary key(formationId, taskId) with(fillfactor = 90),
										     constraint FK_DidacticTasksFormations_Tasks foreign key (taskId) references dbo.DidacticTasks(taskId),
										     constraint FK_DidacticTasksFormations_Formations foreign key (formationId) references dbo.Formations(id))
go

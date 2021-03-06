USE [master]
GO
/****** Object:  Database [QLHS]    Script Date: 4/5/2020 11:02:11 PM ******/
CREATE DATABASE [QLHS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLHS', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLHS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLHS_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\QLHS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLHS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLHS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLHS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLHS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLHS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLHS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLHS] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLHS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLHS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLHS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLHS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLHS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLHS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLHS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLHS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLHS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLHS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLHS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLHS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLHS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLHS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLHS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLHS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLHS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLHS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLHS] SET  MULTI_USER 
GO
ALTER DATABASE [QLHS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLHS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLHS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLHS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLHS] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QLHS]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [varchar](15) NOT NULL,
	[CourseName] [varchar](30) NULL,
	[CourseType] [varchar](30) NULL,
 CONSTRAINT [PK_Mon] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseType]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseType](
	[CourseTypeID] [varchar](30) NOT NULL,
	[CourseTypeName] [varchar](30) NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[CourseTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Group]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Group](
	[GroupID] [varchar](15) NOT NULL,
	[DateCreateAt] [datetime] NULL,
 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Schedule ]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Schedule ](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[SlotID] [varchar](10) NULL,
	[GroupID] [varchar](15) NULL,
	[CourseID] [varchar](15) NULL,
	[UserNameBooker] [varchar](30) NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Schedule ] PRIMARY KEY CLUSTERED 
(
	[Index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Schedule_User]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Schedule_User](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](30) NULL,
	[IndexShedule] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Schedult_User] PRIMARY KEY CLUSTERED 
(
	[Index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[SemesterID] [varchar](10) NOT NULL,
	[SemesterName] [varchar](15) NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[SemesterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Slot]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Slot](
	[SlotID] [varchar](10) NOT NULL,
	[TimeStart] [time](7) NULL,
	[TimeEnd] [time](7) NULL,
 CONSTRAINT [PK_Slot] PRIMARY KEY CLUSTERED 
(
	[SlotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserName] [varchar](30) NOT NULL,
	[Name] [varchar](30) NULL,
	[Password] [varchar](30) NULL,
	[Gender] [bit] NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Role] [varchar](20) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User_Group]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User_Group](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](30) NULL,
	[GroupID] [varchar](15) NULL,
 CONSTRAINT [PK_User_Group] PRIMARY KEY CLUSTERED 
(
	[Index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserName_CourseID]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserName_CourseID](
	[Index] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](30) NULL,
	[CourseID] [varchar](15) NULL,
	[SemesterID] [varchar](10) NULL,
	[Participation] [float] NULL,
	[ProgressTest] [float] NULL,
	[Assignments] [float] NULL,
	[FinalExam] [float] NULL,
	[Total] [float] NULL,
 CONSTRAINT [PK_Diem] PRIMARY KEY CLUSTERED 
(
	[Index] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Course] ([CourseID], [CourseName], [CourseType]) VALUES (N'JPD131', N'Japanese Elementary 3(JPD131)', NULL)
INSERT [dbo].[Course] ([CourseID], [CourseName], [CourseType]) VALUES (N'PRN292', N'.NET and C#(PRN292)', NULL)
INSERT [dbo].[Course] ([CourseID], [CourseName], [CourseType]) VALUES (N'SWR302', N'Software Requirement(SWR302)', NULL)
INSERT [dbo].[Course] ([CourseID], [CourseName], [CourseType]) VALUES (N'SWT301', N'Software Testing(SWT301)', NULL)
INSERT [dbo].[Group] ([GroupID], [DateCreateAt]) VALUES (N'SE1321', CAST(N'2000-05-06 00:00:00.000' AS DateTime))
INSERT [dbo].[Group] ([GroupID], [DateCreateAt]) VALUES (N'SE1325', CAST(N'2020-04-02 00:00:22.187' AS DateTime))
INSERT [dbo].[Group] ([GroupID], [DateCreateAt]) VALUES (N'SE1328', CAST(N'2020-04-02 14:09:37.347' AS DateTime))
INSERT [dbo].[Group] ([GroupID], [DateCreateAt]) VALUES (N'SE1329', CAST(N'2020-04-02 14:11:47.197' AS DateTime))
INSERT [dbo].[Group] ([GroupID], [DateCreateAt]) VALUES (N'SE1356', CAST(N'2000-05-06 00:00:00.000' AS DateTime))
INSERT [dbo].[Group] ([GroupID], [DateCreateAt]) VALUES (N'SE1475', CAST(N'2000-05-06 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Schedule ] ON 

INSERT [dbo].[Schedule ] ([Index], [Date], [SlotID], [GroupID], [CourseID], [UserNameBooker], [DateCreated]) VALUES (1, CAST(N'2020-03-30' AS Date), N'Slot1', N'SE1321', N'SWR302', N'hung', CAST(N'2020-04-03 00:00:00.000' AS DateTime))
INSERT [dbo].[Schedule ] ([Index], [Date], [SlotID], [GroupID], [CourseID], [UserNameBooker], [DateCreated]) VALUES (5, CAST(N'2020-03-30' AS Date), N'Slot2', N'SE1321', N'SWT301', N'hung', CAST(N'2020-04-03 00:00:00.000' AS DateTime))
INSERT [dbo].[Schedule ] ([Index], [Date], [SlotID], [GroupID], [CourseID], [UserNameBooker], [DateCreated]) VALUES (8, CAST(N'2020-03-31' AS Date), N'Slot1', N'SE1321', N'JPD131', N'hung', CAST(N'2020-03-03 00:00:00.000' AS DateTime))
INSERT [dbo].[Schedule ] ([Index], [Date], [SlotID], [GroupID], [CourseID], [UserNameBooker], [DateCreated]) VALUES (9, CAST(N'2020-03-31' AS Date), N'Slot2', N'SE1321', N'JPD131', N'hung', CAST(N'2020-03-03 00:00:00.000' AS DateTime))
INSERT [dbo].[Schedule ] ([Index], [Date], [SlotID], [GroupID], [CourseID], [UserNameBooker], [DateCreated]) VALUES (10, CAST(N'2020-04-01' AS Date), N'Slot1', N'SE1321', N'SWR302', N'hung', CAST(N'2020-03-03 00:00:00.000' AS DateTime))
INSERT [dbo].[Schedule ] ([Index], [Date], [SlotID], [GroupID], [CourseID], [UserNameBooker], [DateCreated]) VALUES (11, CAST(N'2020-04-01' AS Date), N'Slot2', N'SE1321', N'SWT301', N'hung', CAST(N'2020-03-03 00:00:00.000' AS DateTime))
INSERT [dbo].[Schedule ] ([Index], [Date], [SlotID], [GroupID], [CourseID], [UserNameBooker], [DateCreated]) VALUES (12, CAST(N'2020-04-02' AS Date), N'Slot1', N'SE1321', N'JPD131', N'hung', CAST(N'2020-03-03 00:00:00.000' AS DateTime))
INSERT [dbo].[Schedule ] ([Index], [Date], [SlotID], [GroupID], [CourseID], [UserNameBooker], [DateCreated]) VALUES (13, CAST(N'2020-04-06' AS Date), N'Slot2', N'SE1321', N'SWT301', N'hung', CAST(N'2020-03-03 00:00:00.000' AS DateTime))
INSERT [dbo].[Schedule ] ([Index], [Date], [SlotID], [GroupID], [CourseID], [UserNameBooker], [DateCreated]) VALUES (14, CAST(N'2020-04-08' AS Date), N'Slot2', N'SE1321', N'SWT301', N'hung', CAST(N'2020-03-03 00:00:00.000' AS DateTime))
INSERT [dbo].[Schedule ] ([Index], [Date], [SlotID], [GroupID], [CourseID], [UserNameBooker], [DateCreated]) VALUES (15, CAST(N'2020-04-10' AS Date), N'Slot2', N'SE1321', N'SWT301', N'hung', CAST(N'2020-03-03 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Schedule ] OFF
SET IDENTITY_INSERT [dbo].[Schedule_User] ON 

INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (2, N'SenB', 1, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (4, N'HoangNT', 5, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (5, N'TueNDM', 8, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (6, N'TueNDM', 9, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (7, N'SenB', 10, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (8, N'HoangNT', 11, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (9, N'TueNDM', 12, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (10, N'hung', 5, 1)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (13, N'HoangNT', 13, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (14, N'HoangNT', 14, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (15, N'HoangNT', 15, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (27, N'hung1', 8, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (28, N'hung1', 9, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (29, N'hung1', 10, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (30, N'hung1', 11, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (31, N'hung1', 13, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (32, N'hung1', 14, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (33, N'hung1', 15, NULL)
INSERT [dbo].[Schedule_User] ([Index], [UserName], [IndexShedule], [Status]) VALUES (34, N'hung1', 1, NULL)
SET IDENTITY_INSERT [dbo].[Schedule_User] OFF
INSERT [dbo].[Slot] ([SlotID], [TimeStart], [TimeEnd]) VALUES (N'Slot1', CAST(N'07:00:00' AS Time), CAST(N'08:30:00' AS Time))
INSERT [dbo].[Slot] ([SlotID], [TimeStart], [TimeEnd]) VALUES (N'Slot2', CAST(N'08:45:00' AS Time), CAST(N'10:15:00' AS Time))
INSERT [dbo].[Slot] ([SlotID], [TimeStart], [TimeEnd]) VALUES (N'Slot3', CAST(N'10:30:00' AS Time), CAST(N'12:00:00' AS Time))
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'HoangNT', N'Nguyen The Hoang', N'132', 1, N'a3s5d4f', N'56as4df', CAST(N'2007-05-06' AS Date), N'TEACHER')
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'hung', N'hung', N'123', 1, N'123', N'hung', CAST(N'2000-05-06' AS Date), N'ADMIN')
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'hung1', N'hung', N'123456789', 1, N'03214649874', N'asdf', CAST(N'2007-05-07' AS Date), N'STUDENT')
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'hung2', N'hung 2', N'132', 1, N'56sad', N'56asd', CAST(N'2007-05-06' AS Date), N'STUDENT')
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'hung3', N'hung 3', N'123', 1, N'a324sdf', N'56a4df', CAST(N'2007-05-06' AS Date), N'STUDENT')
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'hung4', N'hung 4', N'123', 1, N'a5sd4t', N'56asd4fg', CAST(N'2007-05-06' AS Date), N'STUDENT')
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'hung5', N'hung5', NULL, 1, N'415165', N'4898', CAST(N'2007-05-06' AS Date), N'STUDENT')
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'hung6', N'hung', NULL, 1, N'123e', N'5847e', CAST(N'2007-05-06' AS Date), N'STUDENT')
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'hunghae', N'asdf', N'123', 0, N'4575', N'a65sd4f', CAST(N'2000-05-06' AS Date), N'STUDENT')
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'HungNT', N'hung', N'123', 1, N'457aasdf5', N'a65sasadd4f', CAST(N'2007-05-06' AS Date), N'TEACHER')
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'SenB', N'Sen B', N'123', 1, N'465as4df', N'as564df', CAST(N'2007-05-06' AS Date), N'TEACHER')
INSERT [dbo].[User] ([UserName], [Name], [Password], [Gender], [PhoneNumber], [Email], [DateOfBirth], [Role]) VALUES (N'TueNDM', N'Tue Map', N'123', 1, N'02134655464', N'hunkljkj@gmail.com', CAST(N'2007-05-06' AS Date), N'TEACHER')
SET IDENTITY_INSERT [dbo].[User_Group] ON 

INSERT [dbo].[User_Group] ([Index], [UserName], [GroupID]) VALUES (5, N'hung', N'SE1321')
INSERT [dbo].[User_Group] ([Index], [UserName], [GroupID]) VALUES (8, N'hung', N'SE1325')
SET IDENTITY_INSERT [dbo].[User_Group] OFF
SET IDENTITY_INSERT [dbo].[UserName_CourseID] ON 

INSERT [dbo].[UserName_CourseID] ([Index], [UserName], [CourseID], [SemesterID], [Participation], [ProgressTest], [Assignments], [FinalExam], [Total]) VALUES (1, N'hung', N'SWT301', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserName_CourseID] ([Index], [UserName], [CourseID], [SemesterID], [Participation], [ProgressTest], [Assignments], [FinalExam], [Total]) VALUES (2, N'hung1', N'SWT301', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserName_CourseID] ([Index], [UserName], [CourseID], [SemesterID], [Participation], [ProgressTest], [Assignments], [FinalExam], [Total]) VALUES (3, N'hung58', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserName_CourseID] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_Email]    Script Date: 4/5/2020 11:02:11 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UK_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_PhoneNumber]    Script Date: 4/5/2020 11:02:11 PM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UK_PhoneNumber] UNIQUE NONCLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_CourseType] FOREIGN KEY([CourseType])
REFERENCES [dbo].[CourseType] ([CourseTypeID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_CourseType]
GO
ALTER TABLE [dbo].[Schedule ]  WITH CHECK ADD  CONSTRAINT [FK_Schedule _Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Schedule ] CHECK CONSTRAINT [FK_Schedule _Course]
GO
ALTER TABLE [dbo].[Schedule ]  WITH CHECK ADD  CONSTRAINT [FK_Schedule _Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[Schedule ] CHECK CONSTRAINT [FK_Schedule _Group]
GO
ALTER TABLE [dbo].[Schedule ]  WITH CHECK ADD  CONSTRAINT [FK_Schedule _Slot] FOREIGN KEY([SlotID])
REFERENCES [dbo].[Slot] ([SlotID])
GO
ALTER TABLE [dbo].[Schedule ] CHECK CONSTRAINT [FK_Schedule _Slot]
GO
ALTER TABLE [dbo].[Schedule ]  WITH CHECK ADD  CONSTRAINT [FK_Schedule _User] FOREIGN KEY([UserNameBooker])
REFERENCES [dbo].[User] ([UserName])
GO
ALTER TABLE [dbo].[Schedule ] CHECK CONSTRAINT [FK_Schedule _User]
GO
ALTER TABLE [dbo].[Schedule_User]  WITH CHECK ADD  CONSTRAINT [FK_Schedult_User_Schedule ] FOREIGN KEY([IndexShedule])
REFERENCES [dbo].[Schedule ] ([Index])
GO
ALTER TABLE [dbo].[Schedule_User] CHECK CONSTRAINT [FK_Schedult_User_Schedule ]
GO
ALTER TABLE [dbo].[Schedule_User]  WITH CHECK ADD  CONSTRAINT [FK_Schedult_User_User] FOREIGN KEY([UserName])
REFERENCES [dbo].[User] ([UserName])
GO
ALTER TABLE [dbo].[Schedule_User] CHECK CONSTRAINT [FK_Schedult_User_User]
GO
ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([GroupID])
GO
ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_Group]
GO
ALTER TABLE [dbo].[User_Group]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_User] FOREIGN KEY([UserName])
REFERENCES [dbo].[User] ([UserName])
GO
ALTER TABLE [dbo].[User_Group] CHECK CONSTRAINT [FK_User_Group_User]
GO
ALTER TABLE [dbo].[UserName_CourseID]  WITH CHECK ADD  CONSTRAINT [FK_UserName_CoursseID_Semester] FOREIGN KEY([SemesterID])
REFERENCES [dbo].[Semester] ([SemesterID])
GO
ALTER TABLE [dbo].[UserName_CourseID] CHECK CONSTRAINT [FK_UserName_CoursseID_Semester]
GO
/****** Object:  StoredProcedure [dbo].[USP_AddTeacher]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROC [dbo].[USP_AddTeacher]
@username VARCHAR(30) , @index INT
AS
BEGIN
	DECLARE @count INT
	;WITH T as (SELECT su.UserName , su.IndexShedule  FROM [dbo].[Schedule_User] as su JOIN [dbo].[User] as u ON su.UserName = u.UserName WHERE u.Role ='TEACHER')
	 SELECT @count = COUNT(*) FROM T WHERE [IndexShedule] =  @index
	IF (@count) <= 0
	BEGIN
		INSERT [dbo].[Schedule_User] VALUES (@username , @index , null)
	END
	ELSE
	BEGIN
		RETURN -1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_AddUserSchedule]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_AddUserSchedule]
@idgroup  NVARCHAR(15)
AS
BEGIN
	DECLARE @curUser VARCHAR(30) , @curIndex INT
	SELECT @curIndex = MAX([Index]) FROM [dbo].[Schedule ]
	SELECT  * INTO #TEMP FROM [dbo].[User_Group] WHERE GroupID = @idgroup
	WHILE ( SELECT COUNT(*) FROM #TEMP) > 0
	BEGIN
		SELECT TOP 1 @curUser = UserName FROM #TEMP
		-- process
		INSERT [dbo].[Schedule_User] VALUES (@curUser , @curIndex,null)
		
		DELETE  #TEMP WHERE UserName = @curUser

	END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_DeleteScheduleTeacherAndStudent]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC USP_DeleteScheduleTeacherAndStudent
@idgroup NVARCHAR(15) , @indexSchedule INT 
AS
BEGIN
	DECLARE @userNameStudent VARCHAR(30) 
	DECLARE  @UserNameTeacher NVARCHAR(30)
	SELECT @userNameTeacher = su.UserName  FROM [dbo].[Schedule_User] as su JOIN [dbo].[User] as u ON su.UserName = u.UserName WHERE u.Role ='TEACHER' AND su.IndexShedule = @indexSchedule
	SELECT  UG.UserName INTO #TEMP  FROM [dbo].[User_Group] as ug JOIN  [dbo].[Schedule_User] as su ON UG.UserName = SU.UserName WHERE ug.GroupID = @idgroup AND su.[IndexShedule] = @indexSchedule 
	DELETE [dbo].[Schedule_User] WHERE UserName = @UserNameTeacher AND IndexShedule = @indexSchedule
	WHILE ( SELECT COUNT(*) FROM #TEMP) > 0
	BEGIN
		SELECT TOP 1 @userNameStudent = UserName FROM #TEMP
		-- PROCESS
		DELETE [dbo].[Schedule_User] WHERE UserName = @userNameStudent AND IndexShedule = @indexSchedule

		DELETE #TEMP WHERE UserName = @userNameStudent
	END

END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetScheduleByDate]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetScheduleByDate]
@fromDate  date , @toDate date
AS
BEGIN
	SELECT * FROM [dbo].[Schedule ] WHERE [Date] >= @fromDate AND [Date] <= @toDate
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LoadScheduleByTeacher]    Script Date: 4/5/2020 11:02:11 PM ******/
SET ANSI_NULLS ON
GO
DROP PROCEDURE [dbo].[USP_LoadScheduleByTeacher]
SET QUOTED_IDENTIFIER ON
GO
GO
USE [master]
GO
ALTER DATABASE [QLHS] SET  READ_WRITE 
GO

CREATE DATABASE JobOpportunities;
GO
USE JobOpportunities
GO
CREATE TABLE [Country] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(50)
)
GO

CREATE TABLE [Gender] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(20)
)
GO

CREATE TABLE [MaritalStatus] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(30)
)
GO

CREATE TABLE [EducationLevel] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(30)
)
GO

CREATE TABLE [EducationSubject] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(30)
)
GO

CREATE TABLE [EducationDegree] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(30)
)
GO

CREATE TABLE [Applicant] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Password] varchar(255) NOT NULL,
  [Email] varchar(100) UNIQUE NOT NULL,
  [SecondEmailAddress] varchar(100),
  [RestartAccount] bit DEFAULT (0),
  [ConfirmAccount] bit DEFAULT (0),
  [Token] varchar(max),
  [FirstName] varchar(60) NOT NULL,
  [LastName] varchar(60) NOT NULL,
  [AditionalName] varchar(60),
  [Address1] varchar(100) NOT NULL,
  [Address2] varchar(100),
  [POBox] varchar(20),
  [PostalCode] varchar(20),
  [CountryId] int,
  [CitizenshipId] int,
  [City] varchar(100),
  [GenderId] int,
  [MaritalStatusId] int,
  [DateOfBirth] date,
  [SSN] varchar(50),
  [PrivatePhone] varchar(20),
  [MobilePhone] varchar(20),
  [WorkPhone] varchar(20),
  [EducationLevel] int,
  [Subject] int,
  [Degree] int
)
GO

CREATE TABLE [Employer] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [CompanyName] varchar(100),
  [ContactPerson] varchar(60),
  [Email] varchar(100),
  [Phone] varchar(20),
  [Website] varchar(100)
)
GO

CREATE TABLE [FieldSector] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(50)
)
GO

CREATE TABLE [JobOffer] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Title] varchar(100),
  [Description] text,
  [Salary] decimal(10,2),
  [Location] varchar(100),
  [EmployerId] int,
  [Status] varchar(20),
  [AvailabilityDate] date,
  [WorkExperienceYears] int,
  [CurrentPosition] varchar(100),
  [CurrentEmployer] varchar(100),
  [FieldSectorId] int,
  [RelevantWorkExperience] varchar(100),
  [AvailableReferences] varchar(100),
  [HowDidYouHear] varchar(100),
  [Internal] bit,
  [CoverLetter] text,
  [Cv] varbinary(max),
  [ExternalLinks] text
)
GO

CREATE TABLE [Application] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ApplicantId] int,
  [JobOfferId] int,
  [ApplicationDate] datetime,
  [Status] varchar(20)
)
GO

ALTER TABLE [Applicant] ADD FOREIGN KEY ([CountryId]) REFERENCES [Country] ([Id])
GO

ALTER TABLE [Applicant] ADD FOREIGN KEY ([CitizenshipId]) REFERENCES [Country] ([Id])
GO

ALTER TABLE [Applicant] ADD FOREIGN KEY ([GenderId]) REFERENCES [Gender] ([Id])
GO

ALTER TABLE [Applicant] ADD FOREIGN KEY ([MaritalStatusId]) REFERENCES [MaritalStatus] ([Id])
GO

ALTER TABLE [Applicant] ADD FOREIGN KEY ([EducationLevel]) REFERENCES [EducationLevel] ([Id])
GO

ALTER TABLE [Applicant] ADD FOREIGN KEY ([Subject]) REFERENCES [EducationSubject] ([Id])
GO

ALTER TABLE [Applicant] ADD FOREIGN KEY ([Degree]) REFERENCES [EducationDegree] ([Id])
GO

ALTER TABLE [JobOffer] ADD FOREIGN KEY ([EmployerId]) REFERENCES [Employer] ([Id])
GO

ALTER TABLE [JobOffer] ADD FOREIGN KEY ([FieldSectorId]) REFERENCES [FieldSector] ([Id])
GO

ALTER TABLE [Application] ADD FOREIGN KEY ([ApplicantId]) REFERENCES [Applicant] ([Id])
GO

ALTER TABLE [Application] ADD FOREIGN KEY ([JobOfferId]) REFERENCES [JobOffer] ([Id])
GO

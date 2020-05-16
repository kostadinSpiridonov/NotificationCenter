CREATE DATABASE NotificationCenter;

USE [NotificationCenter];

CREATE TABLE [dbo].[NotificationsCriterias](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](max) NOT NULL,
	[Template] [nvarchar](max) NOT NULL
)

CREATE TABLE [dbo].[NotificationChannels](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](max) NOT NULL
)

CREATE TABLE [dbo].[NotificationEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](max) NOT NULL,
	[CriteriaId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[NotificationsCriterias](Id),
	[NotificationGroupId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[NotificationsGroups](Id)
)

CREATE TABLE [dbo].[NotificationEventChannels](
	[NotificationChannelId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[NotificationChannels](Id),
	[NotificationEventId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[NotificationEvents](Id),
	PRIMARY KEY([NotificationChannelId],[NotificationEventId])
)

CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Content] [nvarchar](max) NOT NULL
)

CREATE TABLE [dbo].[NotificationsGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](max) NOT NULL
)

CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](max) NOT NULL,	
	[Type] [nvarchar](max) NOT NULL
)

CREATE TABLE [dbo].[Logins](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ClientId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Clients](Id),
	[Username] [nvarchar](max) NOT NULL,	
	[Password] [nvarchar](max) NOT NULL
)

CREATE TABLE [dbo].[Certificates](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ClientId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Clients](Id),
	[Name] [nvarchar](max) NOT NULL,	
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL
)

CREATE TABLE [dbo].[Requests](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ClientId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Clients](Id),
	[Type] [nvarchar](max) NOT NULL,	
	[CreatedDate] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NOT NULL
)

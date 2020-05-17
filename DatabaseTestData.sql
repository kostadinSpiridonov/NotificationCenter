USE [NotificationCenter];

INSERT INTO [dbo].[Clients] (Name, ClientTypeId) VALUES('Client 1', 1)
INSERT INTO [dbo].[Clients] (Name, ClientTypeId) VALUES('Client 2', 2)

--Password = Test
INSERT INTO [dbo].[Logins] (ClientId, UserName, Password) VALUES(1, 'user1', '5g+3um0rnOYEoN/gpv6EACV5G9zA6QC3eqcaPZyaG6Vw23lddgBd5RB26IJweNNQmAC/JV5pFPnEVJ1qNuSLnA==')
INSERT INTO [dbo].[Logins] (ClientId, UserName, Password) VALUES(2, 'user2', '5g+3um0rnOYEoN/gpv6EACV5G9zA6QC3eqcaPZyaG6Vw23lddgBd5RB26IJweNNQmAC/JV5pFPnEVJ1qNuSLnA==')

INSERT INTO [dbo].[Certificates] (ClientId, Name, StartDate, EndDate) VALUES(1, 'certificate1', '2020-05-18', '2020-05-18')
INSERT INTO [dbo].[Certificates] (ClientId, Name, StartDate, EndDate) VALUES(2, 'certificate2', '2020-05-18', '2020-05-18')

INSERT INTO [dbo].[NotificationEvents] (CriteriaId, Name) VALUES(1, 'test event 1')
INSERT INTO [dbo].[NotificationEvents] (CriteriaId, Name) VALUES(2, 'test event 2')

INSERT INTO [dbo].[NotificationEventChannels] (NotificationChannelId, NotificationEventId) VALUES(1, 1)
INSERT INTO [dbo].[NotificationEventChannels] (NotificationChannelId, NotificationEventId) VALUES(2, 1)
INSERT INTO [dbo].[NotificationEventChannels] (NotificationChannelId, NotificationEventId) VALUES(1, 2)
INSERT INTO [dbo].[NotificationEventChannels] (NotificationChannelId, NotificationEventId) VALUES(2, 2)

INSERT INTO [dbo].[NotificationsEventClientTypes] (ClientTypeId, NotificationEventId) VALUES(1, 1)
INSERT INTO [dbo].[NotificationsEventClientTypes] (ClientTypeId, NotificationEventId) VALUES(1, 2)
INSERT INTO [dbo].[NotificationsEventClientTypes] (ClientTypeId, NotificationEventId) VALUES(2, 1)
INSERT INTO [dbo].[NotificationsEventClientTypes] (ClientTypeId, NotificationEventId) VALUES(2, 2)


INSERT INTO [dbo].[Requests] (ClientId, Type, CreatedDate, Status) VALUES(1, 'Type1', '2020-05-17', 'StatusTest1')
INSERT INTO [dbo].[Requests] (ClientId, Type, CreatedDate, Status) VALUES(2, 'Type2', '2020-05-17', 'StatusTest2')

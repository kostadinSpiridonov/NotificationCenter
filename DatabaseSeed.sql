USE [NotificationCenter];

INSERT INTO [dbo].[NotificationsCriterias] (Name, Template) VALUES('CertificateExpiration','{0} - Start Date; {1} - End Date; {2} - Serial Number')
INSERT INTO [dbo].[NotificationsCriterias] (Name, Template) VALUES('RequestStatusChange','{0} - Request Type; {1} - Status')

INSERT INTO [dbo].[ClientTypes] (Name) VALUES('Company')
INSERT INTO [dbo].[ClientTypes] (Name) VALUES('Individual')

INSERT INTO [dbo].[NotificationChannels] (Name) VALUES('Web')
INSERT INTO [dbo].[NotificationChannels] (Name) VALUES('Database')

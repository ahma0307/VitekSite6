USE [BussinessContext-8f31fcf3-ca52-4581-92cd-e76c341d8e06]
GO

/****** Object: Table [dbo].[Customer] Script Date: 07-11-2019 14:12:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Customer];


GO
CREATE TABLE [dbo].[Customer] ( 
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [LastName]         NVARCHAR (50) NOT NULL,
    [FirstName]        NVARCHAR (50) NOT NULL,
    [SubscriptionDate] DATETIME2 (7) NOT NULL
);



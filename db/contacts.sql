USE [CustomerContact]
GO

/****** Object:  Table [dbo].[Contacts]    Script Date: 1/2/2019 8:49:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contacts](
	[Hid] [int] IDENTITY(1,1) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](300) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Modified] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Hid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [DF_Contacts_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


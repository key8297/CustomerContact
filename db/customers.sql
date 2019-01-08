USE [CustomerContact]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 1/2/2019 8:50:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[Hid] [int] IDENTITY(1,1) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Address] [varchar](300) NULL,
	[Phone] [varchar](20) NULL,
	[WebSite] [varchar](50) NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[Modified] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Hid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Table_1_created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


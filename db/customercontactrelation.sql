USE [CustomerContact]
GO

/****** Object:  Table [dbo].[CustomerContactRelation]    Script Date: 1/2/2019 8:50:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomerContactRelation](
	[Hid] [int] IDENTITY(1,1) NOT NULL,
	[Customer] [uniqueidentifier] NOT NULL,
	[Contact] [uniqueidentifier] NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_CustomerContactRelation] PRIMARY KEY CLUSTERED 
(
	[Hid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CustomerContactRelation] ADD  CONSTRAINT [DF_CustomerContactRelation_Created]  DEFAULT (getdate()) FOR [Created]
GO


USE [Cake]
GO
/****** Object:  Table [dbo].[Cake]    Script Date: 8/25/2024 7:46:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cake](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CakeId] [int] NOT NULL,
	[CakeType] [nvarchar](max) NOT NULL,
	[CakeName] [nvarchar](max) NOT NULL,
	[CakePpu] [float] NOT NULL,
	[BatterID] [int] NOT NULL,
	[BatterType] [nvarchar](max) NOT NULL,
	[ToppingId] [nvarchar](max) NOT NULL,
	[ToppingType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Cake] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [Dress]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5.11.2018 16:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DressCategory]    Script Date: 5.11.2018 16:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DressCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[DressId] [int] NULL,
 CONSTRAINT [PK_DressCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DressDefinition]    Script Date: 5.11.2018 16:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DressDefinition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Details] [nvarchar](max) NULL,
 CONSTRAINT [PK_DressDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DressImage]    Script Date: 5.11.2018 16:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DressImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageId] [int] NULL,
	[DressId] [int] NULL,
 CONSTRAINT [PK_DressImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image]    Script Date: 5.11.2018 16:06:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[imageName] [nvarchar](50) NULL,
	[imageAlt] [nvarchar](50) NULL,
	[imageData] [image] NULL,
	[ContentType] [nvarchar](50) NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[DressCategory]  WITH CHECK ADD  CONSTRAINT [FK_DressCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[DressCategory] CHECK CONSTRAINT [FK_DressCategory_Category]
GO
ALTER TABLE [dbo].[DressCategory]  WITH CHECK ADD  CONSTRAINT [FK_DressCategory_DressDefinition] FOREIGN KEY([DressId])
REFERENCES [dbo].[DressDefinition] ([Id])
GO
ALTER TABLE [dbo].[DressCategory] CHECK CONSTRAINT [FK_DressCategory_DressDefinition]
GO
ALTER TABLE [dbo].[DressImage]  WITH CHECK ADD  CONSTRAINT [FK_DressImage_DressDefinition] FOREIGN KEY([DressId])
REFERENCES [dbo].[DressDefinition] ([Id])
GO
ALTER TABLE [dbo].[DressImage] CHECK CONSTRAINT [FK_DressImage_DressDefinition]
GO
ALTER TABLE [dbo].[DressImage]  WITH CHECK ADD  CONSTRAINT [FK_DressImage_Image] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([Id])
GO
ALTER TABLE [dbo].[DressImage] CHECK CONSTRAINT [FK_DressImage_Image]
GO

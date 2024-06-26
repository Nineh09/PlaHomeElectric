USE [master]
GO
/****** Object:  Database [HomeElectric]    Script Date: 4/22/2024 7:37:03 AM ******/
CREATE DATABASE [HomeElectric]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HomeElectric', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HomeElectric.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HomeElectric_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HomeElectric_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HomeElectric] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HomeElectric].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HomeElectric] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HomeElectric] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HomeElectric] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HomeElectric] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HomeElectric] SET ARITHABORT OFF 
GO
ALTER DATABASE [HomeElectric] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HomeElectric] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HomeElectric] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HomeElectric] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HomeElectric] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HomeElectric] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HomeElectric] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HomeElectric] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HomeElectric] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HomeElectric] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HomeElectric] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HomeElectric] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HomeElectric] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HomeElectric] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HomeElectric] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HomeElectric] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HomeElectric] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HomeElectric] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HomeElectric] SET  MULTI_USER 
GO
ALTER DATABASE [HomeElectric] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HomeElectric] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HomeElectric] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HomeElectric] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HomeElectric] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HomeElectric] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HomeElectric] SET QUERY_STORE = OFF
GO
USE [HomeElectric]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/22/2024 7:37:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[CreationDate] [datetime] NULL,
	[ModificationDate] [datetime] NULL,
	[DeletionDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK__Category__3214EC27500F220E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 4/22/2024 7:37:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ProductID] [int] NULL,
	[OrderDetailID] [int] NULL,
	[Comment] [nvarchar](max) NULL,
	[Rate] [int] NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK__Feedback__3214EC2703B7349C] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 4/22/2024 7:37:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[ProductID] [int] NULL,
	[CreationDate] [datetime] NULL,
	[ModificationDate] [datetime] NULL,
	[DeletionDate] [datetime] NULL,
 CONSTRAINT [PK__Image__3214EC27832D0A91] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 4/22/2024 7:37:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[UserID] [int] NULL,
	[CreationDate] [datetime] NULL,
	[ModificationDate] [datetime] NULL,
	[DeletionDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK__Order__3214EC27700E411E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 4/22/2024 7:37:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[Status] [int] NULL,
	[CreationDate] [datetime] NULL,
	[ModificationDate] [datetime] NULL,
	[DeletionDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK__OrderDet__3214EC27EC4133E5] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 4/22/2024 7:37:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDetailID] [int] NULL,
	[PaymentName] [nvarchar](100) NULL,
 CONSTRAINT [PK__Payment__3214EC27C56E56A3] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/22/2024 7:37:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Title] [nvarchar](255) NULL,
	[Price] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Status] [int] NULL,
	[CategoryID] [int] NULL,
	[CreationDate] [datetime] NULL,
	[ModificationDate] [datetime] NULL,
	[DeletionDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK__Product__3214EC2768C70AA4] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 4/22/2024 7:37:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](100) NULL,
 CONSTRAINT [PK__Role__3214EC277FA2D5BC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/22/2024 7:37:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Address] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[RoleID] [int] NULL,
	[CreationDate] [datetime] NULL,
	[ModificationDate] [datetime] NULL,
	[DeletionDate] [datetime] NULL,
 CONSTRAINT [PK__User__3214EC27B409FB6B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [CategoryName], [Description], [Status], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (1, N'Electronics', N'Category for electronic devices', 1, CAST(N'2024-04-22T07:34:51.227' AS DateTime), CAST(N'2024-04-22T07:34:51.227' AS DateTime), NULL, 0)
INSERT [dbo].[Category] ([ID], [CategoryName], [Description], [Status], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (2, N'Clothing', N'Category for clothing items', 1, CAST(N'2024-04-22T07:34:51.227' AS DateTime), CAST(N'2024-04-22T07:34:51.227' AS DateTime), NULL, 0)
INSERT [dbo].[Category] ([ID], [CategoryName], [Description], [Status], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (3, N'Books', N'Category for books', 1, CAST(N'2024-04-22T07:34:51.227' AS DateTime), CAST(N'2024-04-22T07:34:51.227' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([ID], [UserID], [ProductID], [OrderDetailID], [Comment], [Rate], [Date]) VALUES (1, 1, 1, 1, N'Great laptop, fast delivery!', 5, CAST(N'2024-04-22T07:34:51.230' AS DateTime))
INSERT [dbo].[Feedback] ([ID], [UserID], [ProductID], [OrderDetailID], [Comment], [Rate], [Date]) VALUES (2, 1, 2, 2, N'Nice T-shirt, fits perfectly.', 4, CAST(N'2024-04-22T07:34:51.230' AS DateTime))
INSERT [dbo].[Feedback] ([ID], [UserID], [ProductID], [OrderDetailID], [Comment], [Rate], [Date]) VALUES (3, 2, 3, 3, N'Excellent book, highly recommend!', 5, CAST(N'2024-04-22T07:34:51.230' AS DateTime))
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([ID], [Title], [Description], [Status], [ProductID], [CreationDate], [ModificationDate], [DeletionDate]) VALUES (1, N'Laptop Image', N'Image of Dell XPS 15', 1, 1, CAST(N'2024-04-22T07:34:51.230' AS DateTime), CAST(N'2024-04-22T07:34:51.230' AS DateTime), NULL)
INSERT [dbo].[Image] ([ID], [Title], [Description], [Status], [ProductID], [CreationDate], [ModificationDate], [DeletionDate]) VALUES (2, N'T-shirt Image', N'Image of Plain White T-shirt', 1, 2, CAST(N'2024-04-22T07:34:51.230' AS DateTime), CAST(N'2024-04-22T07:34:51.230' AS DateTime), NULL)
INSERT [dbo].[Image] ([ID], [Title], [Description], [Status], [ProductID], [CreationDate], [ModificationDate], [DeletionDate]) VALUES (3, N'Book Image', N'Image of The Great Gatsby', 1, 3, CAST(N'2024-04-22T07:34:51.230' AS DateTime), CAST(N'2024-04-22T07:34:51.230' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [Status], [TotalPrice], [UserID], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (1, 1, CAST(1500.00 AS Decimal(18, 2)), 1, CAST(N'2024-04-22T07:34:51.230' AS DateTime), CAST(N'2024-04-22T07:34:51.230' AS DateTime), NULL, 0)
INSERT [dbo].[Order] ([ID], [Status], [TotalPrice], [UserID], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (2, 1, CAST(30.00 AS Decimal(18, 2)), 1, CAST(N'2024-04-22T07:34:51.230' AS DateTime), CAST(N'2024-04-22T07:34:51.230' AS DateTime), NULL, 0)
INSERT [dbo].[Order] ([ID], [Status], [TotalPrice], [UserID], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (3, 1, CAST(10.00 AS Decimal(18, 2)), 2, CAST(N'2024-04-22T07:34:51.230' AS DateTime), CAST(N'2024-04-22T07:34:51.230' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Status], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (1, 1, 1, 1, CAST(1500.00 AS Decimal(18, 2)), 1, CAST(N'2024-04-22T07:34:51.230' AS DateTime), CAST(N'2024-04-22T07:34:51.230' AS DateTime), NULL, 0)
INSERT [dbo].[OrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Status], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (2, 2, 2, 3, CAST(60.00 AS Decimal(18, 2)), 1, CAST(N'2024-04-22T07:34:51.230' AS DateTime), CAST(N'2024-04-22T07:34:51.230' AS DateTime), NULL, 0)
INSERT [dbo].[OrderDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price], [Status], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (3, 3, 3, 1, CAST(10.00 AS Decimal(18, 2)), 1, CAST(N'2024-04-22T07:34:51.230' AS DateTime), CAST(N'2024-04-22T07:34:51.230' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([ID], [OrderDetailID], [PaymentName]) VALUES (1, 1, N'Credit Card')
INSERT [dbo].[Payment] ([ID], [OrderDetailID], [PaymentName]) VALUES (2, 2, N'PayPal')
INSERT [dbo].[Payment] ([ID], [OrderDetailID], [PaymentName]) VALUES (3, 3, N'Cash')
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [ProductName], [Description], [Title], [Price], [Discount], [Quantity], [Status], [CategoryID], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (1, N'Laptop', N'High-performance laptop', N'Dell XPS 15', CAST(1500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 50, 1, 1, CAST(N'2024-04-22T07:34:51.227' AS DateTime), CAST(N'2024-04-22T07:34:51.227' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([ID], [ProductName], [Description], [Title], [Price], [Discount], [Quantity], [Status], [CategoryID], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (2, N'T-shirt', N'Cotton T-shirt', N'Plain White T-shirt', CAST(20.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 100, 1, 2, CAST(N'2024-04-22T07:34:51.227' AS DateTime), CAST(N'2024-04-22T07:34:51.227' AS DateTime), NULL, 0)
INSERT [dbo].[Product] ([ID], [ProductName], [Description], [Title], [Price], [Discount], [Quantity], [Status], [CategoryID], [CreationDate], [ModificationDate], [DeletionDate], [IsDeleted]) VALUES (3, N'Book', N'Bestseller novel', N'The Great Gatsby', CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 200, 1, 3, CAST(N'2024-04-22T07:34:51.227' AS DateTime), CAST(N'2024-04-22T07:34:51.227' AS DateTime), NULL, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (2, N'Staff')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (3, N'Customer')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [FullName], [PhoneNumber], [Email], [Password], [Address], [Description], [Status], [RoleID], [CreationDate], [ModificationDate], [DeletionDate]) VALUES (1, N'John Doe', N'123456789', N'john@example.com', N'password123', N'123 Main St, City', N'Customer account', 1, 2, CAST(N'2024-04-22T07:34:51.227' AS DateTime), CAST(N'2024-04-22T07:34:51.227' AS DateTime), NULL)
INSERT [dbo].[User] ([ID], [FullName], [PhoneNumber], [Email], [Password], [Address], [Description], [Status], [RoleID], [CreationDate], [ModificationDate], [DeletionDate]) VALUES (2, N'Jane Smith', N'987654321', N'jane@example.com', N'password456', N'456 Elm St, Town', N'Admin account', 1, 1, CAST(N'2024-04-22T07:34:51.227' AS DateTime), CAST(N'2024-04-22T07:34:51.227' AS DateTime), NULL)
INSERT [dbo].[User] ([ID], [FullName], [PhoneNumber], [Email], [Password], [Address], [Description], [Status], [RoleID], [CreationDate], [ModificationDate], [DeletionDate]) VALUES (3, N'Bob Johnson', N'555444333', N'bob@example.com', N'password789', N'789 Oak St, Village', N'Vendor account', 1, 3, CAST(N'2024-04-22T07:34:51.227' AS DateTime), CAST(N'2024-04-22T07:34:51.227' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK__Feedback__OrderD__656C112C] FOREIGN KEY([OrderDetailID])
REFERENCES [dbo].[OrderDetail] ([ID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK__Feedback__OrderD__656C112C]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK__Feedback__Produc__6477ECF3] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK__Feedback__Produc__6477ECF3]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK__Feedback__UserID__6383C8BA] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK__Feedback__UserID__6383C8BA]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK__Image__ProductID__6B24EA82] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK__Image__ProductID__6B24EA82]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__UserID__5CD6CB2B] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__UserID__5CD6CB2B]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__Order__5FB337D6] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK__OrderDeta__Order__5FB337D6]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__Produ__60A75C0F] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK__OrderDeta__Produ__60A75C0F]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK__Payment__OrderDe__68487DD7] FOREIGN KEY([OrderDetailID])
REFERENCES [dbo].[OrderDetail] ([ID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK__Payment__OrderDe__68487DD7]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Categor__59FA5E80] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Categor__59FA5E80]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__RoleID__5535A963] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__RoleID__5535A963]
GO
USE [master]
GO
ALTER DATABASE [HomeElectric] SET  READ_WRITE 
GO

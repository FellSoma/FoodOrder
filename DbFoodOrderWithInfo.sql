USE [master]
GO
/****** Object:  Database [FoodOrder]    Script Date: 30.05.2023 8:27:14 ******/
CREATE DATABASE [FoodOrder]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FoodOrder', FILENAME = N'D:\SQL\MSSQL16.MSSQLSERVER\MSSQL\DATA\FoodOrder.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FoodOrder_log', FILENAME = N'D:\SQL\MSSQL16.MSSQLSERVER\MSSQL\DATA\FoodOrder_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FoodOrder] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FoodOrder].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FoodOrder] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FoodOrder] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FoodOrder] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FoodOrder] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FoodOrder] SET ARITHABORT OFF 
GO
ALTER DATABASE [FoodOrder] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FoodOrder] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FoodOrder] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FoodOrder] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FoodOrder] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FoodOrder] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FoodOrder] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FoodOrder] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FoodOrder] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FoodOrder] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FoodOrder] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FoodOrder] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FoodOrder] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FoodOrder] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FoodOrder] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FoodOrder] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FoodOrder] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FoodOrder] SET RECOVERY FULL 
GO
ALTER DATABASE [FoodOrder] SET  MULTI_USER 
GO
ALTER DATABASE [FoodOrder] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FoodOrder] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FoodOrder] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FoodOrder] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FoodOrder] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FoodOrder] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FoodOrder', N'ON'
GO
ALTER DATABASE [FoodOrder] SET QUERY_STORE = OFF
GO
USE [FoodOrder]
GO
/****** Object:  Table [dbo].[Dishes]    Script Date: 30.05.2023 8:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dishes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dishes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DishesOfIngredients]    Script Date: 30.05.2023 8:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DishesOfIngredients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Dishes] [int] NOT NULL,
	[id_ingridient] [int] NOT NULL,
	[weigth] [float] NULL,
 CONSTRAINT [PK_DishesOfIngredients] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DishesOfMenu]    Script Date: 30.05.2023 8:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DishesOfMenu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Menu] [int] NOT NULL,
	[id_Dishes] [int] NOT NULL,
 CONSTRAINT [PK_DishesOfMenu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 30.05.2023 8:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 30.05.2023 8:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[id_Dish] [int] NOT NULL,
	[Prise] [money] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 30.05.2023 8:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[id_User] [int] NOT NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationsOfMenu]    Script Date: 30.05.2023 8:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationsOfMenu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Organization] [int] NOT NULL,
	[id_Menu] [int] NOT NULL,
 CONSTRAINT [PK_OrganizationsOfMenu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 30.05.2023 8:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(12,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[id_Unit] [int] NOT NULL,
	[Mass] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 30.05.2023 8:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30.05.2023 8:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dishes] ON 

INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1034, N'Котлеты домашние')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1035, N'Ёжики в соусе')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1036, N'Тефтели мясные 1-й вариант')
SET IDENTITY_INSERT [dbo].[Dishes] OFF
GO
SET IDENTITY_INSERT [dbo].[DishesOfIngredients] ON 

INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1033, 1034, 1, 113)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1034, 1034, 2, 5)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1035, 1035, 3, 71)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1036, 1035, 2, 6)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1037, 1035, 4, 50)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1038, 1035, 5, 50)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1039, 1035, 6, 2.5)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1040, 1035, 7, 2)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1041, 1035, 8, 5)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1042, 1035, 9, 1.2)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1043, 1035, 10, 0.75)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1044, 1036, 11, 71)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1045, 1036, 2, 6)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1046, 1036, 4, 50)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1047, 1036, 5, 50)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1048, 1036, 6, 2.5)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1049, 1036, 7, 2)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1050, 1036, 8, 5)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1051, 1036, 9, 1.2)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1052, 1036, 10, 0.75)
SET IDENTITY_INSERT [dbo].[DishesOfIngredients] OFF
GO
SET IDENTITY_INSERT [dbo].[DishesOfMenu] ON 

INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1050, 1, 1034)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1051, 2, 1034)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1052, 1, 1035)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1053, 2, 1035)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1054, 1, 1036)
SET IDENTITY_INSERT [dbo].[DishesOfMenu] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([id], [Name]) VALUES (1, N'Меню №1')
INSERT [dbo].[Menu] ([id], [Name]) VALUES (2, N'Меню №2')
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Organizations] ON 

INSERT [dbo].[Organizations] ([id], [Name], [id_User]) VALUES (1, N'Оц5', 1)
INSERT [dbo].[Organizations] ([id], [Name], [id_User]) VALUES (2, N'Оц1', 2)
SET IDENTITY_INSERT [dbo].[Organizations] OFF
GO
SET IDENTITY_INSERT [dbo].[OrganizationsOfMenu] ON 

INSERT [dbo].[OrganizationsOfMenu] ([id], [id_Organization], [id_Menu]) VALUES (1, 1, 1)
INSERT [dbo].[OrganizationsOfMenu] ([id], [id_Organization], [id_Menu]) VALUES (2, 2, 2)
INSERT [dbo].[OrganizationsOfMenu] ([id], [id_Organization], [id_Menu]) VALUES (3, 1, 2)
SET IDENTITY_INSERT [dbo].[OrganizationsOfMenu] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([id], [Name], [id_Unit], [Mass]) VALUES (1, N'Котлеты домашние замороженный полуфабрикат', 2, N'Кг')
INSERT [dbo].[Products] ([id], [Name], [id_Unit], [Mass]) VALUES (2, N'Масло растительное', 1, N'Кг')
INSERT [dbo].[Products] ([id], [Name], [id_Unit], [Mass]) VALUES (3, N'Ёжики замороженный полуфабрикат', 2, N'Кг')
INSERT [dbo].[Products] ([id], [Name], [id_Unit], [Mass]) VALUES (4, N'Соус', 2, N'Кг')
INSERT [dbo].[Products] ([id], [Name], [id_Unit], [Mass]) VALUES (5, N'Вода', 1, N'Кг')
INSERT [dbo].[Products] ([id], [Name], [id_Unit], [Mass]) VALUES (6, N'Мука', 1, N'Кг')
INSERT [dbo].[Products] ([id], [Name], [id_Unit], [Mass]) VALUES (7, N'Томат-паста', 1, N'Кг')
INSERT [dbo].[Products] ([id], [Name], [id_Unit], [Mass]) VALUES (8, N'Морковь', 1, N'Кг')
INSERT [dbo].[Products] ([id], [Name], [id_Unit], [Mass]) VALUES (9, N'Лук репчатый', 1, N'Кг')
INSERT [dbo].[Products] ([id], [Name], [id_Unit], [Mass]) VALUES (10, N'Сахар-песок', 1, N'Кг')
INSERT [dbo].[Products] ([id], [Name], [id_Unit], [Mass]) VALUES (11, N'Тефтели мясные замороженный полуфабрикат', 2, N'Кг')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Units] ON 

INSERT [dbo].[Units] ([id], [Name]) VALUES (1, N'Брутто')
INSERT [dbo].[Units] ([id], [Name]) VALUES (2, N'Нетто')
SET IDENTITY_INSERT [dbo].[Units] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [Name], [Password]) VALUES (1, N'Test', N'123456')
INSERT [dbo].[Users] ([id], [Name], [Password]) VALUES (2, N'Test2', N'123456')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[DishesOfIngredients]  WITH CHECK ADD  CONSTRAINT [FK_DishesOfIngredients_Dishes] FOREIGN KEY([id_Dishes])
REFERENCES [dbo].[Dishes] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DishesOfIngredients] CHECK CONSTRAINT [FK_DishesOfIngredients_Dishes]
GO
ALTER TABLE [dbo].[DishesOfIngredients]  WITH CHECK ADD  CONSTRAINT [FK_DishesOfIngredients_Products] FOREIGN KEY([id_ingridient])
REFERENCES [dbo].[Products] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DishesOfIngredients] CHECK CONSTRAINT [FK_DishesOfIngredients_Products]
GO
ALTER TABLE [dbo].[DishesOfMenu]  WITH CHECK ADD  CONSTRAINT [FK_DishesOfMenu_Dishes] FOREIGN KEY([id_Dishes])
REFERENCES [dbo].[Dishes] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DishesOfMenu] CHECK CONSTRAINT [FK_DishesOfMenu_Dishes]
GO
ALTER TABLE [dbo].[DishesOfMenu]  WITH CHECK ADD  CONSTRAINT [FK_DishesOfMenu_Menu] FOREIGN KEY([id_Menu])
REFERENCES [dbo].[Menu] ([id])
GO
ALTER TABLE [dbo].[DishesOfMenu] CHECK CONSTRAINT [FK_DishesOfMenu_Menu]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Dishes] FOREIGN KEY([id_Dish])
REFERENCES [dbo].[Dishes] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Dishes]
GO
ALTER TABLE [dbo].[Organizations]  WITH CHECK ADD  CONSTRAINT [FK_Organizations_Users] FOREIGN KEY([id_User])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Organizations] CHECK CONSTRAINT [FK_Organizations_Users]
GO
ALTER TABLE [dbo].[OrganizationsOfMenu]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationsOfMenu_Menu] FOREIGN KEY([id_Menu])
REFERENCES [dbo].[Menu] ([id])
GO
ALTER TABLE [dbo].[OrganizationsOfMenu] CHECK CONSTRAINT [FK_OrganizationsOfMenu_Menu]
GO
ALTER TABLE [dbo].[OrganizationsOfMenu]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationsOfMenu_Organizations] FOREIGN KEY([id_Organization])
REFERENCES [dbo].[Organizations] ([id])
GO
ALTER TABLE [dbo].[OrganizationsOfMenu] CHECK CONSTRAINT [FK_OrganizationsOfMenu_Organizations]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Units] FOREIGN KEY([id_Unit])
REFERENCES [dbo].[Units] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Units]
GO
USE [master]
GO
ALTER DATABASE [FoodOrder] SET  READ_WRITE 
GO

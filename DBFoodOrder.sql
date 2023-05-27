USE [master]
GO
/****** Object:  Database [FoodOrder]    Script Date: 05.05.2023 12:42:55 ******/
CREATE DATABASE [FoodOrder]
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
/****** Object:  Table [dbo].[Dishes]    Script Date: 05.05.2023 12:42:55 ******/
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
/****** Object:  Table [dbo].[DishesOfIngredients]    Script Date: 05.05.2023 12:42:55 ******/
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
/****** Object:  Table [dbo].[DishesOfMenu]    Script Date: 05.05.2023 12:42:55 ******/
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
/****** Object:  Table [dbo].[Menu]    Script Date: 05.05.2023 12:42:55 ******/
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
/****** Object:  Table [dbo].[Orders]    Script Date: 05.05.2023 12:42:55 ******/
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
/****** Object:  Table [dbo].[Organizations]    Script Date: 05.05.2023 12:42:55 ******/
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
/****** Object:  Table [dbo].[OrganizationsOfMenu]    Script Date: 05.05.2023 12:42:55 ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 05.05.2023 12:42:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Weight] [float] NOT NULL,
	[id_Unit] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 05.05.2023 12:42:55 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 05.05.2023 12:42:55 ******/
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

INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1, N'Гречка с котлетой')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (2, N'Макароны с котлетой')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (3, N'')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (4, N'болоболо')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (5, N'test1')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (6, N'Тест')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (7, N'Test')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (8, N'жопа')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (9, N'Генний')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (10, N'bcv')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (11, N'юбаджуба')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (12, N'Саша генний')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (13, N'итмчм')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (14, N'хлеб с гречкой')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (16, N'Котлета')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (17, N'мясо с хлебом')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (20, N'булочка с мясом')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1020, N'проверочное блюдо1')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1021, N'Проверочное блюдо 2')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1022, N'Проверочное блюдо 3')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1023, N'zxczzxczz')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1024, N'мим')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1025, N'1233332')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1026, N'12333321')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1027, N'43')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1028, N'm')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1029, N'xcvvv')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1030, N'fsdf')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1031, N'фыввв')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1032, N'тьт')
INSERT [dbo].[Dishes] ([id], [Name]) VALUES (1033, N'1вф')
SET IDENTITY_INSERT [dbo].[Dishes] OFF
GO
SET IDENTITY_INSERT [dbo].[DishesOfIngredients] ON 

INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1, 1, 1, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (2, 1, 2, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (3, 1, 4, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (4, 2, 1, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (5, 2, 2, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (6, 2, 3, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (14, 14, 1, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (15, 14, 4, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (20, 16, 1, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (21, 16, 2, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (22, 17, 2, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (23, 17, 1, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (27, 20, 1, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (28, 20, 2, NULL)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1026, 1022, 2, 123)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1027, 1022, 1, 121)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1028, 1029, 1, 1)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1029, 1030, 1, 312)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1030, 1031, 1, 123)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1031, 1032, 1, 13)
INSERT [dbo].[DishesOfIngredients] ([id], [id_Dishes], [id_ingridient], [weigth]) VALUES (1032, 1033, 1, 31)
SET IDENTITY_INSERT [dbo].[DishesOfIngredients] OFF
GO
SET IDENTITY_INSERT [dbo].[DishesOfMenu] ON 

INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1, 1, 1)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (2, 1, 2)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (3, 2, 1)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (4, 1, 14)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (5, 1, 14)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (6, 1, 14)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (7, 1, 14)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (8, 1, 14)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (14, 1, 16)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (15, 1, 16)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (16, 1, 16)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (17, 1, 16)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (18, 1, 16)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (19, 1, 17)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (20, 1, 17)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (21, 1, 17)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (22, 1, 17)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (23, 1, 17)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (34, 2, 20)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (35, 2, 20)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (36, 2, 20)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (37, 2, 20)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (38, 2, 20)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1029, 1, 1020)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1030, 1, 1021)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1031, 1, 1022)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1032, 1, 1022)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1033, 1, 1023)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1034, 1, 1024)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1035, 1, 1024)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1036, 1, 1025)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1037, 1, 1026)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1038, 1, 1027)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1039, 1, 1028)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1040, 1, 1029)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1041, 1, 1029)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1042, 1, 1030)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1043, 1, 1030)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1044, 1, 1031)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1045, 1, 1031)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1046, 1, 1032)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1047, 1, 1032)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1048, 1, 1033)
INSERT [dbo].[DishesOfMenu] ([id], [id_Menu], [id_Dishes]) VALUES (1049, 1, 1033)
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

INSERT [dbo].[Products] ([id], [Name], [Weight], [id_Unit]) VALUES (1, N'Хлеб', 400, 3)
INSERT [dbo].[Products] ([id], [Name], [Weight], [id_Unit]) VALUES (2, N'Мясо', 1, 1)
INSERT [dbo].[Products] ([id], [Name], [Weight], [id_Unit]) VALUES (3, N'Макароны', 300, 3)
INSERT [dbo].[Products] ([id], [Name], [Weight], [id_Unit]) VALUES (4, N'Гречка', 300, 3)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Units] ON 

INSERT [dbo].[Units] ([id], [Name]) VALUES (1, N'Кг')
INSERT [dbo].[Units] ([id], [Name]) VALUES (2, N'Л')
INSERT [dbo].[Units] ([id], [Name]) VALUES (3, N'Г')
INSERT [dbo].[Units] ([id], [Name]) VALUES (4, N'Мл')
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

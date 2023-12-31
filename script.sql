USE [Steak_Shop]
GO
/****** Object:  Table [dbo].[AboutUs]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AboutUs](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Details] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AboutUs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [nvarchar](255) NOT NULL,
	[BlogDetails] [nvarchar](255) NOT NULL,
	[Date] [date] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[UID] [int] NOT NULL,
	[CID] [int] NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog_Image]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog_Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ImageSource] [nvarchar](max) NOT NULL,
	[BID] [int] NOT NULL,
 CONSTRAINT [PK_Blog_Image] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogCategories]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogCategories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_B] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs_Categories]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs_Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BID] [int] NOT NULL,
	[CID] [int] NOT NULL,
 CONSTRAINT [PK_Blogs_Categorys] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookTable]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NumberOfPeople] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[EventID] [int] NOT NULL,
	[UID] [int] NULL,
 CONSTRAINT [PK_BookTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FoodId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](255) NOT NULL,
	[Descriptions] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chefs]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chefs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Salary] [money] NOT NULL,
	[Certificate] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Chefs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[BID] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[ID] [int] NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[OpenTime] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FoodName] [nvarchar](255) NOT NULL,
	[Price] [money] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[C_ID] [int] NOT NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarketingBudget]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarketingBudget](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](255) NOT NULL,
	[Budget] [money] NOT NULL,
 CONSTRAINT [PK_MarketingBudget] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[IsRead] [int] NULL,
	[Date] [datetime2](1) NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[TotalAmount] [money] NOT NULL,
	[UID] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders_Chefs]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders_Chefs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OID] [int] NOT NULL,
	[ChefID] [int] NOT NULL,
 CONSTRAINT [PK_Orders_Chefs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders_Foods]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders_Foods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OID] [int] NOT NULL,
	[FID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Orders_Foods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleMarketing]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleMarketing](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[CashReceive] [money] NULL,
	[Id_MB] [int] NOT NULL,
 CONSTRAINT [PK_ScheduleMarketing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Role] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[NumberOfLogins] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkShifts]    Script Date: 1/4/2024 7:58:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkShifts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WorkHours] [float] NOT NULL,
	[Shifts] [nvarchar](30) NOT NULL,
	[Holidays] [nvarchar](50) NULL,
	[ChefID] [int] NOT NULL,
 CONSTRAINT [PK_WorkShifts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AboutUs] ([ID], [Title], [Details], [Content]) VALUES (1, N'Our Story', N'SteakShop - The Journey Begins', N'SteakShop is a culinary adventure that started with a passion for great steaks. We believe in serving the finest cuts of meat cooked to perfection.')
INSERT [dbo].[AboutUs] ([ID], [Title], [Details], [Content]) VALUES (2, N'Our Vision', N'Bringing Steak Excellence to Hanoi', N'Our vision is to become the go-to destination for steak lovers in Hanoi. We aim to provide a unique dining experience that combines quality, flavor, and ambiance.')
INSERT [dbo].[AboutUs] ([ID], [Title], [Details], [Content]) VALUES (3, N'Our Team', N'Meet Our Skilled Chefs', N'Our talented chefs bring years of experience to our kitchen. They are dedicated to creating mouthwatering dishes that will satisfy your steak cravings.')
INSERT [dbo].[AboutUs] ([ID], [Title], [Details], [Content]) VALUES (4, N'Why Choose Us', N'What Sets Us Apart', N'At SteakShop, we take pride in sourcing the finest ingredients and preparing them with care. Our commitment to excellence is reflected in every steak we serve.')
INSERT [dbo].[AboutUs] ([ID], [Title], [Details], [Content]) VALUES (5, N'Our Locations', N'Find Us in the Heart of Hanoi', N'You can find our restaurants conveniently located near universities and shopping centers in the heart of Hanoi. Join us for a memorable dining experience.')
INSERT [dbo].[AboutUs] ([ID], [Title], [Details], [Content]) VALUES (6, N'Contact Us', N'Get in Touch', N'Have questions or feedback? Contact our friendly team. We are here to assist you with reservations, inquiries, or any special requests.')
INSERT [dbo].[AboutUs] ([ID], [Title], [Details], [Content]) VALUES (7, N'Our Commitment', N'Quality and Satisfaction', N'We are committed to ensuring your satisfaction. Your dining experience at SteakShop is our top priority.')
INSERT [dbo].[AboutUs] ([ID], [Title], [Details], [Content]) VALUES (8, N'Join Our Team', N'Career Opportunities', N'Interested in joining our team? Explore career opportunities at SteakShop and be part of a culinary journey.')
INSERT [dbo].[AboutUs] ([ID], [Title], [Details], [Content]) VALUES (9, N'News and Updates', N'Stay Informed', N'Keep up with the latest news, promotions, and events at SteakShop. We have exciting updates to share with our loyal customers.')
INSERT [dbo].[AboutUs] ([ID], [Title], [Details], [Content]) VALUES (10, N'Customer Reviews', N'What Our Customers Say', N'Read reviews from our happy customers and discover what makes SteakShop a favorite steakhouse in Hanoi.')
GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([ID], [BlogTitle], [BlogDetails], [Date], [Content], [UID], [CID]) VALUES (2, N'The Art of Grilling Steak', N'Learn the secrets of grilling the perfect steak.', CAST(N'2023-10-01' AS Date), N'Grilling steak is both a science and an art. In this blog post, we share tips and tricks to achieve the ideal grill marks and flavors.', 1, 1)
INSERT [dbo].[Blog] ([ID], [BlogTitle], [BlogDetails], [Date], [Content], [UID], [CID]) VALUES (15, N'asdasd', N'asdasd', CAST(N'2023-11-08' AS Date), N'asdasdads', 2, 1)
INSERT [dbo].[Blog] ([ID], [BlogTitle], [BlogDetails], [Date], [Content], [UID], [CID]) VALUES (16, N'asdasd', N'asdasd', CAST(N'2023-11-08' AS Date), N'asdasd', 2, 1)
INSERT [dbo].[Blog] ([ID], [BlogTitle], [BlogDetails], [Date], [Content], [UID], [CID]) VALUES (17, N'test', N'test', CAST(N'2023-11-08' AS Date), N'test', 2, 1)
SET IDENTITY_INSERT [dbo].[Blog] OFF
GO
SET IDENTITY_INSERT [dbo].[Blog_Image] ON 

INSERT [dbo].[Blog_Image] ([ID], [ImageSource], [BID]) VALUES (2, N'image1.jpg', 2)
INSERT [dbo].[Blog_Image] ([ID], [ImageSource], [BID]) VALUES (3, N'image2.jpg', 2)
INSERT [dbo].[Blog_Image] ([ID], [ImageSource], [BID]) VALUES (4, N'image3.jpg', 2)
INSERT [dbo].[Blog_Image] ([ID], [ImageSource], [BID]) VALUES (5, N'image4.jpg', 2)
INSERT [dbo].[Blog_Image] ([ID], [ImageSource], [BID]) VALUES (6, N'image5.jpg', 2)
INSERT [dbo].[Blog_Image] ([ID], [ImageSource], [BID]) VALUES (7, N'image6.jpg', 2)
INSERT [dbo].[Blog_Image] ([ID], [ImageSource], [BID]) VALUES (8, N'image7.jpg', 2)
INSERT [dbo].[Blog_Image] ([ID], [ImageSource], [BID]) VALUES (9, N'image8.jpg', 2)
INSERT [dbo].[Blog_Image] ([ID], [ImageSource], [BID]) VALUES (10, N'image9.jpg', 2)
INSERT [dbo].[Blog_Image] ([ID], [ImageSource], [BID]) VALUES (11, N'image10.jpg', 2)
SET IDENTITY_INSERT [dbo].[Blog_Image] OFF
GO
SET IDENTITY_INSERT [dbo].[BlogCategories] ON 

INSERT [dbo].[BlogCategories] ([ID], [CategoryName]) VALUES (1, N'Grilling Tips')
INSERT [dbo].[BlogCategories] ([ID], [CategoryName]) VALUES (2, N'Steak Cuts')
INSERT [dbo].[BlogCategories] ([ID], [CategoryName]) VALUES (3, N'Culinary Journeys')
INSERT [dbo].[BlogCategories] ([ID], [CategoryName]) VALUES (4, N'Wine Pairing')
INSERT [dbo].[BlogCategories] ([ID], [CategoryName]) VALUES (5, N'Sensory Experience')
INSERT [dbo].[BlogCategories] ([ID], [CategoryName]) VALUES (6, N'Cooking Techniques')
INSERT [dbo].[BlogCategories] ([ID], [CategoryName]) VALUES (7, N'Dining Experience')
INSERT [dbo].[BlogCategories] ([ID], [CategoryName]) VALUES (8, N'Chef Spotlights')
INSERT [dbo].[BlogCategories] ([ID], [CategoryName]) VALUES (9, N'Events and Promotions')
INSERT [dbo].[BlogCategories] ([ID], [CategoryName]) VALUES (10, N'Cooking Tips and Tricks')
SET IDENTITY_INSERT [dbo].[BlogCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Blogs_Categories] ON 

INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (3, 2, 1)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (4, 2, 2)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (5, 2, 3)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (6, 2, 4)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (7, 2, 5)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (8, 2, 6)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (9, 2, 7)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (10, 2, 8)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (11, 2, 9)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (12, 2, 10)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (13, 2, 4)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (14, 16, 1)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (15, 16, 2)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (16, 17, 1)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (17, 17, 6)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (18, 17, 7)
INSERT [dbo].[Blogs_Categories] ([ID], [BID], [CID]) VALUES (19, 17, 9)
SET IDENTITY_INSERT [dbo].[Blogs_Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[BookTable] ON 

INSERT [dbo].[BookTable] ([ID], [NumberOfPeople], [Date], [EventID], [UID]) VALUES (3, 2, CAST(N'2023-10-15' AS Date), 1, 2)
INSERT [dbo].[BookTable] ([ID], [NumberOfPeople], [Date], [EventID], [UID]) VALUES (4, 4, CAST(N'2023-10-18' AS Date), 2, 2)
INSERT [dbo].[BookTable] ([ID], [NumberOfPeople], [Date], [EventID], [UID]) VALUES (5, 3, CAST(N'2023-10-20' AS Date), 3, 3)
INSERT [dbo].[BookTable] ([ID], [NumberOfPeople], [Date], [EventID], [UID]) VALUES (6, 5, CAST(N'2023-10-25' AS Date), 4, 4)
INSERT [dbo].[BookTable] ([ID], [NumberOfPeople], [Date], [EventID], [UID]) VALUES (7, 2, CAST(N'2023-10-28' AS Date), 1, 5)
INSERT [dbo].[BookTable] ([ID], [NumberOfPeople], [Date], [EventID], [UID]) VALUES (8, 4, CAST(N'2023-11-01' AS Date), 2, 6)
INSERT [dbo].[BookTable] ([ID], [NumberOfPeople], [Date], [EventID], [UID]) VALUES (9, 3, CAST(N'2023-11-05' AS Date), 3, 7)
INSERT [dbo].[BookTable] ([ID], [NumberOfPeople], [Date], [EventID], [UID]) VALUES (10, 5, CAST(N'2023-11-10' AS Date), 4, 8)
INSERT [dbo].[BookTable] ([ID], [NumberOfPeople], [Date], [EventID], [UID]) VALUES (11, 2, CAST(N'2023-11-15' AS Date), 1, 9)
INSERT [dbo].[BookTable] ([ID], [NumberOfPeople], [Date], [EventID], [UID]) VALUES (12, 4, CAST(N'2023-11-18' AS Date), 2, 10)
SET IDENTITY_INSERT [dbo].[BookTable] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [CategoryName], [Descriptions]) VALUES (1, N'Grilling Tips', N'Learn how to grill steak like a pro.')
INSERT [dbo].[Categories] ([ID], [CategoryName], [Descriptions]) VALUES (2, N'Steak Cuts', N'Explore different cuts of steak and their characteristics.')
INSERT [dbo].[Categories] ([ID], [CategoryName], [Descriptions]) VALUES (3, N'Culinary Journeys', N'Embark on a culinary adventure with us.')
INSERT [dbo].[Categories] ([ID], [CategoryName], [Descriptions]) VALUES (4, N'Wine Pairing', N'Discover the perfect wines to pair with steak.')
INSERT [dbo].[Categories] ([ID], [CategoryName], [Descriptions]) VALUES (5, N'Sensory Experience', N'Immerse yourself in the sensory delights of steak.')
INSERT [dbo].[Categories] ([ID], [CategoryName], [Descriptions]) VALUES (6, N'Cooking Techniques', N'Master the art of cooking steak.')
INSERT [dbo].[Categories] ([ID], [CategoryName], [Descriptions]) VALUES (7, N'Dining Experience', N'Savor the ambiance and service of a steakhouse.')
INSERT [dbo].[Categories] ([ID], [CategoryName], [Descriptions]) VALUES (8, N'Chef Spotlights', N'Meet our talented chefs and their stories.')
INSERT [dbo].[Categories] ([ID], [CategoryName], [Descriptions]) VALUES (9, N'Events and Promotions', N'Stay updated on our latest events and promotions.')
INSERT [dbo].[Categories] ([ID], [CategoryName], [Descriptions]) VALUES (10, N'Cooking Tips and Tricks', N'Learn expert cooking tips and tricks.')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Chefs] ON 

INSERT [dbo].[Chefs] ([ID], [Name], [Email], [Phone], [Salary], [Certificate]) VALUES (1, N'Chef John', N'chefjohn@example.com', N'555-123-4567', 5000.0000, N'Master Chef')
INSERT [dbo].[Chefs] ([ID], [Name], [Email], [Phone], [Salary], [Certificate]) VALUES (2, N'Chef Mary', N'chefmary@example.com', N'555-987-6543', 4800.0000, N'Certified Chef')
INSERT [dbo].[Chefs] ([ID], [Name], [Email], [Phone], [Salary], [Certificate]) VALUES (3, N'Chef Robert', N'chefrobert@example.com', N'555-555-5555', 5500.0000, N'Executive Chef')
INSERT [dbo].[Chefs] ([ID], [Name], [Email], [Phone], [Salary], [Certificate]) VALUES (4, N'Chef Emily', N'chefemily@example.com', N'555-111-2222', 4500.0000, N'Sous Chef')
INSERT [dbo].[Chefs] ([ID], [Name], [Email], [Phone], [Salary], [Certificate]) VALUES (5, N'Chef Michael', N'chefmichael@example.com', N'555-333-4444', 4900.0000, N'Pastry Chef')
INSERT [dbo].[Chefs] ([ID], [Name], [Email], [Phone], [Salary], [Certificate]) VALUES (6, N'Chef Olivia', N'chefolivia@example.com', N'555-777-8888', 4600.0000, N'Grill Chef')
INSERT [dbo].[Chefs] ([ID], [Name], [Email], [Phone], [Salary], [Certificate]) VALUES (7, N'Chef Daniel', N'chefdaniel@example.com', N'555-666-9999', 4700.0000, N'Saute Chef')
INSERT [dbo].[Chefs] ([ID], [Name], [Email], [Phone], [Salary], [Certificate]) VALUES (8, N'Chef Sophia', N'chefsophia@example.com', N'555-222-3333', 4300.0000, N'Line Cook')
INSERT [dbo].[Chefs] ([ID], [Name], [Email], [Phone], [Salary], [Certificate]) VALUES (9, N'Chef William', N'chefwilliam@example.com', N'555-888-1111', 4200.0000, N'Prep Cook')
INSERT [dbo].[Chefs] ([ID], [Name], [Email], [Phone], [Salary], [Certificate]) VALUES (10, N'Chef Ava', N'chefava@example.com', N'555-999-0000', 4800.0000, N'Dessert Chef')
SET IDENTITY_INSERT [dbo].[Chefs] OFF
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (5, CAST(N'2023-10-15' AS Date), N'John Doe', N'johndoe@example.com', N'I love the grilling tips in this blog!', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (6, CAST(N'2023-10-18' AS Date), N'Jane Smith', N'janesmith@example.com', N'The steak cuts guide is very informative.', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (7, CAST(N'2023-10-20' AS Date), N'Bob Johnson', N'bobjohnson@example.com', N'Your culinary journeys are inspiring!', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (8, CAST(N'2023-10-25' AS Date), N'Alice Brown', N'alicebrown@example.com', N'Great wine pairing suggestions!', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (9, CAST(N'2023-10-28' AS Date), N'Charlie Davis', N'charliedavis@example.com', N'I can almost hear the sizzle!', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (10, CAST(N'2023-11-01' AS Date), N'Eva White', N'evawhite@example.com', N'Cooking techniques are top-notch.', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (11, CAST(N'2023-11-05' AS Date), N'David Lee', N'davidlee@example.com', N'The dining experience is superb.', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (12, CAST(N'2023-11-10' AS Date), N'Sophia Wilson', N'sophiawilson@example.com', N'Chef John is a culinary genius!', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (13, CAST(N'2023-11-15' AS Date), N'James Miller', N'jamesmiller@example.com', N'Looking forward to your events!', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (14, CAST(N'2023-11-18' AS Date), N'Olivia Harris', N'oliviaharris@example.com', N'These cooking tips are gold.', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (23, CAST(N'2023-11-08' AS Date), N'asdasd', N'asdasd@gmail.com', N'asd', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (24, CAST(N'2023-11-08' AS Date), N'asdasd', N'asdasd@gmail.com', N'asda', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (25, CAST(N'2023-11-08' AS Date), N'asdasd', N'asdasd@gmail.com', N'asdasdas', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (26, CAST(N'2023-11-08' AS Date), N'Jane Smith', N'janesmith@example.com', N'asdasdasd', 2)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (27, CAST(N'2023-11-08' AS Date), N'asdsa', N'asdasd@gmail.com', N'asdasd', 15)
INSERT [dbo].[Comment] ([ID], [Date], [Name], [Email], [Message], [BID]) VALUES (28, CAST(N'2023-11-08' AS Date), N'test', N'test@gmail.com', N'test', 15)
SET IDENTITY_INSERT [dbo].[Comment] OFF
GO
INSERT [dbo].[ContactUs] ([ID], [Details], [Address], [Phone], [OpenTime], [Email], [Location]) VALUES (1, N'Questions? Contact us anytime!', N'123 Main Street, Hanoi', N'555-123-4567', N'Mon-Sun: 10:00 AM - 10:00 PM', N'info@steakshop.com', N'Hanoi')
INSERT [dbo].[ContactUs] ([ID], [Details], [Address], [Phone], [OpenTime], [Email], [Location]) VALUES (2, N'Visit us at our Hanoi location', N'456 Elm Street, Hanoi', N'555-987-6543', N'Mon-Sun: 11:00 AM - 11:00 PM', N'contact@steakshop.com', N'Hanoi')
INSERT [dbo].[ContactUs] ([ID], [Details], [Address], [Phone], [OpenTime], [Email], [Location]) VALUES (3, N'We''re here to assist you', N'789 Oak Street, Hanoi', N'555-555-5555', N'Mon-Sun: 12:00 PM - 9:00 PM', N'support@steakshop.com', N'Hanoi')
INSERT [dbo].[ContactUs] ([ID], [Details], [Address], [Phone], [OpenTime], [Email], [Location]) VALUES (4, N'Join us for a memorable meal', N'101 Maple Street, Hanoi', N'555-111-2222', N'Mon-Sun: 10:30 AM - 10:30 PM', N'reservations@steakshop.com', N'Hanoi')
INSERT [dbo].[ContactUs] ([ID], [Details], [Address], [Phone], [OpenTime], [Email], [Location]) VALUES (5, N'Dine with us in Hanoi', N'246 Pine Street, Hanoi', N'555-333-4444', N'Mon-Sun: 11:30 AM - 10:30 PM', N'feedback@steakshop.com', N'Hanoi')
INSERT [dbo].[ContactUs] ([ID], [Details], [Address], [Phone], [OpenTime], [Email], [Location]) VALUES (6, N'Find us near universities', N'555 Cedar Street, Hanoi', N'555-777-8888', N'Mon-Sun: 10:00 AM - 11:00 PM', N'info@steakshop.com', N'Hanoi')
INSERT [dbo].[ContactUs] ([ID], [Details], [Address], [Phone], [OpenTime], [Email], [Location]) VALUES (7, N'Experience our hospitality', N'999 Birch Street, Hanoi', N'555-666-9999', N'Mon-Sun: 10:30 AM - 10:30 PM', N'contact@steakshop.com', N'Hanoi')
INSERT [dbo].[ContactUs] ([ID], [Details], [Address], [Phone], [OpenTime], [Email], [Location]) VALUES (8, N'Visit our Hanoi locations', N'333 Elm Street, Hanoi', N'555-222-3333', N'Mon-Sun: 11:00 AM - 10:00 PM', N'support@steakshop.com', N'Hanoi')
INSERT [dbo].[ContactUs] ([ID], [Details], [Address], [Phone], [OpenTime], [Email], [Location]) VALUES (9, N'Discover our delicious steaks', N'777 Oak Street, Hanoi', N'555-444-5555', N'Mon-Sun: 10:00 AM - 10:00 PM', N'reservations@steakshop.com', N'Hanoi')
INSERT [dbo].[ContactUs] ([ID], [Details], [Address], [Phone], [OpenTime], [Email], [Location]) VALUES (10, N'We look forward to serving you', N'222 Maple Street, Hanoi', N'555-888-1111', N'Mon-Sun: 11:30 AM - 10:30 PM', N'feedback@steakshop.com', N'Hanoi')
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([ID], [EventName]) VALUES (1, N'Steak Tasting Night')
INSERT [dbo].[Events] ([ID], [EventName]) VALUES (2, N'Wine Pairing Dinner')
INSERT [dbo].[Events] ([ID], [EventName]) VALUES (3, N'Chef''s Special Showcase')
INSERT [dbo].[Events] ([ID], [EventName]) VALUES (4, N'Weekend BBQ Extravaganza')
INSERT [dbo].[Events] ([ID], [EventName]) VALUES (5, N'Culinary Workshop')
INSERT [dbo].[Events] ([ID], [EventName]) VALUES (6, N'Live Music Nights')
INSERT [dbo].[Events] ([ID], [EventName]) VALUES (7, N'Happy Hour Specials')
INSERT [dbo].[Events] ([ID], [EventName]) VALUES (8, N'Family Sunday Brunch')
INSERT [dbo].[Events] ([ID], [EventName]) VALUES (9, N'Valentine''s Day Dinner')
INSERT [dbo].[Events] ([ID], [EventName]) VALUES (10, N'New Year''s Eve Celebration')
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Foods] ON 

INSERT [dbo].[Foods] ([ID], [FoodName], [Price], [Description], [Image], [C_ID]) VALUES (1, N'Classic T-Bone Steak', 28.9900, N'A classic T-bone steak cooked to perfection.', N'tbone.jpg', 1)
INSERT [dbo].[Foods] ([ID], [FoodName], [Price], [Description], [Image], [C_ID]) VALUES (2, N'Filet Mignon', 34.9900, N'A tender and juicy filet mignon with a savory sauce.', N'filetmignon.jpg', 1)
INSERT [dbo].[Foods] ([ID], [FoodName], [Price], [Description], [Image], [C_ID]) VALUES (3, N'Grilled Salmon', 22.9900, N'Grilled salmon fillet with lemon and herbs.', N'salmon.jpg', 2)
INSERT [dbo].[Foods] ([ID], [FoodName], [Price], [Description], [Image], [C_ID]) VALUES (4, N'Ribeye Steak', 25.9900, N'Juicy ribeye steak with a rich marinade.', N'ribeye.jpg', 1)
INSERT [dbo].[Foods] ([ID], [FoodName], [Price], [Description], [Image], [C_ID]) VALUES (5, N'Shrimp Scampi', 19.9900, N'Sauteed shrimp in garlic butter sauce.', N'shrimpscampi.jpg', 2)
INSERT [dbo].[Foods] ([ID], [FoodName], [Price], [Description], [Image], [C_ID]) VALUES (6, N'Chicken Alfredo', 18.9900, N'Creamy Alfredo sauce with grilled chicken.', N'chickenalfredo.jpg', 3)
INSERT [dbo].[Foods] ([ID], [FoodName], [Price], [Description], [Image], [C_ID]) VALUES (7, N'Lobster Tail', 38.9900, N'Grilled lobster tail with melted butter.', N'lobstertail.jpg', 2)
INSERT [dbo].[Foods] ([ID], [FoodName], [Price], [Description], [Image], [C_ID]) VALUES (8, N'Mushroom Risotto', 16.9900, N'Creamy mushroom risotto with Parmesan cheese.', N'mushroomrisotto.jpg', 3)
INSERT [dbo].[Foods] ([ID], [FoodName], [Price], [Description], [Image], [C_ID]) VALUES (9, N'Pork Chop', 21.9900, N'Grilled pork chop with apple chutney.', N'porkchop.jpg', 1)
INSERT [dbo].[Foods] ([ID], [FoodName], [Price], [Description], [Image], [C_ID]) VALUES (10, N'Vegetable Stir-Fry 1', 18.0000, N'Fresh vegetables stir-fried in a savory sauce.', N'vegetablestirfry.jpg', 3)
SET IDENTITY_INSERT [dbo].[Foods] OFF
GO
SET IDENTITY_INSERT [dbo].[Notifications] ON 

INSERT [dbo].[Notifications] ([Id], [Content], [IsRead], [Date]) VALUES (1, N'A new order. Username: user2, Time order: 2023-11-07 00:55:58, Address: 456 Elm St, Hanoi, Total Amount: 57.9800', 2, CAST(N'2023-11-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Notifications] ([Id], [Content], [IsRead], [Date]) VALUES (2, N'A new order. Username: user2, Time order: 2023-11-07 00:56:59, Address: 456 Elm St, Hanoi, Total Amount: 28.9900', 2, CAST(N'2023-11-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Notifications] ([Id], [Content], [IsRead], [Date]) VALUES (3, N'A new order. Username: user2, Time order: 2023-11-07 00:59:27, Address: 456 Elm St, Hanoi, Total Amount: 51.9800', 2, CAST(N'2023-11-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Notifications] ([Id], [Content], [IsRead], [Date]) VALUES (4, N'A new order. Username: user2, Time order: 2023-11-07 01:01:06, Address: 456 Elm St, Hanoi, Total Amount: 57.9800', 2, CAST(N'2023-11-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Notifications] ([Id], [Content], [IsRead], [Date]) VALUES (5, N'A new order. Username: user2, Time order: 2023-11-07 17:24:56, Address: 456 Elm St, Hanoi, Total Amount: 57.9800', 2, CAST(N'2023-11-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Notifications] ([Id], [Content], [IsRead], [Date]) VALUES (6, N'A new order. Username: user2, Time order: 2023-11-07 17:27:59, Address: 456 Elm St, Hanoi, Total Amount: 57.9800', 2, CAST(N'2023-11-07T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Notifications] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (4, CAST(N'2023-10-15' AS Date), N'123 Main St, Hanoi', 75.9800, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (5, CAST(N'2023-10-18' AS Date), N'456 Elm St, Hanoi', 125.9500, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (6, CAST(N'2023-10-20' AS Date), N'789 Oak St, Hanoi', 92.5000, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (7, CAST(N'2023-10-25' AS Date), N'101 Maple St, Hanoi', 148.7500, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (8, CAST(N'2023-10-28' AS Date), N'246 Pine St, Hanoi', 59.9800, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (9, CAST(N'2023-11-01' AS Date), N'555 Cedar St, Hanoi', 82.9900, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (10, CAST(N'2023-11-05' AS Date), N'999 Birch St, Hanoi', 103.5000, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (11, CAST(N'2023-11-10' AS Date), N'333 Elm St, Hanoi', 135.4500, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (12, CAST(N'2023-11-15' AS Date), N'777 Oak St, Hanoi', 67.9900, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (13, CAST(N'2023-11-18' AS Date), N'222 Maple St, Hanoi', 98.7500, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (15, CAST(N'2023-11-18' AS Date), N'asdasd', 80.0000, 2)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (17, CAST(N'2023-11-01' AS Date), N'123 Main St, Hanoi', 143.9500, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (18, CAST(N'2023-11-01' AS Date), N'123 Main St, Hanoi', 143.9500, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (19, CAST(N'2023-11-01' AS Date), N'123 Main St, Hanoi', 143.9500, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (21, CAST(N'2023-11-01' AS Date), N'123 Main St, Hanoi', 57.9800, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (22, CAST(N'2023-11-01' AS Date), N'123 Main St, Hanoi', 37.9800, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (23, CAST(N'2023-11-02' AS Date), N'123 Main St, Hanoi', 156.9500, 1)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (1036, CAST(N'2023-11-07' AS Date), N'456 Elm St, Hanoi', 57.9800, 2)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (1037, CAST(N'2023-11-07' AS Date), N'456 Elm St, Hanoi', 57.9800, 2)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (1038, CAST(N'2023-11-07' AS Date), N'456 Elm St, Hanoi', 57.9800, 2)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (1039, CAST(N'2023-11-06' AS Date), N'456 Elm St, Hanoi', 115.9600, 2)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (1040, CAST(N'2023-11-07' AS Date), N'456 Elm St, Hanoi', 69.9800, 2)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (1041, CAST(N'2023-11-07' AS Date), N'456 Elm St, Hanoi', 57.9800, 2)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (1042, CAST(N'2023-11-06' AS Date), N'456 Elm St, Hanoi', 28.9900, 2)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (1043, CAST(N'2023-11-07' AS Date), N'456 Elm St, Hanoi', 51.9800, 2)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (1044, CAST(N'2023-11-07' AS Date), N'456 Elm St, Hanoi', 57.9800, 2)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (1045, CAST(N'2023-11-07' AS Date), N'456 Elm St, Hanoi', 57.9800, 2)
INSERT [dbo].[Orders] ([ID], [Date], [Address], [TotalAmount], [UID]) VALUES (1046, CAST(N'2023-11-07' AS Date), N'456 Elm St, Hanoi', 57.9800, 2)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders_Chefs] ON 

INSERT [dbo].[Orders_Chefs] ([ID], [OID], [ChefID]) VALUES (5, 4, 1)
INSERT [dbo].[Orders_Chefs] ([ID], [OID], [ChefID]) VALUES (6, 4, 2)
INSERT [dbo].[Orders_Chefs] ([ID], [OID], [ChefID]) VALUES (7, 4, 3)
INSERT [dbo].[Orders_Chefs] ([ID], [OID], [ChefID]) VALUES (8, 5, 4)
INSERT [dbo].[Orders_Chefs] ([ID], [OID], [ChefID]) VALUES (9, 5, 5)
INSERT [dbo].[Orders_Chefs] ([ID], [OID], [ChefID]) VALUES (10, 6, 2)
INSERT [dbo].[Orders_Chefs] ([ID], [OID], [ChefID]) VALUES (11, 6, 1)
INSERT [dbo].[Orders_Chefs] ([ID], [OID], [ChefID]) VALUES (12, 7, 2)
INSERT [dbo].[Orders_Chefs] ([ID], [OID], [ChefID]) VALUES (13, 7, 3)
INSERT [dbo].[Orders_Chefs] ([ID], [OID], [ChefID]) VALUES (14, 7, 3)
SET IDENTITY_INSERT [dbo].[Orders_Chefs] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders_Foods] ON 

INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (2, 4, 2, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (3, 4, 2, 1)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (4, 5, 3, 3)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (5, 4, 4, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (6, 5, 5, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (7, 6, 6, 1)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (8, 7, 7, 1)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (9, 8, 8, 4)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (10, 9, 9, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (11, 10, 10, 3)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (13, 19, 1, 1)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (14, 19, 2, 1)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (15, 19, 3, 1)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (16, 19, 10, 1)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (17, 19, 5, 1)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (18, 19, 6, 1)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (20, 21, 1, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (21, 22, 6, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (22, 23, 1, 3)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (23, 23, 2, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (1035, 1036, 1, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (1036, 1037, 1, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (1037, 1038, 1, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (1038, 1039, 1, 4)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (1039, 1040, 2, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (1040, 1041, 1, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (1041, 1042, 1, 1)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (1042, 1043, 4, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (1043, 1044, 1, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (1044, 1045, 1, 2)
INSERT [dbo].[Orders_Foods] ([ID], [OID], [FID], [Quantity]) VALUES (1045, 1046, 1, 2)
SET IDENTITY_INSERT [dbo].[Orders_Foods] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Email], [Phone], [Address], [NumberOfLogins]) VALUES (1, N'admin', N'admin', 0, N'John Doe', N'johndoe@example.com', N'555-123-4567', N'123 Main St, Hanoi', 10)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Email], [Phone], [Address], [NumberOfLogins]) VALUES (2, N'user2', N'password2', 1, N'Jane Smith', N'janesmith@example.com', N'555-987-6543', N'456 Elm St, Hanoi', 1)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Email], [Phone], [Address], [NumberOfLogins]) VALUES (3, N'user3', N'password3', 1, N'Bob Johnson', N'bobjohnson@example.com', N'555-555-5555', N'789 Oak St, Hanoi', 1)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Email], [Phone], [Address], [NumberOfLogins]) VALUES (4, N'user4', N'password4', 1, N'Alice Brown', N'alicebrown@example.com', N'555-111-2222', N'101 Maple St, Hanoi', 2)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Email], [Phone], [Address], [NumberOfLogins]) VALUES (5, N'user5', N'password5', 1, N'Charlie Davis', N'charliedavis@example.com', N'555-333-4444', N'246 Pine St, Hanoi', 3)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Email], [Phone], [Address], [NumberOfLogins]) VALUES (6, N'user6', N'password6', 2, N'Eva White', N'evawhite@example.com', N'555-777-8888', N'555 Cedar St, Hanoi', 4)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Email], [Phone], [Address], [NumberOfLogins]) VALUES (7, N'user7', N'password7', 2, N'David Lee', N'davidlee@example.com', N'555-666-9999', N'999 Birch St, Hanoi', 5)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Email], [Phone], [Address], [NumberOfLogins]) VALUES (8, N'user8', N'password8', 2, N'Sophia Wilson', N'sophiawilson@example.com', N'555-222-3333', N'333 Elm St, Hanoi', 5)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Email], [Phone], [Address], [NumberOfLogins]) VALUES (9, N'user9', N'password9', 1, N'James Miller', N'jamesmiller@example.com', N'555-888-1111', N'777 Oak St, Hanoi', 5)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Email], [Phone], [Address], [NumberOfLogins]) VALUES (10, N'user10', N'password10', 1, N'Olivia Harris', N'oliviaharris@example.com', N'555-999-0000', N'222 Maple St, Hanoi', 5)
INSERT [dbo].[Users] ([ID], [Username], [Password], [Role], [Name], [Email], [Phone], [Address], [NumberOfLogins]) VALUES (19, N'test', N'123', 2, N'test', N'test@gmail.com', N'1234567890', N'test', 10)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkShifts] ON 

INSERT [dbo].[WorkShifts] ([ID], [WorkHours], [Shifts], [Holidays], [ChefID]) VALUES (1, 8.5, N'Morning', NULL, 1)
INSERT [dbo].[WorkShifts] ([ID], [WorkHours], [Shifts], [Holidays], [ChefID]) VALUES (2, 9, N'Evening', N'Christmas', 2)
INSERT [dbo].[WorkShifts] ([ID], [WorkHours], [Shifts], [Holidays], [ChefID]) VALUES (3, 8, N'Morning', N'New Year', 3)
INSERT [dbo].[WorkShifts] ([ID], [WorkHours], [Shifts], [Holidays], [ChefID]) VALUES (4, 9.5, N'Evening', NULL, 4)
INSERT [dbo].[WorkShifts] ([ID], [WorkHours], [Shifts], [Holidays], [ChefID]) VALUES (5, 8, N'Morning', N'Thanksgiving', 5)
INSERT [dbo].[WorkShifts] ([ID], [WorkHours], [Shifts], [Holidays], [ChefID]) VALUES (6, 9, N'Evening', NULL, 6)
INSERT [dbo].[WorkShifts] ([ID], [WorkHours], [Shifts], [Holidays], [ChefID]) VALUES (7, 8.5, N'Morning', N'Easter', 7)
INSERT [dbo].[WorkShifts] ([ID], [WorkHours], [Shifts], [Holidays], [ChefID]) VALUES (8, 8, N'Morning', NULL, 8)
INSERT [dbo].[WorkShifts] ([ID], [WorkHours], [Shifts], [Holidays], [ChefID]) VALUES (9, 9, N'Evening', N'Independence Day', 9)
INSERT [dbo].[WorkShifts] ([ID], [WorkHours], [Shifts], [Holidays], [ChefID]) VALUES (10, 8.5, N'Morning', NULL, 10)
INSERT [dbo].[WorkShifts] ([ID], [WorkHours], [Shifts], [Holidays], [ChefID]) VALUES (17, 8, N'Afternoon', N'Thanksgiving', 1)
SET IDENTITY_INSERT [dbo].[WorkShifts] OFF
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_Users] FOREIGN KEY([UID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [FK_Blog_Users]
GO
ALTER TABLE [dbo].[Blog_Image]  WITH CHECK ADD  CONSTRAINT [FK_Blog_Image_Blog] FOREIGN KEY([BID])
REFERENCES [dbo].[Blog] ([ID])
GO
ALTER TABLE [dbo].[Blog_Image] CHECK CONSTRAINT [FK_Blog_Image_Blog]
GO
ALTER TABLE [dbo].[Blogs_Categories]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_Categorys_Blog] FOREIGN KEY([BID])
REFERENCES [dbo].[Blog] ([ID])
GO
ALTER TABLE [dbo].[Blogs_Categories] CHECK CONSTRAINT [FK_Blogs_Categorys_Blog]
GO
ALTER TABLE [dbo].[Blogs_Categories]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_Categorys_BlogCategories] FOREIGN KEY([CID])
REFERENCES [dbo].[BlogCategories] ([ID])
GO
ALTER TABLE [dbo].[Blogs_Categories] CHECK CONSTRAINT [FK_Blogs_Categorys_BlogCategories]
GO
ALTER TABLE [dbo].[BookTable]  WITH CHECK ADD  CONSTRAINT [FK_BookTable_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([ID])
GO
ALTER TABLE [dbo].[BookTable] CHECK CONSTRAINT [FK_BookTable_Events]
GO
ALTER TABLE [dbo].[BookTable]  WITH CHECK ADD  CONSTRAINT [FK_BookTable_Users] FOREIGN KEY([UID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[BookTable] CHECK CONSTRAINT [FK_BookTable_Users]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Foods] FOREIGN KEY([FoodId])
REFERENCES [dbo].[Foods] ([ID])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Foods]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Users]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Blog] FOREIGN KEY([BID])
REFERENCES [dbo].[Blog] ([ID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Blog]
GO
ALTER TABLE [dbo].[Foods]  WITH CHECK ADD  CONSTRAINT [FK_Foods_Categories] FOREIGN KEY([C_ID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Foods] CHECK CONSTRAINT [FK_Foods_Categories]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Orders_Chefs]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Chefs_Chefs] FOREIGN KEY([ChefID])
REFERENCES [dbo].[Chefs] ([ID])
GO
ALTER TABLE [dbo].[Orders_Chefs] CHECK CONSTRAINT [FK_Orders_Chefs_Chefs]
GO
ALTER TABLE [dbo].[Orders_Chefs]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Chefs_Orders] FOREIGN KEY([OID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[Orders_Chefs] CHECK CONSTRAINT [FK_Orders_Chefs_Orders]
GO
ALTER TABLE [dbo].[Orders_Foods]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Foods_Foods] FOREIGN KEY([FID])
REFERENCES [dbo].[Foods] ([ID])
GO
ALTER TABLE [dbo].[Orders_Foods] CHECK CONSTRAINT [FK_Orders_Foods_Foods]
GO
ALTER TABLE [dbo].[Orders_Foods]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Foods_Orders] FOREIGN KEY([OID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[Orders_Foods] CHECK CONSTRAINT [FK_Orders_Foods_Orders]
GO
ALTER TABLE [dbo].[ScheduleMarketing]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleMarketing_MarketingBudget] FOREIGN KEY([Id_MB])
REFERENCES [dbo].[MarketingBudget] ([Id])
GO
ALTER TABLE [dbo].[ScheduleMarketing] CHECK CONSTRAINT [FK_ScheduleMarketing_MarketingBudget]
GO
ALTER TABLE [dbo].[WorkShifts]  WITH CHECK ADD  CONSTRAINT [FK_WorkShifts_Chefs] FOREIGN KEY([ChefID])
REFERENCES [dbo].[Chefs] ([ID])
GO
ALTER TABLE [dbo].[WorkShifts] CHECK CONSTRAINT [FK_WorkShifts_Chefs]
GO

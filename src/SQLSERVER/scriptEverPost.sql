USE [master]
GO
/****** Object:  Database [EverPost]    Script Date: 3/04/2025 2:26:48 a. m. ******/
CREATE DATABASE [EverPost]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EverPost', FILENAME = N'C:\Users\Admin\EverPost.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EverPost_log', FILENAME = N'C:\Users\Admin\EverPost_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EverPost] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EverPost].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EverPost] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EverPost] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EverPost] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EverPost] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EverPost] SET ARITHABORT OFF 
GO
ALTER DATABASE [EverPost] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EverPost] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EverPost] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EverPost] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EverPost] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EverPost] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EverPost] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EverPost] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EverPost] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EverPost] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EverPost] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EverPost] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EverPost] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EverPost] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EverPost] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EverPost] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EverPost] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EverPost] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EverPost] SET  MULTI_USER 
GO
ALTER DATABASE [EverPost] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EverPost] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EverPost] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EverPost] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EverPost] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EverPost] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EverPost] SET QUERY_STORE = OFF
GO
USE [EverPost]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/04/2025 2:26:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 3/04/2025 2:26:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategorieId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](3) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategorieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 3/04/2025 2:26:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[PostId] [int] NOT NULL,
	[Status] [nvarchar](3) NOT NULL,
	[UserId] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 3/04/2025 2:26:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[Status] [nvarchar](3) NOT NULL,
	[TotalComments] [int] NOT NULL,
	[ImageRoute] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelPostCategories]    Script Date: 3/04/2025 2:26:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelPostCategories](
	[RelId] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[CategorieId] [int] NOT NULL,
	[Status] [nvarchar](3) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RelPostCategories] PRIMARY KEY CLUSTERED 
(
	[RelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/04/2025 2:26:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Mail] [nvarchar](100) NOT NULL,
	[Pass] [nvarchar](255) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[Status] [nvarchar](3) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_PostId]    Script Date: 3/04/2025 2:26:49 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Comments_PostId] ON [dbo].[Comments]
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_UserId]    Script Date: 3/04/2025 2:26:49 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Comments_UserId] ON [dbo].[Comments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Posts_UserId]    Script Date: 3/04/2025 2:26:49 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Posts_UserId] ON [dbo].[Posts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RelPostCategories_CategorieId]    Script Date: 3/04/2025 2:26:49 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_RelPostCategories_CategorieId] ON [dbo].[RelPostCategories]
(
	[CategorieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RelPostCategories_PostId]    Script Date: 3/04/2025 2:26:49 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_RelPostCategories_PostId] ON [dbo].[RelPostCategories]
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([PostId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Posts_PostId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users_UserId]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Users_UserId]
GO
ALTER TABLE [dbo].[RelPostCategories]  WITH CHECK ADD  CONSTRAINT [FK_RelPostCategories_Categories_CategorieId] FOREIGN KEY([CategorieId])
REFERENCES [dbo].[Categories] ([CategorieId])
GO
ALTER TABLE [dbo].[RelPostCategories] CHECK CONSTRAINT [FK_RelPostCategories_Categories_CategorieId]
GO
ALTER TABLE [dbo].[RelPostCategories]  WITH CHECK ADD  CONSTRAINT [FK_RelPostCategories_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([PostId])
GO
ALTER TABLE [dbo].[RelPostCategories] CHECK CONSTRAINT [FK_RelPostCategories_Posts_PostId]
GO
/****** Object:  StoredProcedure [dbo].[Sp_CategorieRelation]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_CategorieRelation]
    @PostId INT,
    @CategorieId INT
AS
BEGIN
   SET NOCOUNT ON;

   DECLARE @IdInserted INT;
   Insert into RelPostCategories (PostId,CategorieId,Status,DateCreated)
   values (@PostId,@CategorieId,'ACT',GETDATE());
   Set @IdInserted = SCOPE_IDENTITY();

   Select * From RelPostCategories where RelId = @IdInserted

END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_CreateComment]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_CreateComment]
	@Content Varchar(300),
    @PostId INT,
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    declare @IdInserted int;
    
    INSERT INTO Comments(Content, PostId,Status,UserId,DateCreated)
    VALUES (@Content, @PostId,'ACT',  @UserId, GETDATE());

	 UPDATE Posts
		SET TotalComments = TotalComments + 1
		WHERE PostId = @PostId;

    Set @IdInserted = SCOPE_IDENTITY();
	Select * From Comments where CommentId = @IdInserted
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_CreatePost]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_CreatePost]
    @UserID INT,
    @tittle Varchar(100),
	@Description Varchar(250),
	@ImageRoute Varchar(100)
AS
BEGIN
   SET NOCOUNT ON;

   DECLARE @IdInserted INT;
   Insert into Posts (UserId,Title,Description,DateCreated,Status,TotalComments,ImageRoute)
   values (@UserID, @tittle, @Description, GETDATE(),'ACT',0,@ImageRoute);

   Set @IdInserted = SCOPE_IDENTITY();
   Select * From Posts where PostId = @IdInserted

END;

GO
/****** Object:  StoredProcedure [dbo].[Sp_CreateUser]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_CreateUser]
    @UserName VARCHAR(100),
    @Mail VARCHAR(100),
    @Pass VARCHAR(128)
AS
BEGIN
    SET NOCOUNT ON;
    declare @IdInserted int;
    
    IF EXISTS (SELECT top 1 * FROM Users WHERE Mail = @Mail)
    BEGIN
        RETURN NULL; 
    END
    
    INSERT INTO Users (UserName, Mail, Pass, DateCreated, Status)
    VALUES (@UserName, @Mail, @Pass, GETDATE(), 'ACT');

    Set @IdInserted = SCOPE_IDENTITY();
	Select * From Users where UserId = @IdInserted

END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_DeletePost]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_DeletePost]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

	Update Posts Set Status = 'INA'   where PostId = @Id and Status = 'ACT'

	select * From  Posts where PostId = @Id
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_EditPost]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Sp_EditPost]
    @Id INT,
	@Title Varchar(50),
	@Descripcion Varchar(250)
AS
BEGIN
    SET NOCOUNT ON;

	UPDATE Posts
    SET 
    Title = CASE WHEN @Title IS NOT NULL AND @Title <> '' THEN @Title ELSE Title END, 
    Description = CASE WHEN @Descripcion IS NOT NULL AND @Descripcion <> '' THEN @Descripcion ELSE Description END
    WHERE PostId = @Id AND Status = 'ACT';

	SELECT * FROM Posts WHERE PostId = @Id AND Status = 'ACT';

END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetCategorieRelation]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Sp_GetCategorieRelation]
    @PostId INT
AS
BEGIN
   SET NOCOUNT ON;
   Select * From RelPostCategories where PostId = @PostId and Status = 'ACT'
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetCategories]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Sp_GetCategories]
AS
BEGIN
    SET NOCOUNT ON;
	Select * From Categories where Status = 'ACT'
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetCommentsPagined]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_GetCommentsPagined]
	@PostId INT,
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;


    DECLARE @TotalPosts INT;
    SELECT @TotalPosts = COUNT(*) FROM Comments;


    SELECT 
        *
    FROM Comments
	Where Status = 'ACT' and PostId = @PostId
    ORDER BY DateCreated DESC
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetPostById]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Sp_GetPostById]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

	Select * from Posts  where PostId = @Id and Status = 'ACT'
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetPostsPaginated]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_GetPostsPaginated]
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;


    DECLARE @TotalPosts INT;
    SELECT @TotalPosts = COUNT(*) FROM Posts;


    SELECT 
        *
    FROM Posts
	Where Status = 'ACT'
    ORDER BY DateCreated DESC
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END;
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUserByCredentials]    Script Date: 3/04/2025 2:26:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_GetUserByCredentials]
    @Mail VARCHAR(100),
    @Pass VARCHAR(128)
AS
BEGIN
    SET NOCOUNT ON;
    
	SELECT * FROM Users WHERE Mail = @Mail and Pass = @Pass

END;
GO
USE [master]
GO
ALTER DATABASE [EverPost] SET  READ_WRITE 
GO

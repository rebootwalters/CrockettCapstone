USE [master]
GO
/****** Object:  Database [Crockett]    Script Date: 10/3/2019 2:57:53 PM ******/
CREATE DATABASE [Crockett]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Crockett', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Crockett.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Crockett_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Crockett_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Crockett] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Crockett].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Crockett] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Crockett] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Crockett] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Crockett] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Crockett] SET ARITHABORT OFF 
GO
ALTER DATABASE [Crockett] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Crockett] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Crockett] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Crockett] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Crockett] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Crockett] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Crockett] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Crockett] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Crockett] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Crockett] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Crockett] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Crockett] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Crockett] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Crockett] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Crockett] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Crockett] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Crockett] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Crockett] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Crockett] SET  MULTI_USER 
GO
ALTER DATABASE [Crockett] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Crockett] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Crockett] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Crockett] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Crockett] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Crockett] SET QUERY_STORE = OFF
GO
USE [Crockett]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/3/2019 2:57:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](200) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (1, N'Administrator')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'Changed')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (3, N'Medium')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (4, N'zzz')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (5, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (6, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (7, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (8, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (9, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (10, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (11, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (12, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (13, N'yyy')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (14, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (15, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (16, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (17, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (18, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (19, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (20, N'ZZZ')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (21, N'XXX')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (22, N'XXX')
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  StoredProcedure [dbo].[RoleCreate]    Script Date: 10/3/2019 2:57:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[RoleCreate]
-- use this one when your primary key is not an integer
@RoleName nvarchar(200),
@RoleID int output
as
begin
  insert into roles (RoleName) values (@RoleName)
  select @RoleID = @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[RoleCreateIDOutput]    Script Date: 10/3/2019 2:57:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RoleCreateIDOutput]
-- use this one when your primary key is not an integer
@RoleName nvarchar(200),
@RoleID int output
as
begin
  insert into roles (RoleName) values (@RoleName)
  select @RoleID = @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[RoleCreateIDReturned]    Script Date: 10/3/2019 2:57:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[RoleCreateIDReturned]
-- use this one when your primary key is an integer
@RoleName nvarchar(200)


as
begin
  declare @data int
  insert into roles (RoleName) values (@RoleName)
 
  SELECT	'Return Value' = @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[RoleDelete]    Script Date: 10/3/2019 2:57:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RoleDelete]
@RoleID int
as
begin
   delete from Roles
   where RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[RoleFindByID]    Script Date: 10/3/2019 2:57:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RoleFindByID]
@RoleID int
as
begin
  select RoleID, RoleName from Roles
  where RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[RolesGetAll]    Script Date: 10/3/2019 2:57:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc  [dbo].[RolesGetAll]
@skip int,
@take int
as
begin
select RoleID, RoleName from Roles
order by RoleID
offset @skip rows 
fetch next @take rows only
end
GO
/****** Object:  StoredProcedure [dbo].[RolesObtainCount]    Script Date: 10/3/2019 2:57:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RolesObtainCount]
as
begin
  select count(*) from Roles
end
GO
/****** Object:  StoredProcedure [dbo].[RoleUpdateJust]    Script Date: 10/3/2019 2:57:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RoleUpdateJust]
@RoleID int,
@RoleName nvarchar(200)
as
begin
   update roles set RoleName = @Rolename
   where RoleID = @RoleID
end
GO
/****** Object:  StoredProcedure [dbo].[RoleUpdateSafe]    Script Date: 10/3/2019 2:57:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[RoleUpdateSafe]
@RoleID int,
@OldRoleName nvarchar(200),
@NewRoleName nvarchar(200)
as
begin
   update roles set RoleName = @NewRolename
   where RoleID = @RoleID and 
       RoleName = @OldRoleName
end
GO
USE [master]
GO
ALTER DATABASE [Crockett] SET  READ_WRITE 
GO

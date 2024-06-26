USE [master]
GO

/****** Object:  Database [HMO]    Script Date: 28/03/2024 11:59:35 ******/
CREATE DATABASE [HMO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HMO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HMO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HMO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HMO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HMO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [HMO] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [HMO] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [HMO] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [HMO] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [HMO] SET ARITHABORT OFF 
GO

ALTER DATABASE [HMO] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [HMO] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [HMO] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [HMO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [HMO] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [HMO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [HMO] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [HMO] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [HMO] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [HMO] SET  DISABLE_BROKER 
GO

ALTER DATABASE [HMO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [HMO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [HMO] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [HMO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [HMO] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [HMO] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [HMO] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [HMO] SET RECOVERY FULL 
GO

ALTER DATABASE [HMO] SET  MULTI_USER 
GO

ALTER DATABASE [HMO] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [HMO] SET DB_CHAINING OFF 
GO

ALTER DATABASE [HMO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [HMO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [HMO] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [HMO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [HMO] SET QUERY_STORE = OFF
GO

ALTER DATABASE [HMO] SET  READ_WRITE 
GO


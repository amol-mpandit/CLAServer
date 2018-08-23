USE [master]
GO

/****** Object:  Database [cla]    Script Date: 05/15/2018 23:31:18 ******/
CREATE DATABASE [cla] ON  PRIMARY 
( NAME = N'cla', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\cla.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'cla_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\cla_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [cla] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cla].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [cla] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [cla] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [cla] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [cla] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [cla] SET ARITHABORT OFF 
GO

ALTER DATABASE [cla] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [cla] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [cla] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [cla] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [cla] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [cla] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [cla] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [cla] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [cla] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [cla] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [cla] SET  DISABLE_BROKER 
GO

ALTER DATABASE [cla] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [cla] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [cla] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [cla] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [cla] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [cla] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [cla] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [cla] SET  READ_WRITE 
GO

ALTER DATABASE [cla] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [cla] SET  MULTI_USER 
GO

ALTER DATABASE [cla] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [cla] SET DB_CHAINING OFF 
GO



-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/30/2020 10:06:08
-- Generated from EDMX file: C:\test_rep\WPF MSSQL\Students\Students\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [StudentsDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Assessmen__Indek__0F624AF8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssessmentsTable] DROP CONSTRAINT [FK__Assessmen__Indek__0F624AF8];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AssessmentsTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssessmentsTable];
GO
IF OBJECT_ID(N'[dbo].[StudentsTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentsTable];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AssessmentsTable'
CREATE TABLE [dbo].[AssessmentsTable] (
    [Id] int  NOT NULL,
    [Assessment] decimal(18,0)  NOT NULL,
    [IndeksID] int  NULL
);
GO

-- Creating table 'StudentsTable'
CREATE TABLE [dbo].[StudentsTable] (
    [Id] int  NOT NULL,
    [StudentName] varchar(30)  NOT NULL,
    [StudentSurname] varchar(30)  NOT NULL,
    [DateOfBirt] datetime  NOT NULL,
    [IndexID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AssessmentsTable'
ALTER TABLE [dbo].[AssessmentsTable]
ADD CONSTRAINT [PK_AssessmentsTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentsTable'
ALTER TABLE [dbo].[StudentsTable]
ADD CONSTRAINT [PK_StudentsTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IndeksID] in table 'AssessmentsTable'
ALTER TABLE [dbo].[AssessmentsTable]
ADD CONSTRAINT [FK__Assessmen__Indek__0F624AF8]
    FOREIGN KEY ([IndeksID])
    REFERENCES [dbo].[StudentsTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Assessmen__Indek__0F624AF8'
CREATE INDEX [IX_FK__Assessmen__Indek__0F624AF8]
ON [dbo].[AssessmentsTable]
    ([IndeksID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/17/2015 14:55:10
-- Generated from EDMX file: C:\Users\lasts\Documents\Visual Studio 2015\Projects\WebApplication\Model\ELearning.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Elearning];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Class_Course_Class]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Class_Course] DROP CONSTRAINT [FK_Class_Course_Class];
GO
IF OBJECT_ID(N'[dbo].[FK_Class_Course_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Class_Course] DROP CONSTRAINT [FK_Class_Course_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_Action_UserCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Action_UserCourse] DROP CONSTRAINT [FK_Action_UserCourse_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_Quiz]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Quiz] DROP CONSTRAINT [FK_Project_Quiz];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_Project_User];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Login]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Login] DROP CONSTRAINT [FK_User_Login];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Role] DROP CONSTRAINT [FK_User_Role_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Role] DROP CONSTRAINT [FK_User_Role_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Action_UserCourse_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Action_UserCourse] DROP CONSTRAINT [FK_Action_UserCourse_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Action_UserQuiz_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Action_UserQuiz] DROP CONSTRAINT [FK_Action_UserQuiz_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Action_UserQuiz_Quiz]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Action_UserQuiz] DROP CONSTRAINT [FK_Action_UserQuiz_Quiz];
GO
IF OBJECT_ID(N'[dbo].[FK_Course_Courseware]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Course] DROP CONSTRAINT [FK_Course_Courseware];
GO
IF OBJECT_ID(N'[dbo].[FK_Quiz_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Quiz] DROP CONSTRAINT [FK_Quiz_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_Quiz_Paper]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Quiz] DROP CONSTRAINT [FK_Quiz_Paper];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_Class]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Class] DROP CONSTRAINT [FK_Project_Class];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Class_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Class] DROP CONSTRAINT [FK_User_Class_User];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Class_Class]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Class] DROP CONSTRAINT [FK_User_Class_Class];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Claim]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Claim] DROP CONSTRAINT [FK_User_Claim];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_Course_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project_Course] DROP CONSTRAINT [FK_Project_Course_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_Course_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project_Course] DROP CONSTRAINT [FK_Project_Course_Course];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Course]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Course];
GO
IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO
IF OBJECT_ID(N'[dbo].[Class]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Class];
GO
IF OBJECT_ID(N'[dbo].[Courseware]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courseware];
GO
IF OBJECT_ID(N'[dbo].[Paper]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paper];
GO
IF OBJECT_ID(N'[dbo].[Quiz]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Quiz];
GO
IF OBJECT_ID(N'[dbo].[Claim]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Claim];
GO
IF OBJECT_ID(N'[dbo].[Login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Login];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Action_UserCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Action_UserCourse];
GO
IF OBJECT_ID(N'[dbo].[Action_UserQuiz]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Action_UserQuiz];
GO
IF OBJECT_ID(N'[dbo].[Class_Course]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Class_Course];
GO
IF OBJECT_ID(N'[dbo].[User_Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Role];
GO
IF OBJECT_ID(N'[dbo].[User_Class]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Class];
GO
IF OBJECT_ID(N'[dbo].[Project_Course]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project_Course];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Course'
CREATE TABLE [dbo].[Course] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CoursewareId] int  NULL
);
GO

-- Creating table 'Project'
CREATE TABLE [dbo].[Project] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Class'
CREATE TABLE [dbo].[Class] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] int  NOT NULL
);
GO

-- Creating table 'Courseware'
CREATE TABLE [dbo].[Courseware] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Paper'
CREATE TABLE [dbo].[Paper] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Quiz'
CREATE TABLE [dbo].[Quiz] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] int  NOT NULL,
    [CourseId] int  NULL,
    [PaperId] int  NULL
);
GO

-- Creating table 'Claim'
CREATE TABLE [dbo].[Claim] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'Login'
CREATE TABLE [dbo].[Login] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [ProjectId] int  NOT NULL
);
GO

-- Creating table 'Action_UserCourse'
CREATE TABLE [dbo].[Action_UserCourse] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [CourseId] int  NOT NULL
);
GO

-- Creating table 'Action_UserQuiz'
CREATE TABLE [dbo].[Action_UserQuiz] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [QuizId] int  NOT NULL
);
GO

-- Creating table 'Class_Course'
CREATE TABLE [dbo].[Class_Course] (
    [Class_Id] int  NOT NULL,
    [Course_Id] int  NOT NULL
);
GO

-- Creating table 'User_Role'
CREATE TABLE [dbo].[User_Role] (
    [Role_Id] nvarchar(128)  NOT NULL,
    [User_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'User_Class'
CREATE TABLE [dbo].[User_Class] (
    [User_Id] nvarchar(128)  NOT NULL,
    [Class_Id] int  NOT NULL
);
GO

-- Creating table 'Project_Course'
CREATE TABLE [dbo].[Project_Course] (
    [Project_Id] int  NOT NULL,
    [Course_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Course'
ALTER TABLE [dbo].[Course]
ADD CONSTRAINT [PK_Course]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [PK_Project]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Class'
ALTER TABLE [dbo].[Class]
ADD CONSTRAINT [PK_Class]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Courseware'
ALTER TABLE [dbo].[Courseware]
ADD CONSTRAINT [PK_Courseware]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Paper'
ALTER TABLE [dbo].[Paper]
ADD CONSTRAINT [PK_Paper]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Quiz'
ALTER TABLE [dbo].[Quiz]
ADD CONSTRAINT [PK_Quiz]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Claim'
ALTER TABLE [dbo].[Claim]
ADD CONSTRAINT [PK_Claim]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'Login'
ALTER TABLE [dbo].[Login]
ADD CONSTRAINT [PK_Login]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Action_UserCourse'
ALTER TABLE [dbo].[Action_UserCourse]
ADD CONSTRAINT [PK_Action_UserCourse]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Action_UserQuiz'
ALTER TABLE [dbo].[Action_UserQuiz]
ADD CONSTRAINT [PK_Action_UserQuiz]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Class_Id], [Course_Id] in table 'Class_Course'
ALTER TABLE [dbo].[Class_Course]
ADD CONSTRAINT [PK_Class_Course]
    PRIMARY KEY CLUSTERED ([Class_Id], [Course_Id] ASC);
GO

-- Creating primary key on [Role_Id], [User_Id] in table 'User_Role'
ALTER TABLE [dbo].[User_Role]
ADD CONSTRAINT [PK_User_Role]
    PRIMARY KEY CLUSTERED ([Role_Id], [User_Id] ASC);
GO

-- Creating primary key on [User_Id], [Class_Id] in table 'User_Class'
ALTER TABLE [dbo].[User_Class]
ADD CONSTRAINT [PK_User_Class]
    PRIMARY KEY CLUSTERED ([User_Id], [Class_Id] ASC);
GO

-- Creating primary key on [Project_Id], [Course_Id] in table 'Project_Course'
ALTER TABLE [dbo].[Project_Course]
ADD CONSTRAINT [PK_Project_Course]
    PRIMARY KEY CLUSTERED ([Project_Id], [Course_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Class_Id] in table 'Class_Course'
ALTER TABLE [dbo].[Class_Course]
ADD CONSTRAINT [FK_Class_Course_Class]
    FOREIGN KEY ([Class_Id])
    REFERENCES [dbo].[Class]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Course_Id] in table 'Class_Course'
ALTER TABLE [dbo].[Class_Course]
ADD CONSTRAINT [FK_Class_Course_Course]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[Course]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Class_Course_Course'
CREATE INDEX [IX_FK_Class_Course_Course]
ON [dbo].[Class_Course]
    ([Course_Id]);
GO

-- Creating foreign key on [CourseId] in table 'Action_UserCourse'
ALTER TABLE [dbo].[Action_UserCourse]
ADD CONSTRAINT [FK_Action_UserCourse_Course]
    FOREIGN KEY ([CourseId])
    REFERENCES [dbo].[Course]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_UserCourse_Course'
CREATE INDEX [IX_FK_Action_UserCourse_Course]
ON [dbo].[Action_UserCourse]
    ([CourseId]);
GO

-- Creating foreign key on [ProjectId] in table 'Quiz'
ALTER TABLE [dbo].[Quiz]
ADD CONSTRAINT [FK_Project_Quiz]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_Quiz'
CREATE INDEX [IX_FK_Project_Quiz]
ON [dbo].[Quiz]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_Project_User]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_User'
CREATE INDEX [IX_FK_Project_User]
ON [dbo].[User]
    ([ProjectId]);
GO

-- Creating foreign key on [UserId] in table 'Login'
ALTER TABLE [dbo].[Login]
ADD CONSTRAINT [FK_User_Login]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Login'
CREATE INDEX [IX_FK_User_Login]
ON [dbo].[Login]
    ([UserId]);
GO

-- Creating foreign key on [Role_Id] in table 'User_Role'
ALTER TABLE [dbo].[User_Role]
ADD CONSTRAINT [FK_User_Role_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_Id] in table 'User_Role'
ALTER TABLE [dbo].[User_Role]
ADD CONSTRAINT [FK_User_Role_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Role_User'
CREATE INDEX [IX_FK_User_Role_User]
ON [dbo].[User_Role]
    ([User_Id]);
GO

-- Creating foreign key on [UserId] in table 'Action_UserCourse'
ALTER TABLE [dbo].[Action_UserCourse]
ADD CONSTRAINT [FK_Action_UserCourse_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_UserCourse_User'
CREATE INDEX [IX_FK_Action_UserCourse_User]
ON [dbo].[Action_UserCourse]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Action_UserQuiz'
ALTER TABLE [dbo].[Action_UserQuiz]
ADD CONSTRAINT [FK_Action_UserQuiz_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_UserQuiz_User'
CREATE INDEX [IX_FK_Action_UserQuiz_User]
ON [dbo].[Action_UserQuiz]
    ([UserId]);
GO

-- Creating foreign key on [QuizId] in table 'Action_UserQuiz'
ALTER TABLE [dbo].[Action_UserQuiz]
ADD CONSTRAINT [FK_Action_UserQuiz_Quiz]
    FOREIGN KEY ([QuizId])
    REFERENCES [dbo].[Quiz]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_UserQuiz_Quiz'
CREATE INDEX [IX_FK_Action_UserQuiz_Quiz]
ON [dbo].[Action_UserQuiz]
    ([QuizId]);
GO

-- Creating foreign key on [CoursewareId] in table 'Course'
ALTER TABLE [dbo].[Course]
ADD CONSTRAINT [FK_Course_Courseware]
    FOREIGN KEY ([CoursewareId])
    REFERENCES [dbo].[Courseware]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Course_Courseware'
CREATE INDEX [IX_FK_Course_Courseware]
ON [dbo].[Course]
    ([CoursewareId]);
GO

-- Creating foreign key on [CourseId] in table 'Quiz'
ALTER TABLE [dbo].[Quiz]
ADD CONSTRAINT [FK_Quiz_Course]
    FOREIGN KEY ([CourseId])
    REFERENCES [dbo].[Course]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Quiz_Course'
CREATE INDEX [IX_FK_Quiz_Course]
ON [dbo].[Quiz]
    ([CourseId]);
GO

-- Creating foreign key on [PaperId] in table 'Quiz'
ALTER TABLE [dbo].[Quiz]
ADD CONSTRAINT [FK_Quiz_Paper]
    FOREIGN KEY ([PaperId])
    REFERENCES [dbo].[Paper]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Quiz_Paper'
CREATE INDEX [IX_FK_Quiz_Paper]
ON [dbo].[Quiz]
    ([PaperId]);
GO

-- Creating foreign key on [ProjectId] in table 'Class'
ALTER TABLE [dbo].[Class]
ADD CONSTRAINT [FK_Project_Class]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_Class'
CREATE INDEX [IX_FK_Project_Class]
ON [dbo].[Class]
    ([ProjectId]);
GO

-- Creating foreign key on [User_Id] in table 'User_Class'
ALTER TABLE [dbo].[User_Class]
ADD CONSTRAINT [FK_User_Class_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Class_Id] in table 'User_Class'
ALTER TABLE [dbo].[User_Class]
ADD CONSTRAINT [FK_User_Class_Class]
    FOREIGN KEY ([Class_Id])
    REFERENCES [dbo].[Class]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Class_Class'
CREATE INDEX [IX_FK_User_Class_Class]
ON [dbo].[User_Class]
    ([Class_Id]);
GO

-- Creating foreign key on [UserId] in table 'Claim'
ALTER TABLE [dbo].[Claim]
ADD CONSTRAINT [FK_User_Claim]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Claim'
CREATE INDEX [IX_FK_User_Claim]
ON [dbo].[Claim]
    ([UserId]);
GO

-- Creating foreign key on [Project_Id] in table 'Project_Course'
ALTER TABLE [dbo].[Project_Course]
ADD CONSTRAINT [FK_Project_Course_Project]
    FOREIGN KEY ([Project_Id])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Course_Id] in table 'Project_Course'
ALTER TABLE [dbo].[Project_Course]
ADD CONSTRAINT [FK_Project_Course_Course]
    FOREIGN KEY ([Course_Id])
    REFERENCES [dbo].[Course]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Project_Course_Course'
CREATE INDEX [IX_FK_Project_Course_Course]
ON [dbo].[Project_Course]
    ([Course_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Course] (
    [CourseID] int NOT NULL,
    [Title] nvarchar(max) NULL,
    [Credits] int NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY ([CourseID])
);

GO

CREATE TABLE [Student] (
    [ID] int NOT NULL IDENTITY,
    [LastName] nvarchar(max) NULL,
    [FirstMidName] nvarchar(max) NULL,
    [EnrollmentDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [StudentVM] (
    [ID] int NOT NULL IDENTITY,
    [LastName] nvarchar(max) NULL,
    [FirstMidName] nvarchar(max) NULL,
    [EnrollmentDate] datetime2 NOT NULL,
    CONSTRAINT [PK_StudentVM] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [Enrollment] (
    [EnrollmentID] int NOT NULL IDENTITY,
    [CourseID] int NOT NULL,
    [StudentID] int NOT NULL,
    [Grade] int NULL,
    CONSTRAINT [PK_Enrollment] PRIMARY KEY ([EnrollmentID]),
    CONSTRAINT [FK_Enrollment_Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [Course] ([CourseID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Enrollment_Student_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [Student] ([ID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Enrollment_CourseID] ON [Enrollment] ([CourseID]);

GO

CREATE INDEX [IX_Enrollment_StudentID] ON [Enrollment] ([StudentID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190811110719_InitialCreate', N'2.1.11-servicing-32099');

GO


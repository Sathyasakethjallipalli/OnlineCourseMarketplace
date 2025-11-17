CREATE DATABASE OnlineCourseMarketplace;
GO

USE OnlineCourseMarketplace;
GO

CREATE TABLE [User] (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    IsAdmin BIT NOT NULL DEFAULT 0
);

CREATE TABLE [Course] (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(1000),
    Price DECIMAL(10,2) NOT NULL
);

CREATE TABLE [Enrollment] (
    EnrollmentId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT REFERENCES [User](UserId),
    CourseId INT REFERENCES [Course](CourseId),
    EnrolledOn DATETIME NOT NULL DEFAULT GETDATE()
);
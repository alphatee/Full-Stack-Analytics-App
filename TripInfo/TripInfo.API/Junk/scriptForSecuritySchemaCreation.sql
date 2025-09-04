USE [TripInfoDb]
GO
CREATE SCHEMA [Security]
GO
CREATE TABLE [TripInfoDb].[Security].[User]
(
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [UserName] NVARCHAR(50) NOT NULL,
    [Password] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);
GO
CREATE TABLE [TripInfoDb].[Security].[UserClaim]
(
    [ClaimId] UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [ClaimType] NVARCHAR(255) NOT NULL,
    [ClaimValue] NVARCHAR(255) NOT NULL,
    CONSTRAINT [PK_UserClaim] PRIMARY KEY CLUSTERED ([ClaimId] ASC),
    CONSTRAINT [FK_UserClaim_User] FOREIGN KEY ([UserId]) REFERENCES [TripInfoDb].[Security].[User] ([UserId])
);


-- Insert data
INSERT INTO [TripInfoDb].[Security].[User] ([UserId], [UserName], [Password])
VALUES
    (NEWID(), 'alphatee', 'P@ssw0rd'),
    (NEWID(), 'BJones', 'P@ssw0rd');

INSERT INTO [TripInfoDb].[Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue])
VALUES
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'alphatee'), 'CanAddProduct', 'false'),
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'alphatee'), 'CanAccessProducts', 'true'),
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'alphatee'), 'CanAddProduct', 'true'),
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'alphatee'), 'CanSaveProduct', 'true'),
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'alphatee'), 'CanAccessCategories', 'true'),
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'alphatee'), 'CanAddCategory', 'true'),
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'BJones'), 'CanAccessProducts', 'false'),
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'BJones'), 'CanAddCategory', 'true'),
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'BJones'), 'CanAccessCategories', 'true'),
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'BJones'), 'CanAccessSettings', 'true'),
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'alphatee'), 'CanAccessSettings', 'true');


-- Insert the new claim for alphatee
INSERT INTO [TripInfoDb].[Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue])
VALUES
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'alphatee'), 'CanAccessTravelDetails', 'true');

-- Insert the new claim for BJones
INSERT INTO [TripInfoDb].[Security].[UserClaim] ([ClaimId], [UserId], [ClaimType], [ClaimValue])
VALUES
    (NEWID(), (SELECT [UserId] FROM [TripInfoDb].[Security].[User] WHERE [UserName] = 'BJones'), 'CanAccessTravelDetails', 'false');

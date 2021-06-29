-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 03, 2020 at 12:31 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.4

create database learningportal;
use learningportal;

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `learningportal`
--

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` int(11) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` int(11) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
(1, 'Admin', 'ADMIN', 'a169048f-ad7c-44ad-befd-a6e11fab3636'),
(2, 'Parent', 'PARENT', '64ffbda6-70b0-4246-9b11-d2a52a1459a0'),
(3, 'Teacher', 'TEACHER', '1cbf3a25-f327-4a7a-87db-f8f5a3e95514'),
(4, 'Student', 'STUDENT', '55e5adbc-1d77-4fce-adb5-d2009c6877bd');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` int(11) NOT NULL,
  `RoleId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
(1, 1),
(3, 3),
(4, 2),
(5, 4);

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` int(11) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `FirstName` longtext DEFAULT NULL,
  `LastName` longtext DEFAULT NULL,
  `Address` longtext DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `CreatedById` int(11) DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `LoggedInAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `FirstName`, `LastName`, `Address`, `IsActive`, `CreatedById`, `CreatedAt`, `LoggedInAt`) VALUES
(1, 'super', 'SUPER', 'admin@learningportal.com', 'ADMIN@LEARNINGPORTAL.COM', 1, 'AQAAAAEAACcQAAAAEFgr+MbKAJYI6IgxIUpKd9Y0//6P8LL8sAfKih3ioiRb7gjj2Gp6fTBNd6BDhfO8vA==', 'IR7KJLWUI2T6AJC7GN3UUPIZOBDGIT5Z', 'b458e12b-2a73-4159-874f-410384a20367', NULL, 0, 0, NULL, 1, 0, NULL, NULL, NULL, 1, NULL, '2020-05-03 06:12:14.711067', '0001-01-01 00:00:00.000000'),
(3, 'z.Ejaz', 'Z.EJAZ', 'z.ejaz@gmail.com', 'Z.EJAZ@GMAIL.COM', 1, 'AQAAAAEAACcQAAAAEEg6D68M5LRU8x2KlnX49WE71N3BMFU0rA5lZu3Hp9/pkvqAZe8neWW3x9l0uNC3Hg==', 'HQIDNPPXHF5KTL2XRGNT5EG7SJGDE4B5', '41121786-a1f4-4843-aa79-b8f920997879', '3335555111', 0, 0, NULL, 1, 0, 'Z', 'Ejaz', 'abc', 0, 1, '2020-05-03 06:12:14.711067', '0001-01-01 00:00:00.000000'),
(4, 'zara', 'ZARA', 'zara@gmail.com', 'ZARA@GMAIL.COM', 1, 'AQAAAAEAACcQAAAAEAlBzkFLxyAQYachpUl8HVLpIp/HrZ3uerdT+QTh7zoceabmI2khwliLVT7Ip/jlkA==', 'F7TC2CFFTI6PH4YFRW22DZKYJAZ33T6F', 'd1abccde-8f70-4b5d-8896-15caf18b8402', '3344444', 0, 0, NULL, 1, 0, 'Zara', 'z', 'home', 0, 1, '2020-05-03 06:12:14.711067', '0001-01-01 00:00:00.000000'),
(5, 'student', 'STUDENT', 'stude@gmailc.om', 'STUDE@GMAILC.OM', 1, 'AQAAAAEAACcQAAAAEE1YKzz7AIzIq5TGwA+58fcqHPAXDxLTEXEKmxa0KdY/jinC90kNlYHK52u/xGXqRQ==', 'W7FLRAO3XWFLZ4LZQAQYHYQ2BTET2FNE', '8942fcaa-6bc7-4dd4-820f-fb8e5481e565', '11111111111111', 0, 0, NULL, 1, 0, 'studen', 'A', 'sssssssssssjkdnkfj', 0, 1, '2020-05-03 10:27:03.090767', '0001-01-01 00:00:00.000000');

-- --------------------------------------------------------

--
-- Table structure for table `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` int(11) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `classes`
--

CREATE TABLE `classes` (
  `Id` int(11) NOT NULL,
  `Title` longtext DEFAULT NULL,
  `Description` longtext DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `classes`
--

INSERT INTO `classes` (`Id`, `Title`, `Description`, `CreatedAt`) VALUES
(1, 'Class-1', 'Class-1', '2020-05-03 09:12:47.981980'),
(2, 'Class-2', 'Class-2', '2020-05-03 09:12:47.997747'),
(3, 'Class-3', 'Class-3', '2020-05-03 09:12:47.998887'),
(4, 'Class-4', 'Class-4', '2020-05-03 09:12:47.999661'),
(5, 'Class-5', 'Class-5', '2020-05-03 09:12:48.000372'),
(6, 'Class-6', 'Class-6', '2020-05-03 09:12:48.001082'),
(7, 'Class-7', 'Class-7', '2020-05-03 09:12:48.001824'),
(8, 'Class-8', 'Class-8', '2020-05-03 09:12:48.002471'),
(9, 'Class-9', 'Class-9', '2020-05-03 09:12:48.003113'),
(10, 'Class-10', 'Class-10', '2020-05-03 09:12:48.003724');

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `Id` int(11) NOT NULL,
  `Q` longtext DEFAULT NULL,
  `Option1` longtext DEFAULT NULL,
  `Option2` longtext DEFAULT NULL,
  `Option3` longtext DEFAULT NULL,
  `Option4` longtext DEFAULT NULL,
  `Option5` longtext DEFAULT NULL,
  `CorrectAnswer` longtext DEFAULT NULL,
  `TestId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`Id`, `Q`, `Option1`, `Option2`, `Option3`, `Option4`, `Option5`, `CorrectAnswer`, `TestId`) VALUES
(1, 'what is 1 + 1', '2', '1', '34', NULL, NULL, '1', 1),
(2, 'what is 2 + 2', '4', '1', '34', NULL, NULL, '1', 2),
(3, 'what is 120-2', '118', '121', '122', NULL, NULL, '1', 3),
(4, 'Question 2', 'Option 1', 'Option 2', 'Option 3', NULL, NULL, '1', 3),
(5, 'Question 3', 'Option 3', 'Option 2', 'Option 1', NULL, NULL, '3', 3);

-- --------------------------------------------------------

--
-- Table structure for table `subjects`
--

CREATE TABLE `subjects` (
  `Id` int(11) NOT NULL,
  `Title` longtext DEFAULT NULL,
  `Description` longtext DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `subjects`
--

INSERT INTO `subjects` (`Id`, `Title`, `Description`, `CreatedAt`) VALUES
(1, 'Maths', 'Maths subject for all classes', '2020-05-03 10:15:18.592138');

-- --------------------------------------------------------

--
-- Table structure for table `tests`
--

CREATE TABLE `tests` (
  `Id` int(11) NOT NULL,
  `Title` longtext DEFAULT NULL,
  `CreatedById` int(11) DEFAULT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `ClassId` int(11) DEFAULT NULL,
  `SubjectId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tests`
--

INSERT INTO `tests` (`Id`, `Title`, `CreatedById`, `CreatedAt`, `ClassId`, `SubjectId`) VALUES
(1, 'Test Add', 3, '2020-05-03 06:12:14.711067', 1, 1),
(2, 'Test Add', 3, '2020-05-03 06:13:31.484001', 2, 1),
(3, 'Test X', 3, '2020-05-03 06:47:48.145311', 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200502172616_first-migration', '3.1.3'),
('20200502173504_changing-to-role', '3.1.3'),
('20200502180356_changing', '3.1.3'),
('20200503091149_added-classes', '3.1.3'),
('20200503100818_subjects', '3.1.3');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `IX_AspNetUsers_CreatedById` (`CreatedById`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `classes`
--
ALTER TABLE `classes`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Questions_TestId` (`TestId`);

--
-- Indexes for table `subjects`
--
ALTER TABLE `subjects`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `tests`
--
ALTER TABLE `tests`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Tests_CreatedById` (`CreatedById`),
  ADD KEY `IX_Tests_ClassId` (`ClassId`),
  ADD KEY `IX_Tests_SubjectId` (`SubjectId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `classes`
--
ALTER TABLE `classes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `questions`
--
ALTER TABLE `questions`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `subjects`
--
ALTER TABLE `subjects`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tests`
--
ALTER TABLE `tests`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD CONSTRAINT `FK_AspNetUsers_AspNetUsers_CreatedById` FOREIGN KEY (`CreatedById`) REFERENCES `aspnetusers` (`Id`);

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `FK_Questions_Tests_TestId` FOREIGN KEY (`TestId`) REFERENCES `tests` (`Id`);

--
-- Constraints for table `tests`
--
ALTER TABLE `tests`
  ADD CONSTRAINT `FK_Tests_AspNetUsers_CreatedById` FOREIGN KEY (`CreatedById`) REFERENCES `aspnetusers` (`Id`),
  ADD CONSTRAINT `FK_Tests_Classes_ClassId` FOREIGN KEY (`ClassId`) REFERENCES `classes` (`Id`),
  ADD CONSTRAINT `FK_Tests_Subjects_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `subjects` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

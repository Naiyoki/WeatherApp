-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 28, 2021 at 04:58 AM
-- Server version: 10.4.14-MariaDB
-- PHP Version: 7.4.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ppt_evaluation`
--

-- --------------------------------------------------------

--
-- Table structure for table `emprecord`
--

CREATE TABLE `emprecord` (
  `ID` int(11) NOT NULL,
  `Fname` varchar(45) DEFAULT NULL,
  `Lname` varchar(45) DEFAULT NULL,
  `Address1` varchar(100) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  `Telephone` varchar(10) DEFAULT NULL,
  `Role` varchar(45) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Location` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `emprecord`
--

INSERT INTO `emprecord` (`ID`, `Fname`, `Lname`, `Address1`, `City`, `Country`, `Telephone`, `Role`, `Email`, `Location`) VALUES
(1001, 'Mark', 'Brown', '12 Far Road Ave', 'Kingston', 'Jamaica', '8765555555', 'IT', 'gx54@live.com', 'Kingston'),
(1002, 'Antonie', 'White', '8 Limber Road', 'Montego Bay', 'Jamaica', '8763333333', 'IT', 'gordon54mordecai@outlook.com', 'Montego Bay');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `emprecord`
--
ALTER TABLE `emprecord`
  ADD PRIMARY KEY (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

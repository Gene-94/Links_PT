-- --------------------------------------------------------
-- Anfitrião:                    127.0.0.1
-- Versão do servidor:           8.0.31 - MySQL Community Server - GPL
-- SO do servidor:               Win64
-- HeidiSQL Versão:              12.1.0.6559
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- A despejar estrutura da base de dados para linkspt
CREATE DATABASE IF NOT EXISTS `linkspt` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `linkspt`;

-- A despejar estrutura para tabela linkspt.cards
CREATE TABLE IF NOT EXISTS `cards` (
  `CardNr` int NOT NULL AUTO_INCREMENT,
  `ClientId` int NOT NULL,
  `Credit` float NOT NULL,
  `ValidUntil` datetime(6) NOT NULL,
  `CardName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`CardNr`)
) ENGINE=InnoDB AUTO_INCREMENT=775319103 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- A despejar dados para tabela linkspt.cards: ~2 rows (aproximadamente)
DELETE FROM `cards`;
INSERT INTO `cards` (`CardNr`, `ClientId`, `Credit`, `ValidUntil`, `CardName`) VALUES
	(775319101, 2, 10, '2022-10-30 03:47:34.000000', ''),
	(775319102, 1, 15, '2022-10-30 03:47:34.000000', '');

-- A despejar estrutura para tabela linkspt.clients
CREATE TABLE IF NOT EXISTS `clients` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Phone` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Addr` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Local` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Vat` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Postal` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- A despejar dados para tabela linkspt.clients: ~2 rows (aproximadamente)
DELETE FROM `clients`;
INSERT INTO `clients` (`Id`, `Phone`, `Name`, `Addr`, `Local`, `Vat`, `Email`, `Postal`) VALUES
	(1, '926555371', 'Juan Pablo', 'Maybe st', 'Valhala', '7985452163', 'jonny_peperoni@mail.mail', '6969'),
	(2, '978187554', 'Andromeda', 'Jupiter', 'Europa Moon', '8465546', 'notandy@ggmail.g', '778');

-- A despejar estrutura para tabela linkspt.colaborators
CREATE TABLE IF NOT EXISTS `colaborators` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Addr` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Phone` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- A despejar dados para tabela linkspt.colaborators: ~1 rows (aproximadamente)
DELETE FROM `colaborators`;
INSERT INTO `colaborators` (`Id`, `Name`, `Addr`, `Phone`, `Email`) VALUES
	(1, 'André Soares', 'lala land', '922543182', 'andre.soares@links.pt');

-- A despejar estrutura para tabela linkspt.messages
CREATE TABLE IF NOT EXISTS `messages` (
  `MsgId` int NOT NULL AUTO_INCREMENT,
  `To` int NOT NULL,
  `From` int NOT NULL,
  `SentDate` datetime(6) NOT NULL,
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MsgId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- A despejar dados para tabela linkspt.messages: ~3 rows (aproximadamente)
DELETE FROM `messages`;
INSERT INTO `messages` (`MsgId`, `To`, `From`, `SentDate`, `Content`) VALUES
	(1, 775319101, 775319102, '2022-10-28 23:32:41.000000', 'This is a message '),
	(2, 775319102, 775319101, '2022-10-28 23:32:41.000000', 'This is also a  message '),
	(3, 775319102, 775319102, '2022-10-28 23:32:41.000000', 'a note to self');

-- A despejar estrutura para tabela linkspt.users
CREATE TABLE IF NOT EXISTS `users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Role` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Active` tinyint(1) NOT NULL DEFAULT '0',
  `LastLogin` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `ReferenceId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Users_Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- A despejar dados para tabela linkspt.users: ~8 rows (aproximadamente)
DELETE FROM `users`;
INSERT INTO `users` (`Id`, `Email`, `Password`, `Role`, `Active`, `LastLogin`, `ReferenceId`) VALUES
	(1, 'admin@links.pt', 'admin', 'A', 1, '2022-10-30 13:13:29.837735', 0),
	(2, 'manager@links.pt', '123banana', 'M', 1, '0001-01-01 00:00:00.000000', 0),
	(3, 'inactive@links.pt', 'muchacha', 'M', 0, '0001-01-01 00:00:00.000000', 0),
	(4, 'andre.soares@links.pt', 'megalodon', 'M', 1, '2022-10-29 20:17:03.673471', 1),
	(5, 'andro_deia@mymail.com', 'Deia123', 'C', 1, '0001-01-01 00:00:00.000000', 2),
	(6, 'muy_muchacho@malo.es', 'MachoMacho', 'C', 1, '0001-01-01 00:00:00.000000', 1),
	(7, 'lasldasd@sadfasd.pt', 'pass', 'M', 0, '0001-01-01 00:00:00.000000', 33),
	(8, 'pala@links.pt', 'pass', 'M', 1, '2022-10-30 12:52:05.472285', 4);

-- A despejar estrutura para tabela linkspt.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- A despejar dados para tabela linkspt.__efmigrationshistory: ~14 rows (aproximadamente)
DELETE FROM `__efmigrationshistory`;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20221009172925_DbVersion1', '6.0.9'),
	('20221014185602_DbVersion2', '6.0.9'),
	('20221026002319_DbVersion3', '6.0.9'),
	('20221026002612_DbVersion4', '6.0.9'),
	('20221027220753_DbVersion5', '6.0.9'),
	('20221027235922_DbVersion6', '6.0.9'),
	('20221028002442_DbVersion7', '6.0.9'),
	('20221028165151_DbVersion7.1', '6.0.9'),
	('20221028220607_DbVersion7.1.1', '6.0.9'),
	('20221028220947_DbVersion7.1.2', '6.0.9'),
	('20221029120357_DbVersion7.1.3', '6.0.9'),
	('20221029120755_DbVersion7.2', '6.0.9'),
	('20221030114626_DbVersion7.3', '6.0.9'),
	('20221030115955_DbVersion7.3.1', '6.0.9');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

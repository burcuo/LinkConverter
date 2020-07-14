CREATE DATABASE `trendyollinkconverter`;

USE trendyollinkconverter;

CREATE TABLE `shortlinks` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `ShortLink` varchar(10) NOT NULL,
  `WebUrl` varchar(200) NOT NULL,
  `Deeplink` varchar(150) NOT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `IsActive` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ShortLink_UNIQUE` (`ShortLink`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
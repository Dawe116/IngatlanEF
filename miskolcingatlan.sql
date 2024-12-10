-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Dec 10. 11:06
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `miskolcingatlan`
--
CREATE DATABASE IF NOT EXISTS `miskolcingatlan` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `miskolcingatlan`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ingatlan`
--

CREATE TABLE `ingatlan` (
  `Id` int(11) NOT NULL,
  `Település` varchar(64) NOT NULL,
  `Cim` varchar(64) NOT NULL,
  `Ár` int(11) NOT NULL,
  `Tipus` varchar(32) NOT NULL,
  `KepNev` varchar(32) NOT NULL,
  `UgyintezoId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `ingatlan`
--

INSERT INTO `ingatlan` (`Id`, `Település`, `Cim`, `Ár`, `Tipus`, `KepNev`, `UgyintezoId`) VALUES
(1, 'Putnok', 'Serényi Béla út 106', 500000, 'Családi ház', 'puss.png', 1),
(2, 'Ózd', 'Lehel vezér út 9', 120000, 'Lyuk', 'kok.png', 3);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ugyintezo`
--

CREATE TABLE `ugyintezo` (
  `Id` int(11) NOT NULL,
  `Nev` varchar(32) NOT NULL,
  `TelefonSzám` varchar(15) NOT NULL,
  `Email` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `ugyintezo`
--

INSERT INTO `ugyintezo` (`Id`, `Nev`, `TelefonSzám`, `Email`) VALUES
(1, 'Füty Imre', '0670 502 3991', 'fuytike69@gmail.com'),
(3, 'Molnár Erik', '0670 502 3991', 'csakmertkelll123@gmail.com');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `ingatlan`
--
ALTER TABLE `ingatlan`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `UgyintezoId` (`UgyintezoId`);

--
-- A tábla indexei `ugyintezo`
--
ALTER TABLE `ugyintezo`
  ADD PRIMARY KEY (`Id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `ingatlan`
--
ALTER TABLE `ingatlan`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `ugyintezo`
--
ALTER TABLE `ugyintezo`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `ingatlan`
--
ALTER TABLE `ingatlan`
  ADD CONSTRAINT `ingatlan_ibfk_1` FOREIGN KEY (`UgyintezoId`) REFERENCES `ugyintezo` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 15-02-2026 a las 21:16:16
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `libreria_db`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `autores`
--

CREATE TABLE `autores` (
  `IdAutor` int(11) NOT NULL,
  `Nombre` varchar(100) DEFAULT NULL,
  `Nacionalidad` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `autores`
--

INSERT INTO `autores` (`IdAutor`, `Nombre`, `Nacionalidad`) VALUES
(1, 'Gabriel García Márquez', 'Colombiana'),
(2, 'Stephen King', 'Estadounidense'),
(3, 'Isaac Asimov', 'Rusa'),
(4, 'Isabel Allende', 'Chilena'),
(5, 'Jorge Luis Borges', 'Argentina');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libros`
--

CREATE TABLE `libros` (
  `IdLibro` int(11) NOT NULL,
  `Titulo` varchar(150) DEFAULT NULL,
  `Precio` decimal(10,2) DEFAULT NULL,
  `Stock` int(11) DEFAULT NULL,
  `IdAutor` int(11) DEFAULT NULL,
  `IdTipo` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `libros`
--

INSERT INTO `libros` (`IdLibro`, `Titulo`, `Precio`, `Stock`, `IdAutor`, `IdTipo`) VALUES
(101, 'Cien años de soledad', 25.50, 15, 1, 1),
(102, 'It (Eso)', 19.99, 10, 2, 3),
(103, 'Fundación', 22.00, 8, 3, 2),
(104, 'La casa de los espíritus', 18.75, 12, 4, 1),
(105, 'El Aleph', 15.00, 5, 5, 4),
(106, 'El resplandor', 21.30, 7, 2, 3),
(107, 'Crónica de una muerte anunciada', 14.50, 20, 1, 1),
(108, 'Yo, Robot', 17.80, 14, 3, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipolibro`
--

CREATE TABLE `tipolibro` (
  `IdTipo` int(11) NOT NULL,
  `NombreTipo` varchar(100) DEFAULT NULL,
  `Descripcion` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tipolibro`
--

INSERT INTO `tipolibro` (`IdTipo`, `NombreTipo`, `Descripcion`) VALUES
(1, 'Novela', 'Obras narrativas de ficción de extensión considerable.'),
(2, 'Ciencia Ficción', 'Relatos basados en avances científicos o futuros posibles.'),
(3, 'Terror', 'Historias diseñadas para provocar miedo o suspenso.'),
(4, 'Ensayo', 'Textos que analizan un tema específico desde un punto de vista crítico.'),
(5, 'Poesía', 'Expresión literaria de la belleza o el sentimiento a través del verso.');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `autores`
--
ALTER TABLE `autores`
  ADD PRIMARY KEY (`IdAutor`);

--
-- Indices de la tabla `libros`
--
ALTER TABLE `libros`
  ADD PRIMARY KEY (`IdLibro`),
  ADD KEY `IdAutor` (`IdAutor`),
  ADD KEY `IdTipo` (`IdTipo`);

--
-- Indices de la tabla `tipolibro`
--
ALTER TABLE `tipolibro`
  ADD PRIMARY KEY (`IdTipo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `autores`
--
ALTER TABLE `autores`
  MODIFY `IdAutor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `libros`
--
ALTER TABLE `libros`
  MODIFY `IdLibro` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=110;

--
-- AUTO_INCREMENT de la tabla `tipolibro`
--
ALTER TABLE `tipolibro`
  MODIFY `IdTipo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `libros`
--
ALTER TABLE `libros`
  ADD CONSTRAINT `libros_ibfk_1` FOREIGN KEY (`IdAutor`) REFERENCES `autores` (`IdAutor`),
  ADD CONSTRAINT `libros_ibfk_2` FOREIGN KEY (`IdTipo`) REFERENCES `tipolibro` (`IdTipo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

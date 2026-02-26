-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 26-02-2026 a las 03:12:46
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
-- Base de datos: `sistema_academico`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_actualizar_asignatura` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_asignatura` INT, IN `p_nombre` VARCHAR(60), IN `p_creditos` TINYINT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_old_nombre VARCHAR(60); DECLARE v_old_creditos TINYINT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        SELECT nombre, creditos INTO v_old_nombre, v_old_creditos FROM asignatura WHERE id_asignatura = p_id_asignatura;
        
        UPDATE asignatura SET nombre = p_nombre, creditos = p_creditos WHERE id_asignatura = p_id_asignatura;

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_anterior, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'UPDATE', 'asignatura', p_id_asignatura, 
               JSON_OBJECT('nombre', v_old_nombre, 'creditos', v_old_creditos), 
               JSON_OBJECT('nombre', p_nombre, 'creditos', p_creditos), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_actualizar_calificacion` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_calificacion` INT, IN `p_nota` DECIMAL(5,2), IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_nota_ant DECIMAL(5,2);
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        SELECT nota INTO v_nota_ant FROM calificacion WHERE id_calificacion = p_id_calificacion;
        
        UPDATE calificacion SET nota = p_nota WHERE id_calificacion = p_id_calificacion;

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_anterior, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'UPDATE', 'calificacion', p_id_calificacion, JSON_OBJECT('nota', v_nota_ant), JSON_OBJECT('nota', p_nota), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_actualizar_docente` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_docente` INT, IN `p_cedula` VARCHAR(20), IN `p_estado` TINYINT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_old_estado TINYINT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        SELECT estado INTO v_old_estado FROM docente WHERE id_docente = p_id_docente;
        
        UPDATE docente SET cedula = p_cedula, estado = p_estado WHERE id_docente = p_id_docente;

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_anterior, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'UPDATE', 'docente', p_id_docente, JSON_OBJECT('estado', v_old_estado), JSON_OBJECT('estado', p_estado), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_actualizar_estudiante` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_estudiante` INT, IN `p_cedula` VARCHAR(20), IN `p_codigo` VARCHAR(20), IN `p_estado` TINYINT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_old_codigo VARCHAR(20); DECLARE v_old_estado TINYINT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        SELECT codigo, estado INTO v_old_codigo, v_old_estado FROM estudiante WHERE id_estudiante = p_id_estudiante;
        
        UPDATE estudiante SET cedula = p_cedula, codigo = p_codigo, estado = p_estado WHERE id_estudiante = p_id_estudiante;

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_anterior, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'UPDATE', 'estudiante', p_id_estudiante, 
               JSON_OBJECT('codigo', v_old_codigo, 'estado', v_old_estado), 
               JSON_OBJECT('codigo', p_codigo, 'estado', p_estado), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_actualizar_usuario` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_usuario_mod` INT, IN `p_nombre` VARCHAR(50), IN `p_apellido` VARCHAR(50), IN `p_estado` TINYINT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_old_nombre VARCHAR(50); DECLARE v_old_apellido VARCHAR(50); DECLARE v_old_estado TINYINT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        SELECT nombre, apellido, estado INTO v_old_nombre, v_old_apellido, v_old_estado FROM usuario WHERE id_usuario = p_id_usuario_mod;
        
        UPDATE usuario SET nombre = p_nombre, apellido = p_apellido, estado = p_estado WHERE id_usuario = p_id_usuario_mod;

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_anterior, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'UPDATE', 'usuario', p_id_usuario_mod, 
               JSON_OBJECT('nombre', v_old_nombre, 'apellido', v_old_apellido, 'estado', v_old_estado), 
               JSON_OBJECT('nombre', p_nombre, 'apellido', p_apellido, 'estado', p_estado), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cambiar_password` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_usuario_mod` INT, IN `p_new_password_hash` VARCHAR(255), IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        UPDATE usuario SET password_hash = p_new_password_hash, intentos_fallidos = 0, bloqueado_hasta = NULL, fecha_cambio_password = NOW() WHERE id_usuario = p_id_usuario_mod;

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'UPDATE', 'usuario', p_id_usuario_mod, JSON_OBJECT('password_changed', 'TRUE'), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_eliminar_calificacion` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_calificacion` INT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_old_activo TINYINT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        SELECT activo INTO v_old_activo FROM calificacion WHERE id_calificacion = p_id_calificacion;
        UPDATE calificacion SET activo = 0 WHERE id_calificacion = p_id_calificacion;

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_anterior, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'DELETE', 'calificacion', p_id_calificacion, JSON_OBJECT('activo', v_old_activo), JSON_OBJECT('activo', 0), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_eliminar_matricula` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_matricula` INT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        DELETE FROM matricula WHERE id_matricula = p_id_matricula;

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'DELETE', 'matricula', p_id_matricula, JSON_OBJECT('status', 'eliminada'), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_eliminar_usuario` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_usuario_del` INT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_old_estado TINYINT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        SELECT estado INTO v_old_estado FROM usuario WHERE id_usuario = p_id_usuario_del;
        UPDATE usuario SET estado = 0 WHERE id_usuario = p_id_usuario_del;

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_anterior, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'DELETE', 'usuario', p_id_usuario_del, JSON_OBJECT('estado', v_old_estado), JSON_OBJECT('estado', 0), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertar_asignatura` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_nombre` VARCHAR(60), IN `p_creditos` TINYINT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_id INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        INSERT INTO asignatura(nombre, creditos) VALUES(p_nombre, p_creditos);
        SET v_id = LAST_INSERT_ID();
        
        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'INSERT', 'asignatura', v_id, JSON_OBJECT('nombre', p_nombre, 'creditos', p_creditos), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertar_calificacion` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_estudiante` INT, IN `p_id_evaluacion` INT, IN `p_nota` DECIMAL(5,2), IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_id INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        INSERT INTO calificacion(id_estudiante, id_evaluacion, nota, activo) VALUES(p_id_estudiante, p_id_evaluacion, p_nota, 1);
        SET v_id = LAST_INSERT_ID();
        
        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'INSERT', 'calificacion', v_id, JSON_OBJECT('nota', p_nota), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertar_docente` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_usuario` INT, IN `p_cedula` VARCHAR(20), IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_id INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        INSERT INTO docente(id_usuario, cedula) VALUES(p_id_usuario, p_cedula);
        SET v_id = LAST_INSERT_ID();
        
        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'INSERT', 'docente', v_id, JSON_OBJECT('id_usuario', p_id_usuario), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertar_estudiante` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_usuario` INT, IN `p_cedula` VARCHAR(20), IN `p_codigo` VARCHAR(20), IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_id INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        INSERT INTO estudiante(id_usuario, cedula, codigo) VALUES(p_id_usuario, p_cedula, p_codigo);
        SET v_id = LAST_INSERT_ID();
        
        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'INSERT', 'estudiante', v_id, JSON_OBJECT('codigo', p_codigo, 'id_usuario', p_id_usuario), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertar_matricula` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_estudiante` INT, IN `p_id_asignatura` INT, IN `p_id_periodo` INT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_id INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        INSERT INTO matricula(id_estudiante, id_asignatura, id_periodo) VALUES(p_id_estudiante, p_id_asignatura, p_id_periodo);
        SET v_id = LAST_INSERT_ID();
        
        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'INSERT', 'matricula', v_id, JSON_OBJECT('id_estudiante', p_id_estudiante, 'id_asignatura', p_id_asignatura), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertar_usuario` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_nombre` VARCHAR(50), IN `p_apellido` VARCHAR(50), IN `p_correo` VARCHAR(100), IN `p_password_hash` VARCHAR(255), IN `p_id_rol_nuevo` INT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_id INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        INSERT INTO usuario(nombre, apellido, correo, password_hash, estado) VALUES(p_nombre, p_apellido, p_correo, p_password_hash, 1);
        SET v_id = LAST_INSERT_ID();
        
        INSERT INTO usuario_rol(id_usuario, id_rol) VALUES (v_id, p_id_rol_nuevo);

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'INSERT', 'usuario', v_id, JSON_OBJECT('nombre', p_nombre, 'apellido', p_apellido, 'id_rol', p_id_rol_nuevo), p_ip_user);
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_login_paso1_credenciales` (IN `p_correo` VARCHAR(100), IN `p_password_hash` VARCHAR(255))   BEGIN
    DECLARE v_id_usuario INT; DECLARE v_password VARCHAR(255); DECLARE v_estado TINYINT; DECLARE v_codigo_generado VARCHAR(6);
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        SELECT id_usuario, password_hash, estado INTO v_id_usuario, v_password, v_estado 
        FROM usuario WHERE correo_hash = UNHEX(SHA2(CONCAT(p_correo, 'SALT_ACADEMICO_2026'), 256));

        IF v_id_usuario IS NULL OR v_estado = 0 OR v_password <> p_password_hash THEN 
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Credenciales incorrectas o usuario inactivo'; 
        END IF;

        SET v_codigo_generado = LPAD(FLOOR(RAND() * 999999), 6, '0');
        
        -- Guardar código 2FA Hashed en la DB para máxima seguridad
        UPDATE usuario SET codigo_2fa = UNHEX(SHA2(v_codigo_generado, 256)), expiracion_2fa = DATE_ADD(NOW(), INTERVAL 5 MINUTE) WHERE id_usuario = v_id_usuario;

        -- Retorna en plano solo a C# para enviarlo por correo
        SELECT v_id_usuario AS id_usuario, u.nombre, p_correo AS correo, v_codigo_generado AS codigo_2fa FROM usuario u WHERE id_usuario = v_id_usuario;
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_login_paso2_verificar2fa` (IN `p_id_usuario` INT, IN `p_codigo_ingresado` VARCHAR(6), IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_codigo_real BINARY(32); DECLARE v_expiracion DATETIME; DECLARE v_intentos INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        SELECT codigo_2fa, expiracion_2fa, intentos_fallidos INTO v_codigo_real, v_expiracion, v_intentos FROM usuario WHERE id_usuario = p_id_usuario;

        -- Verificar Hash
        IF v_codigo_real IS NULL OR v_codigo_real <> UNHEX(SHA2(p_codigo_ingresado, 256)) OR NOW() > v_expiracion THEN
            UPDATE usuario SET intentos_fallidos = intentos_fallidos + 1 WHERE id_usuario = p_id_usuario;
            IF v_intentos + 1 >= 3 THEN
                UPDATE usuario SET bloqueado_hasta = NOW() + INTERVAL 15 MINUTE WHERE id_usuario = p_id_usuario;
            END IF;
            INSERT INTO auditoria_sistema(id_usuario, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
            VALUES(p_id_usuario, 'LOGIN', 'usuario', p_id_usuario, JSON_OBJECT('resultado', 'FAILED_2FA'), p_ip_user);
            
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Código inválido o expirado';
        END IF;

        UPDATE usuario SET codigo_2fa = NULL, expiracion_2fa = NULL, intentos_fallidos = 0 WHERE id_usuario = p_id_usuario;

        INSERT INTO auditoria_sistema(id_usuario, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario, 'LOGIN', 'usuario', p_id_usuario, JSON_OBJECT('resultado', 'SUCCESS_2FA'), p_ip_user);

        SELECT r.id_rol, r.nombre AS rol_nombre FROM usuario_rol ur JOIN rol r ON ur.id_rol = r.id_rol WHERE ur.id_usuario = p_id_usuario;
    COMMIT;
END$$

--
-- Funciones
--
CREATE DEFINER=`root`@`localhost` FUNCTION `fn_estado_academico` (`p_nota` DECIMAL(5,2)) RETURNS VARCHAR(15) CHARSET utf8mb4 COLLATE utf8mb4_general_ci DETERMINISTIC BEGIN
    RETURN CASE
        WHEN p_nota >= 7 THEN 'APROBADO'
        ELSE 'REPROBADO'
    END;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `fn_promedio_ponderado` (`p_id_estudiante` INT, `p_id_asignatura` INT) RETURNS DECIMAL(5,2) DETERMINISTIC BEGIN
    DECLARE v_promedio DECIMAL(5,2);
    SELECT SUM(c.nota * te.peso / 100) INTO v_promedio
    FROM calificacion c
    JOIN evaluacion e ON c.id_evaluacion = e.id_evaluacion
    JOIN tipoevaluacion te ON e.id_tipo_evaluacion = te.id_tipo_evaluacion
    WHERE c.id_estudiante = p_id_estudiante AND e.id_asignatura = p_id_asignatura AND c.activo = 1;
    RETURN IFNULL(v_promedio,0);
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `asignaciondocente`
--

CREATE TABLE `asignaciondocente` (
  `id_asignacion` int(11) NOT NULL,
  `id_docente` int(11) NOT NULL,
  `id_asignatura` int(11) NOT NULL,
  `id_periodo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `asignatura`
--

CREATE TABLE `asignatura` (
  `id_asignatura` int(11) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `creditos` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `asignatura`
--

INSERT INTO `asignatura` (`id_asignatura`, `nombre`, `creditos`) VALUES
(1, 'Automatización', 4),
(2, 'Programación Orientada a Objetos II', 5),
(3, 'Redes de Datos', 4),
(4, 'Administración de Base de Datos', 4),
(5, 'Ingeniería de Requerimientos y Validación de Software', 4),
(6, 'Modelos Matemáticos y Simulación', 4);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `auditoria_sistema`
--

CREATE TABLE `auditoria_sistema` (
  `id_auditoria` int(11) NOT NULL,
  `ip_user` varchar(45) DEFAULT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  `id_rol` int(11) DEFAULT NULL,
  `accion` enum('INSERT','UPDATE','DELETE','LOGIN') NOT NULL,
  `tabla_afectada` varchar(50) DEFAULT NULL,
  `registro_id` int(11) DEFAULT NULL,
  `valor_anterior` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL CHECK (json_valid(`valor_anterior`)),
  `valor_nuevo` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL CHECK (json_valid(`valor_nuevo`)),
  `fecha` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `auditoria_sistema`
--

INSERT INTO `auditoria_sistema` (`id_auditoria`, `ip_user`, `id_usuario`, `id_rol`, `accion`, `tabla_afectada`, `registro_id`, `valor_anterior`, `valor_nuevo`, `fecha`) VALUES
(1, '127.0.0.1', 1, 1, 'INSERT', 'asignatura', 1, NULL, '{\"nombre\": \"Automatización\", \"creditos\": \"4\"}', '2026-02-25 16:41:16'),
(2, '127.0.0.1', 1, 1, 'INSERT', 'asignatura', 2, NULL, '{\"nombre\": \"Programación Orientada a Objetos II\", \"creditos\": \"5\"}', '2026-02-25 16:41:16'),
(3, '127.0.0.1', 1, 1, 'INSERT', 'asignatura', 3, NULL, '{\"nombre\": \"Redes de Datos\", \"creditos\": \"4\"}', '2026-02-25 16:41:16'),
(4, '127.0.0.1', 1, 1, 'INSERT', 'asignatura', 4, NULL, '{\"nombre\": \"Administración de Base de Datos\", \"creditos\": \"4\"}', '2026-02-25 16:41:16'),
(5, '127.0.0.1', 1, 1, 'INSERT', 'asignatura', 5, NULL, '{\"nombre\": \"Ingeniería de Requerimientos y Validación de Software\", \"creditos\": \"4\"}', '2026-02-25 16:41:16'),
(6, '127.0.0.1', 1, 1, 'INSERT', 'asignatura', 6, NULL, '{\"nombre\": \"Modelos Matemáticos y Simulación\", \"creditos\": \"4\"}', '2026-02-25 16:41:16'),
(7, '127.0.0.1', 1, 1, 'INSERT', 'usuario', 2, NULL, '{\"nombre\": \"Juan\", \"apellido\": \"Perez\", \"id_rol\": \"4\"}', '2026-02-25 16:41:16'),
(8, '127.0.0.1', 1, 1, 'INSERT', 'usuario', 3, NULL, '{\"nombre\": \"Bolivar Enrique\", \"apellido\": \"Villalta Jadan\", \"id_rol\": \"2\"}', '2026-02-25 16:41:16'),
(9, '127.0.0.1', 1, 1, 'INSERT', 'docente', 1, NULL, '{\"id_usuario\": \"3\"}', '2026-02-25 16:41:16'),
(10, '127.0.0.1', 1, 1, 'INSERT', 'usuario', 4, NULL, '{\"nombre\": \"Walter Vinicio\", \"apellido\": \"Culque Toapanta\", \"id_rol\": \"2\"}', '2026-02-25 16:41:16'),
(11, '127.0.0.1', 1, 1, 'INSERT', 'docente', 2, NULL, '{\"id_usuario\": \"4\"}', '2026-02-25 16:41:16'),
(12, '127.0.0.1', 1, 1, 'INSERT', 'usuario', 5, NULL, '{\"nombre\": \"Luis Antonio\", \"apellido\": \"Llerena Ocana\", \"id_rol\": \"2\"}', '2026-02-25 16:41:16'),
(13, '127.0.0.1', 1, 1, 'INSERT', 'docente', 3, NULL, '{\"id_usuario\": \"5\"}', '2026-02-25 16:41:16'),
(14, '127.0.0.1', 1, 1, 'INSERT', 'usuario', 6, NULL, '{\"nombre\": \"Rita Azucena\", \"apellido\": \"Diaz Vasquez\", \"id_rol\": \"2\"}', '2026-02-25 16:41:16'),
(15, '127.0.0.1', 1, 1, 'INSERT', 'docente', 4, NULL, '{\"id_usuario\": \"6\"}', '2026-02-25 16:41:16'),
(16, '127.0.0.1', 1, 1, 'INSERT', 'usuario', 7, NULL, '{\"nombre\": \"Cristian Javier\", \"apellido\": \"Saltos Ponce\", \"id_rol\": \"2\"}', '2026-02-25 16:41:16'),
(17, '127.0.0.1', 1, 1, 'INSERT', 'docente', 5, NULL, '{\"id_usuario\": \"7\"}', '2026-02-25 16:41:16'),
(18, '127.0.0.1', 1, 1, 'INSERT', 'usuario', 8, NULL, '{\"nombre\": \"Andres Roberto\", \"apellido\": \"Leon Yacelga\", \"id_rol\": \"2\"}', '2026-02-25 16:41:16'),
(19, '127.0.0.1', 1, 1, 'INSERT', 'docente', 6, NULL, '{\"id_usuario\": \"8\"}', '2026-02-25 16:41:16'),
(20, '127.0.0.1', 1, 1, 'INSERT', 'usuario', 9, NULL, '{\"nombre\": \"María Josefina\", \"apellido\": \"Gómez López\", \"id_rol\": \"3\"}', '2026-02-25 16:41:16'),
(21, '127.0.0.1', 1, 1, 'INSERT', 'estudiante', 1, NULL, '{\"codigo\": \"EST-001\", \"id_usuario\": \"9\"}', '2026-02-25 16:41:16'),
(22, '127.0.0.1', 1, 1, 'INSERT', 'usuario', 10, NULL, '{\"nombre\": \"Pedro\", \"apellido\": \"Maldonado\", \"id_rol\": \"3\"}', '2026-02-25 16:41:16'),
(23, '127.0.0.1', 1, 1, 'INSERT', 'estudiante', 2, NULL, '{\"codigo\": \"EST-002\", \"id_usuario\": \"10\"}', '2026-02-25 16:41:16'),
(24, '127.0.0.1', 1, 1, 'INSERT', 'matricula', 1, NULL, '{\"id_estudiante\": \"1\", \"id_asignatura\": \"4\"}', '2026-02-25 16:41:16'),
(25, '127.0.0.1', 1, 1, 'INSERT', 'matricula', 2, NULL, '{\"id_estudiante\": \"2\", \"id_asignatura\": \"4\"}', '2026-02-25 16:41:16'),
(26, '127.0.0.1', 1, 1, 'INSERT', 'calificacion', 1, NULL, '{\"nota\": \"9.50\"}', '2026-02-25 16:41:16'),
(27, '127.0.0.1', 1, 1, 'INSERT', 'calificacion', 2, NULL, '{\"nota\": \"8.75\"}', '2026-02-25 16:41:16'),
(28, '127.0.0.1', 1, 1, 'INSERT', 'calificacion', 3, NULL, '{\"nota\": \"6.50\"}', '2026-02-25 16:41:16');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `calificacion`
--

CREATE TABLE `calificacion` (
  `id_calificacion` int(11) NOT NULL,
  `id_estudiante` int(11) NOT NULL,
  `id_evaluacion` int(11) NOT NULL,
  `nota` decimal(5,2) NOT NULL,
  `fecha_registro` datetime DEFAULT current_timestamp(),
  `activo` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `calificacion`
--

INSERT INTO `calificacion` (`id_calificacion`, `id_estudiante`, `id_evaluacion`, `nota`, `fecha_registro`, `activo`) VALUES
(1, 1, 1, 9.50, '2026-02-25 16:41:16', 1),
(2, 1, 2, 8.75, '2026-02-25 16:41:16', 1),
(3, 2, 1, 6.50, '2026-02-25 16:41:16', 1);

--
-- Disparadores `calificacion`
--
DELIMITER $$
CREATE TRIGGER `tr_validar_nota_insert` BEFORE INSERT ON `calificacion` FOR EACH ROW BEGIN
    IF NEW.nota < 0 OR NEW.nota > 10 THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La nota debe estar entre 0 y 10'; END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `tr_validar_nota_update` BEFORE UPDATE ON `calificacion` FOR EACH ROW BEGIN
    IF NEW.nota < 0 OR NEW.nota > 10 THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La nota debe estar entre 0 y 10'; END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `docente`
--

CREATE TABLE `docente` (
  `id_docente` int(11) NOT NULL,
  `cedula` varbinary(255) NOT NULL,
  `cedula_hash` binary(32) DEFAULT NULL,
  `id_usuario` int(11) NOT NULL,
  `fecha_registro` datetime DEFAULT current_timestamp(),
  `estado` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `docente`
--

INSERT INTO `docente` (`id_docente`, `cedula`, `cedula_hash`, `id_usuario`, `fecha_registro`, `estado`) VALUES
(1, 0x265afee563039814037912b620aeb673, 0x642ccba9c5bcc01bd148c0963afb6cdce627354bb29b95d521720a6826e71656, 3, '2026-02-25 16:41:16', 1),
(2, 0x666a837273287ef25013e946f266aef3, 0xbb0b99891bfad98dad55415adeb5deee4a705bb5613f1179f03ac04a8e1a66b9, 4, '2026-02-25 16:41:16', 1),
(3, 0xa9f9f8445cc757c8aa23d86f94289825, 0xb41d9452e2c56313b466f842032041c2aa375d57ffc206ffde2a9b991f7eb930, 5, '2026-02-25 16:41:16', 1),
(4, 0xc37889b3f32a2ec2a1860c13310c59ec, 0x86f46bae48e22cd02532d055651d28fea864f336221b0b30edcfb0f8928358cb, 6, '2026-02-25 16:41:16', 1),
(5, 0x8e98c717125b2094d1c03de284f24afd, 0x6acfd5955ca77061f1313652ee1c379ad1295f509f0cf4f0d7c3100680e5e80a, 7, '2026-02-25 16:41:16', 1),
(6, 0x50e75616e8158b1b0fe65de9c07b4a68, 0xf8a853235b4a22c8bf608c4ed1864d3f4fb0f6cc1447fd18f2d09bb9e8b85a4d, 8, '2026-02-25 16:41:16', 1);

--
-- Disparadores `docente`
--
DELIMITER $$
CREATE TRIGGER `tr_docente_procesar_datos_insert` BEFORE INSERT ON `docente` FOR EACH ROW BEGIN
    SET NEW.cedula_hash = UNHEX(SHA2(CONCAT(NEW.cedula, 'SALT_ACADEMICO_2026'), 256));
    SET NEW.cedula = AES_ENCRYPT(NEW.cedula, 'CLAVE_ACADEMICO_2026');
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `tr_docente_procesar_datos_update` BEFORE UPDATE ON `docente` FOR EACH ROW BEGIN
    IF NEW.cedula <> OLD.cedula THEN
        SET NEW.cedula_hash = UNHEX(SHA2(CONCAT(NEW.cedula, 'SALT_ACADEMICO_2026'), 256));
        SET NEW.cedula = AES_ENCRYPT(NEW.cedula, 'CLAVE_ACADEMICO_2026');
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estudiante`
--

CREATE TABLE `estudiante` (
  `id_estudiante` int(11) NOT NULL,
  `cedula` varbinary(255) NOT NULL,
  `cedula_hash` binary(32) DEFAULT NULL,
  `codigo` varchar(20) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `fecha_registro` datetime DEFAULT current_timestamp(),
  `estado` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `estudiante`
--

INSERT INTO `estudiante` (`id_estudiante`, `cedula`, `cedula_hash`, `codigo`, `id_usuario`, `fecha_registro`, `estado`) VALUES
(1, 0x112fb64dbd0c50f09a679b66b7085c71, 0x895cd9c4bada417d6759f7200e8c99bde7c5ca07fb7a5a7bdcb37c63cbb2405b, 'EST-001', 9, '2026-02-25 16:41:16', 1),
(2, 0x5e63e6c6f3c29239a9ad95796fb1c537, 0x3e623249fb3c3827d405c6719e80f82bdea3bb159c81ef50324290433727dce7, 'EST-002', 10, '2026-02-25 16:41:16', 1);

--
-- Disparadores `estudiante`
--
DELIMITER $$
CREATE TRIGGER `tr_estudiante_procesar_datos_insert` BEFORE INSERT ON `estudiante` FOR EACH ROW BEGIN
    SET NEW.cedula_hash = UNHEX(SHA2(CONCAT(NEW.cedula, 'SALT_ACADEMICO_2026'), 256));
    SET NEW.cedula = AES_ENCRYPT(NEW.cedula, 'CLAVE_ACADEMICO_2026');
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `tr_estudiante_procesar_datos_update` BEFORE UPDATE ON `estudiante` FOR EACH ROW BEGIN
    IF NEW.cedula <> OLD.cedula THEN
        SET NEW.cedula_hash = UNHEX(SHA2(CONCAT(NEW.cedula, 'SALT_ACADEMICO_2026'), 256));
        SET NEW.cedula = AES_ENCRYPT(NEW.cedula, 'CLAVE_ACADEMICO_2026');
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `evaluacion`
--

CREATE TABLE `evaluacion` (
  `id_evaluacion` int(11) NOT NULL,
  `id_asignatura` int(11) NOT NULL,
  `id_tipo_evaluacion` int(11) NOT NULL,
  `id_periodo` int(11) NOT NULL,
  `descripcion` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `evaluacion`
--

INSERT INTO `evaluacion` (`id_evaluacion`, `id_asignatura`, `id_tipo_evaluacion`, `id_periodo`, `descripcion`) VALUES
(1, 4, 1, 1, 'Examen Parcial I'),
(2, 4, 2, 1, 'Examen Final Práctico');

--
-- Disparadores `evaluacion`
--
DELIMITER $$
CREATE TRIGGER `tr_evaluacion_validar_peso_insert` BEFORE INSERT ON `evaluacion` FOR EACH ROW BEGIN
    DECLARE v_peso_actual DECIMAL(5,2); DECLARE v_nuevo_peso DECIMAL(5,2);
    SELECT peso INTO v_nuevo_peso FROM tipoevaluacion WHERE id_tipo_evaluacion = NEW.id_tipo_evaluacion;
    
    SELECT IFNULL(SUM(te.peso), 0) INTO v_peso_actual FROM evaluacion e
    JOIN tipoevaluacion te ON e.id_tipo_evaluacion = te.id_tipo_evaluacion
    WHERE e.id_asignatura = NEW.id_asignatura AND e.id_periodo = NEW.id_periodo;
    
    IF (v_peso_actual + v_nuevo_peso) > 100 THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Error: Los pesos de evaluación superan el 100%'; END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `tr_evaluacion_validar_peso_update` BEFORE UPDATE ON `evaluacion` FOR EACH ROW BEGIN
    DECLARE v_peso_actual DECIMAL(5,2); DECLARE v_nuevo_peso DECIMAL(5,2);
    IF NEW.id_tipo_evaluacion <> OLD.id_tipo_evaluacion THEN
        SELECT peso INTO v_nuevo_peso FROM tipoevaluacion WHERE id_tipo_evaluacion = NEW.id_tipo_evaluacion;
        SELECT IFNULL(SUM(te.peso), 0) INTO v_peso_actual FROM evaluacion e
        JOIN tipoevaluacion te ON e.id_tipo_evaluacion = te.id_tipo_evaluacion
        WHERE e.id_asignatura = NEW.id_asignatura AND e.id_periodo = NEW.id_periodo AND e.id_evaluacion <> NEW.id_evaluacion;
        IF (v_peso_actual + v_nuevo_peso) > 100 THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Error: Los pesos de evaluación superan el 100%'; END IF;
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `matricula`
--

CREATE TABLE `matricula` (
  `id_matricula` int(11) NOT NULL,
  `id_estudiante` int(11) NOT NULL,
  `id_asignatura` int(11) NOT NULL,
  `id_periodo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `matricula`
--

INSERT INTO `matricula` (`id_matricula`, `id_estudiante`, `id_asignatura`, `id_periodo`) VALUES
(1, 1, 4, 1),
(2, 2, 4, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `periodoacademico`
--

CREATE TABLE `periodoacademico` (
  `id_periodo` int(11) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `fecha_inicio` date NOT NULL,
  `fecha_fin` date NOT NULL,
  `estado` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `periodoacademico`
--

INSERT INTO `periodoacademico` (`id_periodo`, `nombre`, `fecha_inicio`, `fecha_fin`, `estado`) VALUES
(1, 'Octubre - Marzo 2026', '2025-10-01', '2026-03-31', 'Activo');

--
-- Disparadores `periodoacademico`
--
DELIMITER $$
CREATE TRIGGER `tr_validar_periodo` BEFORE INSERT ON `periodoacademico` FOR EACH ROW BEGIN
    IF NEW.fecha_fin <= NEW.fecha_inicio THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La fecha fin debe ser mayor que fecha inicio'; END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rol`
--

CREATE TABLE `rol` (
  `id_rol` int(11) NOT NULL,
  `nombre` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `rol`
--

INSERT INTO `rol` (`id_rol`, `nombre`) VALUES
(1, 'Administrador'),
(4, 'Coordinador'),
(2, 'Docente'),
(3, 'Estudiante');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipoevaluacion`
--

CREATE TABLE `tipoevaluacion` (
  `id_tipo_evaluacion` int(11) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `peso` decimal(5,2) NOT NULL CHECK (`peso` > 0 and `peso` <= 100)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tipoevaluacion`
--

INSERT INTO `tipoevaluacion` (`id_tipo_evaluacion`, `nombre`, `peso`) VALUES
(1, 'Examen Parcial', 30.00),
(2, 'Examen Final', 40.00),
(3, 'Proyecto', 30.00);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `id_usuario` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `apellido` varchar(50) DEFAULT NULL,
  `correo` varbinary(255) DEFAULT NULL,
  `correo_hash` binary(32) DEFAULT NULL,
  `codigo_2fa` binary(32) DEFAULT NULL,
  `expiracion_2fa` datetime DEFAULT NULL,
  `password_hash` varchar(255) NOT NULL,
  `estado` tinyint(1) DEFAULT 1,
  `fecha_cambio_password` datetime DEFAULT current_timestamp(),
  `intentos_fallidos` int(11) DEFAULT 0,
  `bloqueado_hasta` datetime DEFAULT NULL,
  `fecha_creacion` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`id_usuario`, `nombre`, `apellido`, `correo`, `correo_hash`, `codigo_2fa`, `expiracion_2fa`, `password_hash`, `estado`, `fecha_cambio_password`, `intentos_fallidos`, `bloqueado_hasta`, `fecha_creacion`) VALUES
(1, 'Super', 'Admin', 0xccef7f6c8c6c3bbb1c66ce513ff13438879efaa446e49ff13fbdcd350f92af5b, 0x72d8ab81d96a9d9d0e51d18d63023c8fe891ed3b49efb136f6579b24841aa866, NULL, NULL, '3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2', 1, '2026-02-25 16:41:16', 0, NULL, '2026-02-25 16:41:16'),
(2, 'Juan', 'Perez', 0xf609b7af861a2cbbaba5d60b6441ba7caf1611ab39bfb16afadcc2f225eb1145, 0x18c9905dd9993f0e0f6bf09f2b4d08c7975cee766b9b0423238c07d0665cf78a, NULL, NULL, 'a6e45e8d6d687658eb517e4afc415fcbb35305d857bf18703adebc4fe321a7e9', 1, '2026-02-25 16:41:16', 0, NULL, '2026-02-25 16:41:16'),
(3, 'Bolivar Enrique', 'Villalta Jadan', 0xdc06585254c0207b6c039fa91ac8277d388f0382fab7ee17b07d7f95f377decb, 0xc80432c74cc14905cc98ff786d57549cc33dd58266e14956f1952571143c47a7, NULL, NULL, '41cfb30a0c16b0ea26d7892a8a1ff486876228557448614e2825716655de5774', 1, '2026-02-25 16:41:16', 0, NULL, '2026-02-25 16:41:16'),
(4, 'Walter Vinicio', 'Culque Toapanta', 0x5a32daf2663180383a2839f154efa583a1943c51efcda2a13392787717ac3b31, 0x7e38918141f66734a1ed8de168b9ac951d4099ff25a2d8da8c1f9fb71100829f, NULL, NULL, '41cfb30a0c16b0ea26d7892a8a1ff486876228557448614e2825716655de5774', 1, '2026-02-25 16:41:16', 0, NULL, '2026-02-25 16:41:16'),
(5, 'Luis Antonio', 'Llerena Ocana', 0x5018de5b6de716c3e66932e44afcbb21abe7d1931d1ef2c782338e340982fe62, 0x414c6cada8be546834a6b0b466d1c53a1a00c211c58d4a29e95b8577a0ea64b6, NULL, NULL, '41cfb30a0c16b0ea26d7892a8a1ff486876228557448614e2825716655de5774', 1, '2026-02-25 16:41:16', 0, NULL, '2026-02-25 16:41:16'),
(6, 'Rita Azucena', 'Diaz Vasquez', 0xab4df200604532e0527db7dd8549dfbb879efaa446e49ff13fbdcd350f92af5b, 0x60fbbc06484b685065cdf744e00a3b2f985df5e5aef67725331ca3375237ebb0, NULL, NULL, '41cfb30a0c16b0ea26d7892a8a1ff486876228557448614e2825716655de5774', 1, '2026-02-25 16:41:16', 0, NULL, '2026-02-25 16:41:16'),
(7, 'Cristian Javier', 'Saltos Ponce', 0x1582a1ba5e07f17c44bed6ccf72fb027a1943c51efcda2a13392787717ac3b31, 0x60037ec31229597be8be8f2056c556f19e2362b6ea36e40bb03327f8304009e8, NULL, NULL, '41cfb30a0c16b0ea26d7892a8a1ff486876228557448614e2825716655de5774', 1, '2026-02-25 16:41:16', 0, NULL, '2026-02-25 16:41:16'),
(8, 'Andres Roberto', 'Leon Yacelga', 0xf96b65607c8432979876d433a76ce977879efaa446e49ff13fbdcd350f92af5b, 0x27d1c86e08541f62b436fef636412d808f47389f66f8550598be369caee13f03, NULL, NULL, '41cfb30a0c16b0ea26d7892a8a1ff486876228557448614e2825716655de5774', 1, '2026-02-25 16:41:16', 0, NULL, '2026-02-25 16:41:16'),
(9, 'María Josefina', 'Gómez López', 0xb954ddf445ac49b6ec8c9e165ae38cc8d2edf97505c540ff157fdfb2eab0d8c2, 0x04fbfd94d5c54407ee9a8ec0241a4c117b675eac4875f05c241c7a00b19a0635, NULL, NULL, '7016fa198a233f51a7f0d47cabbd65244822adcecc7c4c491367e245ab302236', 1, '2026-02-25 16:41:16', 0, NULL, '2026-02-25 16:41:16'),
(10, 'Pedro', 'Maldonado', 0xae6ae395d74e8ba99b9cee6609e4a1d4f8337c401cc2b79969930867e2218a3f, 0x5272ee1c015036a57c2b13d4a084c70e0d4b37eead62606e814469fbb1028169, NULL, NULL, '7016fa198a233f51a7f0d47cabbd65244822adcecc7c4c491367e245ab302236', 1, '2026-02-25 16:41:16', 0, NULL, '2026-02-25 16:41:16');

--
-- Disparadores `usuario`
--
DELIMITER $$
CREATE TRIGGER `tr_usuario_procesar_datos_insert` BEFORE INSERT ON `usuario` FOR EACH ROW BEGIN
    IF NEW.correo NOT LIKE '%@%' THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Error: Formato de correo inválido'; END IF;
    IF CHAR_LENGTH(NEW.password_hash) < 8 THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La contraseña debe tener mínimo 8 caracteres'; END IF;

    IF CHAR_LENGTH(NEW.password_hash) <> 64 THEN SET NEW.password_hash = SHA2(NEW.password_hash, 256); END IF;

    SET NEW.correo_hash = UNHEX(SHA2(CONCAT(NEW.correo, 'SALT_ACADEMICO_2026'), 256));
    SET NEW.correo = AES_ENCRYPT(NEW.correo, 'CLAVE_ACADEMICO_2026');
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `tr_usuario_procesar_datos_update` BEFORE UPDATE ON `usuario` FOR EACH ROW BEGIN
    IF NEW.password_hash <> OLD.password_hash THEN
        IF CHAR_LENGTH(NEW.password_hash) < 8 THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La contraseña debe tener mínimo 8 caracteres'; END IF;
        IF CHAR_LENGTH(NEW.password_hash) <> 64 THEN SET NEW.password_hash = SHA2(NEW.password_hash, 256); END IF;
        SET NEW.fecha_cambio_password = NOW(); SET NEW.intentos_fallidos = 0; SET NEW.bloqueado_hasta = NULL;
    END IF;

    IF NEW.correo <> OLD.correo THEN
        IF NEW.correo NOT LIKE '%@%' THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Error: Formato de correo inválido'; END IF;
        SET NEW.correo_hash = UNHEX(SHA2(CONCAT(NEW.correo, 'SALT_ACADEMICO_2026'), 256));
        SET NEW.correo = AES_ENCRYPT(NEW.correo, 'CLAVE_ACADEMICO_2026');
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario_rol`
--

CREATE TABLE `usuario_rol` (
  `id_usuario` int(11) NOT NULL,
  `id_rol` int(11) NOT NULL,
  `fecha_asignacion` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuario_rol`
--

INSERT INTO `usuario_rol` (`id_usuario`, `id_rol`, `fecha_asignacion`) VALUES
(1, 1, '2026-02-25 16:41:16'),
(2, 4, '2026-02-25 16:41:16'),
(3, 2, '2026-02-25 16:41:16'),
(4, 2, '2026-02-25 16:41:16'),
(5, 2, '2026-02-25 16:41:16'),
(6, 2, '2026-02-25 16:41:16'),
(7, 2, '2026-02-25 16:41:16'),
(8, 2, '2026-02-25 16:41:16'),
(9, 3, '2026-02-25 16:41:16'),
(10, 3, '2026-02-25 16:41:16');

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_docentes_admin`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_docentes_admin` (
`id_docente` int(11)
,`nombre` varchar(50)
,`apellido` varchar(50)
,`cedula_plana` varchar(255)
,`correo_plano` varchar(255)
,`estado` tinyint(1)
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_docentes_periodo`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_docentes_periodo` (
`nombres` varchar(50)
,`apellidos` varchar(50)
,`asignatura` varchar(60)
,`periodo` varchar(30)
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_estudiantes_admin`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_estudiantes_admin` (
`id_estudiante` int(11)
,`nombre` varchar(50)
,`apellido` varchar(50)
,`cedula_plana` varchar(255)
,`correo_plano` varchar(255)
,`codigo` varchar(20)
,`estado` tinyint(1)
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_historial_auditoria`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_historial_auditoria` (
`id_auditoria` int(11)
,`usuario_nombre` varchar(101)
,`rol` varchar(30)
,`accion` enum('INSERT','UPDATE','DELETE','LOGIN')
,`tabla_afectada` varchar(50)
,`registro_id` int(11)
,`valor_anterior` longtext
,`valor_nuevo` longtext
,`fecha` datetime
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_historial_notas`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_historial_notas` (
`id_auditoria` int(11)
,`usuario_nombre` varchar(101)
,`rol` varchar(30)
,`accion` enum('INSERT','UPDATE','DELETE','LOGIN')
,`id_calificacion` int(11)
,`valor_anterior` longtext
,`valor_nuevo` longtext
,`fecha` datetime
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_login_docentes`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_login_docentes` (
`nombres` varchar(50)
,`apellidos` varchar(50)
,`fecha_ingreso` datetime
,`ip_user` varchar(45)
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_promedios_estudiantes`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_promedios_estudiantes` (
`cedula_texto` varchar(255)
,`nombres` varchar(50)
,`apellidos` varchar(50)
,`asignatura` varchar(60)
,`promedio_final` decimal(5,2)
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_reporte_academico`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_reporte_academico` (
`id_estudiante` int(11)
,`nombres` varchar(50)
,`apellidos` varchar(50)
,`asignatura` varchar(60)
,`promedio_final` decimal(5,2)
,`estado` varchar(15)
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_usuarios_admin`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_usuarios_admin` (
`id_usuario` int(11)
,`nombre` varchar(50)
,`apellido` varchar(50)
,`correo_plano` varchar(255)
,`roles` mediumtext
,`estado` tinyint(1)
,`intentos_fallidos` int(11)
,`bloqueado_hasta` datetime
,`fecha_cambio_password` datetime
,`fecha_creacion` datetime
);

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_docentes_admin`
--
DROP TABLE IF EXISTS `vista_docentes_admin`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_docentes_admin`  AS SELECT `d`.`id_docente` AS `id_docente`, `u`.`nombre` AS `nombre`, `u`.`apellido` AS `apellido`, cast(aes_decrypt(`d`.`cedula`,'CLAVE_ACADEMICO_2026') as char charset utf8mb4) AS `cedula_plana`, cast(aes_decrypt(`u`.`correo`,'CLAVE_ACADEMICO_2026') as char charset utf8mb4) AS `correo_plano`, `d`.`estado` AS `estado` FROM (`docente` `d` join `usuario` `u` on(`d`.`id_usuario` = `u`.`id_usuario`)) ;

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_docentes_periodo`
--
DROP TABLE IF EXISTS `vista_docentes_periodo`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_docentes_periodo`  AS SELECT `u`.`nombre` AS `nombres`, `u`.`apellido` AS `apellidos`, `a`.`nombre` AS `asignatura`, `p`.`nombre` AS `periodo` FROM ((((`asignaciondocente` `ad` join `docente` `d` on(`ad`.`id_docente` = `d`.`id_docente`)) join `usuario` `u` on(`d`.`id_usuario` = `u`.`id_usuario`)) join `asignatura` `a` on(`ad`.`id_asignatura` = `a`.`id_asignatura`)) join `periodoacademico` `p` on(`ad`.`id_periodo` = `p`.`id_periodo`)) ;

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_estudiantes_admin`
--
DROP TABLE IF EXISTS `vista_estudiantes_admin`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_estudiantes_admin`  AS SELECT `e`.`id_estudiante` AS `id_estudiante`, `u`.`nombre` AS `nombre`, `u`.`apellido` AS `apellido`, cast(aes_decrypt(`e`.`cedula`,'CLAVE_ACADEMICO_2026') as char charset utf8mb4) AS `cedula_plana`, cast(aes_decrypt(`u`.`correo`,'CLAVE_ACADEMICO_2026') as char charset utf8mb4) AS `correo_plano`, `e`.`codigo` AS `codigo`, `e`.`estado` AS `estado` FROM (`estudiante` `e` join `usuario` `u` on(`e`.`id_usuario` = `u`.`id_usuario`)) ;

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_historial_auditoria`
--
DROP TABLE IF EXISTS `vista_historial_auditoria`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_historial_auditoria`  AS SELECT `a`.`id_auditoria` AS `id_auditoria`, concat(`u`.`nombre`,' ',`u`.`apellido`) AS `usuario_nombre`, `r`.`nombre` AS `rol`, `a`.`accion` AS `accion`, `a`.`tabla_afectada` AS `tabla_afectada`, `a`.`registro_id` AS `registro_id`, `a`.`valor_anterior` AS `valor_anterior`, `a`.`valor_nuevo` AS `valor_nuevo`, `a`.`fecha` AS `fecha` FROM ((`auditoria_sistema` `a` left join `usuario` `u` on(`a`.`id_usuario` = `u`.`id_usuario`)) left join `rol` `r` on(`a`.`id_rol` = `r`.`id_rol`)) ;

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_historial_notas`
--
DROP TABLE IF EXISTS `vista_historial_notas`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_historial_notas`  AS SELECT `a`.`id_auditoria` AS `id_auditoria`, concat(`u`.`nombre`,' ',`u`.`apellido`) AS `usuario_nombre`, `r`.`nombre` AS `rol`, `a`.`accion` AS `accion`, `a`.`registro_id` AS `id_calificacion`, `a`.`valor_anterior` AS `valor_anterior`, `a`.`valor_nuevo` AS `valor_nuevo`, `a`.`fecha` AS `fecha` FROM ((`auditoria_sistema` `a` left join `usuario` `u` on(`a`.`id_usuario` = `u`.`id_usuario`)) left join `rol` `r` on(`a`.`id_rol` = `r`.`id_rol`)) WHERE `a`.`tabla_afectada` = 'calificacion' ;

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_login_docentes`
--
DROP TABLE IF EXISTS `vista_login_docentes`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_login_docentes`  AS SELECT `u`.`nombre` AS `nombres`, `u`.`apellido` AS `apellidos`, `a`.`fecha` AS `fecha_ingreso`, `a`.`ip_user` AS `ip_user` FROM ((`auditoria_sistema` `a` join `usuario` `u` on(`a`.`id_usuario` = `u`.`id_usuario`)) join `docente` `d` on(`d`.`id_usuario` = `u`.`id_usuario`)) WHERE `a`.`accion` = 'LOGIN' ;

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_promedios_estudiantes`
--
DROP TABLE IF EXISTS `vista_promedios_estudiantes`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_promedios_estudiantes`  AS SELECT cast(aes_decrypt(`e`.`cedula`,'CLAVE_ACADEMICO_2026') as char charset utf8mb4) AS `cedula_texto`, `u`.`nombre` AS `nombres`, `u`.`apellido` AS `apellidos`, `a`.`nombre` AS `asignatura`, `fn_promedio_ponderado`(`e`.`id_estudiante`,`a`.`id_asignatura`) AS `promedio_final` FROM (((`estudiante` `e` join `usuario` `u` on(`e`.`id_usuario` = `u`.`id_usuario`)) join `matricula` `m` on(`e`.`id_estudiante` = `m`.`id_estudiante`)) join `asignatura` `a` on(`m`.`id_asignatura` = `a`.`id_asignatura`)) GROUP BY `e`.`id_estudiante`, `a`.`id_asignatura`, `u`.`nombre`, `u`.`apellido` ;

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_reporte_academico`
--
DROP TABLE IF EXISTS `vista_reporte_academico`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_reporte_academico`  AS SELECT `e`.`id_estudiante` AS `id_estudiante`, `u`.`nombre` AS `nombres`, `u`.`apellido` AS `apellidos`, `a`.`nombre` AS `asignatura`, `fn_promedio_ponderado`(`e`.`id_estudiante`,`a`.`id_asignatura`) AS `promedio_final`, `fn_estado_academico`(`fn_promedio_ponderado`(`e`.`id_estudiante`,`a`.`id_asignatura`)) AS `estado` FROM (((`estudiante` `e` join `usuario` `u` on(`e`.`id_usuario` = `u`.`id_usuario`)) join `matricula` `m` on(`e`.`id_estudiante` = `m`.`id_estudiante`)) join `asignatura` `a` on(`m`.`id_asignatura` = `a`.`id_asignatura`)) ;

-- --------------------------------------------------------

--
-- Estructura para la vista `vista_usuarios_admin`
--
DROP TABLE IF EXISTS `vista_usuarios_admin`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_usuarios_admin`  AS SELECT `u`.`id_usuario` AS `id_usuario`, `u`.`nombre` AS `nombre`, `u`.`apellido` AS `apellido`, cast(aes_decrypt(`u`.`correo`,'CLAVE_ACADEMICO_2026') as char charset utf8mb4) AS `correo_plano`, group_concat(`r`.`nombre` separator ', ') AS `roles`, `u`.`estado` AS `estado`, `u`.`intentos_fallidos` AS `intentos_fallidos`, `u`.`bloqueado_hasta` AS `bloqueado_hasta`, `u`.`fecha_cambio_password` AS `fecha_cambio_password`, `u`.`fecha_creacion` AS `fecha_creacion` FROM ((`usuario` `u` left join `usuario_rol` `ur` on(`u`.`id_usuario` = `ur`.`id_usuario`)) left join `rol` `r` on(`ur`.`id_rol` = `r`.`id_rol`)) GROUP BY `u`.`id_usuario` ;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `asignaciondocente`
--
ALTER TABLE `asignaciondocente`
  ADD PRIMARY KEY (`id_asignacion`),
  ADD UNIQUE KEY `uk_asignacion_concurrencia` (`id_docente`,`id_asignatura`,`id_periodo`),
  ADD KEY `fk_asigdoc_asignatura` (`id_asignatura`),
  ADD KEY `fk_asigdoc_periodo` (`id_periodo`);

--
-- Indices de la tabla `asignatura`
--
ALTER TABLE `asignatura`
  ADD PRIMARY KEY (`id_asignatura`);

--
-- Indices de la tabla `auditoria_sistema`
--
ALTER TABLE `auditoria_sistema`
  ADD PRIMARY KEY (`id_auditoria`),
  ADD KEY `idx_audit_completo` (`tabla_afectada`,`accion`,`fecha`),
  ADD KEY `idx_audit_usuario` (`id_usuario`,`fecha`),
  ADD KEY `idx_audit_fecha` (`fecha`);

--
-- Indices de la tabla `calificacion`
--
ALTER TABLE `calificacion`
  ADD PRIMARY KEY (`id_calificacion`),
  ADD UNIQUE KEY `uk_calificacion_unica` (`id_estudiante`,`id_evaluacion`),
  ADD KEY `fk_calif_evaluacion` (`id_evaluacion`);

--
-- Indices de la tabla `docente`
--
ALTER TABLE `docente`
  ADD PRIMARY KEY (`id_docente`),
  ADD UNIQUE KEY `uk_docente_usuario` (`id_usuario`),
  ADD UNIQUE KEY `uk_docente_cedula_hash` (`cedula_hash`);

--
-- Indices de la tabla `estudiante`
--
ALTER TABLE `estudiante`
  ADD PRIMARY KEY (`id_estudiante`),
  ADD UNIQUE KEY `uk_est_codigo` (`codigo`),
  ADD UNIQUE KEY `uk_est_usuario` (`id_usuario`),
  ADD UNIQUE KEY `uk_est_cedula_hash` (`cedula_hash`);

--
-- Indices de la tabla `evaluacion`
--
ALTER TABLE `evaluacion`
  ADD PRIMARY KEY (`id_evaluacion`),
  ADD KEY `fk_eval_asignatura` (`id_asignatura`),
  ADD KEY `fk_eval_tipoeval` (`id_tipo_evaluacion`),
  ADD KEY `fk_eval_periodo` (`id_periodo`);

--
-- Indices de la tabla `matricula`
--
ALTER TABLE `matricula`
  ADD PRIMARY KEY (`id_matricula`),
  ADD UNIQUE KEY `uk_matricula_concurrencia` (`id_estudiante`,`id_asignatura`,`id_periodo`),
  ADD KEY `fk_mat_asignatura` (`id_asignatura`),
  ADD KEY `fk_mat_periodo` (`id_periodo`);

--
-- Indices de la tabla `periodoacademico`
--
ALTER TABLE `periodoacademico`
  ADD PRIMARY KEY (`id_periodo`);

--
-- Indices de la tabla `rol`
--
ALTER TABLE `rol`
  ADD PRIMARY KEY (`id_rol`),
  ADD UNIQUE KEY `uk_rol_nombre` (`nombre`);

--
-- Indices de la tabla `tipoevaluacion`
--
ALTER TABLE `tipoevaluacion`
  ADD PRIMARY KEY (`id_tipo_evaluacion`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id_usuario`),
  ADD UNIQUE KEY `uk_usuario_correo_hash` (`correo_hash`);

--
-- Indices de la tabla `usuario_rol`
--
ALTER TABLE `usuario_rol`
  ADD PRIMARY KEY (`id_usuario`,`id_rol`),
  ADD KEY `fk_ur_rol` (`id_rol`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `asignaciondocente`
--
ALTER TABLE `asignaciondocente`
  MODIFY `id_asignacion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `asignatura`
--
ALTER TABLE `asignatura`
  MODIFY `id_asignatura` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `auditoria_sistema`
--
ALTER TABLE `auditoria_sistema`
  MODIFY `id_auditoria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT de la tabla `calificacion`
--
ALTER TABLE `calificacion`
  MODIFY `id_calificacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `docente`
--
ALTER TABLE `docente`
  MODIFY `id_docente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `estudiante`
--
ALTER TABLE `estudiante`
  MODIFY `id_estudiante` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `evaluacion`
--
ALTER TABLE `evaluacion`
  MODIFY `id_evaluacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `matricula`
--
ALTER TABLE `matricula`
  MODIFY `id_matricula` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `periodoacademico`
--
ALTER TABLE `periodoacademico`
  MODIFY `id_periodo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `rol`
--
ALTER TABLE `rol`
  MODIFY `id_rol` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `tipoevaluacion`
--
ALTER TABLE `tipoevaluacion`
  MODIFY `id_tipo_evaluacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `asignaciondocente`
--
ALTER TABLE `asignaciondocente`
  ADD CONSTRAINT `fk_asigdoc_asignatura` FOREIGN KEY (`id_asignatura`) REFERENCES `asignatura` (`id_asignatura`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_asigdoc_docente` FOREIGN KEY (`id_docente`) REFERENCES `docente` (`id_docente`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_asigdoc_periodo` FOREIGN KEY (`id_periodo`) REFERENCES `periodoacademico` (`id_periodo`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `calificacion`
--
ALTER TABLE `calificacion`
  ADD CONSTRAINT `fk_calif_estudiante` FOREIGN KEY (`id_estudiante`) REFERENCES `estudiante` (`id_estudiante`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_calif_evaluacion` FOREIGN KEY (`id_evaluacion`) REFERENCES `evaluacion` (`id_evaluacion`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `docente`
--
ALTER TABLE `docente`
  ADD CONSTRAINT `fk_docente_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `estudiante`
--
ALTER TABLE `estudiante`
  ADD CONSTRAINT `fk_estudiante_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `evaluacion`
--
ALTER TABLE `evaluacion`
  ADD CONSTRAINT `fk_eval_asignatura` FOREIGN KEY (`id_asignatura`) REFERENCES `asignatura` (`id_asignatura`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_eval_periodo` FOREIGN KEY (`id_periodo`) REFERENCES `periodoacademico` (`id_periodo`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_eval_tipoeval` FOREIGN KEY (`id_tipo_evaluacion`) REFERENCES `tipoevaluacion` (`id_tipo_evaluacion`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `matricula`
--
ALTER TABLE `matricula`
  ADD CONSTRAINT `fk_mat_asignatura` FOREIGN KEY (`id_asignatura`) REFERENCES `asignatura` (`id_asignatura`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_mat_estudiante` FOREIGN KEY (`id_estudiante`) REFERENCES `estudiante` (`id_estudiante`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_mat_periodo` FOREIGN KEY (`id_periodo`) REFERENCES `periodoacademico` (`id_periodo`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `usuario_rol`
--
ALTER TABLE `usuario_rol`
  ADD CONSTRAINT `fk_ur_rol` FOREIGN KEY (`id_rol`) REFERENCES `rol` (`id_rol`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_ur_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

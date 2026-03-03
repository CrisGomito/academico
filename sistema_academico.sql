-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 03-03-2026 a las 07:24:57
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

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_actualizar_usuario` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_usuario_mod` INT, IN `p_nombre` VARCHAR(50), IN `p_apellido` VARCHAR(50), IN `p_estado` TINYINT, IN `p_id_rol_nuevo` INT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_old_nombre VARCHAR(50); DECLARE v_old_apellido VARCHAR(50); DECLARE v_old_estado TINYINT;
    DECLARE v_old_rol INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; END IF;

        SELECT nombre, apellido, estado INTO v_old_nombre, v_old_apellido, v_old_estado FROM usuario WHERE id_usuario = p_id_usuario_mod;
        SELECT id_rol INTO v_old_rol FROM usuario_rol WHERE id_usuario = p_id_usuario_mod LIMIT 1;
        
        UPDATE usuario SET nombre = p_nombre, apellido = p_apellido, estado = p_estado WHERE id_usuario = p_id_usuario_mod;
        
        -- Si el rol cambió, lo actualizamos
        IF v_old_rol <> p_id_rol_nuevo THEN
            DELETE FROM usuario_rol WHERE id_usuario = p_id_usuario_mod;
            INSERT INTO usuario_rol(id_usuario, id_rol) VALUES (p_id_usuario_mod, p_id_rol_nuevo);
        END IF;

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_anterior, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'UPDATE', 'usuario', p_id_usuario_mod, 
               JSON_OBJECT('nombre', v_old_nombre, 'apellido', v_old_apellido, 'estado', v_old_estado, 'id_rol', v_old_rol), 
               JSON_OBJECT('nombre', p_nombre, 'apellido', p_apellido, 'estado', p_estado, 'id_rol', p_id_rol_nuevo), p_ip_user);
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

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_eliminar_asignacion` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_asignacion` INT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        -- Validar permisos de auditoría
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN 
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; 
        END IF;

        -- Eliminar físicamente el registro puente
        DELETE FROM asignaciondocente WHERE id_asignacion = p_id_asignacion;

        -- Registrar en Auditoría
        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'DELETE', 'asignaciondocente', p_id_asignacion, JSON_OBJECT('status', 'eliminada'), p_ip_user);
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

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertar_asignacion` (IN `p_id_usuario_aud` INT, IN `p_id_rol_aud` INT, IN `p_id_docente` INT, IN `p_id_asignatura` INT, IN `p_id_periodo` INT, IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_id INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        -- 1. Validar permisos de auditoría
        IF NOT EXISTS (SELECT 1 FROM usuario_rol WHERE id_usuario = p_id_usuario_aud AND id_rol = p_id_rol_aud) THEN 
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Acceso denegado.'; 
        END IF;

        -- 2. Insertar la asignación del docente
        INSERT INTO asignaciondocente(id_docente, id_asignatura, id_periodo) 
        VALUES(p_id_docente, p_id_asignatura, p_id_periodo);
        
        SET v_id = LAST_INSERT_ID();
        
        -- 3. Registrar en Auditoría
        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario_aud, p_id_rol_aud, 'INSERT', 'asignaciondocente', v_id, 
               JSON_OBJECT('id_docente', p_id_docente, 'id_asignatura', p_id_asignatura, 'id_periodo', p_id_periodo), 
               p_ip_user);

        -- =========================================================================
        -- 4. MAGIA AUTOMÁTICA: CREAR EVALUACIONES REGLAMENTARIAS SI NO EXISTEN
        -- =========================================================================
        IF NOT EXISTS (SELECT 1 FROM evaluacion WHERE id_asignatura = p_id_asignatura AND id_periodo = p_id_periodo) THEN
            INSERT INTO evaluacion (id_asignatura, id_tipo_evaluacion, id_periodo, descripcion) VALUES
            (p_id_asignatura, 1, p_id_periodo, 'Evaluación Frecuente 1 (Tareas)'),
            (p_id_asignatura, 2, p_id_periodo, 'Examen Parcial 1'),
            (p_id_asignatura, 3, p_id_periodo, 'Evaluación Frecuente 2 (Tareas)'),
            (p_id_asignatura, 4, p_id_periodo, 'Examen Parcial 2'),
            (p_id_asignatura, 5, p_id_periodo, 'Proyecto Final Integrador'),
            (p_id_asignatura, 6, p_id_periodo, 'Examen Remedial');
        END IF;

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

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_login_paso1_credenciales` (IN `p_correo` VARCHAR(100), IN `p_password_hash` VARCHAR(255), IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_id_usuario INT; DECLARE v_password VARCHAR(255); DECLARE v_estado TINYINT; DECLARE v_codigo_generado VARCHAR(6); DECLARE v_rol INT;
    
    -- Buscamos al usuario y su rol principal
    SELECT u.id_usuario, u.password_hash, u.estado, ur.id_rol 
    INTO v_id_usuario, v_password, v_estado, v_rol
    FROM usuario u LEFT JOIN usuario_rol ur ON u.id_usuario = ur.id_usuario
    WHERE u.correo_hash = UNHEX(SHA2(CONCAT(p_correo, 'SALT_ACADEMICO_2026'), 256)) LIMIT 1;

    IF v_id_usuario IS NULL THEN 
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Credenciales incorrectas'; 
    END IF;

    IF v_estado = 0 THEN
        -- Insertamos el fallo de usuario inactivo
        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(v_id_usuario, v_rol, 'LOGIN', 'usuario', v_id_usuario, JSON_OBJECT('resultado', 'FAILED_INACTIVE'), p_ip_user);
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Usuario inactivo'; 
    END IF;

    IF v_password <> p_password_hash THEN 
        -- Iniciamos transacción solo para guardar la auditoría y luego enviar el error a C#
        START TRANSACTION;
            UPDATE usuario SET intentos_fallidos = intentos_fallidos + 1 WHERE id_usuario = v_id_usuario;
            INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
            VALUES(v_id_usuario, v_rol, 'LOGIN', 'usuario', v_id_usuario, JSON_OBJECT('resultado', 'FAILED_PASSWORD'), p_ip_user);
        COMMIT;
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Credenciales incorrectas'; 
    END IF;

    START TRANSACTION;
        SET v_codigo_generado = LPAD(FLOOR(RAND() * 999999), 6, '0');
        UPDATE usuario SET codigo_2fa = UNHEX(SHA2(v_codigo_generado, 256)), expiracion_2fa = DATE_ADD(NOW(), INTERVAL 5 MINUTE) WHERE id_usuario = v_id_usuario;
        
        SELECT v_id_usuario AS id_usuario, u.nombre, p_correo AS correo, v_codigo_generado AS codigo_2fa FROM usuario u WHERE id_usuario = v_id_usuario;
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_login_paso2_verificar2fa` (IN `p_id_usuario` INT, IN `p_codigo_ingresado` VARCHAR(6), IN `p_ip_user` VARCHAR(45))   BEGIN
    DECLARE v_codigo_real BINARY(32); DECLARE v_expiracion DATETIME; DECLARE v_intentos INT; DECLARE v_rol INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION BEGIN ROLLBACK; RESIGNAL; END;

    START TRANSACTION;
        SELECT codigo_2fa, expiracion_2fa, intentos_fallidos INTO v_codigo_real, v_expiracion, v_intentos FROM usuario WHERE id_usuario = p_id_usuario;
        SELECT id_rol INTO v_rol FROM usuario_rol WHERE id_usuario = p_id_usuario LIMIT 1;

        IF v_codigo_real IS NULL OR v_codigo_real <> UNHEX(SHA2(p_codigo_ingresado, 256)) OR NOW() > v_expiracion THEN
            UPDATE usuario SET intentos_fallidos = intentos_fallidos + 1 WHERE id_usuario = p_id_usuario;
            IF v_intentos + 1 >= 3 THEN
                UPDATE usuario SET bloqueado_hasta = NOW() + INTERVAL 15 MINUTE WHERE id_usuario = p_id_usuario;
            END IF;
            
            INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
            VALUES(p_id_usuario, v_rol, 'LOGIN', 'usuario', p_id_usuario, JSON_OBJECT('resultado', 'FAILED_2FA'), p_ip_user);
            
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Código inválido o expirado';
        END IF;

        UPDATE usuario SET codigo_2fa = NULL, expiracion_2fa = NULL, intentos_fallidos = 0 WHERE id_usuario = p_id_usuario;

        INSERT INTO auditoria_sistema(id_usuario, id_rol, accion, tabla_afectada, registro_id, valor_nuevo, ip_user)
        VALUES(p_id_usuario, v_rol, 'LOGIN', 'usuario', p_id_usuario, JSON_OBJECT('resultado', 'SUCCESS_2FA'), p_ip_user);

        SELECT r.id_rol, r.nombre AS rol_nombre FROM usuario_rol ur JOIN rol r ON ur.id_rol = r.id_rol WHERE ur.id_usuario = p_id_usuario;
    COMMIT;
END$$

--
-- Funciones
--
CREATE DEFINER=`root`@`localhost` FUNCTION `fn_estado_academico` (`p_id_estudiante` INT, `p_id_asignatura` INT) RETURNS VARCHAR(15) CHARSET utf8mb4 COLLATE utf8mb4_general_ci DETERMINISTIC BEGIN
    DECLARE v_exf DECIMAL(5,2) DEFAULT 0; DECLARE v_rem DECIMAL(5,2) DEFAULT NULL;
    DECLARE v_final_usar DECIMAL(5,2) DEFAULT 0; DECLARE v_promedio DECIMAL(5,2);

    SELECT IFNULL(MAX(c.nota), 0) INTO v_exf FROM calificacion c JOIN evaluacion e ON c.id_evaluacion = e.id_evaluacion WHERE c.id_estudiante = p_id_estudiante AND e.id_asignatura = p_id_asignatura AND e.id_tipo_evaluacion = 5 AND c.activo = 1;
    SELECT MAX(c.nota) INTO v_rem FROM calificacion c JOIN evaluacion e ON c.id_evaluacion = e.id_evaluacion WHERE c.id_estudiante = p_id_estudiante AND e.id_asignatura = p_id_asignatura AND e.id_tipo_evaluacion = 6 AND c.activo = 1;

    IF v_rem IS NOT NULL AND v_rem > v_exf THEN
        SET v_final_usar = v_rem;
    ELSE
        SET v_final_usar = v_exf;
    END IF;

    SET v_promedio = fn_promedio_ponderado(p_id_estudiante, p_id_asignatura);

    -- Regla Institucional: Promedio >= 7 AND Nota Final >= 7
    IF v_promedio >= 7 AND v_final_usar >= 7 THEN
        RETURN 'APROBADO';
    ELSEIF v_final_usar < 7 AND v_rem IS NULL THEN
        RETURN 'REMEDIAL';
    ELSE
        RETURN 'REPROBADO';
    END IF;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `fn_promedio_ponderado` (`p_id_estudiante` INT, `p_id_asignatura` INT) RETURNS DECIMAL(5,2) DETERMINISTIC BEGIN
    DECLARE v_ef1 DECIMAL(5,2) DEFAULT 0; DECLARE v_ep1 DECIMAL(5,2) DEFAULT 0;
    DECLARE v_ef2 DECIMAL(5,2) DEFAULT 0; DECLARE v_ep2 DECIMAL(5,2) DEFAULT 0;
    DECLARE v_exf DECIMAL(5,2) DEFAULT 0; DECLARE v_rem DECIMAL(5,2) DEFAULT NULL;
    DECLARE v_parcial1 DECIMAL(5,2) DEFAULT 0;
    DECLARE v_parcial2 DECIMAL(5,2) DEFAULT 0;
    DECLARE v_final_usar DECIMAL(5,2) DEFAULT 0;
    DECLARE v_promedio_final DECIMAL(5,2) DEFAULT 0;

    -- Obtener las notas
    SELECT IFNULL(MAX(c.nota), 0) INTO v_ef1 FROM calificacion c JOIN evaluacion e ON c.id_evaluacion = e.id_evaluacion WHERE c.id_estudiante = p_id_estudiante AND e.id_asignatura = p_id_asignatura AND e.id_tipo_evaluacion = 1 AND c.activo = 1;
    SELECT IFNULL(MAX(c.nota), 0) INTO v_ep1 FROM calificacion c JOIN evaluacion e ON c.id_evaluacion = e.id_evaluacion WHERE c.id_estudiante = p_id_estudiante AND e.id_asignatura = p_id_asignatura AND e.id_tipo_evaluacion = 2 AND c.activo = 1;
    SELECT IFNULL(MAX(c.nota), 0) INTO v_ef2 FROM calificacion c JOIN evaluacion e ON c.id_evaluacion = e.id_evaluacion WHERE c.id_estudiante = p_id_estudiante AND e.id_asignatura = p_id_asignatura AND e.id_tipo_evaluacion = 3 AND c.activo = 1;
    SELECT IFNULL(MAX(c.nota), 0) INTO v_ep2 FROM calificacion c JOIN evaluacion e ON c.id_evaluacion = e.id_evaluacion WHERE c.id_estudiante = p_id_estudiante AND e.id_asignatura = p_id_asignatura AND e.id_tipo_evaluacion = 4 AND c.activo = 1;
    SELECT IFNULL(MAX(c.nota), 0) INTO v_exf FROM calificacion c JOIN evaluacion e ON c.id_evaluacion = e.id_evaluacion WHERE c.id_estudiante = p_id_estudiante AND e.id_asignatura = p_id_asignatura AND e.id_tipo_evaluacion = 5 AND c.activo = 1;
    SELECT MAX(c.nota) INTO v_rem FROM calificacion c JOIN evaluacion e ON c.id_evaluacion = e.id_evaluacion WHERE c.id_estudiante = p_id_estudiante AND e.id_asignatura = p_id_asignatura AND e.id_tipo_evaluacion = 6 AND c.activo = 1;

    -- Cálculos (P1 y P2)
    SET v_parcial1 = (v_ef1 + v_ep1) / 2;
    SET v_parcial2 = (v_ef2 + v_ep2) / 2;
    
    -- Si el estudiante dio remedial y sacó más, se reemplaza la nota del final
    IF v_rem IS NOT NULL AND v_rem > v_exf THEN
        SET v_final_usar = v_rem;
    ELSE
        SET v_final_usar = v_exf;
    END IF;

    -- Promedio General
    SET v_promedio_final = (v_parcial1 + v_parcial2 + v_final_usar) / 3;
    RETURN ROUND(v_promedio_final, 2);
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

--
-- Volcado de datos para la tabla `asignaciondocente`
--

INSERT INTO `asignaciondocente` (`id_asignacion`, `id_docente`, `id_asignatura`, `id_periodo`) VALUES
(5, 3, 2, 1),
(1, 4, 4, 1),
(3, 5, 5, 1),
(2, 6, 6, 1);

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
  `fecha` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci
PARTITION BY RANGE COLUMNS(`fecha`)
(
PARTITION p_historico VALUES LESS THAN ('2025-01-01') ENGINE=InnoDB,
PARTITION p_2025 VALUES LESS THAN ('2026-01-01') ENGINE=InnoDB,
PARTITION p_2026 VALUES LESS THAN ('2027-01-01') ENGINE=InnoDB,
PARTITION p_2027 VALUES LESS THAN ('2028-01-01') ENGINE=InnoDB,
PARTITION p_futuro VALUES LESS THAN (MAXVALUE) ENGINE=InnoDB
);

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
(28, '127.0.0.1', 1, 1, 'INSERT', 'calificacion', 3, NULL, '{\"nota\": \"6.50\"}', '2026-02-25 16:41:16'),
(29, '192.108.1.1', 1, 1, 'INSERT', 'usuario', 11, NULL, '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"id_rol\": \"4\"}', '2026-02-25 23:46:50'),
(30, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-25 23:48:11'),
(32, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-25 23:57:55'),
(33, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 00:04:37'),
(34, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 00:08:27'),
(35, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 00:22:43'),
(36, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 00:31:58'),
(37, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 01:03:52'),
(38, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 01:17:01'),
(39, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 01:19:50'),
(40, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 01:21:18'),
(41, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 01:42:13'),
(42, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 01:46:43'),
(43, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 01:58:24'),
(44, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 02:05:06'),
(45, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 02:07:10'),
(46, '169.254.243.153', 11, NULL, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 02:10:45'),
(47, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 03:07:12'),
(48, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 15:09:42'),
(49, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 16:03:35'),
(50, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 16:14:06'),
(51, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 16:24:13'),
(52, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 16:43:35'),
(53, '169.254.243.153', 11, 1, 'INSERT', 'asignaciondocente', 1, NULL, '{\"id_docente\": \"4\", \"id_asignatura\": \"4\", \"id_periodo\": \"1\"}', '2026-02-26 16:44:36'),
(54, '169.254.243.153', 11, 1, 'INSERT', 'asignaciondocente', 2, NULL, '{\"id_docente\": \"6\", \"id_asignatura\": \"6\", \"id_periodo\": \"1\"}', '2026-02-26 16:44:49'),
(55, '169.254.243.153', 11, 1, 'INSERT', 'asignaciondocente', 3, NULL, '{\"id_docente\": \"5\", \"id_asignatura\": \"5\", \"id_periodo\": \"1\"}', '2026-02-26 16:44:59'),
(56, '169.254.243.153', 11, 1, 'INSERT', 'asignaciondocente', 5, NULL, '{\"id_docente\": \"3\", \"id_asignatura\": \"2\", \"id_periodo\": \"1\"}', '2026-02-26 16:45:27'),
(57, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 17:03:53'),
(58, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"2\"}', '2026-02-26 17:06:05'),
(59, '169.254.243.153', 11, 2, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 17:22:00'),
(60, '169.254.243.153', 11, 2, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 17:24:40'),
(61, '169.254.243.153', 11, 2, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 17:25:45'),
(62, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 17:28:06'),
(63, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 10, '{\"nombre\": \"Pedro\", \"apellido\": \"Maldonado\", \"estado\": \"1\", \"id_rol\": \"3\"}', '{\"nombre\": \"Pedro\", \"apellido\": \"Maldonado\", \"estado\": \"1\", \"id_rol\": \"2\"}', '2026-02-26 17:31:13'),
(64, '169.254.243.153', 11, 1, 'INSERT', 'docente', 7, NULL, '{\"id_usuario\": \"10\"}', '2026-02-26 17:32:03'),
(65, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 18:03:23'),
(66, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 18:23:08'),
(67, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 18:25:34'),
(68, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 18:30:02'),
(70, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 18:38:20'),
(71, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 18:44:48'),
(72, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 18:57:08'),
(73, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 19:19:06'),
(74, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 19:34:58'),
(75, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 20:38:15'),
(76, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 21:21:58'),
(77, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 21:28:05'),
(78, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 21:45:07'),
(79, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, NULL, '{\"password_changed\": \"TRUE\"}', '2026-02-26 22:02:23'),
(80, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"FAILED_PASSWORD\"}', '2026-02-26 22:02:56'),
(82, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 22:04:02'),
(83, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 22:26:34'),
(84, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, NULL, '{\"password_changed\": \"TRUE\"}', '2026-02-26 22:28:11'),
(85, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 22:29:10'),
(86, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 23:04:11'),
(87, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-26 23:36:53'),
(88, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 00:28:03'),
(89, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, NULL, '{ \"correo_modificado\":\"TRUE\" }', '2026-02-27 00:30:28'),
(90, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '2026-02-27 00:37:49'),
(91, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '2026-02-27 00:38:11'),
(92, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '2026-02-27 00:39:25'),
(93, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 01:38:20'),
(94, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '{\"nombre\": \"Cristia\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '2026-02-27 01:42:53'),
(95, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, '{\"nombre\": \"Cristia\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '2026-02-27 01:43:13'),
(96, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 01:51:46'),
(97, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '{\"nombre\": \"Cristia\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '2026-02-27 01:53:50'),
(98, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, '{\"nombre\": \"Cristia\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '2026-02-27 01:53:55'),
(99, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 02:04:10'),
(100, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 02:17:03'),
(102, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 02:39:06'),
(103, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 02:39:45'),
(104, '169.254.243.153', 11, 1, 'UPDATE', 'calificacion', 1, '{\"nota\": \"9.50\"}', '{\"nota\": \"9.50\"}', '2026-02-27 02:46:01'),
(105, '169.254.243.153', 11, 1, 'UPDATE', 'calificacion', 3, '{\"nota\": \"6.50\"}', '{\"nota\": \"6.50\"}', '2026-02-27 02:46:01'),
(106, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 15:42:00'),
(107, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 18:41:37'),
(108, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 20:39:17'),
(109, '169.254.243.153', 11, 1, 'INSERT', 'usuario', 12, NULL, '{\"nombre\": \"Pepito\", \"apellido\": \"Pérez\", \"id_rol\": \"3\"}', '2026-02-27 20:44:35'),
(110, '169.254.243.153', 11, 1, 'INSERT', 'estudiante', 3, NULL, '{\"codigo\": \"EST-003\", \"id_usuario\": \"12\"}', '2026-02-27 20:44:57'),
(111, '169.254.243.153', 11, 1, 'INSERT', 'matricula', 3, NULL, '{\"id_estudiante\": \"3\", \"id_asignatura\": \"4\"}', '2026-02-27 20:45:17'),
(112, '169.254.243.153', 11, 1, 'UPDATE', 'calificacion', 1, '{\"nota\": \"9.50\"}', '{\"nota\": \"9.50\"}', '2026-02-27 20:45:59'),
(113, '169.254.243.153', 11, 1, 'UPDATE', 'calificacion', 3, '{\"nota\": \"6.50\"}', '{\"nota\": \"6.50\"}', '2026-02-27 20:45:59'),
(114, '169.254.243.153', 11, 1, 'INSERT', 'calificacion', 4, NULL, '{\"nota\": \"10.00\"}', '2026-02-27 20:45:59'),
(115, '169.254.243.153', 11, 1, 'UPDATE', 'calificacion', 2, '{\"nota\": \"8.75\"}', '{\"nota\": \"8.75\"}', '2026-02-27 20:46:14'),
(116, '169.254.243.153', 11, 1, 'INSERT', 'calificacion', 5, NULL, '{\"nota\": \"7.00\"}', '2026-02-27 20:46:14'),
(117, '169.254.243.153', 11, 1, 'INSERT', 'calificacion', 6, NULL, '{\"nota\": \"9.00\"}', '2026-02-27 20:46:56'),
(118, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 20:47:59'),
(119, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:06:56'),
(120, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:09:45'),
(121, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:15:51'),
(122, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:18:10'),
(123, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:20:22'),
(124, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:27:30'),
(125, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:30:08'),
(126, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:34:55'),
(127, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:39:23'),
(128, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:42:23'),
(129, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:47:51'),
(130, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:52:40'),
(131, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"FAILED_PASSWORD\"}', '2026-02-27 22:54:09'),
(132, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-27 22:54:29'),
(133, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 15:14:22'),
(134, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 15:45:09'),
(135, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 18:12:47'),
(136, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 18:21:14'),
(137, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 18:38:36'),
(138, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 18:46:59'),
(139, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 19:00:22'),
(140, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 19:02:12'),
(141, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 19:09:21'),
(142, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 19:12:09'),
(143, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 19:16:58'),
(144, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 19:29:25'),
(145, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 19:53:49'),
(146, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 19:55:21'),
(147, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 20:16:16'),
(148, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 20:47:23'),
(149, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 20:49:17'),
(150, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 20:53:24'),
(151, '169.254.243.153', 11, 1, 'INSERT', 'usuario', 13, NULL, '{\"nombre\": \"Alisson\", \"apellido\": \"Paredes\", \"id_rol\": \"4\"}', '2026-02-28 20:58:02'),
(152, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 21:00:17'),
(153, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 21:02:14'),
(154, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 21:04:40'),
(155, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 21:41:17'),
(156, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 21:52:57'),
(157, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 21:56:17'),
(158, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 21:58:44'),
(159, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 22:01:50'),
(160, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 22:06:16'),
(161, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 22:09:14'),
(162, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 22:10:55'),
(163, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 22:14:14'),
(164, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 22:19:41'),
(165, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 22:21:06'),
(166, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-02-28 22:22:47'),
(167, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 12:59:12'),
(168, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 14:25:34'),
(169, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 14:30:20'),
(170, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"FAILED_PASSWORD\"}', '2026-03-01 14:31:32'),
(171, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 14:31:51'),
(172, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 14:33:11'),
(173, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 14:38:20'),
(174, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 14:55:11'),
(175, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '{\"nombre\": \"Cristian\", \"apellido\": \"Pilc\", \"estado\": \"1\", \"id_rol\": \"1\"}', '2026-03-01 14:57:36'),
(176, '169.254.243.153', 11, 1, 'UPDATE', 'usuario', 11, '{\"nombre\": \"Cristian\", \"apellido\": \"Pilc\", \"estado\": \"1\", \"id_rol\": \"1\"}', '{\"nombre\": \"Cristian\", \"apellido\": \"Pilco\", \"estado\": \"1\", \"id_rol\": \"1\"}', '2026-03-01 14:58:02'),
(177, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 15:17:57'),
(178, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 15:29:19'),
(179, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 15:37:37'),
(180, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 15:42:51'),
(181, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 15:49:02'),
(182, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 15:54:46'),
(183, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 20:26:19'),
(184, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 20:30:53'),
(185, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 20:45:43'),
(186, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 20:48:11'),
(187, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 20:52:09'),
(188, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 21:00:35'),
(189, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 21:07:40'),
(190, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 21:13:05'),
(191, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 21:17:05'),
(192, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 21:24:36'),
(193, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 21:38:35'),
(194, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 22:13:01'),
(195, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 22:22:59'),
(196, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 22:27:59'),
(197, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 22:36:47'),
(198, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 22:40:38'),
(199, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 22:45:17'),
(200, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 22:47:48'),
(201, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 22:53:43'),
(202, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 22:59:05'),
(203, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:04:09'),
(204, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:12:15'),
(205, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:15:32'),
(206, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:18:05'),
(207, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:21:37'),
(208, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:24:43'),
(209, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:27:00'),
(210, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:29:44'),
(211, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:32:14'),
(212, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:34:03'),
(213, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:43:01'),
(214, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:46:22'),
(215, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-01 23:51:46'),
(216, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 14:38:43'),
(217, '169.254.243.153', 11, 1, 'UPDATE', 'calificacion', 1, '{\"nota\": \"9.50\"}', '{\"nota\": \"9.50\"}', '2026-03-02 14:43:37'),
(218, '169.254.243.153', 11, 1, 'UPDATE', 'calificacion', 3, '{\"nota\": \"6.50\"}', '{\"nota\": \"7.00\"}', '2026-03-02 14:43:37'),
(219, '169.254.243.153', 11, 1, 'UPDATE', 'calificacion', 4, '{\"nota\": \"10.00\"}', '{\"nota\": \"10.00\"}', '2026-03-02 14:43:37'),
(220, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 15:19:14'),
(221, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 16:45:15'),
(222, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 18:18:01'),
(223, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 18:24:36'),
(224, '169.254.243.153', 11, 1, 'INSERT', 'calificacion', 7, NULL, '{\"nota\": \"9.00\"}', '2026-03-02 18:27:30'),
(225, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 18:45:35'),
(226, '169.254.243.153', 11, 1, 'INSERT', 'calificacion', 8, NULL, '{\"nota\": \"8.00\"}', '2026-03-02 18:46:51'),
(227, '169.254.243.153', 11, 1, 'UPDATE', 'calificacion', 7, '{\"nota\": \"9.00\"}', '{\"nota\": \"9.00\"}', '2026-03-02 18:47:32'),
(228, '169.254.243.153', 11, 1, 'INSERT', 'calificacion', 9, NULL, '{\"nota\": \"7.50\"}', '2026-03-02 18:47:32'),
(229, '169.254.243.153', 11, 1, 'UPDATE', 'calificacion', 7, '{\"nota\": \"9.00\"}', '{\"nota\": \"9.00\"}', '2026-03-02 18:47:39'),
(230, '169.254.243.153', 11, 1, 'UPDATE', 'calificacion', 9, '{\"nota\": \"7.50\"}', '{\"nota\": \"8.75\"}', '2026-03-02 18:47:39'),
(231, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 19:04:08'),
(232, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 19:12:05'),
(233, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 19:15:27'),
(234, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 19:18:47'),
(235, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 19:26:07'),
(236, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 20:13:34'),
(237, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 20:49:25'),
(238, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 20:58:36'),
(239, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 21:27:54'),
(240, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 21:53:34'),
(241, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 22:23:37'),
(242, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 22:30:22'),
(243, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 22:36:14'),
(244, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 23:03:16'),
(245, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 23:10:38'),
(246, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 23:36:56'),
(247, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 23:41:28'),
(248, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-02 23:56:38'),
(249, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:08:35'),
(250, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:10:25'),
(251, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:13:22'),
(252, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:15:30'),
(253, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:17:47'),
(254, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:20:13'),
(255, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:23:00'),
(256, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:25:23'),
(257, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:29:16'),
(258, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:31:24'),
(259, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:38:07'),
(260, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:47:27'),
(261, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 00:54:34'),
(262, '169.254.243.153', 11, 1, 'LOGIN', 'usuario', 11, NULL, '{\"resultado\": \"SUCCESS_2FA\"}', '2026-03-03 01:16:36');

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
(7, 1, 13, 9.00, '2026-03-02 18:27:30', 1),
(8, 2, 12, 8.00, '2026-03-02 18:46:51', 1),
(9, 2, 13, 8.75, '2026-03-02 18:47:32', 1);

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
(6, 0x50e75616e8158b1b0fe65de9c07b4a68, 0xf8a853235b4a22c8bf608c4ed1864d3f4fb0f6cc1447fd18f2d09bb9e8b85a4d, 8, '2026-02-25 16:41:16', 1),
(7, 0x094c050a8fb5dd1eeb127d1430d75205, 0xffda55a3438e7f3e6cbbd0e5e48ef5e62a7f6ebb9756880e788eec7112620de5, 10, '2026-02-26 17:32:03', 1);

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
(2, 0x5e63e6c6f3c29239a9ad95796fb1c537, 0x3e623249fb3c3827d405c6719e80f82bdea3bb159c81ef50324290433727dce7, 'EST-002', 10, '2026-02-25 16:41:16', 1),
(3, 0x094c050a8fb5dd1eeb127d1430d75205, 0xffda55a3438e7f3e6cbbd0e5e48ef5e62a7f6ebb9756880e788eec7112620de5, 'EST-003', 12, '2026-02-27 20:44:57', 1);

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
(12, 4, 1, 1, 'Evaluación Frecuente 1 (Tareas)'),
(13, 4, 2, 1, 'Examen Parcial 1'),
(14, 4, 3, 1, 'Evaluación Frecuente 2 (Tareas)'),
(15, 4, 4, 1, 'Examen Parcial 2'),
(16, 4, 5, 1, 'Proyecto Final Integrador'),
(17, 4, 6, 1, 'Examen Remedial'),
(18, 1, 1, 1, 'Evaluación Frecuente 1 (Tareas)'),
(19, 2, 1, 1, 'Evaluación Frecuente 1 (Tareas)'),
(20, 3, 1, 1, 'Evaluación Frecuente 1 (Tareas)'),
(21, 5, 1, 1, 'Evaluación Frecuente 1 (Tareas)'),
(22, 6, 1, 1, 'Evaluación Frecuente 1 (Tareas)'),
(23, 1, 2, 1, 'Examen Parcial 1'),
(24, 2, 2, 1, 'Examen Parcial 1'),
(25, 3, 2, 1, 'Examen Parcial 1'),
(26, 5, 2, 1, 'Examen Parcial 1'),
(27, 6, 2, 1, 'Examen Parcial 1'),
(28, 1, 3, 1, 'Evaluación Frecuente 2 (Tareas)'),
(29, 2, 3, 1, 'Evaluación Frecuente 2 (Tareas)'),
(30, 3, 3, 1, 'Evaluación Frecuente 2 (Tareas)'),
(31, 5, 3, 1, 'Evaluación Frecuente 2 (Tareas)'),
(32, 6, 3, 1, 'Evaluación Frecuente 2 (Tareas)'),
(33, 1, 4, 1, 'Examen Parcial 2'),
(34, 2, 4, 1, 'Examen Parcial 2'),
(35, 3, 4, 1, 'Examen Parcial 2'),
(36, 5, 4, 1, 'Examen Parcial 2'),
(37, 6, 4, 1, 'Examen Parcial 2'),
(38, 1, 5, 1, 'Proyecto Final Integrador'),
(39, 2, 5, 1, 'Proyecto Final Integrador'),
(40, 3, 5, 1, 'Proyecto Final Integrador'),
(41, 5, 5, 1, 'Proyecto Final Integrador'),
(42, 6, 5, 1, 'Proyecto Final Integrador'),
(43, 1, 6, 1, 'Examen Remedial'),
(44, 2, 6, 1, 'Examen Remedial'),
(45, 3, 6, 1, 'Examen Remedial'),
(46, 5, 6, 1, 'Examen Remedial'),
(47, 6, 6, 1, 'Examen Remedial');

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
(2, 2, 4, 1),
(3, 3, 4, 1);

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
(1, 'Evaluación Frecuente 1', 16.66),
(2, 'Examen Parcial 1', 16.67),
(3, 'Evaluación Frecuente 2', 16.66),
(4, 'Examen Parcial 2', 16.67),
(5, 'Examen Final', 33.34),
(6, 'Remedial Final', 33.34);

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
(10, 'Pedro', 'Maldonado', 0xae6ae395d74e8ba99b9cee6609e4a1d4f8337c401cc2b79969930867e2218a3f, 0x5272ee1c015036a57c2b13d4a084c70e0d4b37eead62606e814469fbb1028169, NULL, NULL, '7016fa198a233f51a7f0d47cabbd65244822adcecc7c4c491367e245ab302236', 1, '2026-02-25 16:41:16', 0, NULL, '2026-02-25 16:41:16'),
(11, 'Cristian', 'Pilco', 0xed6b44d649d54187dde2f61079152638fe831782c95fde276aa9f697a071445b, 0xb3a9de62dafd476b6ca28cf89066b3d5423f02813b93348fac249ce88a945f7f, NULL, NULL, '82c2cb4784186792c6646a2b53ad4ca895c3e61e74796306190453c003804169', 1, '2026-02-26 22:28:11', 0, NULL, '2026-02-25 23:46:50'),
(12, 'Pepito', 'Pérez', 0xfa6a49e1210487ce4b5c96ecaeeb1a4e991aa391898bfab0bec6bf76d4421b56, 0x40ca7cfc6d82e7ce0aa5cfb5ccbf2501b29cadb05c31f5994d7b6ee18155177a, NULL, NULL, 'eab7a03a74b0be827f960dc32c42b58f48ca4586a639efcdac5d79cc31582f14', 1, '2026-02-27 20:44:35', 0, NULL, '2026-02-27 20:44:35'),
(13, 'Alisson', 'Paredes', 0x48176b23648d093ada448fea112518032c8dfbd801127e655f0b52406ab2567b, 0x88d05428b2bf9d9c3d49c405c164c1c165c84e21d619ca15abf4394a4b2508d2, NULL, NULL, 'eac6403ee6425e5a04d3c63527f350e4816a242b4c4bb71346fd48367a7af6a0', 1, '2026-02-28 20:58:02', 0, NULL, '2026-02-28 20:58:02');

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
(10, 2, '2026-02-26 17:31:13'),
(11, 1, '2026-02-26 17:06:05'),
(12, 3, '2026-02-27 20:44:35'),
(13, 4, '2026-02-28 20:58:02');

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `vista_auditoria_actual`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_auditoria_actual` (
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
-- Estructura Stand-in para la vista `vista_login_seguridad_actual`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `vista_login_seguridad_actual` (
`nombres` varchar(50)
,`apellidos` varchar(50)
,`fecha_ingreso` datetime
,`ip_user` varchar(45)
,`resultado_login` longtext
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
-- Estructura para la vista `vista_auditoria_actual`
--
DROP TABLE IF EXISTS `vista_auditoria_actual`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_auditoria_actual`  AS SELECT `a`.`id_auditoria` AS `id_auditoria`, concat(`u`.`nombre`,' ',`u`.`apellido`) AS `usuario_nombre`, `r`.`nombre` AS `rol`, `a`.`accion` AS `accion`, `a`.`tabla_afectada` AS `tabla_afectada`, `a`.`registro_id` AS `registro_id`, `a`.`valor_anterior` AS `valor_anterior`, `a`.`valor_nuevo` AS `valor_nuevo`, `a`.`fecha` AS `fecha` FROM ((`auditoria_sistema` `a` left join `usuario` `u` on(`a`.`id_usuario` = `u`.`id_usuario`)) left join `rol` `r` on(`a`.`id_rol` = `r`.`id_rol`)) WHERE `a`.`fecha` >= date_format(curdate(),'%Y-01-01') AND `a`.`fecha` < date_format(curdate() + interval 1 year,'%Y-01-01') ;

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
-- Estructura para la vista `vista_login_seguridad_actual`
--
DROP TABLE IF EXISTS `vista_login_seguridad_actual`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_login_seguridad_actual`  AS SELECT `u`.`nombre` AS `nombres`, `u`.`apellido` AS `apellidos`, `a`.`fecha` AS `fecha_ingreso`, `a`.`ip_user` AS `ip_user`, json_unquote(json_extract(`a`.`valor_nuevo`,'$.resultado')) AS `resultado_login` FROM (`auditoria_sistema` `a` join `usuario` `u` on(`a`.`id_usuario` = `u`.`id_usuario`)) WHERE `a`.`accion` = 'LOGIN' AND `a`.`fecha` >= date_format(curdate(),'%Y-01-01') AND `a`.`fecha` < date_format(curdate() + interval 1 year,'%Y-01-01') ;

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

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_reporte_academico`  AS SELECT `e`.`id_estudiante` AS `id_estudiante`, `u`.`nombre` AS `nombres`, `u`.`apellido` AS `apellidos`, `a`.`nombre` AS `asignatura`, `fn_promedio_ponderado`(`e`.`id_estudiante`,`a`.`id_asignatura`) AS `promedio_final`, `fn_estado_academico`(`e`.`id_estudiante`,`a`.`id_asignatura`) AS `estado` FROM (((`estudiante` `e` join `usuario` `u` on(`e`.`id_usuario` = `u`.`id_usuario`)) join `matricula` `m` on(`e`.`id_estudiante` = `m`.`id_estudiante`)) join `asignatura` `a` on(`m`.`id_asignatura` = `a`.`id_asignatura`)) ;

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
  ADD PRIMARY KEY (`id_auditoria`,`fecha`),
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
  MODIFY `id_asignacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `asignatura`
--
ALTER TABLE `asignatura`
  MODIFY `id_asignatura` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `auditoria_sistema`
--
ALTER TABLE `auditoria_sistema`
  MODIFY `id_auditoria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=263;

--
-- AUTO_INCREMENT de la tabla `calificacion`
--
ALTER TABLE `calificacion`
  MODIFY `id_calificacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `docente`
--
ALTER TABLE `docente`
  MODIFY `id_docente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `estudiante`
--
ALTER TABLE `estudiante`
  MODIFY `id_estudiante` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `evaluacion`
--
ALTER TABLE `evaluacion`
  MODIFY `id_evaluacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- AUTO_INCREMENT de la tabla `matricula`
--
ALTER TABLE `matricula`
  MODIFY `id_matricula` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

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
  MODIFY `id_tipo_evaluacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

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

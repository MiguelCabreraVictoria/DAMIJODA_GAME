-- Team Name: DAMIJODA
-- Team Members: Miguel Angel Cabrera Victoria      - A01782982
--               Luis Carlos Rico Alamada           - A01252831
--               Jose Daniel Rodrriguex Cruz        - A01781933
--               Natalia Maya Bolaños               - A01781992
--               David Santiago Vieyra Garcia       - A01656030
--               Joaquin Eduardo Saldarriaga Tamayo - A01783093

-- Teachers: Esteban Castillo Juarez
--           Octavio Navarro Hinojosa
--           Gilberto Echeverria Furío

-- Tecnologico de Monterrey, Campus Santa Fe

-- SQL Script to create the database and tables for the project


DROP SCHEMA IF EXISTS damijoda;
CREATE SCHEMA damijoda;
USE damijoda;

------------------------------------------------------------- SCRIPT SCHEMA -------------------------------------------------------------


---------
-- Usuarios table
---------

CREATE TABLE users (
    id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(255) NOT NULL,
    creation_date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY(id),
    UNIQUE KEY(username)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE users;

---------
-- Secuaces table
---------

CREATE TABLE enemies (
    enemy_id INT NOT NULL AUTO_INCREMENT,
    enemy_name VARCHAR(50) NOT NULL,
    HP INT UNSIGNED NOT NULL,
    attack INT UNSIGNED NOT NULL,
    defense INT UNSIGNED NOT NULL,
    velocity INT UNSIGNED NOT NULL,
    boss_id INT UNSIGNED NOT NULL,
    PRIMARY KEY(enemy_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE enemies;

---------
-- Jefes table
---------
CREATE TABLE bosses (
    boss_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    boss_name VARCHAR(50) NOT NULL,
    HP INT UNSIGNED NOT NULL,
    attack INT UNSIGNED NOT NULL,
    defense INT UNSIGNED NOT NULL,
    velocity INT UNSIGNED NOT NULL,
    enemy_id INT UNSIGNED NOT NULL,
    CONSTRAINT FOREIGN KEY fk_enemy_id (enemy_id) REFERENCES enemies(enemy_id) ON DELETE CASCADE,
    PRIMARY KEY(boss_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE bosses;


---------
-- Niveles table
---------

CREATE TABLE levels (
    level_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    boss_id INT UNSIGNED NOT NULL,
    CONSTRAINT FOREIGN KEY fk_boss_id (boss_id) REFERENCES bosses(boss_id),
    PRIMARY KEY(level_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE levels;

---------
-- Partidas table
---------

CREATE TABLE matches (
    match_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    user_id INT UNSIGNED NOT NULL,
    level_id INT UNSIGNED NOT NULL DEFAULT 1,
    match_name VARCHAR(50) NOT NULL,
    CONSTRAINT FOREIGN KEY fk_user_id (user_id) REFERENCES users(id) ON DELETE CASCADE,
    CONSTRAINT FOREIGN KEY fk_level_id (level_id) REFERENCES levels(level_id) ON DELETE CASCADE,
    PRIMARY KEY(match_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE matches;

---------
-- Personajes table
---------
CREATE TABLE characters (
    character_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    character_name VARCHAR(50) NOT NULL,
    HP INT UNSIGNED NOT NULL,
    attack INT UNSIGNED NOT NULL,
    defense INT UNSIGNED NOT NULL,
    velocity INT UNSIGNED NOT NULL,
    match_id INT UNSIGNED NOT NULL,
    CONSTRAINT FOREIGN KEY fk_match_id (match_id) REFERENCES matches(match_id) ON DELETE CASCADE,
    PRIMARY KEY(character_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE characters;

---------
-- Armas table
---------

CREATE TABLE weapons (
    weapon_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    weapon_name VARCHAR(50) NOT NULL,
    level INT UNSIGNED NOT NULL,
    damage INT UNSIGNED NOT NULL,
    character_id INT UNSIGNED NOT NULL,
    CONSTRAINT FOREIGN KEY fk_character_id (character_id) REFERENCES characters(character_id) ON DELETE CASCADE,
    PRIMARY KEY(weapon_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

---------
-- Gemas table
---------

CREATE TABLE gems (
    gem_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    gem_name VARCHAR(50) NOT NULL,
    level INT UNSIGNED NOT NULL,
    damage INT UNSIGNED NOT NULL,
    character_id INT NOT NULL,
    CONSTRAINT FOREIGN KEY fk_character_id (character_id) REFERENCES characters(character_id) ON DELETE CASCADE,
    PRIMARY KEY(gem_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

---------
-- Gemas table
---------

CREATE TABLE armors (
    armor_id INT UNSIGNED NOT NULL AUTO_INCREMENT,
    armor_name VARCHAR(50) NOT NULL,
    level INT UNSIGNED UNSIGNED NOT NULL,
    defense INT UNSIGNED UNSIGNED NOT NULL,
    character_id INT UNSIGNED NOT NULL,
    CONSTRAINT FOREIGN KEY fk_character_id (character_id) REFERENCES characters(character_id) ON DELETE CASCADE,
    PRIMARY KEY(armor_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;
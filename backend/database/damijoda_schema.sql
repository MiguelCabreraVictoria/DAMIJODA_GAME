-- Team Name: DAMIJODA
-- Team Members: Miguel Angel Cabrera Victoria      - A01782982
--               Luis Carlos Rico Alamada           - A
--               Jose Daniel Rodrriguex Cruz        - A
--               Natalia Maya Bolaños               - A
--               David Santiago Vieyra Garcia       - A
--               Joaquin Eduardo Saldarriaga Tamayo - A

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
    id INT NOT NULL AUTO_INCREMENT,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(255) NOT NULL,
    creation_date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY(id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE users;

---------
-- Secuaces table
---------

CREATE TABLE enemies (
    enemy_id INT NOT NULL AUTO_INCREMENT,
    enemy_name VARCHAR(50) NOT NULL,
    HP INT NOT NULL,
    attack INT NOT NULL,
    defense INT NOT NULL,
    velocity INT NOT NULL,
    boss_id INT NOT NULL,
    PRIMARY KEY(enemy_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE enemies;

---------
-- Jefes table
---------
CREATE TABLE bosses (
    boss_id INT NOT NULL AUTO_INCREMENT,
    boss_name VARCHAR(50) NOT NULL,
    HP INT NOT NULL,
    attack INT NOT NULL,
    defense INT NOT NULL,
    velocity INT NOT NULL,
    enemy_id INT NOT NULL,
    CONSTRAINT FOREIGN KEY fk_enemy_id (enemy_id) REFERENCES enemies(enemy_id),
    PRIMARY KEY(boss_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE bosses;


---------
-- Niveles table
---------

CREATE TABLE levels (
    level_id INT NOT NULL AUTO_INCREMENT,
    boss_id INT NOT NULL,
    CONSTRAINT FOREIGN KEY fk_boss_id (boss_id) REFERENCES bosses(boss_id),
    PRIMARY KEY(level_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE levels;

---------
-- Partidas table
---------

CREATE TABLE matches (
    match_id INT NOT NULL AUTO_INCREMENT,
    user_id INT NOT NULL,
    level_id INT NOT NULL,
    CONSTRAINT FOREIGN KEY fk_user_id (user_id) REFERENCES users(id),
    CONSTRAINT FOREIGN KEY fk_level_id (level_id) REFERENCES levels(level_id),
    PRIMARY KEY(match_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE matches;

---------
-- Personajes table
---------
CREATE TABLE characters (
    character_id INT NOT NULL AUTO_INCREMENT,
    character_name VARCHAR(50) NOT NULL,
    HP INT NOT NULL,
    attack INT NOT NULL,
    defense INT NOT NULL,
    velocity INT NOT NULL,
    match_id INT NOT NULL,
    CONSTRAINT FOREIGN KEY fk_match_id (match_id) REFERENCES matches(match_id),
    PRIMARY KEY(character_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE characters;

---------
-- Armas table
---------

CREATE TABLE weapons (
    weapon_id INT NOT NULL AUTO_INCREMENT,
    weapon_name VARCHAR(50) NOT NULL,
    level INT NOT NULL,
    damage INT NOT NULL,
    character_id INT NOT NULL,
    CONSTRAINT FOREIGN KEY fk_character_id (character_id) REFERENCES characters(character_id),
    PRIMARY KEY(weapon_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

---------
-- Gemas table
---------

CREATE TABLE gems (
    gem_id INT NOT NULL AUTO_INCREMENT,
    gem_name VARCHAR(50) NOT NULL,
    level INT NOT NULL,
    damage INT NOT NULL,
    character_id INT NOT NULL,
    CONSTRAINT FOREIGN KEY fk_character_id (character_id) REFERENCES characters(character_id),
    PRIMARY KEY(gem_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

---------
-- Gemas table
---------

CREATE TABLE armors (
    armor_id INT NOT NULL AUTO_INCREMENT,
    armor_name VARCHAR(50) NOT NULL,
    level INT NOT NULL,
    defense INT NOT NULL,
    character_id INT NOT NULL,
    CONSTRAINT FOREIGN KEY fk_character_id (character_id) REFERENCES characters(character_id),
    PRIMARY KEY(armor_id)
) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;



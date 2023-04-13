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

DROP SCHEMA IF  EXISTS damijoda;
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
-- Partidas table
---------

CREATE TABLE matches(
    match_id SMALLINT NOT NULL AUTO_INCREMENT,
    user_id SMALLINT NOT NULL,
    level_id SMALLINT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (level_id) REFERENCES levels(level_id),
    PRIMARY KEY(match_id)
    ) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE matches;

---------
-- Niveles table
---------

CREATE TABLE levels(
    level_id SMALLINT NOT NULL AUTO_INCREMENT,
    boss_id SMALLINT NOT NULL,
    enemy_id SMALLINT NOT NULL,
    FOREIGN KEY (level_id) REFERENCES bosses(boss_id),
    FOREIGN KEY (enemy_id) REFERENCES enemies(enemy_id),
    PRIMARY KEY(level_id)
    ) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE levels;

---------
-- Personajes table
---------
CREATE TABLE characters(
    character_id SMALLINT NOT NULL AUTO_INCREMENT,
    characters_name VARCHAR(50) NOT NULL,
    HP SMALLINT NOT NULL,
    attack SMALLINT NOT NULL,
    defense SMALLINT NOT NULL,
    velocity SMALLINT NOT NULL,
    match_id SMALLINT NOT NULL,
    FOREIGN KEY (match_id) REFERENCES matches(match_id),
    PRIMARY KEY(character_id)
    ) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE characters;

---------
-- Jefes table
---------
CREATE TABLE bosses(
    boss_id SMALLINT NOT NULL AUTO_INCREMENT,
    boss_name VARCHAR(50) NOT NULL,
    HP SAMLLINT NOT NULL,
    attack SMALLINT NOT NULL,
    defense SMALLINT NOT NULL,
    velocity SMALLINT NOT NULL,
    PRIMARY KEY(boss_id)
    ) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE bosses;

---------
-- Secuaces table
---------

CREATE TABLE enemies(
    enemy_id SMALLINT NOT NULL AUTO_INCREMENT,
    enemy_name VARCHAR(50) NOT NULL,
    HP SMALLINT NOT NULL,
    attack SMALLINT NOT NULL,
    defense SMALLINT NOT NULL,
    velocity SMALLINT NOT NULL,
    PRIMARY KEY(enemy_id)
    ) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE enemies;
---------
-- Armas table
---------

CREATE TABLE weapons(
    weapon_id SMALLINT NOT NULL AUTO_INCREMENT,
    weapon_name VARCHAR(50) NOT NULL,
    level SMALLINT NOT NULL,
    damage SMALLINT NOT NULL,
    character_id SMALLINT NOT NULL,
    FOREIGN KEY (character_id) REFERENCES personajes(character_id),
    PRIMARY KEY(weapon_id)
    ) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE weapons;
---------
-- Gemas table 
---------
CREATE table gems(
    gem_id SMALLINT NOT NULL AUTO_INCREMENT,
    gem_name VARCHAR(50) NOT NULL,
    effect VARCHAR(50) NOT NULL,
    character_id SMALLINT NOT NULL,
    FOREIGN KEY (character_id) REFERENCES characters(character_id),
    PRIMARY KEY(gem_id)
    ) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE gems;

---------
-- Armaduras table
---------

CREATE table armor(
    armor_id SMALLINT NOT NULL AUTO_INCREMENT,
    armor_name VARCHAR(50) NOT NULL,
    level SMALLINT NOT NULL,
    defense SMALLINT NOT NULL,
    character_id SMALLINT NOT NULL,
    FOREIGN KEY (character_id) REFERENCES personajes(character_id),
    PRIMARY KEY(armor_id)
    ) ENGINE = InnoDB DEFAULT CHARSET=utf8mb4;

DESCRIBE armor;



--



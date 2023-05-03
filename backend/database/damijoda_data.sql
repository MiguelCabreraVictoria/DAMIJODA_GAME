
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

-- SQL Script to insert data into the db 

--No se establece una tabla de usuarios debido a que las contraseña se guardan encriptadas en la base de datos.

USE damijoda;

SET FOREIGN_KEY_CHECKS = 0;

INSERT INTO damijoda.enemies (enemy_name, HP, attack, defense, velocity, boss_id) VALUES
    ('Oraculo', 50, 10, 5, 20, 1),
    ('Velafar', 50, 15, 10, 15, 2),
    ('VelafarVerde', 50, 20, 15, 10, 3),
    ('Astaroth', 50, 25, 20, 5, 4),
    ('Berius', 50, 30, 25, 3, 4);

INSERT INTO  damijoda.bosses (boss_name, HP, attack, defense, velocity, enemy_id) VALUES
    ('SeQueLus', 100, 50, 30, 10, 1),
    ('Octerminiti', 120, 75, 50, 5, 2),
    ('Gileus', 100 , 75 , 50 , 5 , 3),
    ('Socio', 200, 100, 75, 3, 4);

INSERT INTO damijoda.levels (boss_id) VALUES
    (1),
    (2),
    (3),
    (4);


INSERT INTO damijoda.matches (user_id, level_id, match_name) VALUES
    (1, 3,'partida Miguel'),
    (2, 2,'partida Luis'),
    (3, 1, 'partida David'),
    (4, 4, 'partida Nat'), -- added comma after 4
    (5, 2, 'partida Daniel'),
    (6, 1, 'partida Joaquin');


INSERT INTO damijoda.characters (character_name, HP, attack, defense, velocity, match_id) VALUES
    ('Miguel', 150, 30, 10, 15, 1),
    ('Luis', 150, 30, 10, 15, 4),
    ('David', 150, 30, 10, 15, 2),
    ('Nat', 150, 30, 10, 15, 3),
    ('Daniel', 150, 30, 10, 15, 5),
    ('Joaquin', 150, 30, 10, 15, 6);

INSERT INTO damijoda.weapons (weapon_name, level, damage, character_id) VALUES
    ('SableLaser', 1, 10, 1),
    ('EspadaPlata', 2, 15, 2),
    ('EspadaMadera', 3, 20, 3),
    ('EspadaHoro', 1, 10, 4),
    ('Katana', 3, 20, 5);

INSERT INTO damijoda.gems (gem_name, level, damage, character_id) VALUES
    ('red', 1, 5, 1),
    ('white', 2, 10, 2),
    ('green', 3, 15, 3),
    ('yellow', 4, 5, 4),
    ('purple', 3, 15, 5);

INSERT INTO damijoda.armors (armor_name, level, defense, character_id) VALUES
    ('ArmaduraDeBronce', 1, 5, 1),
    ('ArmaduraDeCuero', 2, 10, 2),
	('ArmaduraDePlata', 3, 15, 3),
	('ArmaduraDeOro', 3, 5, 4),
<<<<<<< HEAD
	('ArmaduraMagica', 5, 15, 5);
=======
	('ArmaduraMagica', 5, 15, 5);


SET FOREIGN_KEY_CHECKS = 1;
>>>>>>> 34f2c131b803d6332d0957a8389febfde6f44c00

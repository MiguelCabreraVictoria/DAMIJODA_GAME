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

USE damijoda;

INSERT INTO damijoda.enemies (enemy_name, HP, attack, defense, velocity, boss_id) VALUES
    ('Oraculo', 50, 10, 5, 20, 1),
    ('Velafar', 50, 15, 10, 15, 1),
    ('VelafarVerde', 50, 20, 15, 10, 2),
    ('Astaroth', 50, 25, 20, 5, 2),
    ('Berius', 50, 30, 25, 3, 3) 
    SET FOREIGN_KEY_CHECKS=0;

INSERTO INTO damijoda.bosses (boss_name, HP, attack, defense, velocity, enemy_id) VALUES
    ('SeQueLus', 100, 50, 30, 10, 1),
    ('Octerminiti', 120, 75, 50, 5, 3),
    ('Gileus',100,75,50,5,5),
    ('Socio', 200, 100, 75, 3, 5);

INSERT INTO damijoda.levels (boss_id) VALUES
    (1),
    (2),
    (3),
    (4);


INSERT INTO damijoda.matches (user_id, level_id) VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 2),
    (5, 4);

INSERT INTO damijoda.characters (character_name, HP, attack, defense, velocity, match_id) VALUES
    ('Miguel', 150, 35, 10, 15, 1),
    ('Nat', 150, 25, 15, 10, 2),
    ('David', 150, 15, 5, 20, 4),
    ('Joaq', 150, 30, 20, 5, 3),
    ('Luis', 150, 30, 20, 5, 5),
    ('Daniel', 150, 30, 20, 5, 6);

INSERT INTO damijoda.weapons (weapon_name, level, damage, character_id) VALUES
    ('SableLaser', 1, 10, 1),
    ('EspadaPlata', 2, 15, 2),
    ('EspadaMadera', 3, 20, 3),
    ('EspadaHoro', 1, 10, 4),
    ('Katana', 3, 20, 5);

INSERT INTO damijoda.gems (gem_name, level, damage, character_id) VALUES
    ('Roja', 1, 5, 1),
    ('Blanca', 2, 10, 2),
    ('Verde', 3, 15, 3),
    ('Amarilla', 1, 5, 4),
    ('Morada', 3, 15, 5);

INSERT INTO damijoda.armors (armor_name, level, defense, character_id) VALUES
    ('ArmaduraDeBronce', 1, 5, 1),
    ('ArmaduraDeCuero', 2, 10, 2),
	('ArmaduraDePlata', 3, 15, 3),
	('ArmaduraDeOro', 3, 5, 4),
	('ArmaduraMagica', 5, 15, 5);
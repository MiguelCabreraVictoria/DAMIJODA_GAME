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

-- SQL Script to insert dummy data into the db

-- Insertar usuarios
INSERT INTO users (username, password) VALUES
    ('beborico', 'password1'),
    ('miguel23', 'password2'),
    ('rale0', 'password3'),
    ('daniel', 'password4'),
    ('nat', 'password5');

-- Insertar enemigos
INSERT INTO enemies (enemy_name, HP, attack, defense, velocity, boss_id) VALUES
    ('Oraculo', 50, 10, 5, 20, 1),
    ('Velafar', 80, 15, 10, 15, 1),
    ('VelafarVerde', 100, 20, 15, 10, 2),
    ('Astartoh', 120, 25, 20, 5, 2),
    ('Berius', 150, 30, 25, 3, 3);

-- Insertar jefes
INSERT INTO bosses (boss_name, HP, attack, defense, velocity, enemy_id) VALUES
    ('SeQueLus', 500, 50, 30, 10, 1),
    ('Octerminiti', 800, 75, 50, 5, 3),
    ('Socio', 1200, 100, 75, 3, 5);

-- Insertar niveles
INSERT INTO levels (boss_id) VALUES
    (1),
    (2),
    (3);

-- Insertar partidas
INSERT INTO matches (user_id, level_id) VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 1),
    (5, 3);

-- Insertar personajes
INSERT INTO characters (character_name, HP, attack, defense, velocity, match_id) VALUES
    ('Miguel', 100, 20, 10, 15, 1),
    ('Nat', 120, 25, 15, 10, 2),
    ('David', 80, 15, 5, 20, 4),
    ('Joaq', 150, 30, 20, 5, 3),
    ('Bebo', 80, 15, 5, 20, 4),
    ('Daniel', 100, 20, 15, 10, 5);

-- Insertar armas
INSERT INTO weapons (weapon_name, level, damage, character_id) VALUES
    ('SableLaser', 1, 10, 1),
    ('EspadaPlata', 2, 15, 2),
    ('EspadaMadera', 3, 20, 3),
    ('EspadaHoro', 1, 10, 4),
    ('Katana', 3, 20, 5);

-- Insertar gemas
INSERT INTO gems (gem_name, level, damage, character_id) VALUES
    ('Roja', 1, 5, 1),
    ('Blanca', 2, 10, 2),
    ('Verde', 3, 15, 3),
    ('Amarilla', 1, 5, 4),
    ('Morada', 3, 15, 5);

-- Insertar armaduras
INSERT INTO armors (armor_name, level, defense, character_id) VALUES
    ('ArmaduraDeBronce', 1, 5, 1),
    ('ArmaduraDeCuero', 2, 10, 2),
	('ArmaduraDePlata', 3, 15, 3),
	('ArmaduraDeOro', 1, 5, 4),
	('ArmaduraMagica', 3, 15, 5);


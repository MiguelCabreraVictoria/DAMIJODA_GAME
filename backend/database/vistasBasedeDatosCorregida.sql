-- Vista 1 – Usuarios y partidas:
CREATE VIEW user_matches AS SELECT u.username, m.match_id, m.level_id 
FROM users u INNER JOIN matches m ON u.id = m.user_id;
-- Vista 2 – Personajes y armaduras:
CREATE VIEW character_equipment AS SELECT c.character_name, w.weapon_name, g.gem_name, a.armor_name 
FROM characters c LEFT JOIN weapons w ON c.character_id = w.character_id 
LEFT JOIN gems g ON c.character_id = g.character_id 
LEFT JOIN armors a ON c.character_id = a.character_id;
-- Vista 3 – Bosses y niveles:
CREATE VIEW boss_levels AS SELECT b.boss_name, l.level_id 
FROM bosses b INNER JOIN levels l ON b.boss_id = l.boss_id;
-- Vista 4 – Bosses y enemies (secuaces):
CREATE VIEW boss_enemies AS SELECT b.boss_name, e.enemy_name 
FROM bosses b INNER JOIN enemies e ON b.boss_id = e.boss_id;

--Creacion de Views 

USE damijoda;

CREATE VIEW;

-- Levels and bosses
CREATE VIEW level_join_boss AS
SELECT levels.level_id, bosses.boss_name, bosses.HP, bosses.attack, bosses.defense, bosses.velocity
FROM levels
INNER JOIN bosses ON levels.boss_id = bosses.boss_id;

-- Character details (gems, armour and weapons)

CREATE VIEW character_details AS
SELECT characters.character_id, characters.character_name, characters.HP, characters.attack, characters.defense, characters.velocity,
weapons.weapon_id, weapons.weapon_name, weapons.level AS weapon_level, weapons.damage AS weapon_damage,
gems.gem_id, gems.gem_name, gems.level AS gem_level, gems.damage AS gem_damage,
armors.armor_id, armors.armor_name, armors.level AS armor_level, armors.defense AS armor_defense
FROM characters
LEFT JOIN weapons ON characters.character_id = weapons.character_id
LEFT JOIN gems ON characters.character_id = gems.character_id
LEFT JOIN armors ON characters.character_id = armors.character_id;

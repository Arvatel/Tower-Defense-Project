# Tower Defence Project

Project created for Elective "Game Development with Unity"
Idea from the game Sanctum 2 

## Project features:
- Wave-based enemy spawning 
- Enemies moves by predefined paths
- Several maps
	- At least 3
- Difficulty scaling
- Building structures to defend the base (Towers)
	- 3-4 types
	- Limited ammo
- Resource management 
	- Collect resources to improve defences
	- 3-4 types of resources
	- Replenish ammo for Towers
- Different weapon types for the player 
	- At least 2 - like Shotgun and SMG
- Lvl based players body
	- Character improves from game to game
	- Special features opens when lvl increasing
- Abilities for player during the game
	- Increase ammo capacity for Towers
	- Increase speed of fire or damage dealt by Towers when player is nearby
	- Increase amount of resources received

### Note:
Description will change during development

## Work Done:
- Basic movement system
	- Includes jumping, walking, running
- Base script for interactions with objects
	- Descriptions to help user with interactions
	- Creating Tower by interacting
- Automatic gathering resources
	- Detecting, picking up and destroing resource object afterwards
	- Storing in simple Player's inventory
- Simple Health System for Player
	- Shows Health Bar
	- Ability to take damage and restore health
- Base scripting for Towers
	- Detecting Enemies within predefined radius
	- Shooting Enemies and spending ammo
	- Abstract class for simple Tower creating process
- Simplified Enemy 
	- Taking damage
	- Dieing after loosing all HP

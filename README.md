# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**


**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Producer

**The producer coordinates the technical dependencies and basic team logistics. Responsibilities include but are not limited to creating a dependency chart for the significant development tasks for the game, coordinating team meetings, working with the other roles to integrate their work into the main project, deciding on the Git-based workflow (i.e. how everyone's work gets combined into release branches without breaking the project), and organizing the final presentation.**

**While this role has fewer direct programming responsibilities, it requires understanding all parts of the development process. When performed well, the producer multiplies the effort of the entire team, which results in a better game project.**

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

#### Below is the resources used in this game:
[Portal: Animated 2D Portal Spritesheet by Cookiscuit](https://cookiscuit.itch.io/animated-2d-portal-spritesheet)  
[Monsters: Monsters Creatures Fantasy by Luiz Melo](https://luizmelo.itch.io/monsters-creatures-fantasy)  
[Main character: Free Wizard Sprite Sheets Pixel Art by Craftpix](https://craftpix.net/freebies/free-wizard-sprite-sheets-pixel-art/)  
[Background: Free War Pixel Art 2D Backgrounds by Craftpix](https://craftpix.net/freebies/free-war-pixel-art-2d-backgrounds/)  
[Background: Pixel Backgrounds Laboratory Dark 1-4 by ComradeCourage](https://www.deviantart.com/comradecourage/art/Pixel-Backgrounds-Laboratory-Dark-1-4-868674719)  

I was mainly in charge of creating the animations for the game. This involved designing actions for various elements such as the main character, monsters, teleportation portal, and spells.  

For the main character, I created basic movements like standing, walking, running, and getting hurt. I also added different attack actions, including two regular attacks, casting a fireball, and using flamejet. In the monster part, I designed four different types of monsters: goblins, fly eyes, mushrooms, and skeletons. Each monster has its own actions like walking, standing, and attacking. I also tried to add spellcasting actions for the monsters, but due to technical and time limitations, these actions were unused in the final game. The portal part consists of a sprite sheet for the teleportation portal and animations for its appearance. As for the spells, there were totally five different options, but since the main character focuses on fire magic, only the fireball spell was used in the game eventually.  

I created corresponding folders and categorized the materials, all sprite sheets use none compression and their filter mode is point. For every different item and character, I created an animation controller and edited the logic for transitions between actions. In order to facilitate some action transitions, I added triggers to some actions. For example, in order to allow the character to attack while moving, I added a trigger to the fireball action and used it in the [code](https://github.com/Sherry1016/ECS189L_Final_Project/blob/74691c39d3e861ae9cce1401316a26a6b09dc17b/Survival/Assets/Scripts/MainCharacter.cs#L256), allowing the character's actions to transition smoothly. In order to make some attack actions coordinate smoothly with animations, I created some IEnumerators for fireball and jump, such as [DelayedFireBall](https://github.com/Sherry1016/ECS189L_Final_Project/blob/74691c39d3e861ae9cce1401316a26a6b09dc17b/Survival/Assets/Scripts/MainCharacter.cs#L205). This way, the occurrence of attack actions will not conflict with the animation. There are also some minor modifications, such as adjusting the position and frequency of the fireball shooting. The fireball is shot out from the position where the character raises their hand, and the character is restricted from attacking again before the previous attack action is over. Subsequently, to solve the problem of animation playback delay, I set all time durations to 0, and set an exit time of 1 for some animations.  

I added a mechanism for [generating portals](https://github.com/Sherry1016/ECS189L_Final_Project/blob/dcb61bddb823942a5d65577e2b91c4eb92e876a7/Survival/Assets/Scripts/SpawnSystem.cs#L54), which determines whether to generate a portal by checking the number of remaining monsters in the current stage of the character. If the number of monsters in the current stage is 0, then the portal will be generated on the right side of the character and teleport the character to the far left side of the next stage. In addition to this, I modified the logic of the [camera](https://github.com/Sherry1016/ECS189L_Final_Project/blob/dcb61bddb823942a5d65577e2b91c4eb92e876a7/Survival/Assets/Scripts/CameraObjectFollow.cs#L28), limiting the x position of the camera within the range of the map, and imposed restrictions on the movement of the character, so that the range of character movement cannot exceed the display range of the screen, thereby limiting the size of the map.

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

#### Background audio: ####
[bgm1](https://assetstore.unity.com/packages/audio/sound-fx/foley/fantasy-sfx-for-particle-distort-texture-effect-library-42146)  
[bgm2](https://assetstore.unity.com/packages/audio/music/rpg-game-music-63051)  
[bgm3](https://assetstore.unity.com/packages/audio/sound-fx/horror-game-essentials-153417)  
#### Sound effects: ####
[fire](https://assetstore.unity.com/packages/audio/sound-fx/foley/fantasy-sfx-for-particle-distort-texture-effect-library-42146)  
[jump](https://pixabay.com/sound-effects/human-impact-on-ground-6982/)  
[dodge](https://assetstore.unity.com/packages/audio/sound-fx/foley/fantasy-sfx-for-particle-distort-texture-effect-library-42146)  
[transport](https://assetstore.unity.com/packages/audio/sound-fx/foley/fantasy-sfx-for-particle-distort-texture-effect-library-42146)  
[lose](https://assetstore.unity.com/packages/audio/sound-fx/foley/fantasy-sfx-for-particle-distort-texture-effect-library-42146)  
[win](https://pixabay.com/sound-effects/winfantasia-6912/). 

I attached a location trigger script as the component to the corresponding three different terrains: daytime, sunset and nighttime. When the player enters the terrain, the corresponding background music is triggered and will automatically play. To ensure the corresponding uninterrupted background music throughout each level, we set the music as “play on awake” and “Loop”. I also add three action sound effects to the main character such as jump, dodge and attacking ,and add sounds to the portal to enhance the game feeling. 

Given that our game is a role-playing adventure set in a magical world on the brink of destruction, we have adopted a sound style that leans towards horror, tension, and excitement. This deliberate choice aligns with our game's theme and aims to elevate the immersive experience.


## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

#### presskit materials:
[Survival](https://juditost.itch.io/survival?secret=0guHxVlXkENKlZyvOZCaO0yus)  

#### trailer:
[Trailer](https://www.youtube.com/watch?v=qDfukOdoYq8)


The web page for this game is a draft and has not been published. I gave a simple description of the game, included the materials we used in our game, as well as some game screenshots. The production of this trailer is also relatively simple. As neither my team members nor I have video editing experience, plus the production period of this video was during the final examination period. Under the dual constraints of technology and time, the production quality of the trailer is not high. In the video, I focused on showcasing the various mechanics and skills of the game. Finally, it ends on the game's title screen to conclude the trailer. I used online video editor [Clipchamp](https://app.clipchamp.com/) to create the trailer.  



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**

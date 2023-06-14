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

## Movement/Physics (Shuyang Qian)
**Name: Shuyang Qian**  
**Email: syqian@ucdavis.edu**  
**Github: ElaineQian09**

- Preparation:  
Add three kinds of monster prefabs, in order to make the future physics effect, for example, attack, dead, add the `Box Collider 2D` and `Rigidbody 2D`.  
Add the `Box Collider 2D` and `Rigidbody 2D` for the Main Character to lay a good foundation for the follow-up work.  

* Main Character:
1. Left and Right movement:  
In the `MainCharacter.cs script`, I use the input system, with the help of the project settings Input Manager, can gain the command from the player: https://github.com/Sherry1016/ECS189L_Final_Project/blob/7a593d3498a23cda14f1751061998e329346b2d1/Survival/Assets/Scripts/MainCharacter.cs#L69-L72
Then, we can convert it from -1 to 1 and put it into `xvalue`. Then calculate the moving point by multiplying`xvalue` (determine the moving direction ), `speed`, `Time.deltaTime`, and `Vector2.right`. At the same time, the flip X of the character sprite is assigned according to the positive and negative values of `xvalue` to realize the character's orientation flip: https://github.com/Sherry1016/ECS189L_Final_Project/blob/7a593d3498a23cda14f1751061998e329346b2d1/Survival/Assets/Scripts/MainCharacter.cs#L84. 

2. Other Movement Effects of the Main Character:
In addition, I better manage character movement expressions such as [attacks](https://github.com/Sherry1016/ECS189L_Final_Project/blob/2592e1029b0c4262da0a2b784cd087b08cef5c10/Survival/Assets/Scripts/MainCharacter.cs#L249-L251), hurt, and dead by using the corresponding animation. I set the Bool value in the Parameters in the Animator of the Main Character. When the statement is true, it activates the animation, and then exits the animation, giving the player a smoother and more vivid experience. To make sure the hurt action is complete and smooth, add the 0.35 seconds [Delay](https://github.com/Sherry1016/ECS189L_Final_Project/blob/2592e1029b0c4262da0a2b784cd087b08cef5c10/Survival/Assets/Scripts/MainCharacter.cs#L356)
by using the `StartCoroutine()` and `IEnumerator`. 
3. Physics  
I choose to set the `Body Type` to `Dynamic` to better simulate the real-world situation.  
Set the `tag` of the Main Character and with the help of the `Box Collider 2D`, can have a collision and pass through the Portal to enter the next level.
Freeze the Rotation of z in the `Constraints` to make sure the Main Character still heads up and will not fall down stiffly.  
Set the `Gravity Scale` of the Main Character to 1.5 to make the jump more vivid.  


+ Monster:

1. Creation of the monster: 
We have three scenes and each scene has one ground. I Create a `Spawnsystem.cs` to better manage different monsters that will be generated at different levels. Using this system will be easier to manage different monsters that have different settings which can make our game more playable: https://github.com/Sherry1016/ECS189L_Final_Project/blob/1528da97dca51d14ad23453bb1340ed5e3ac21b0/Survival/Assets/Scripts/SpawnSystem.cs#L22-L24 https://github.com/Sherry1016/ECS189L_Final_Project/blob/1528da97dca51d14ad23453bb1340ed5e3ac21b0/Survival/Assets/Scripts/SpawnSystem.cs#L34-L39  
I also use the [for statement to create the monsters](https://github.com/Sherry1016/ECS189L_Final_Project/blob/1528da97dca51d14ad23453bb1340ed5e3ac21b0/Survival/Assets/Scripts/SpawnSystem.cs#L44-L52). Also changing the i number can change the number of monsters generated in each level.

2. Movement of the monster: 
Using the `random.range` to get the x position and let it be the `targetpostion` to achieve random coordinate generation. According to the comparison between the new position and current position x value, the flip X of the character's sprite is assigned according to the positive and negative values between them to realize the character's orientation flip. Monsters also have the ability to track attacks in the set version:
https://github.com/Sherry1016/ECS189L_Final_Project/blob/342a7c30be1d99426c48d4853fb31654d0c30de0/Survival/Assets/Scripts/PirateController.cs#L60-L64  
When the Main Character moves away from the Monsters, they will go back to normal and go to random locations again. In oder to better manage monsters’ behavior, I also declare [the enumeration of the MonsterType](https://github.com/Sherry1016/ECS189L_Final_Project/blob/6328c2dc05fe3ad822b395d2c4f03b43fa788d93/Survival/Assets/Scripts/PirateController.cs#L8-L14)


3. Physics  
I choose to set the `Body Type` in the `Rigidbody 2D` to `Kinematic` to let them not have a gravity effect but can still get collided.  
Set the `Is Trigger` in the `Box Collider 2D` to let the monster not push each other when they move in the same level. 

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


## Gameplay Testing (Shuyang Qian)
**Name: Shuyang Qian**  
**Email: syqian@ucdavis.edu**  
**Github: ElaineQian09**

- Game testing is very important for game development, as it can help our developers better improve our game playability. Our group did game testing from time to time. During our development process, each time when our group members push new files on GitHub, I will download them and make some notes for improvement, then I will communicate with my group members and then distribute tasks to each member in our group to deal with it. Testing needs to pay attention to many aspects. For example, I noticed that the hurt and attack animation is not smooth for the Main Character, so I canceled the Exit time to let the animation more smooth and give the player a better visual experience. I also find some potential problems in our game, like the monsters can not randomly move when they are close to each other and the Main Character may sometimes get stuck. This problem will cause our game to not run successfully. After communicating with my group members, we finally solved this problem.

- Game testing not only tests the game and finds some potential running problems but also tries to find the best presentation of the game. After testing the game many times, I choose to set the Gravity Scale Main Character to 1.5 instead of 1 (built-in value) to make the jump more vivid. We also set different speeds and damage amounts for different monsters, so that the game difficulty will be progressive. After testing the game again and again, our game became more and more playable and solved some potential problems that may let our game crushed.

- I also do the game testing after everything is done. I invite ten people to play our game and here is the link for the [Observations and Playtester Comments form summary version](https://docs.google.com/document/d/1TPuzrFwl4hrnDEZRaEj5rH0Bu1S-puC1CbGLLLasNn4/edit?usp=sharing.). This form contains all my thoughts and findings when testing. I also let them rate our game. I made two tables to show the result more clearly: https://docs.google.com/spreadsheets/d/18lXD0Wz-vKrKnqIJ1FK3InlfIqK6n3yp6WoHyOBlZp4/edit?usp=sharing. 

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

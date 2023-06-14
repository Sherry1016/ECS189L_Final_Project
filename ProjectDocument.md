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

**Describe the steps you took in your role as producer. Typical items include group scheduling mechanism, links to meeting notes, descriptions of team logistics problems with their resolution, project organization tools (e.g., timelines, depedency/task tracking, Gantt charts, etc.), and repository management methodology.**

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

## Movement/Physics (Shuyang Qian)
**Name: Shuyang Qian**  
**Email: syqian@ucdavis.edu**  
**Github: ElaineQian09**

- Preparation:  
I add three kinds of monster prefabs, in order to make the future physics effect, for example, attack, dead, add the `Box Collider 2D` and `Rigidbody 2D`.  
I add the `Box Collider 2D` and `Rigidbody 2D` for the Main Character to lay a good foundation for the follow-up work.  

* Main Character:
1. Left and Right movement:  
In the `MainCharacter.cs script`, I use the input system, with the help of the project settings Input Manager, can gain the command from the player: https://github.com/Sherry1016/ECS189L_Final_Project/blob/7a593d3498a23cda14f1751061998e329346b2d1/Survival/Assets/Scripts/MainCharacter.cs#L69-L72
Then, we can convert it from -1 to 1 and put it into `xvalue`. Then calculate the moving point by multiplying`xvalue` (determine the moving direction ), `speed`, `Time.deltaTime`, and `Vector2.right`. At the same time, the flip X of the character sprite is assigned according to the positive and negative values of `xvalue` to realize the character's orientation flip: https://github.com/Sherry1016/ECS189L_Final_Project/blob/7a593d3498a23cda14f1751061998e329346b2d1/Survival/Assets/Scripts/MainCharacter.cs#L84

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

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input (Zijun Ye)
In our game, we use the keyboard to control our main characters.

In `MainCharacter.cs`, we use `GetKeyDown` to determine the key pressed by the player and give the corresponding action and skill back to the player.

["A"](https://github.com/Sherry1016/ECS189L_Final_Project/blob/2592e1029b0c4262da0a2b784cd087b08cef5c10/Survival/Assets/Scripts/MainCharacter.cs#L71) for left move, "D" for left move and "space" for jump.

["L"](https://github.com/Sherry1016/ECS189L_Final_Project/blob/2592e1029b0c4262da0a2b784cd087b08cef5c10/Survival/Assets/Scripts/MainCharacter.cs#L315) for high speed and the main character will be able to dodge the monsters' attacks.

["J"](https://github.com/Sherry1016/ECS189L_Final_Project/blob/2592e1029b0c4262da0a2b784cd087b08cef5c10/Survival/Assets/Scripts/MainCharacter.cs#L251) for normal attack, the main character will launch a fireball.

["O"](https://github.com/Sherry1016/ECS189L_Final_Project/blob/2592e1029b0c4262da0a2b784cd087b08cef5c10/Survival/Assets/Scripts/MainCharacter.cs#L183) for ultimate skill, the main character will launch multiple fireballs and increase the attack power.

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Cross-Platform

**Describe the platforms you targeted for your game release. For each, describe the process and unique actions taken for each platform. What obstacles did you overcome? What was easier than expected?**

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

I attached a location trigger script as the component to the corresponding three different terrains: daytime, sunset and nighttime. When the player enters the terrain, the corresponding background music is triggered and will automatically play. To ensure the corresponding uninterrupted background music throughout each level, we set the music as “play on awake” and “Loop”. I also add three action sound effects to the main character such as jump, dodge and attacking ,and add sounds to the portal to enhance the game feeling. Given that our game is a role-playing adventure set in a magical world on the brink of destruction, we have adopted a sound style that leans towards horror, tension, and excitement. This deliberate choice aligns with our game's theme and aims to elevate the immersive experience.
## Gameplay Testing (Shuyang Qian)
**Name: Shuyang Qian**  
**Email: syqian@ucdavis.edu**  
**Github: ElaineQian09**

- Game testing is very important for game development, as it can help our developers better improve our game playability. Our group did game testing from time to time. During our development process, each time when our group members push new files on GitHub, I will download them and make some notes for improvement, then I will communicate with my group members and then distribute tasks to each member in our group to deal with it. Testing needs to pay attention to many aspects. For example, I noticed that the hurt and attack animation is not smooth for the Main Character, so I canceled the `Exit time` to let the animation more smooth and give the player a better visual experience. I also find some potential problems in our game, like the monsters can not randomly move when they are close to each other and the Main Character may sometimes get stuck. This problem will cause our game to not run successfully. After communicating with my group members, we finally solved this problem. Testing not only tests the game and finds some potential running problems but also tries to find the best presentation of the game. After testing the game many times, I choose to set the `Gravity Scale` Main Character to 1.5 instead of 1 (built-in value) to make the jump more vivid. We also set different speeds and damage amounts for different monsters, so that the game difficulty will be progressive. After testing the game again and again, our game became more and more playable and solved some potential problems that may let our game crushed.

- I also do the game testing after everything is done. I invite ten people to play our game and here is the link for the [Observations and Playtester Comments form summary version](https://docs.google.com/document/d/1TPuzrFwl4hrnDEZRaEj5rH0Bu1S-puC1CbGLLLasNn4/edit?usp=sharing.). This form contains all my thoughts and findings when testing. I also let them rate our game. I made two tables to show the result more clearly: https://docs.google.com/spreadsheets/d/18lXD0Wz-vKrKnqIJ1FK3InlfIqK6n3yp6WoHyOBlZp4/edit?usp=sharing. 


## Narrative Design (Zijun Ye)

The inspiration for our game came from a TV show about the end of the world. We ultimately chose the idea because we wanted to encourage the protection of the environment and cherish our family. In the game, players will play as an older brother with magical powers in a pollution-ridden world, and in the process save his brother and reveal the conspiracy that caused the environmental pollution. This can serve as a powerful medium to raise awareness of the importance of environmental awareness. Through gameplay and narrative, players can witness the consequences of environmental neglect, prompting them to reflect on their impact on the world and the need to protect the environment.

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**

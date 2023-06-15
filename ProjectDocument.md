# Game Basic Information #

## Summary ##

Survival is a 2D action-adventure game set in a world on the brink of destruction and ravaged by pollution. You play as a brave hero with magic as you navigate the obstacles to save your brother from the monsters created by the evil scientists in the lab and uncover the conspiracy behind it.

Game link: https://juditost.itch.io/survival?secret=0guHxVlXkENKlZyvOZCaO0yus


## Gameplay Explanation ##

Key `A and D`: player move left and move right. 

Key `Space`: player jump. 

Key `J`: normal attack (The character can randomly release one of three fireballs with different effects. Normal fireballs are orange color and have no special effects. Green fireballs can slow down monsters for 5 seconds while dealing damage. Purple fireballs deal great damage) 

Key `L`: dodge skill. 

Key `O`: special skill (The character can use this skill to generate six random fireballs) 

For more information, please see this file: https://drive.google.com/drive/u/0/folders/11vY15RFK1PTqRRJDYEI4cjWMpGlpLXvg

#### Optimal strategy ####
Move the character slowly to ensure the monster gets hurt in the longest distance. When there are at least 2 monsters attacking the player, press 'O' button to use the magic fireball attacking to increase the hurt to all enemies or press `L’ continually to dodge the monster faster.

**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Producer (Shuhao Gao, Shuyang Qian)

Hosted the group meeting, led the team members to select [game model](https://docs.google.com/document/d/1NmPpcFJbgQ_VbXemW--UYIo7P9FYkh0jjyau3wRpQC0/edit?usp=sharing), [supervised the progress](https://docs.google.com/document/d/1z4qK4TqkN1sSSgll6bbFgbzSmZ5f1ZfK9YCcDeabOfM/edit), discussed with the team members in time how to modify the game elements, including movement/physics, user interface, animation, and audio, led the team members to make the schedule, and collected a lot of feedback from players on the game.

## User Interface (Shuhao Gao)
**Name: Shuhao Gao**  
**Email: shgao@ucdavis.edu**  
**Github: Snackiller**

* Set life bar and energy bar for the character in the game, the character's energy regenerates 1 per second, and set life and attack damage for the monster.
  
  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/MainCharacter.cs#L121-L125
  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/MainCharacter.cs#L140-L148

* Removed the monster's blood bar and damage numbers to give the player a good game experience.

* Added collision box and Rigidbody for characters and monsters. By adding collision box and Rigidbody, characters and monsters can be repelled and attacked.

  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/MainCharacter.cs#L150-L160

* Made remote attack for character attacks. The character can inflict damage on monsters by releasing fireballs. The character can randomly release one of three fireballs with different effects. Normal fireballs are orange color and have no special effects. Green fireballs can slow down monsters for 5 seconds while dealing damage. Purple fireballs deal great damage.

  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/MainCharacter.cs#L249-L309
  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/PirateController.cs#L159-L191

* Made the character's skills. By releasing skills, the character can fire six fireballs of different effects, and it will deduct ten energies. 

  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/MainCharacter.cs#L179-L247

* Set the Dodge key for the character, the Dodge effect can remain for 1 second, and it will deduct three energies.

  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/MainCharacter.cs#L311-L333
  
* Set the monster attack character's judgment. When the character is in the attack range of the monster, the monster will initiate attack mode and deal damage to the character for 1.5 to 3 seconds.

  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/PirateController.cs#L121-L155

* Designed that defeating enemy could drop gems randomly. When character got gem, he could get 5 energies.

  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/PirateController.cs#L92-L116
  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/MainCharacter.cs#L335-L343


* Designed the game's start interface, the interface where the character wins, and the interface where the character loses.

  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/MainCharacter.cs#L48-L52
  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/MainCharacter.cs#L56-L59
  https://github.com/Sherry1016/ECS189L_Final_Project/blob/main/Survival/Assets/Scripts/TeleportCaptain.cs#L32

## Movement/Physics (Shuyang Qian)
**Name: Shuyang Qian**  
**Email: syqian@ucdavis.edu**  
**Github: ElaineQian09**

- Preparation:  
I add three kinds of monster prefabs, in order to make the future physics effect, for example, attack, dead, add the `Box Collider 2D` and `Rigidbody 2D`.  
I add the `Box Collider 2D` and `Rigidbody 2D` for the Main Character to lay a good foundation for the follow-up work.  

* Main Character:
1. Left and Right movement:  
In the `MainCharacter.cs` script, I use the input system, with the help of the project settings Input Manager, can gain the command from the player: https://github.com/Sherry1016/ECS189L_Final_Project/blob/7a593d3498a23cda14f1751061998e329346b2d1/Survival/Assets/Scripts/MainCharacter.cs#L69-L72
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
Using the `random.range` to get the x position and let it be the `targetpostion` to achieve random coordinate generation. According to the comparison between the new position and current position x value, the flip X of the character's sprite is assigned according to the positive and negative values between them to realize the character's orientation flip. I also design that monsters have the ability to track attacks in the set version:
https://github.com/Sherry1016/ECS189L_Final_Project/blob/342a7c30be1d99426c48d4853fb31654d0c30de0/Survival/Assets/Scripts/PirateController.cs#L60-L64  
When the Main Character moves away from the Monsters, they will go back to normal and go to random locations again. In oder to better manage monsters’ behavior, I also declare [the enumeration of the MonsterType](https://github.com/Sherry1016/ECS189L_Final_Project/blob/6328c2dc05fe3ad822b395d2c4f03b43fa788d93/Survival/Assets/Scripts/PirateController.cs#L8-L14)


3. Physics  
I choose to set the `Body Type` in the `Rigidbody 2D` to `Kinematic` to let them not have a gravity effect but can still get collided.  
Set the `Is Trigger` in the `Box Collider 2D` to let the monster not push each other when they move in the same level.  

## Animation and Visuals (ZeSheng Wang)
**Name: ZeSheng Wang**  
**Email: wzswang@ucdavis.edu**  
**Github: WZS-Juditost**

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

## Input (Zijun Ye)
**Name: Zijun Ye**  
**Email: zijye@ucdavis.edu**  
**Github: Sherry1016**

In our game, we use the keyboard to control our main characters.

In `MainCharacter.cs`, we use `GetKeyDown` to determine the key pressed by the player and give the corresponding action and skill back to the player.

["A"](https://github.com/Sherry1016/ECS189L_Final_Project/blob/2592e1029b0c4262da0a2b784cd087b08cef5c10/Survival/Assets/Scripts/MainCharacter.cs#L71) for left move, "D" for left move and "space" for jump.

["L"](https://github.com/Sherry1016/ECS189L_Final_Project/blob/2592e1029b0c4262da0a2b784cd087b08cef5c10/Survival/Assets/Scripts/MainCharacter.cs#L315) for high speed and the main character will be able to dodge the monsters' attacks.

["J"](https://github.com/Sherry1016/ECS189L_Final_Project/blob/2592e1029b0c4262da0a2b784cd087b08cef5c10/Survival/Assets/Scripts/MainCharacter.cs#L251) for normal attack, the main character will launch a fireball.

["O"](https://github.com/Sherry1016/ECS189L_Final_Project/blob/2592e1029b0c4262da0a2b784cd087b08cef5c10/Survival/Assets/Scripts/MainCharacter.cs#L183) for ultimate skill, the main character will launch multiple fireballs and increase the attack power.

## Game Logic (Wenhui Li)
**Name: Wenhui Li**  
**Email: whli@ucdavis.edu**  
**Github: Wenhui1130**

This game mode is a single player survival game, which includes three levels in total.  With the level increase, the player needs to survive against increasing difficulty levels or waves of enemies.

MainCharacter.cs: 
* MainCharacter.cs: This script represents the behavior of the main character in a game. It contains various properties and components such as buttons, images, prefabs, animations, life and energy bars, cooldowns, and more.  The `Start()` function initializes the character's attributes and positions it at a specific location. The `MoveCharacter()` function handles the character's movement based on player input, clamping its position within the camera's boundaries. The `Update()` function is responsible for updating the character's actions and behaviors during gameplay. It manages the character's life and energy bars, checks for win or lose conditions, handles skill activation, fireball attacks, dodging, and character death. This script also defined five types of actions of the player: movement, fireball attack, magic fireball attack and dodge, jump. Here we use the energy system to add a resource management aspect to the game. The character can perform a fireball attack by pressing the `J` key, which is called  the `FireBall()` to trigger the attack animation and create fireball projectiles without consuming the energy. However, when the player performs a skill (magic fireball attack) by pressing the `O` key and consuming 10 energy. Pressing the L key to call the `Dodge(`) method which applies a velocity to the character to simulate a dodge movement and consuming the player 3 energy. All actions are controlled by several cooldowns to limit the frequency of attacks, skills, and dodges to prevent spamming.  The script has four game status flags to indicate whether the game has started, whether the player is dead, whether the player is performing a fireball attack and whether the character is currently in a hurt state. According to these flags, the character has references to UI elements like startButton, win, lose, BeginStory, EndStory, lifeBar, and energyBar, which are used to display game information and story elements. The character's life and energy values are displayed using the lifeBar and energyBar UI elements. When the character does not dodge or use magic fireball attacks or gethurted and the energy is not reached the maximum, the main character’s energy will converge after `nextEnergyRecoveryTime` .  Finally, the collision detection with objects tagged as "Gem" and gaining energy from them adds a collectible aspect to the game. This provides an incentive for the player to explore the game environment and rewards them with additional resources.
* Parallax.cs: this script calculates the movement of a GameObject based on the Camera's position to create a parallax scrolling effect. The GameObject's position is updated using the `ParallaxMagnitude`, and the sprite attached to the GameObject is wrapped around when needed to create an illusion of infinite scrolling.
* PirateController.cs: this script represents the behavior and logic of a monster character in a game. The monster moves towards the player if they are within a certain distance (`version`), while periodically attacking the player if they are in range. The monster's movement is controlled by randomly selecting a target position within a limited space, and it continuously moves towards that position. When the monster's health (`blood`) reaches zero, it is destroyed and removed from the game, and there is a chance for it to drop a gem. The monster's attack causes damage to the player, applies a force to push them back, and triggers the player's hurt animation. The pirate can also be affected by specific game objects, such as normal fireballs  (reducing health) or slow traps (reducing speed temporarily). The script utilizes an animator to control the monster's animations based on different states, such as walking, attacking, or being exhausted. 
* SpawSystem.cs: this script is responsible for spawning and managing monsters. It contains references to different ground objects and prefabs for different types of monsters. The SpawnSystem keeps track of monsters spawned on each ground using a dictionary called `monstersByGround`, where each ground object is associated with a list of monsters. The `Start()` function initializes the system by loading the monster prefabs, creating a list for each ground, and calling the `CreateMonster()` function to spawn initial monsters. The `DoCreate()` function is used to instantiate a monster prefab at a random position on a specified ground, and the spawned monster is added to the respective ground's list. When a monster is killed, the `MonsterKilled()` function is called, which removes the monster from the corresponding ground's list. If the ground becomes empty (no more monsters on it), a portal prefab is spawned at a random position offset from the player's position.
* TeleportCaptain.cs: This script is responsible for teleporting the main character to different levels based on certain conditions. It has references to UI elements, game objects representing different grounds, a destination level object, and the main camera. The `Start()` function initializes the script by deactivating the win image. When a collision occurs with the main character, the script checks if there are any monsters on Ground2 or Ground3 by accessing the `monstersByGround` dictionary from the SpawnSystem. If there are monsters on Ground2, the destination level is set to an object named "Sunset." If there are monsters on Ground3, the destination level is set to an object named "Nighttime." If there are no monsters on either ground, the win image is activated, background music is stopped, a win sound effect is played, and the function returns. If the collision object is the main character, its position is set to a specific location near the destination level, and the main camera's position is adjusted accordingly. Additionally, a sound effect is played to indicate the character's teleportation.
* SoundManager.cs: this script is responsible for managing the audio in the game. It has a list of music tracks and sound effects, each represented by a SoundClip class. During the `Awake` function, audio sources are dynamically added to the game object and assigned to each clip. When `PlayMusicTrack` is called with a specific track title, the corresponding music track is played while stopping any previously playing music. The PlaySoundEffect function plays the sound effect associated with the given title. The StopPlayingMusic function stops the currently playing music track if there is one, which aims stop the backgound muisc when the player win.
* MusicTrack.cs: this script is used in conjunction with the SoundManager script to define properties and settings for each audio clip, 
* LocationTrigger.cs: This script is attached to a game object with a `BoxCollider2D` component and is responsible for triggering a music track when the player enters the trigger area. When the player collides with the trigger area, the script checks if the colliding object has a tag "Player". If it does, it calls the PlayMusicTrack method of the SoundManager instance and passes the specified music track (`musicTrack`) as a parameter, which starts playing the corresponding music track. 


# Sub-Roles

## Cross-Platform

**Describe the platforms you targeted for your game release. For each, describe the process and unique actions taken for each platform. What obstacles did you overcome? What was easier than expected?**

## Audio (Wenhui Li)
## Game Logic
**Name: Wenhui Li**  
**Email: whli@ucdavis.edu**  
**Github: Wenhui1130**

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
**Name: Zijun Ye**  
**Email: zijye@ucdavis.edu**  
**Github: Sherry1016**

The inspiration for our game came from a TV show about the end of the world. We ultimately chose the idea because we wanted to encourage the protection of the environment and cherish our family. In the game, players will play as an older brother with magical powers in a pollution-ridden world, and in the process save his brother and reveal the conspiracy that caused the environmental pollution. This can serve as a powerful medium to raise awareness of the importance of environmental awareness. Through gameplay and narrative, players can witness the consequences of environmental neglect, prompting them to reflect on their impact on the world and the need to protect the environment.

## Press Kit and Trailer (ZeSheng Wang)
**Name: ZeSheng Wang**  
**Email: wzswang@ucdavis.edu**  
**Github: WZS-Juditost**

#### presskit materials:
[Survival](https://juditost.itch.io/survival?secret=0guHxVlXkENKlZyvOZCaO0yus)  

#### trailer:
[Trailer](https://www.youtube.com/watch?v=qDfukOdoYq8)


The web page for this game is a draft and has not been published. I gave a simple description of the game, included the materials we used in our game, as well as some game screenshots. The production of this trailer is also relatively simple. As neither my team members nor I have video editing experience, plus the production period of this video was during the final examination period. Under the dual constraints of technology and time, the production quality of the trailer is not high. In the video, I focused on showcasing the various mechanics and skills of the game. Finally, it ends on the game's title screen to conclude the trailer. I used online video editor [Clipchamp](https://app.clipchamp.com/) to create the trailer.  



## Game Feel (Shuhao Gao)
**Name: Shuhao Gao**  
**Email: shgao@ucdavis.edu**  
**Github: Snackiller**

In this process, I modified the player's blood volume, energy, attack power, and movement speed and the monster's blood volume, attack power, attack range, and movement speed. During this process, I found five or six classmates to experience the game we designed. Because the attributes of the game monsters we designed initially were too strong, these five or six students failed to pass the first level. For this reason, these five or six students and I discussed the attributes of monsters. In the end, we concluded that the game's difficulty needs to be gradual, and the game must allow players to have achievement feedback after defeating the enemy. So when designing the attributes of the first Goblin, I weakened all the attributes of the Goblin. It allows players to pass the first level easily and have a certain degree of confidence in their game level. In the attribute design of the flying eye in the second level, I weakened the attack power of the flying eye and increased its moving speed and attack range. It will catch players who pass the first level by surprise and increase the game's difficulty to a certain extent. In the test, we got feedback from the players' behavior that when most players enter the second level after clearing the Goblin, they will be injured by the super fast-moving speed of the flying eye, thus increasing the difficulty of game clearance. When designing the attributes of the mushroom in the third level, I increased its blood volume and attack power and weakened its movement speed. In this way, when players pass the second level, they will learn the use of dodge skills because of the super high moving speed of the flying eye. Players will ideally think that the monsters in the third level are also monsters with high movement speed. When players use dodge skills in the same way as in the second level in the third level, they are likely to rush into the pile of monsters in the mushroom and be defeated by the high attack power of the mushroom. The third level focuses on controlling the distance between the player and the monster. Players need to move to avoid being hit by the mushroom while attacking the mushroom. Such a design makes mushroom, a monster with high blood volume and high attack power, difficult for players to pass the game. While changing the value and looking for players to test, I found that all players can easily pass the first level in the first game, and most players will be super high by the second level flying eye in the first game. A few players will pass the second level in the first game, but they will be defeated by the mushroom's super high blood volume and attack power. By modifying the attributes of the player and monsters in the game, our game has managed to follow a progression in difficulty and attract players to play our game multiple times.

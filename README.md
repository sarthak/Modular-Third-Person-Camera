# Modular-Third-Person-Camera

## What's this?
Creating a third person camera is usually a big headache and most of the times the camera is glitchy, moreover, most third camera designs are catered to need of one particular game (style). You could, in principle, create a third person camera script that caters to all game designs by loading it with all possible features in the world but such a script would be inefficient for games that don't need to harness it's full power and not to mention the fact how buggy the script could be.

This project is an experiment, an attempt to create a third person camera script not as a whole but in pieces. Pieces, called modules, that when put together create a functional third person camera. The idea is that by breaking down parts of code into seperate modules and adding the ability to use only some of those modules it is possible to design a camera which could adopt to needs of different styles of games while being efficient at the same time by strictly using only the most necessary features and nothing more.

Although, it is true that a dedicated camera script hand written for a specific game is always going to be more efficient than any other 'general' implementations, this project aims to be a handy prototype so that you may leave the camera scripting to a later time and focus on core game mechanics. Once you are done with the mechanics, you can come back to replace this with a dedicated camera system for extra performance.

Example - 

![GIF of Top-down style games](https://i.imgur.com/tmStATN.gif)]
![GIF of third person style games](https://i.imgur.com/jAW9vVw.gif)]
![GIF of 2D style games](https://i.imgur.com/t1M3CpQ.gif)]

## Setup and Usage
Clone the scripts folder. If you want a demo first, also clone the Demo folder.

The camera is actually a collection of 3 gameobjects :- Main Camera, Container (Parent of Main Camera) and Root (Parent of Container).

root > container > camera

This chain is mainly to ease the process of transformation by providing 3 transforms instead of one. Basically, all the movment actions are carried by root. All the orbiting and lookat actions are carried by container. Camera transform should only be modified for special effects like camera setback on explosion etc.

Set the initial position of root to the position of player. Adjust the container to any position you feel is good. And don't really bother with camera. Just make sure the following -

1. Rotation of root = rotation of player, that is to say forward of root is forward of player. (This is not a restriction but a design consideration. If, however, your player is like a rolling ball which rotates continuosly, you may ignore this consideration. Only some modules require this restriction to be met).
2. Forward of container is forward of camera.

### The modules -

**Note** : Modules are all attached to root object and not any other.

**Note** : It is indeed possible that 2 modules modify the same transform property of some object, in that case jitter may be observed. To ensure that this rarely happens, most of the modules use *smooth* interpolations to avoid jitter. Also, each module prints to the console, at the start, the list of properties it modifies.

**1. Camera_Main**
The main camera module. Acts as a central holder of references. This is only to centralize what needs to be centralized. Every other module carries a reference to this module.

**2. Camera_Follow**
Have the camera smoothly follow the player. Moves the *root* when the player moves so that `position(root) = position(player)`.

**3. Camera_LookAt**
Have the camera smoothly look at player or some other point. `container looksat (player)`

**4. Camera_Orbit**
Enable the camera to orbit about player. The X-Rotation is given to root and Y-rotation is given to container by rotating it about root.

**5. Camera_Turn**
Have the camera rotate with player. Don't use Camera_Orbit with this module. `rotation(root) = rotation(player)`. This module is rarely used. Most of the time Camera_Orbit is used to change rotation and player script is configured to follow root's rotation.

These are the primary modules. Depending upon needs the modules can be extended.

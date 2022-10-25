#Readme

I have decided to work on this Cross-Platform Game project. This is intended to be a quick action-packed game to play amongst friends locally. The game concept is based on DotA 2 custom game mode hardcore ninja. The standout features for this game is the cross-play between all types of devices.

## Design Decisions

The game will be made using local networking as it is easy to implement and free.

Since this game is intended to be cross-play, the first obstacle is a Unified-Input system. The challenge is to ensure that all players have similar competitive experience across different platforms. This is my proposed solution of implementation.

| Input | Movement | Ability Activate | Ability Aim (if applicable) |
|-------|--------|---------|----------|
| Keyboard & Mouse (PC) | WASD | Mouse | Mouse Position |
| Controller (Console) | Left Joystick | Triggers | Right Joystick |
| Screen (Mobile) | Touch Joystick | Touch Buttons | Touch Buttons can be dragged in direction of strike |

Unity has a built-in input system (UIS) so mapping the controls can be done using UIS.

![]({{page.ftimage | relative_url}})

## Currently Working on:
- Multiplayer Implementation
- Networking player states and damage/hit registration
- Player Character Design and Animation

# Learning Outcomes:
- Learn the Unity Game Engine
- Learn about networking for a competitive skill-based multiplayer game
- Learn C# programming (OOP)

# Project Goals:
- Multiplayer Support
- Easy to install on multiple platforms
- Quick to load and Start Game (minimal screens between games)
- Multi-platform crossplay
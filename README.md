# Wills World 🌍

Welcome to **Wills World**, a vibrant 2D platformer built with Unity! This project is a customized version of the Unity Platformer Microgame, designed to provide a fun and engaging gameplay experience.

## 🎮 Gameplay Features

- **Fluid Movement**: Smooth sprite-based controls including jumping, running, and precise landing.
- **Classic Mechanics**: Battle enemies, collect tokens, and navigate through challenging environments.
- **Victory Zones**: Reach the end of the level to secure your win!
- **Dynamic Physics**: Built with Unity's 2D physics engine for realistic interactions.

## 🛠️ Technical Overview

- **Engine**: Unity 6 (or compatible version)
- **Graphics Pipeline**: Universal Render Pipeline (URP) for modern, high-performance visuals.
- **UI System**: TextMesh Pro for crisp, high-quality typography.
- **Physics**: 2D Rigidbody and Collider-based movement logic.

## 🚀 Getting Started

### Prerequisites

- [Unity Hub](https://unity.com/download) installed.
- Unity 6 (see `ProjectSettings/ProjectVersion.txt` for exact version).

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/dev-zd/wills-world.git
   ```
2. Open Unity Hub and click **Add** -> **Add project from disk**.
3. Select the `wills world` folder.
4. Wait for the project to import and open.

### Running the Game

1. In the Project window, navigate to `Assets/Scenes`.
2. Open `SampleScene.unity`.
3. Press the **Play** button in the Unity Editor to start the adventure!

## 🌐 Web Launcher

The game includes a **Web-based Login & Launch System** powered by PHP and WampServer.

### Features
- **User Registration & Login**: Secure authentication with session management.
- **Game Launcher**: Click "Launch Game" from your browser to start the Unity game.
- **Premium UI**: Glassmorphism design with smooth animations.

### Setup (WampServer Required)
1. Copy the `WebLauncher` folder to `C:\wamp64\www\`.
2. Run `http://localhost/WebLauncher/setup.php` to auto-create the database.
3. Double-click `register_protocol.reg` to enable browser-to-game launching.
4. Build your Unity game into `C:\wamp64\www\WebLauncher\Game\`.
5. Access the launcher at `http://localhost/WebLauncher`.

## 📜 Credits

- Built using the [Unity Platformer Microgame](https://assetstore.unity.com/packages/templates/platformer-microgame-151055) template.
- Developed by **dev-zd**.

---
*Created with ❤️ using Unity.*

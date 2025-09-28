# Promethean Heat

A 2D platformer game built in Unity, featuring multi-world exploration with unique environments including overworld, underworld, and underwater levels.

## 🎮 Game Overview

**Promethean Heat** is a 2D side-scrolling platformer that takes players on an adventure through diverse environments. The game features character movement mechanics, animated enemies, and multiple interconnected levels with distinct visual themes.

## 👥 Authors

- **@RD2P**: Raphael De Los Reyes
- **@Weunbeatable**: Josh O
- **@R4nd0mDude**: Mel
- **@mr200paul**: Paul

## ✨ Features

### Gameplay Mechanics
- **Character Movement**: Smooth 2D character controls with running and jumping
- **Physics-Based Movement**: Rigidbody2D-based player physics with customizable speed and jump force
- **Platform Detection**: Ground detection system using layer masks
- **Input System**: Modern Unity Input System implementation with customizable controls

### Game Worlds
- **Overworld**: Surface-level environments with grass and natural elements
- **Underworld**: Dark, underground levels with unique challenges  
- **Underwater**: Submerged environments with bubble particle effects
- **Main Hub**: Central area connecting different game worlds

### Visual & Audio
- **Pixel Art Style**: 8x8 pixel art assets with over 245+ unique tiles
- **Animated Characters**: Player character with idle, run, jump, and fall animations
- **Animated Enemies**: Flying demon enemies with idle and movement animations
- **Particle Effects**: Fire, smoke, and bubble particle systems
- **Audio System**: Integrated audio mixer with music and sound effects
- **Parallax Backgrounds**: Multi-layer background system for depth

### Technical Features
- **Scene Management**: Seamless level transitions and scene loading
- **Tilemap System**: Efficient level design using Unity's tilemap system
- **Animation Controllers**: Comprehensive animation system for characters and enemies
- **Universal Render Pipeline**: Modern rendering with post-processing effects

## 🎯 Controls

| Action | Key Binding |
|--------|-------------|
| Move | Arrow Keys / WASD |
| Jump | Spacebar |
| Interact | E |
| Attack | Left Click |
| Sprint | Left Shift |
| Progress/Start | Enter |

## 🛠️ Technical Requirements

### Unity Version
- **Unity 2022.3 LTS** or newer
- **Universal Render Pipeline (URP)**

### Platform Support
- Windows (Primary)
- Additional platforms supported through Unity build system

### Dependencies
- Unity Input System Package
- Universal Render Pipeline
- TextMeshPro
- 2D Tilemap Extras

## 🚀 Getting Started

### Prerequisites
1. Install Unity Hub
2. Install Unity 2022.3 LTS or newer
3. Ensure Universal Render Pipeline is available

### Setup Instructions
1. **Clone or Download** the project to your local machine
2. **Open Unity Hub** and click "Add project from disk"
3. **Navigate** to the `Promethean Heat` folder and select it
4. **Open the project** in Unity
5. **Open the Main scene** from `Assets/Scenes/Main.unity`
6. **Press Play** to start the game

### Build Instructions
1. Go to `File > Build Settings`
2. Add scenes in the following order:
   - Main.unity
   - Overworld.unity
   - Underworld.unity
   - Underwater.unity
3. Select your target platform
4. Click "Build" and choose output directory

## 📁 Project Structure

```
Assets/
├── Art/                    # Visual assets and artwork
│   ├── Animation/         # Character and enemy animations
│   ├── Sprites/          # 2D sprites and textures
│   ├── Tilemaps/         # Level tilemap assets
│   └── Overworld/        # Overworld-specific art
├── Audio/                 # Sound effects and music
│   ├── Music/            # Background music tracks
│   └── SFX/              # Sound effects
├── Character/            # Character-related assets
├── Environment/          # Environmental assets
├── Gameplay/             # Gameplay-specific assets
├── ParticleSystems/      # Particle effect prefabs
├── Prefabs/              # Reusable game objects
│   ├── Characters/       # Character prefabs
│   └── Demon.prefab      # Enemy prefab
├── Scenes/               # Game scenes
│   ├── Main.unity        # Main menu/hub scene
│   ├── Overworld.unity   # Surface world level
│   ├── Underworld.unity  # Underground level
│   └── Underwater.unity  # Underwater level
├── Scripts/              # C# game scripts
│   ├── PlayerScript.cs   # Player movement and controls
│   ├── Demon.cs          # Enemy behavior
│   └── LevelManagerScript.cs # Scene management
└── Settings/             # Project configuration
```

## 🎨 Asset Credits

### Art Assets
- **BigManJD Asset Package**: 8x8 pixel art tiles, animated characters, and decorations
- **Water Temple Assets**: Environmental artwork (Non-commercial license)
- **PixelFX Vol.1**: Fire and smoke particle effects

### Technical Assets
- **Unity Technologies**: Standard Unity packages and tools
- **TextMeshPro**: Advanced text rendering system

## 🔧 Development Notes

### Key Scripts
- **PlayerScript.cs**: Handles player movement, jumping, and input processing
- **Demon.cs**: Controls enemy animation states
- **LevelManager.cs**: Manages scene transitions and level progression

### Input System
The game uses Unity's new Input System with the following action maps:
- Player movement (Vector2)
- Jump action (Button)
- Attack action (Button)  
- Interact action (Button)
- Sprint action (Button)

### Physics Configuration
- Player uses Rigidbody2D for physics-based movement
- Ground detection via BoxCollider2D and layer masks
- Customizable movement parameters (speed: 3f, jump force: 5f)

## 🐛 Known Issues

- Jump detection system may need refinement for edge cases
- Some commented-out collision detection code in PlayerScript.cs
- Level progression system is basic (Enter key to advance)

## 🚧 Future Enhancements

- [ ] Enemy AI and combat system
- [ ] Collectible items and power-ups
- [ ] Save/load game system
- [ ] Enhanced level progression mechanics
- [ ] Mobile platform support
- [ ] Additional sound effects and music tracks
- [ ] Menu system improvements

## 📄 License

This project uses various assets under different licenses:
- Unity-created content follows Unity's standard license
- Third-party assets retain their original licenses (see individual asset folders)
- Water Temple assets are for non-commercial use only
- Code scripts are available for educational and non-commercial purposes

## 🤝 Contributing

This appears to be a learning/development project. If you'd like to contribute:
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## 📞 Support

For questions or issues related to this project, please check the Unity documentation or community forums for general Unity development help.

---

**Built with Unity 2022.3 LTS** | **Genre**: 2D Platformer | **Status**: In Development
# Technical Context

## Development Environment
- Unity Engine 
- Visual Studio Code
- C# sebagai bahasa pemrograman utama

## Project Structure
```
Assets/
├── Scripts/
│   ├── GameManager.cs      # Game state dan UI management
│   ├── PlayerController.cs # Player input dan physics
│   ├── PipeSpawner.cs     # Object pooling dan spawning
│   └── Pipe.cs            # Pipe movement dan reset
├── Prefabs/
│   └── pipe.prefab        # Prefab untuk obstacles
├── Scenes/
│   └── SampleScene.unity  # Main game scene
```

## Key Components

### 1. GameManager
```csharp
public class GameManager : MonoBehaviour
{
    // UI References
    public GameObject mainMenuPanel;
    public GameObject gameplayPanel;
    public GameObject winPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    
    // Game state management
    private bool isGameStarted = false;
    private int currentScore = 0;
    private int currentCoins = 0;
}
```

### 2. Player Configuration
```csharp
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    private Rigidbody rb;
}
```

### 3. Pipe System
```csharp
public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float heightOffset = 2f;
    [SerializeField] private int poolSize = 5;
}
```

## Dependencies
1. TextMeshPro package untuk UI text
2. Unity Physics system untuk collision dan movement
3. Unity UI system untuk menu dan HUD

## UI System
1. Canvas dengan:
   - Main Menu Panel
   - Gameplay Panel (score & coins)
   - Win/Game Over Panel

## Physics Setup
1. Rigidbody configuration:
   - Use Gravity: true
   - Is Kinematic: false
   - Constraints: Freeze rotation (optional)

2. Collider setup:
   - Player: Sphere Collider
   - Pipes: Box Collider
   - Ground: Box Collider

## Tags & Layers
Required Tags:
- "Player"
- "Ground"
- "Pipe"
- "ScoreTrigger"
- "Coin"

## Performance Considerations
1. Object Pooling untuk Pipes
2. Efficient physics calculations
3. Limited use of Update() calls
4. UI optimization dengan static elements

## Future Improvements
1. Save system untuk high scores
2. Power-up system
3. Sound effects dan background music
4. Visual effects untuk collisions dan coin collection

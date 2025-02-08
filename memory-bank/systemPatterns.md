# System Patterns

## Core Architecture
Game menggunakan arsitektur komponen-based yang terdiri dari:

1. GameManager
   - Singleton pattern untuk mengatur game state
   - Mengontrol UI state transitions
   - Mengelola scoring system

2. Object Pooling System
   - Implementasi di PipeSpawner
   - Pre-instantiate objects saat startup
   - Reuse objects untuk optimisasi performa

## Design Patterns

### 1. Singleton Pattern (GameManager)
```csharp
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
}
```

### 2. Object Pooling Pattern (PipeSpawner)
```csharp
private List<GameObject> pipePool;
private void InitializePipePool()
{
    pipePool = new List<GameObject>();
    for (int i = 0; i < poolSize; i++)
    {
        GameObject pipe = Instantiate(pipePrefab);
        pipe.SetActive(false);
        pipePool.Add(pipe);
    }
}
```

## Component Relationships

1. Player Dependencies:
   - Rigidbody untuk physics
   - Collision detection dengan pipes dan ground
   - Input handling untuk controls

2. Pipe System:
   - PipeSpawner mengatur spawning dan pooling
   - Pipe component mengatur movement
   - Collision triggers untuk scoring

3. UI System:
   - Panel-based UI management
   - Score dan coin display
   - Menu state management

## State Management
1. Game States:
   - Main Menu
   - Gameplay
   - Game Over

2. State Transitions:
   - Main Menu -> Gameplay (Play button)
   - Gameplay -> Game Over (Collision)
   - Game Over -> Main Menu (Restart button)

## Optimization Techniques
1. Object Pooling
   - Menghindari Instantiate/Destroy runtime
   - Pre-allocated memory
   - Efficient object reuse

2. Physics Optimization
   - Limited collision checks
   - Simplified collision shapes
   - Efficient rigidbody usage

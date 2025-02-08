using UnityEngine;
using System.Collections.Generic;

public class PipeSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float heightOffset = 1.5f;
    [SerializeField] private int poolSize = 5;
    
    [Header("References")]
    [SerializeField] private GameObject pipePrefab;
    
    private float spawnTimer;
    private List<GameObject> pipePool;
    private GameManager gameManager;
    
    private void Start()
    {
        transform.position = new Vector3(10f, 0f, 0f);
        gameManager = FindObjectOfType<GameManager>();
        InitializePipePool();
    }
    
    private void InitializePipePool()
    {
        pipePool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject pipe = Instantiate(pipePrefab);
            pipe.transform.position = transform.position;
            pipe.SetActive(false);
            pipePool.Add(pipe);
        }
    }
    
    private void Update()
    {
        // Hentikan spawning jika game belum mulai atau sudah game over
        if (!gameManager.IsGameStarted() || gameManager.IsGameOver()) return;
        
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnPipe();
            spawnTimer = 0f;
        }
    }
    
    private void SpawnPipe()
    {
        GameObject pipe = GetInactivePipe();
        if (pipe == null) return;
        
        float randomHeight = Random.Range(-heightOffset, heightOffset);
        pipe.transform.position = transform.position + Vector3.up * randomHeight;
        pipe.SetActive(true);
        
        Pipe pipeScript = pipe.GetComponent<Pipe>();
        pipeScript.Initialize(moveSpeed);
    }
    
    private GameObject GetInactivePipe()
    {
        foreach (GameObject pipe in pipePool)
        {
            if (!pipe.activeInHierarchy)
            {
                return pipe;
            }
        }
        return null;
    }
}

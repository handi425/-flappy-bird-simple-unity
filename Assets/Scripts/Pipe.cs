using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float moveSpeed;
    private float destroyXPosition = -15f;
    private GameManager gameManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    public void Initialize(float speed)
    {
        moveSpeed = speed;
    }
    
    private void Update()
    {
        // Hentikan pergerakan jika game over
        if (gameManager.IsGameOver()) return;
        
        // Gerakkan pipe ke kiri
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        
        // Jika sudah melewati batas, non-aktifkan pipe
        if (transform.position.x < destroyXPosition)
        {
            gameObject.SetActive(false);
        }
    }
}

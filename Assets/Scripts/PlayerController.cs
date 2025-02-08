using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    
    private Rigidbody rb;
    private GameManager gameManager;
    private bool isDead = false;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        rb.useGravity = false; // Nonaktifkan gravity sampai game dimulai
    }

    private void Update()
    {
        if (isDead) return;

        // Aktifkan gravity saat game dimulai
        if (gameManager.IsGameStarted() && !rb.useGravity)
        {
            rb.useGravity = true;
        }

        // Hanya bisa kontrol jika game sudah dimulai
        if (!gameManager.IsGameStarted()) return;

        // Input untuk lompat
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Rotasi bird berdasarkan velocity
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, rb.velocity.y * 6), 
            rotationSpeed * Time.deltaTime
        );
    }

    private void Jump()
    {
        // Reset velocity dan tambahkan force ke atas
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Jika menabrak ground atau pipe
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe"))
        {
            if (!isDead)
            {
                isDead = true;
                StartCoroutine(BounceEffect());
            }
        
        }
    }

            private IEnumerator BounceEffect()
            {
                // Implement the bounce effect logic here using AddForce for a more natural effect
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                yield return new WaitForSeconds(2f); // Wait for the bounce effect to complete
                gameManager.GameOver();
                
                Time.timeScale = 0f; // Slow down time
            }
    private void OnTriggerEnter(Collider other)
    {
        // Jika melewati score trigger
        if (other.CompareTag("ScoreTrigger"))
        {
            gameManager.AddScore();
        }
        // Jika mengambil coin
        else if (other.CompareTag("Coin"))
        {
            gameManager.AddCoin();
            other.gameObject.SetActive(false);
        }
    }
}

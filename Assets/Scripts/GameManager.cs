using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Reference UI panels
    public GameObject mainMenuPanel;
    public GameObject gameplayPanel;
    public GameObject winPanel;
    
    // Reference text elements
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    
    // Game state
    private bool isGameStarted = false;
    private bool isGameOver = false;
    private int currentScore = 0;
    private int currentCoins = 0;

    private void Start()
    {
        Time.timeScale = 1; // Pastikan time scale normal saat start
        // Pastikan panel yang tepat ditampilkan saat game dimulai
        mainMenuPanel.SetActive(true);
        gameplayPanel.SetActive(false);
        winPanel.SetActive(false);
        
        isGameOver = false;
    }

    // Dipanggil oleh button Play
    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        gameplayPanel.SetActive(true);
        winPanel.SetActive(false);
        
        // Reset score dan coins
        currentScore = 0;
        currentCoins = 0;
        UpdateUI();
        
        // Mulai game
        isGameStarted = true;
        isGameOver = false;
        Time.timeScale = 1;
    }

    // Dipanggil saat player mati
    public void GameOver()
    {
        if (isGameOver) return; // Prevent multiple calls
        
        isGameStarted = false;
        isGameOver = true;
        Time.timeScale = 0; // Hentikan semua movement
        winPanel.SetActive(true);
    }

    // Dipanggil oleh button Restart
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Tambah score
    public void AddScore()
    {
        if (!isGameStarted || isGameOver) return;
        currentScore++;
        UpdateUI();
    }

    // Tambah coins
    public void AddCoin()
    {
        if (!isGameStarted || isGameOver) return;
        currentCoins++;
        UpdateUI();
    }

    // Update UI elements
    private void UpdateUI()
    {
        scoreText.text = currentScore.ToString();
        coinText.text = currentCoins.ToString();
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}

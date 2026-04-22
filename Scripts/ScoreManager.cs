using UnityEngine;
using UnityEngine.UI;
using TMPro;

// ScoreManager sınıfı, oyundaki score , miss ve level yönetimini yapar.
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0; // Oyuncunun mevcut skoru 
    public int missCount = 0; // Kaçırılan nota sayısı
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI missText;
    public TextMeshProUGUI levelText;

    private int currentLevel = 1;
    private bool level2Reached = false; // Level 2'ye geçilip geçilmediğini kontrol eder 
    private bool level3Reached = false;
    private bool level4Reached = false;
    private bool level5Reached = false;

    public NoteSpawner noteSpawner;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();  // Oyuna başlarken skor, miss ve level text'leri güncellenir
    }

    void Update()
    {
        CheckLevelUp(); // Her frame'de skor kontrol edilip level atlanması gerekirse yapılır
    }

    public void AddScore()
    {
        score += 100; // Her başarılı notada 100 puan verilir
        UpdateUI();
    }

    public void AddMiss()
    {
        missCount += 1; // Miss sayısı bir artar
        UpdateUI();
    }

    void UpdateUI() // UI text'lerini günceller
    {
        scoreText.text = "Score: " + score;
        missText.text = "Misses: " + missCount;
        levelText.text = "Level: " + currentLevel;
    }

    void CheckLevelUp() // Skora göre seviye atlayıp atlamadığını kontrol eder
    {
        if (score >= 300 && !level2Reached)
        {
            LevelUp(2);
            level2Reached = true;
        }
        else if (score >= 600 && !level3Reached)
        {
            LevelUp(3);
            level3Reached = true;
        }
        else if (score >= 900 && !level4Reached)
        {
            LevelUp(4);
            level4Reached = true;
        }
        else if (score >= 1200 && !level5Reached)
        {
            LevelUp(5);
            level5Reached = true;
        }
    }

    void LevelUp(int newLevel) // Yeni seviyeye geçildiğinde ayarları değiştirir
    {
        currentLevel = newLevel;
        Debug.Log("LEVEL UP! Now at Level: " + currentLevel);

        if (currentLevel == 2)
        {
            noteSpawner.noteSpeed = 120f;
            noteSpawner.spawnInterval = 3.0f;
        }
        else if (currentLevel == 3)
        {
            noteSpawner.noteSpeed = 150f;
            noteSpawner.spawnInterval = 2.0f;
        }
         else if (currentLevel == 4)
        {
            noteSpawner.noteSpeed = 180f;
            noteSpawner.spawnInterval = 2.0f;
        }
        else if (currentLevel == 5)
        {
            noteSpawner.noteSpeed = 200f;
            noteSpawner.spawnInterval = 2.0f;
        }


        noteSpawner.RestartSpawning();
        UpdateUI();
    }
}

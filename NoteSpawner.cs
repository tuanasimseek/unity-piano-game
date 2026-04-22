using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab; // Spawn edilecek nota prefab'ı
    public Transform[] spawnPoints; // Notaların çıkabileceği konumların listesi
    public string[] noteNames = { "C4", "D4", "E4", "F4", "G4", "A4", "B4" }; // Her spawn noktasına karşılık gelen nota ismi

    public float spawnInterval = 4.0f;  // İlk başta notalar kaç saniyede bir doğacak
    public float noteSpeed = 100f;  // Notaların hareket hızı

    private void Start()
    {
        ScoreManager.instance.noteSpawner = this;
        InvokeRepeating("SpawnNote", 2f, spawnInterval);
    }

    public void RestartSpawning()  // Seviye değiştiğinde spawn süresi değişeceği için eski çağrıları iptal edip yenisini başlatırız
    {
        CancelInvoke("SpawnNote");
        InvokeRepeating("SpawnNote", 2f, spawnInterval); // Yeni interval'e göre tekrar başlat
    }

    void SpawnNote() // Her çağrıldığında ekrana bir nota doğurur
    {
        int index = Random.Range(0, spawnPoints.Length); // Rastgele bir spawn noktası seç
        Transform spawnPoint = spawnPoints[index];

        GameObject note = Instantiate(notePrefab, spawnPoint.position, Quaternion.identity); // Seçilen noktada yeni bir nota oluştur
        Note noteScript = note.GetComponent<Note>();
        noteScript.noteName = noteNames[index];
        noteScript.speed = noteSpeed;
    }
}

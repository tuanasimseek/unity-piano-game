using UnityEngine;

public class Note : MonoBehaviour
{
    public string noteName; // Notaların ismi 
    public float speed = 5f; // Notaların hareket hızı
    public bool canBeHit = false;

    private AudioSource audioSource; // Nota sesi çalmak için
    private Renderer cubeRenderer; // Renk değiştirme için 
    private bool hasBeenHit = false; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cubeRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);  // Nota objesi sürekli ileri Z ekseni hareket eder

        if (transform.position.z < -1f && !hasBeenHit) // Eğer ekranın altına inmişse ve vurulmamışsa miss olarak say
        {
            MissNote();
        }

        if (Input.GetKeyDown(GetKeyCodeForNote(noteName))) // Klavyeden doğru tuşa basıldı mı kontrol
        {
            if (canBeHit && !hasBeenHit) 
            {
                hasBeenHit = true;
                PlayNoteSound();
                ScoreManager.instance.AddScore();  // Skoru arttır

                if (cubeRenderer != null)  // Doğru basıldıysa yeşile boya
                {
                    cubeRenderer.material.color = Color.green; 
                }

                Invoke("DestroyNote", 0.3f); 
                Debug.Log("Klavye ile doğru nota basıldı: " + noteName);
            }
        }
    }

    void PlayNoteSound() // Nota sesi çalmak için
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource yok!");
        }
    }

    void MissNote() // Nota kaçırılırsa
    {
        hasBeenHit = true; 
        ScoreManager.instance.AddMiss(); // Miss sayısını arttır

        if (cubeRenderer != null)  // Kırmızıya boya
        {
            cubeRenderer.material.color = Color.red; 
        }
        Invoke("DestroyNote", 0.3f); // 0.3 saniye sonra yok et
    }

    void DestroyNote() // Objeyi sahneden sil
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) // HitZone alanına girdiğinde notaya basılabilir hale gelir
    {
        if (other.CompareTag("HitZone"))
        {
            canBeHit = true;
        }
    }

    private void OnTriggerExit(Collider other) // HitZone'dan çıkınca artık basılamaz
    {
        if (other.CompareTag("HitZone"))
        {
            canBeHit = false;
        }
    }

    KeyCode GetKeyCodeForNote(string note) // Her notanın hangi tuşla eşleştiği
    {
        switch (note)
        {
            case "C4": return KeyCode.A;
            case "D4": return KeyCode.S;
            case "E4": return KeyCode.D;
            case "F4": return KeyCode.F;
            case "G4": return KeyCode.G;
            case "A4": return KeyCode.H;
            case "B4": return KeyCode.Z;
            default: return KeyCode.None;
        }
    }
}

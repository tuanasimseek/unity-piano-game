using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public SongData currentSong; // Çalınacak şarkı verisi
    public TextMeshProUGUI noteDisplayText;  // Şu anki notayı ekranda göstermek için
    private int currentNoteIndex = 0; // Şarkıdaki kaçıncı notadayız
    private bool isSongFinished = false; 

    public AudioSource audioSource; // Sesleri çalmak için
    public TextMeshProUGUI wrongKeyText; // Yanlış tuş basıldığında gösterilecek metin

    public AudioClip C4Clip;
    public AudioClip D4Clip;
    public AudioClip E4Clip;
    public AudioClip F4Clip;
    public AudioClip G4Clip;
    public AudioClip A4Clip;
    public AudioClip B4Clip;

    void Start()
    {
        if (wrongKeyText != null)  // Yanlış tuş yazısını sıfırla
        {
            wrongKeyText.text = "";
        }

        if (currentSong != null && currentSong.notes != null && currentSong.notes.Count > 0)
        {
            ShowCurrentNote();
        }
        else
        {
            Debug.LogError("Song Data boş veya notalar eksik!");
        }

        if (noteDisplayText == null)
        {
            Debug.LogError("Note Display Text atanmadı!");
        }
    }

    void Update()
    {
        if (isSongFinished || currentSong == null || currentSong.notes == null || currentSong.notes.Count == 0)
            return;

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCodeForNote(currentSong.notes[currentNoteIndex].noteName)))  // Doğru nota tuşuna basıldıysa ses çal
            {
                PlayNoteSound(currentSong.notes[currentNoteIndex].noteName);

                currentNoteIndex++; // Bir sonraki notaya geç
                if (currentNoteIndex < currentSong.notes.Count)
                {
                    ShowCurrentNote(); // Yeni notayı ekranda göster
                }
                else
                {
                    noteDisplayText.text = "Şarkı Tamamlandı!";
                    isSongFinished = true;
                }
            }
            else
            {
                ShowWrongKeyMessage("Yanlış Tuş!"); // Yanlış tuşa basıldıysa uyarı göster
            }
        }
    }

    void ShowCurrentNote() // Ekranda hangi notaya basılması gerektiğini gösterir
    {
        if (noteDisplayText != null && currentSong != null && currentSong.notes != null && currentNoteIndex < currentSong.notes.Count)
        {
            noteDisplayText.text = "Basılacak Nota: " + currentSong.notes[currentNoteIndex].noteName;
        }
    }

    KeyCode KeyCodeForNote(string noteName)  // Nota ismine göre klavye tuşu eşlemesi
    {
        switch (noteName)
        {
            case "C4": return KeyCode.C;
            case "D4": return KeyCode.D;
            case "E4": return KeyCode.E;
            case "F4": return KeyCode.F;
            case "G4": return KeyCode.G;
            case "A4": return KeyCode.A;
            case "B4": return KeyCode.B;
            default: return KeyCode.None;
        }
    }

    void PlayNoteSound(string noteName)    // Nota sesini çalmak 
    {
        switch (noteName)
        {
            case "C4":
                audioSource.PlayOneShot(C4Clip);
                break;
            case "D4":
                audioSource.PlayOneShot(D4Clip);
                break;
            case "E4":
                audioSource.PlayOneShot(E4Clip);
                break;
            case "F4":
                audioSource.PlayOneShot(F4Clip);
                break;
            case "G4":
                audioSource.PlayOneShot(G4Clip);
                break;
            case "A4":
                audioSource.PlayOneShot(A4Clip);
                break;
            case "B4":
                audioSource.PlayOneShot(B4Clip);
                break;
            default:
                Debug.LogWarning("Ses bulunamadı: " + noteName);
                break;
        }
    }

    public void PlayNoteButton(string noteName) // Eğer kullanıcı UI’daki butonlara tıklarsa bu fonksiyon çalışır
    {
        if (isSongFinished) return;

        if (noteName == currentSong.notes[currentNoteIndex].noteName)
        {
            PlayNoteSound(noteName);
            currentNoteIndex++;
            if (currentNoteIndex < currentSong.notes.Count)
            {
                ShowCurrentNote();
            }
            else
            {
                noteDisplayText.text = "Şarkı Tamamlandı!";
                isSongFinished = true;
            }
        }
        else
        {
            Debug.LogWarning("Yanlış nota tıklandı: " + noteName);
        }
    }

    IEnumerator ClearWrongKeyMessage() // Yanlış tuş basıldığında 2 saniyeliğine uyarı mesajı gösterir
    {
        yield return new WaitForSeconds(2f);
        if (wrongKeyText != null)
        {
            wrongKeyText.text = "";
        }
    }

    void ShowWrongKeyMessage(string message) 
    {
        if (wrongKeyText != null)
        {
            wrongKeyText.text = message;
            StopAllCoroutines();
            StartCoroutine(ClearWrongKeyMessage());
        }
    }

    public void SetSong(SongData song) // Yeni şarkı seçildiğinde çağrılır
    {
        StopAllCoroutines(); 

        currentSong = song;
        currentNoteIndex = 0;
        isSongFinished = false;

        if (wrongKeyText != null)
        {
            wrongKeyText.text = "";
        }

        if (currentSong != null && currentSong.notes != null && currentSong.notes.Count > 0)
        {
            ShowCurrentNote();
        }
        else
        {
            Debug.LogError("Yeni seçilen şarkıda nota yok!");
        }
    }
}

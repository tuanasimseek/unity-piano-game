using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MelodyManager : MonoBehaviour
{
    public AudioSource audioSource; // Sesleri çalmak için
    public AudioClip C4Clip;
    public AudioClip D4Clip;
    public AudioClip E4Clip;
    public AudioClip F4Clip;
    public AudioClip G4Clip;
    public AudioClip A4Clip;
    public AudioClip B4Clip;
    public TextMeshProUGUI statusText; // Kullanıcıya durum mesajları göstermek için


    private List<string> recordedNotes = new List<string>();  // Kullanıcının kaydettiği nota listesi
    private bool isRecording = false;

    public void Record()  // Kayıt işlemini başlatır
    {
        recordedNotes.Clear(); // Önceki kayıtları sil
        isRecording = true; // Kayıt modunu aç
        Debug.Log("Kayıt Başladı!");
        statusText.text = "Kayıt Başladı!";
    }

    public void Stop() // Kayıt işlemini durdurur
    {
        isRecording = false;
        Debug.Log("Kayıt Durduruldu!");
        statusText.text = "Kayıt Bitti!";
    }

    public void PlayMelody() // Kayıtlı melodiyi sırayla çal
    {
        if (recordedNotes.Count > 0)
        {
            statusText.text = "Çalınıyor...";
            StartCoroutine(PlayMelodyCoroutine()); // Coroutine ile aralıklı çalma
        }
    }

    // Coroutine: Notaları sırayla çalar ve her birinden sonra kısa bekler
    IEnumerator PlayMelodyCoroutine()
    {
        foreach (string note in recordedNotes)
        {
            PlayNote(note); // Her notayı sırayla çal
            yield return new WaitForSeconds(0.5f); // 0.5 saniye bekle
        }
        statusText.text = "Oynatma Tamamlandı!";
    }

    public void PlayNoteButton(string noteName) // UI’daki tuşlara basıldığında çalışır
    {
        PlayNote(noteName);  // Ses çal
        if (isRecording)
        {
            recordedNotes.Add(noteName); // Eğer kayıt açıksa listeye ekle
        }
    }

    private void PlayNote(string noteName) // Belirli bir notanın sesini çal
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
        }
    }
}

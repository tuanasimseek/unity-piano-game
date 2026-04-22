using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PianoNote
{
    public string noteName;  // Notaların ismi 
    public float time;  // Notaların ne zaman çalınacağı
}

[CreateAssetMenu(fileName = "NewSong", menuName = "PianoTutorial/Song")]
public class SongData : ScriptableObject
{
    public List<PianoNote> notes;// Şarkının tüm notaları listelenir
}

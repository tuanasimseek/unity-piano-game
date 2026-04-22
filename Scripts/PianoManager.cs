using UnityEngine;

public class PianoManager : MonoBehaviour
{
    public AudioSource[] keySounds; 
    public GameObject prefab; // Instantiate edilecek prefab


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            Debug.Log("printed");
            keySounds[0].Play(); // C1
        }
        if (Input.GetKeyDown(KeyCode.Q)) keySounds[1].Play(); // C#1
        if (Input.GetKeyDown(KeyCode.W)) keySounds[2].Play(); // D1
        if (Input.GetKeyDown(KeyCode.E)) keySounds[3].Play(); // D#1
        if (Input.GetKeyDown(KeyCode.R)) keySounds[4].Play(); // E1
        if (Input.GetKeyDown(KeyCode.T)) keySounds[5].Play();
        if (Input.GetKeyDown(KeyCode.Y)) keySounds[6].Play();
        if (Input.GetKeyDown(KeyCode.U)) keySounds[7].Play();
        if (Input.GetKeyDown(KeyCode.I)) keySounds[8].Play();
        if (Input.GetKeyDown(KeyCode.O)) keySounds[9].Play();
        if (Input.GetKeyDown(KeyCode.P)) keySounds[10].Play();
        if (Input.GetKeyDown(KeyCode.A)) keySounds[11].Play();
        if (Input.GetKeyDown(KeyCode.S)) keySounds[12].Play();
        if (Input.GetKeyDown(KeyCode.D)) keySounds[12].Play();


        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("pressd");
            // Fare konumunu dünya koordinatlarına çevir
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane; // Z eksenini belirlemek için
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Prefabı instantiate et
        Instantiate(prefab, new Vector3(7, 13, 5), Quaternion.identity);
        }
        // Diğer tuşları buraya ekle
    }


}

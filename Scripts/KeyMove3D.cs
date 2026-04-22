using UnityEngine;

public class KeyMove3D : MonoBehaviour
{
    public float moveDistance = 0.1f; //tusun asagi haraket miktari
    public float moveSpeed = 2f; // tusun geri donus suresi eski haline
    private Rigidbody rb;
    private Vector3 originalPosition;//tusun baslangic konumu
    private bool isMoving = false;//tusun baslangic durumu haraket etmiyor

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // objenin Rigidbody bilesenini alir rb degiskenine atar

        originalPosition = rb.position; // baslangic konumunu kaydetme
    }

    void FixedUpdate()
    {
        if (isMoving) //haraket ediyorsa,tusa basildiysa 
        {
            Vector3 targetPosition = originalPosition + Vector3.down * moveDistance;// moveDistance kadar haraket ettir
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime));// Rigidbody pozisyonunu hedef pozisyona dogru yavasca hareket ettir
        }
        else// tusa basilmiyorsa
        {
            rb.MovePosition(Vector3.MoveTowards(rb.position, originalPosition, moveSpeed * Time.fixedDeltaTime));// moveSpeed uyarak eski konumuna getir tusu
        }
    }

    void OnMouseDown()// mouse ile tiklandiginda calissin
    {
        MoveKey(); // tusu haraket ettir
    }

    public void MoveKey()
    {
        isMoving = true;// tusu haraket ettir 
        Invoke("ResetKey", 0.1f); //geri donus suresi 0.1f
    }

    void ResetKey()
    {
        isMoving = false;//eski konumunda dursun tus haraketsiz 
    }
}

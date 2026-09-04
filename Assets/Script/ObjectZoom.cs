using UnityEngine;

public class ObjectZoomer : MonoBehaviour
{
    public float zoomSpeed = 0.005f;
    public float minScale = 0.1f;
    public float maxScale = 5f;

    void Update()
    {
        // Mengecek apakah ada tepat dua sentuhan jari di layar
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // Mencari posisi kedua jari pada frame sebelumnya
            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            // Menghitung jarak antar jari (sebelumnya vs sekarang)
            float prevMagnitude = (touch0PrevPos - touch1PrevPos).magnitude;
            float currentMagnitude = (touch0.position - touch1.position).magnitude;

            // Selisih jarak untuk menentukan arah zoom in/out
            float difference = currentMagnitude - prevMagnitude;

            // Menghitung skala baru objek
            Vector3 newScale = transform.localScale + (Vector3.one * difference * zoomSpeed);

            // Membatasi ukuran (clamp) agar tidak hilang atau terlalu raksasa
            newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
            newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
            newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

            transform.localScale = newScale;
        }
    }
}
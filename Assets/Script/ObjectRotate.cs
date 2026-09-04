using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float rotationSpeed = 0.5f;

    void Update()
    {
        // Mengecek apakah ada sentuhan di layar
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Mengecek apakah jari sedang bergerak (mengusap)
            if (touch.phase == TouchPhase.Moved)
            {
                // Memutar objek ke kiri/kanan berdasarkan usapan jari secara horizontal
                float rotationAmount = touch.deltaPosition.x * rotationSpeed;
                transform.Rotate(Vector3.up, -rotationAmount, Space.World);
            }
        }
    }
}
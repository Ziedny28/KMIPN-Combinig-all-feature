using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public GameObject bridge;
    public float rotationSpeed = 100.0f;

    private bool isBridgeRotating = false; // status rotasi jembatan
    private int targetRotation = 0; // rotasi target (0, 90, 180, 270)

    private void Update()
    {
        if (isBridgeRotating)
        {
            RotateBridge();
        }
    }

    private void RotateBridge()
    {
        // Hitung perbedaan rotasi antara rotasi saat ini dengan rotasi target
        float currentRotation = bridge.transform.eulerAngles.z;
        float difference = targetRotation - currentRotation;
        
        // Jika perbedaan rotasi masih cukup besar, terus rotasi jembatan
        if (Mathf.Abs(difference) > 0.1f)
        {
            float rotationAmount = Mathf.Sign(difference) * Mathf.Min(rotationSpeed * Time.deltaTime, Mathf.Abs(difference));
            bridge.transform.Rotate(Vector3.forward, rotationAmount);
        }
        else
        {
            // Jika perbedaan rotasi sudah cukup kecil, maka hentikan rotasi jembatan
            bridge.transform.eulerAngles = new Vector3(0, 0, targetRotation);
            isBridgeRotating = false;
        }
    }

    public void RotateBridgeLeft()
    {
        // Jika jembatan sedang tidak berputar, maka putar jembatan ke kiri
        if (!isBridgeRotating)
        {
            targetRotation += 90;
            if (targetRotation >= 360)
            {
                targetRotation -= 360;
            }

            isBridgeRotating = true;
        }
    }

    public void RotateBridgeRight()
    {
        // Jika jembatan sedang tidak berputar, maka putar jembatan ke kanan
        if (!isBridgeRotating)
        {
            targetRotation -= 90;
            if (targetRotation < 0)
            {
                targetRotation += 360;
            }

            isBridgeRotating = true;
        }
    }
}
using System.Collections;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public float laserSpeed = 5.0f; // kecepatan laser
    public float reflectDelay = 0.1f; // waktu tunda antara pantulan

    private LineRenderer lineRenderer;
    private bool laserActive = false;
    private Vector2 laserDirection; // menyimpan arah laser sebelum memantul

    void Start()
    {
        ActivateLaser();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (laserActive)
        {
            // gerakkan laser ke depan
            transform.Translate(laserDirection * laserSpeed * Time.deltaTime);

            // gambar line renderer
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);

            // deteksi tabrakan dengan objek
            RaycastHit2D hit = Physics2D.Raycast(transform.position, laserDirection);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Reflective"))
                {
                    // pantulkan laser
                    Vector2 reflectDir = Vector2.Reflect(laserDirection, hit.normal);
                    laserDirection = reflectDir;
                    StartCoroutine(ReflectDelay());
                }
                // else if (hit.collider.CompareTag("Button"))
                // {
                //     // tembak tombol
                //     hit.collider.GetComponent<ButtonController>().PressButton();
                // }
            }
        }
    }

    // aktifkan laser
    public void ActivateLaser()
    {
        laserActive = true;
        laserDirection = transform.right; // inisialisasi arah laser
    }

    // tunda waktu antara pantulan
    IEnumerator ReflectDelay()
    {
        yield return new WaitForSeconds(reflectDelay);
    }
}

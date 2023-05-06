using UnityEngine;

public class MonsterController : MonoBehaviour {
    public float speed = 2.0f; // kecepatan monster
    public float left = -2.5f; // batas gerakan ke kiri
    public float right = 2.5f; // batas gerakan ke kanan
    public float detectionRadius = 0.5f;
    public LayerMask playerLayer; // layer yang berisi objek dengan tag "Player"
    private bool movingRight = true;
    private float normalSpeed;

    public GameObject player;

    void Start() {
        normalSpeed = speed;
    }

    void Update() {
        // Pergerakan monster
        if (movingRight) 
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= right) 
            {
                movingRight = false;
            }
        }
        else 
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= left) {
                movingRight = true;
            }
        }

        // Deteksi pemain
        Collider2D[] hitColl = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);
        if (hitColl.Length > 0) 
        {
            foreach (Collider2D coll in hitColl) 
            {
                if (coll.CompareTag("Player")) 
                {
                    speed = normalSpeed * 2f; // kejar dan kill player ketika player ada di range musuh
                    Vector3 direction = player.transform.position - transform.position;
                    transform.Translate(direction.normalized * speed * Time.deltaTime);
                    Debug.Log("MAMPUS!1!!");
                }
            }
        }
        else 
        {
            speed = normalSpeed; // kecepatan monster kembali seperti semula, ketika player tidak di range musuh
        }
    }

    void OnDrawGizmos() {
        // Menampilkan radius deteksi pada saat play
        Gizmos.color = Color.red;
        float radius = detectionRadius;
        if (GetComponent<Collider>() != null)
        {
            radius = GetComponent<Collider>().bounds.size.magnitude; // ambil ukuran dari collider
        }
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
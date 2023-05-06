using UnityEngine;

public class WaterController : MonoBehaviour
{
    public float freezeDuration = 1.0f; // durasi pembekuan dalam detik
    public Collider2D waterCollider;
    public LayerMask nitrogenLayer;

    private bool isFrozen = false;
    private float timeElapsed = 0.0f;
    private Collider2D monsterCollider;

    public GameObject Monster;
    public string MonsterController;

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(waterCollider.bounds.center, waterCollider.bounds.size, 0, nitrogenLayer);

        foreach (Collider2D coll in colliders)
        {
            if (coll.CompareTag("Nitrogen"))
            {
                Debug.Log("Collidin with nitrogen");
                Debug.Log("BREZEEE");
                // Deteksi monster
                monsterCollider = Physics2D.OverlapCircle(waterCollider.bounds.center, waterCollider.bounds.size.y, LayerMask.GetMask("Monster"));

                // Freeze monster
                if (monsterCollider != null)
                {
                    (Monster.GetComponent(MonsterController) as MonoBehaviour).enabled = false;
                }
                // Freeze Genangan air
                isFrozen = true;
            }
        }

        if (isFrozen)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= freezeDuration)
            {
                Debug.Log("GETTO BACK");
                // Unfreeze Monster & Genangan air
                timeElapsed = 0;
                isFrozen = false;
                if (monsterCollider != null || isFrozen == false)
                {
                    (Monster.GetComponent(MonsterController) as MonoBehaviour).enabled = true;
                }
            }
        }
    }
}

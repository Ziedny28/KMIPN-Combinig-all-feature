using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseNoRot : MonoBehaviour
{
    public GameObject player;
    public float speed=4f;
    public float distanceBetween=6f;

    private float distance;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite= GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        //check if we need to flip sprite/not
        if (player.transform.position.x < transform.position.x && distance < distanceBetween)
        {
            sprite.flipX = true;
        }
        if (player.transform.position.x > transform.position.x || distance > distanceBetween)
        {
            sprite.flipX = false;
        }

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovingRandomly : MonoBehaviour
{

    public float moveSpeed=2f;
    private Rigidbody2D rb;
    public bool isWalking;

    public Vector2 facing;

    public float walkTime =1f;
    private float walkCounter;
    public float waitTime=3f;
    private float waitCounter;

    private int walkDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

    }


    void Update()
    {
        if (isWalking == false)
        {
            facing.x = 0;
            facing.y = 0;
        }

        if (isWalking == true)
        {
            walkCounter -= Time.deltaTime;


            switch (walkDirection)
            {


                case 0:
                    rb.velocity = new Vector2(0, moveSpeed);
                    break;

                case 1:
                    rb.velocity = new Vector2(moveSpeed, 0);
                    break;

                case 2:
                    rb.velocity = new Vector2(0, -moveSpeed);
                    break;

                case 3:
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    break;





            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }

        else
        {
            rb.velocity = Vector2.zero;

            waitCounter -= Time.deltaTime;

            if (waitCounter < 0)
            {
                ChooseDirection();

            }
        }
    }

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
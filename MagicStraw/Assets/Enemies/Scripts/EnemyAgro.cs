using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    private GameObject alive;
    Rigidbody2D aliveRb;



    // Start is called before the first frame update
    void Start()
    {
        alive = transform.Find("Alive").gameObject;
        aliveRb = alive.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("distToPlayer:" + distToPlayer);

        if(distToPlayer < agroRange)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop chasing player
            StopChasingPlayer();
        }
    }

    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //enemy is to the left side of the player, so move right
            aliveRb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else 
        {
            //enemy is to the side of the player, so move left
            aliveRb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }


    }

    void StopChasingPlayer()
    {
        aliveRb.velocity = new Vector2(0, 0);
    }
}

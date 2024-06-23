using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float maxSpeed;

    public Transform groundDetection;

    private bool movingRight = true;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down);

        if (groundInfo.collider == false || groundInfo.collider.gameObject.tag != "Ground")
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;

            }
            else 
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

        }
    }

    void FixedUpdate()
    {
        rb.AddForce(speed * transform.right, ForceMode2D.Impulse);

        //limiting the maximum velocity that the enemy can reach
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            if (rb.velocity.x < 0) //left movement
            {
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
            }
            else if (rb.velocity.x > 0) //right movement
            {
                rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            }
        }
    }
}

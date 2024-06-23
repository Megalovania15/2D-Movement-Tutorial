using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float speed = 15f; //movement speed
    public float mouseSensitivity = 100f; //how fast the character rotates to look

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //Input.GetAxis provides a number between 1 and -1 that is used to determine
        //the direction of movement
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        rb.AddForce(new Vector2(moveX, moveY), ForceMode2D.Impulse);
    }

    void Look()
    {
        //need to find the position of the mouse on the screen
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0; //working with a 2D plane

        //find the position of the camera on the screen by converting it from world
        //coordinates to the screen coordinates of the player
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        //find the difference between the mouse and the camera's x and y values
        float mouseX = mousePos.x - objectPos.x;
        float mouseY = mousePos.y - objectPos.y;

        //Mathf.Atan2 will provide the angle that it is facing
        //in Rads, so convert to degrees
        float angle = Mathf.Atan2(mouseY, mouseX) * Mathf.Rad2Deg;

        //updates the character's rotation to wherever the mouse is pointing
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

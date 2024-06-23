using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothTime = 0.3f;
    public int yOffset;
    public int zOffset;

    private GameObject player;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //finds the game object named "Player"
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //update the position of the camera. Ensure the z value stays the same
        //or you won't be able to see the player
        /*transform.position = new Vector3(player.transform.position.x, 
            player.transform.position.y, transform.position.z);*/

        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, zOffset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}

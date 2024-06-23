using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    
    public Transform spawnPoint;
    
    public GameObject bulletPrefab;

    private float fireRateCountdown;

    // Start is called before the first frame update
    void Start()
    {
        fireRateCountdown = fireRate;
      
    }

    // Update is called once per frame
    void Update()
    {
        
        fireRateCountdown -= Time.deltaTime;

        if (fireRateCountdown <= 0) 
        {
            Shoot();
            fireRateCountdown = fireRate;
        }
        
    }

    void Shoot()
    {
        //if the player presses the left mouse button, spawn the bullet at the spawn point
        //with the player's rotation
        if (Input.GetMouseButton(0))
        {
            Instantiate(bulletPrefab, spawnPoint.position, transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectItem : MonoBehaviour
{
    public int ammoCount = 10;

    public TMP_Text ammoCounter;

    // Start is called before the first frame update
    void Start()
    {
        ammoCounter.text = "Ammo: " + ammoCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ammo")
        {
            ammoCount++;
            ammoCounter.text = "Ammo: " + ammoCount.ToString();
            Destroy(other.gameObject);
        }
    }
}

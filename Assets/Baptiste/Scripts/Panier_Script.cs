using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panier_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("baguette"))
        {
            DayMenu_Script.score += 100;
        }
        if (other.CompareTag("brioche"))
        {
            DayMenu_Script.score += 200;
        }
        if (other.CompareTag("muffin"))
        {
            DayMenu_Script.score += 300;
        }
        if (other.CompareTag("gateau"))
        {
            DayMenu_Script.score += 350;
        }
        if (other.CompareTag("croissant"))
        {
            DayMenu_Script.instance.croissants++;
        }
    }
}

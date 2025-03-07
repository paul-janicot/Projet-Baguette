using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Key pressed");
            GetComponent<LootBag>().InstantiateLoot(transform.position);
        }
    }
}

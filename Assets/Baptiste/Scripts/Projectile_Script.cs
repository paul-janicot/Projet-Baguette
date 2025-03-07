using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Script : MonoBehaviour
{
    private Rigidbody body;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Death", 3);
        body = GetComponent<Rigidbody>();
        body.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Put damage function for player here
        Death();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecetteMove_Script : MonoBehaviour
{
    [SerializeField] float maxSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("mat"))
        {
            if (gameObject.GetComponent<Rigidbody>().velocity.sqrMagnitude <= maxSpeed * maxSpeed)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 20, ForceMode.Force);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("mat"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 100, ForceMode.Force);
        }
    }

}

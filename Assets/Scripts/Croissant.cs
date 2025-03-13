using UnityEngine;

public class Croissant : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}

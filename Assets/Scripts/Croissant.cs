using UnityEngine;

public class Croissant : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0,100 * rotateSpeed * Time.deltaTime, 0));
    }
}

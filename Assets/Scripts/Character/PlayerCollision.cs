using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Item"))
        {
            Loot itemData = collision.gameObject.GetComponent<ItemDataHolder>().data;
            InventoryManager.instance.AddItem(itemData);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerLife.instance.TakeDamage(1);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.gameObject.transform.forward * 2, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Enemy"))
        {
            PlayerLife.instance.TakeDamage(1);

            Destroy(other);
        }
    }
}

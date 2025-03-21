using UnityEngine;

// Joa

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
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
        if (other.CompareTag("Enemy"))
        {
            PlayerLife.instance.TakeDamage(1);

            Destroy(other);
        }
    }
}

using UnityEngine;

public class AddItemToInventory : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private ItemBase item;
    [SerializeField] private int quantity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.Instance.AddItemToInventory(item, quantity);
            Destroy(gameObject);
        }
    }
}

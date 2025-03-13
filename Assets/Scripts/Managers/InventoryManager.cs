using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [SerializeField] private Dictionary<Loot, int> inventoryDict;

    private void Awake()
    {
        instance = this;
    }

    public Dictionary<Loot, int> GetInventory()
    {
        return inventoryDict;
    }

    public void AddItem(Loot item)
    {
        if (inventoryDict != null)
        {
            if (inventoryDict.ContainsKey(item))
            {
                inventoryDict[item]++;
            }
            else
            {
                inventoryDict[item] = 1;
            }
        }
    }

    public bool RemoveItem(Loot item)
    {
        if (inventoryDict != null)
        {
            if (inventoryDict.ContainsKey(item))
            {
                if (inventoryDict[item] > 0)
                {
                    inventoryDict[item]--;
                    return true;
                }
            }
        }
        Debug.LogWarning("Fools you are trying to take an item that you don't have");
        return false;
    }

}

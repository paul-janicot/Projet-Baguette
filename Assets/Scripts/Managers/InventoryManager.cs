using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [SerializeField] private Dictionary<string, int> inventoryDict;

    private void Awake()
    {
        instance = this;
    }

    public Dictionary<string, int> GetInventory()
    {
        return inventoryDict;
    }

    public void AddItem(Loot item)
    {
        if (inventoryDict != null)
        {
            if (inventoryDict.ContainsKey(item.lootName))
            {
                inventoryDict[item.lootName]++;
            }
            else
            {
                inventoryDict[item.lootName] = 1;
            }
        }
    }

    public bool RemoveItem(string item)
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

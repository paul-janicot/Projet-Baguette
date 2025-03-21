using System.Collections.Generic;
using UnityEngine;

// Joa

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    private static Dictionary<string, int> inventoryDict = new();

    public static int score;

    private void Awake()
    {
        instance = this;
    }

    public Dictionary<string, int> GetInventory()
    {
        return inventoryDict;
    }

    public void AddItem(string item)
    {
        if (inventoryDict != null)
        {
            if (inventoryDict.ContainsKey(item))
            {
                inventoryDict[item]++;
            }
            else
            {
                inventoryDict.Add(item, 1);
            }
        }

        foreach (string a in inventoryDict.Keys)
        {
            Debug.Log(a + " " + inventoryDict[a]);
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

    public void ResetInventory()
    {
        inventoryDict = new();
    }
}

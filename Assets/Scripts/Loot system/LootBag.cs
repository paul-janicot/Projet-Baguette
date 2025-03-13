using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    
    public List<Loot> lootList = new List<Loot>();
    int sumOfRarity = 0;
    [SerializeField] private int numberOfItem;
  
    // Start is called before the first frame update

    Loot GetDroppedItems()
    {
        int randomNumber = Random.Range(1, sumOfRarity+1);
        
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);

            }
        }
            if(possibleItems.Count > 0)
            {
            Loot mostRareItem = possibleItems[0];
            foreach (Loot item in possibleItems)
            {
                if(item.dropChance < mostRareItem.dropChance)
                {
                    mostRareItem = item;
                }
                else if (item.dropChance == mostRareItem.dropChance)
                {
                    int randomInt = Random.Range(0, 2);
                    if(randomInt == 0)
                    {
                        mostRareItem = item;
                    }
                    
                }
            }
            Loot droppedItems = mostRareItem;
            return droppedItems; 
            }
            Debug.Log("No loots dropped");
            return null;
        }
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem  = GetDroppedItems();
        GameObject lootGameObject = Instantiate(droppedItem.LootPrefab,spawnPosition, Quaternion.identity);
        
    }
    private void Start()
    {
        
        foreach (Loot item in lootList)
        {
            sumOfRarity += item.dropChance;
        }
    }
}







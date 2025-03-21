using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    
    public List<Loot> lootList = new List<Loot>();
    int sumOfRarity = 0;
    [SerializeField] private int numberOfItem;

    Loot GetLoot(List<Loot> booster)
    {
        int magicNumber = Random.Range(0, sumOfRarity);

        int a = 0;
        for (int i = 0; i < lootList.Count; i++)
        {
            if (magicNumber >= a && magicNumber < a + lootList[i].dropChance)
            {
                return lootList[i];
            }
            a += lootList[i].dropChance;
        }
        return lootList[0];
    }


    // Start is called before the first frame update

    //Loot GetDroppedItems()
    //{
    //    int randomNumber = Random.Range(1, 101);

    //    List<Loot> possibleItems = new List<Loot>();

    //    foreach (Loot item in lootList)
    //    {
    //        if (randomNumber <= item.dropChance)
    //        {
    //            possibleItems.Add(item);

    //        }
    //    }

    //    if(possibleItems.Count > 0)
    //    {
    //    Loot mostRareItem = possibleItems[0];
    //    foreach (Loot item in possibleItems)
    //    {
    //        if(item.dropChance < mostRareItem.dropChance)
    //        {
    //            mostRareItem = item;
    //        }
    //        else if (item.dropChance == mostRareItem.dropChance)
    //        {
    //            int randomInt = Random.Range(0, 2);
    //            if(randomInt == 0)
    //            {
    //                mostRareItem = item;
    //            }

    //        }
    //    }
    //    Loot droppedItems = mostRareItem;
    //    return droppedItems; 
    //    }
    //        Debug.Log("No loots dropped");
    //        return null;
    //}

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetLoot(lootList);
        if (droppedItem == null) return;
        GameObject lootGameObject = Instantiate(droppedItem.LootPrefab, spawnPosition, Quaternion.identity);

    }
    private void Start()
    {
        foreach (Loot item in lootList)
        {
            sumOfRarity += item.dropChance;
        }
    }
}







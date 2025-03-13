using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loot")]
public class Loot : ScriptableObject
{
    public GameObject LootPrefab;
    public string lootName;
    public int dropChance;
    

    public Loot(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayMenu_Script : MonoBehaviour
{
    // Score
    public int score;
    [SerializeField] TextMeshProUGUI textScore;

    // Ingrédients
    public int farine;
    [SerializeField] TextMeshProUGUI textFarine;
    public int beurre;
    [SerializeField] TextMeshProUGUI textBeurre;
    public int oeuf;
    [SerializeField] TextMeshProUGUI textOeuf;
    public int sucre;
    [SerializeField] TextMeshProUGUI textSucre;
    public int lait;
    [SerializeField] TextMeshProUGUI textLait;
    public int fruit;
    [SerializeField] TextMeshProUGUI textFruit;

    //Croissant 
    public int croissants;
    [SerializeField] TextMeshProUGUI textCroissants;
   




    void Start()
    {
        if (InventoryManager.instance.GetInventory().ContainsKey("farine"))
        {
            farine = InventoryManager.instance.GetInventory()["farine"];
        }
        if (InventoryManager.instance.GetInventory().ContainsKey("beurre"))
        {
            beurre = InventoryManager.instance.GetInventory()["beurre"];
        }
        if (InventoryManager.instance.GetInventory().ContainsKey("oeuf"))
        {
            oeuf = InventoryManager.instance.GetInventory()["oeuf"];
        }
        if (InventoryManager.instance.GetInventory().ContainsKey("sucre"))
        {
            sucre = InventoryManager.instance.GetInventory()["sucre"];
        }
        if (InventoryManager.instance.GetInventory().ContainsKey("lait"))
        {
            lait = InventoryManager.instance.GetInventory()["lait"];
        }
        if (InventoryManager.instance.GetInventory().ContainsKey("fruit"))
        {
            fruit = InventoryManager.instance.GetInventory()["fruit"];
        }
    }

    // Update is called once per frame
    void Update()
    {
        textFarine.text = "" + farine;
        textBeurre.text = "" + beurre;
        textOeuf.text = "" + oeuf;
        textSucre.text = "" + sucre;
        textLait.text = "" + lait;
        textFruit.text = "" + fruit;
        textCroissants.text = "Nombre de croissant :" + croissants;
        textScore.text = "" + score;

    }

    // Fonctions Boutons
    void Baguette() { }
    void Brioche() { }
    void Muffin () { }
    void Gateau () { }

    void Croissant() { }
}

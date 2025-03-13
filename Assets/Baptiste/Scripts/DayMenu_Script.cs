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
    private int farine;
    [SerializeField] TextMeshProUGUI textFarine;
    private int beurre;
    [SerializeField] TextMeshProUGUI textBeurre;
    private int oeuf;
    [SerializeField] TextMeshProUGUI textOeuf;
    private int sucre;
    [SerializeField] TextMeshProUGUI textSucre;
    private int lait;
    [SerializeField] TextMeshProUGUI textLait;
    private int fruits;
    [SerializeField] TextMeshProUGUI textFruits;

    //Croissant 
    private int croissants;
    [SerializeField] TextMeshProUGUI textCroissants;


    [SerializeField] Loot Oeuf;


    private Dictionary<string, int> dico = new();


    void Start()
    { 
        InventoryManager.instance.AddItem(Oeuf);
        dico = InventoryManager.instance.GetInventory() ;
      
        Debug.Log(dico["Oeuf"]);
        if (dico.ContainsKey("Farine"))
        {
            farine = dico["Farine"];
        }
        if (dico.ContainsKey("Beurre"))
        {
            beurre = dico["Beurre"];
        }
        if (dico.ContainsKey("Oeuf"))
        {
            oeuf = dico["Oeuf"];
        }
        if (dico.ContainsKey("Sucre"))
        {
            sucre = dico["Sucre"];
        }
        if (dico.ContainsKey("Lait"))
        {
            lait = dico["Lait"];
        }
        if (dico.ContainsKey("Fruits"))
        {
            fruits = dico["Fruits"];
        }
        if (dico.ContainsKey("Croissant"))
        {
            croissants = dico["Croissant"];
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
        textFruits.text = "" + fruits;
        textCroissants.text = "Nombre de croissant: " + croissants;
        textScore.text = "" + score;

    }

    // Fonctions Boutons
    public void Baguette() 
    { 
       
    }
    public void Brioche() 
    { 
    
    }
    public void Muffin () 
    {
    
    }
    public void Gateau () 
    { 
    
    }
    public void Croissant() 
    { 
    
    }
}

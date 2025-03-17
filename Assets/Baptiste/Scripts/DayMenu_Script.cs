using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayMenu_Script : MonoBehaviour
{
    // Score
    public static int score;

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
    public int croissants;
    [SerializeField] TextMeshProUGUI textCroissants;

    //Recette
    public GameObject spawnPoint;
    [SerializeField] private  GameObject baguetteObject;
    [SerializeField] private GameObject briocheObject;
    [SerializeField] private GameObject croissantObject;
    [SerializeField] private GameObject muffinObject;
    [SerializeField] private GameObject gateauObject;
    private GameObject recette;


    private Dictionary<string, int> dico = new();

    public static DayMenu_Script instance;

    private void Awake()
    {
    instance = this;
    }
    void Start()
    { 
        dico = InventoryManager.instance.GetInventory() ;

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
        InstantiateRecette(baguetteObject);
    }
    public void Brioche() 
    {
        InstantiateRecette(briocheObject);
    }
    public void Muffin () 
    {
        InstantiateRecette(muffinObject);
    }
    public void Gateau () 
    {
        for (int i = 0; i < 1000; i++)
        {
            InstantiateRecette(gateauObject);
        }
    }
    public void Croissant()
    {
        InstantiateRecette(croissantObject);
        
    }


    private void InstantiateRecette(GameObject go)
    {
        recette = Instantiate(go, spawnPoint.transform.localPosition, transform.localRotation) as GameObject;
        recette.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        
    }
}

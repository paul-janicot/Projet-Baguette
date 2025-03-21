using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]public Loot croissantsData;

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

       score = InventoryManager.score;
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
        textCroissants.text = "Croissants : " + croissants;
        textScore.text = "Score : " + score;

    }

    // Fonctions Boutons
    public void Baguette() 
    {
        if (farine >= 2)
        {
            InstantiateRecette(baguetteObject);
            farine -= 2;
        }
    }
    public void Brioche() 
    {
        if (farine >= 2 && oeuf >= 2 && beurre >= 1 && lait >= 1 && sucre >= 1)
        {
            InstantiateRecette(briocheObject);
            farine -= 2;
            oeuf -= 2;
            beurre--;
            lait--;
            sucre--;
        }
       
       
    }
    public void Muffin () 
    {
        if (farine >= 1 && beurre >= 1 && sucre >= 1 && oeuf >= 1)
        {
            InstantiateRecette(muffinObject);
            farine--;
            beurre--;
            sucre--;
            oeuf--;
        }
    }
    public void Gateau () 
    {
       if(farine >= 1 &&  oeuf >= 2 && sucre >= 1 && fruits >= 1)
        {
            InstantiateRecette(gateauObject);
            farine--;
            oeuf -= 2;
            sucre--;
            fruits -= 1;
        }
    }
    public void Croissant()
    {
        if (farine >= 1 && beurre >= 1)
        {
            InstantiateRecette(croissantObject);
            farine --;
            beurre --;
        }
        
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void NextLevel()
    {
        Collider[] hitColliders = Physics.OverlapBox(spawnPoint.transform.localPosition, new Vector3(13, 3, 5), spawnPoint.transform.rotation, 1);
        for (int i = 0; i < hitColliders.Length; i++)
        { Debug.Log(hitColliders[i].name);
            if (hitColliders[i].CompareTag("baguette"))
            {
                score += 100;
            }
            if (hitColliders[i].CompareTag("brioche"))
            {
                score += 250;
            }
            if (hitColliders[i].CompareTag("muffin"))
            {
                score += 300;
            }
            if (hitColliders[i].CompareTag("gateau"))
            {
                score += 350;
            }
            if (hitColliders[i].CompareTag("croissant"))
            {
                croissants++;
                InventoryManager.instance.AddItem(croissantsData);
            }
        }

        InventoryManager.score = score;
       SceneManager.LoadScene("Night");
    }


    private void InstantiateRecette(GameObject recetteGO)
    {
        recette = Instantiate(recetteGO, spawnPoint.transform.localPosition, transform.localRotation) as GameObject;
        recette.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        
    }
}

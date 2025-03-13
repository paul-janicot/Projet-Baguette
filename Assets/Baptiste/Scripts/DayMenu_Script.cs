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
        textCroissants.text = "" + croissants;
        textScore.text = "" + score;

    }

    // Fonctions Boutons
    void Baguette() { }
    void Brioche() { }
    void Muffin () { }
    void Gateau () { }

    void Croissant() { }
}

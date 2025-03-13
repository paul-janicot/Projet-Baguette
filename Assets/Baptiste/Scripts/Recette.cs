using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recette")]
public class Recette : ScriptableObject
{
    // Start is called before the first frame update
    public Object graphic;
    public string recetteName;
    public int points;

    public Recette(string recetteName, int points)
    {
        this.recetteName = recetteName;
        this.points = points;
    }
}

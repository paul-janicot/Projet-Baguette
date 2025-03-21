using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] TextMeshProUGUI changementFarine;
    [SerializeField] TextMeshProUGUI changementBeurre;
    [SerializeField] TextMeshProUGUI changementOeuf;
    [SerializeField] TextMeshProUGUI changementSucre;
    [SerializeField] TextMeshProUGUI changementLait;
    [SerializeField] TextMeshProUGUI changementFruits;

    [SerializeField] private bool deuxFarine; //Do they spend two ingredient or 1
    [SerializeField] private bool deuxBeurre;
    [SerializeField] private bool deuxOeuf;
    [SerializeField] private bool deuxSucre;
    [SerializeField] private bool deuxLait;
    [SerializeField] private bool deuxFruits;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (changementFarine != null) { changementFarine.text = "-1"; if (deuxFarine) { changementFarine.text = "-2"; } }
        if (changementBeurre != null) { changementBeurre.text = "-1"; if (deuxBeurre) { changementBeurre.text = "-2"; } }
        if (changementOeuf != null) { changementOeuf.text = "-1"; if (deuxOeuf) { changementOeuf.text = "-2"; } }
        if (changementSucre != null) { changementSucre.text = "-1"; if (deuxSucre) { changementSucre.text = "-2"; } }
        if (changementLait != null) { changementLait.text = "-1"; if (deuxLait) { changementLait.text = "-2"; } }
        if (changementFruits != null) { changementFruits.text = "-1"; if (deuxFruits) { changementFruits.text = "-2"; } }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (changementFarine != null) { changementFarine.text = ""; }
        if (changementBeurre != null) { changementBeurre.text = ""; }
        if (changementOeuf != null) { changementOeuf.text = ""; }
        if (changementSucre != null) { changementSucre.text = ""; }
        if (changementLait != null) { changementLait.text = ""; }
        if (changementFruits != null) { changementFruits.text = ""; }
    }    

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (changementFarine != null) { changementFarine.text = "-1"; if (deuxFarine) { changementFarine.text = "-2"; } }
        if (changementBeurre != null) { changementBeurre.text = "-1"; if (deuxBeurre) { changementBeurre.text = "-2"; } }
        if (changementOeuf != null) { changementOeuf.text = "-1"; if (deuxOeuf) { changementOeuf.text = "-2"; } }
        if (changementSucre != null) { changementSucre.text = "-1"; if (deuxSucre) { changementSucre.text = "-2"; } }
        if (changementLait != null) { changementLait.text = "-1"; if (deuxLait) { changementLait.text = "-2"; } }
        if (changementFruits != null) { changementFruits.text = "-1"; if (deuxFruits) { changementFruits.text = "-2"; } }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (changementFarine != null) { changementFarine.text = ""; }
        if (changementBeurre != null) { changementBeurre.text = "";  }
        if (changementOeuf != null) { changementOeuf.text = "";  }
        if (changementSucre != null) { changementSucre.text = ""; }
        if (changementLait != null) { changementLait.text = "";  }
        if (changementFruits != null) { changementFruits.text = "";  }
    }

}
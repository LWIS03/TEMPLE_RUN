using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class script_puntuacio : MonoBehaviour
{
     private TextMeshProUGUI monedes;

    // Start is called before the first frame update
    void Start()
    {
        monedes = this.GetComponent<TextMeshProUGUI>();
        monedes.text = 0.ToString();
    }

    // Update is called once per frame
    public void actualitzar_monedes(int puntuacio)
    { 
        monedes.text = puntuacio.ToString();
    }
}

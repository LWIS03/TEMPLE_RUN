using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class morir_trigger : MonoBehaviour
{
    public GameObject nino;
    public TextMeshProUGUI monedes;
    public TextMeshProUGUI puntuacio;
    public float duracio_mort = 0.15f;
    public float magnitud = 0.4f;
    public GameObject menuMorir;
    public AudioClip morir_so;
    public AudioClip estamparese;

    private void OnTriggerEnter(Collider other)
    {
        int mon = nino.GetComponent<Script_Moviment>().monedes;
        int pun = nino.GetComponent<Script_Moviment>().puntuacio;
        if (other.CompareTag("Morir"))
        {
            AudioSource.PlayClipAtPoint(morir_so, transform.position);
            monedes.text = ("Monedes Totals: " + mon.ToString());
            puntuacio.text = ("Puntuacio: " + (mon + pun).ToString());

            Time.timeScale = 0;
            menuMorir.SetActive(true);
        }
        else if (other.CompareTag("Morir+Camera")) 
        {

            AudioSource.PlayClipAtPoint(estamparese, transform.position);
            StartCoroutine(executar_linealment());
            Time.timeScale = 0;
            monedes.text = ("Monedes Totals: " + mon.ToString());
            puntuacio.text = ("Puntuacio: " + (pun + mon).ToString());
            menuMorir.SetActive(true);
        }

        else if (other.CompareTag("gg"))
        {

            Time.timeScale = 0;
            monedes.text = ("Monedes Totals: " + mon.ToString());
            puntuacio.text = ("Puntuacio: " + (pun + mon).ToString());
            menuMorir.SetActive(true);
        }
    }

    IEnumerator executar_linealment() {
        GameObject camara = GameObject.Find("Camera");
        yield return StartCoroutine(camara.GetComponent<camera_xocar>().Shake(duracio_mort, magnitud));

    }
}

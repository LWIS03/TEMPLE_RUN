using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_generar_monedes : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1.0f;
        Transform[] hijos = GetComponentsInChildren<Transform>(true);
        List<GameObject> files_monedes = new List<GameObject>();

        foreach (Transform hijo in hijos)
        {
            if (hijo.CompareTag("files_monedes"))
            {
                files_monedes.Add(hijo.gameObject);
            }
        }

        float probabilidad = Random.value;
        if (probabilidad < 0.5)
        {
           int numero = Random.Range(0, files_monedes.Count);
            files_monedes[numero].SetActive(true);
        }

    }
}

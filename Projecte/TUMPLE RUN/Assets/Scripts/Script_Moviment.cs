using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Script_Moviment : MonoBehaviour
{
    public TextMeshProUGUI distancia;
    public GameObject nino;

    public int puntuacio;
    public int monedes;

    public float Velocitat_Corre = 10f;
    public float Velocitat = 5f;
    public float DistanciaTotal = 8f;

    public float VelocitatGodMode = 1.0f;
    public float actual_pos = 0f;

    public KeyCode Dreta = KeyCode.RightArrow;
    public KeyCode Esquerra = KeyCode.LeftArrow;
    public KeyCode Adalt = KeyCode.UpArrow;

    public bool GodMode = false;
    public float rayLength = 2.0f;

    private Vector3 previousPosition; 
    private float totalDistance; 

    private void Start()
    {
        previousPosition = transform.position;
        totalDistance = 0f; 
    }
    void Update()
    {

        transform.Translate(Vector3.forward * Velocitat_Corre * Time.deltaTime);

        float distanceThisFrame = Vector3.Distance(previousPosition, transform.position);


        totalDistance += distanceThisFrame;

        previousPosition = transform.position;
        puntuacio = ((int)totalDistance);
        monedes = nino.GetComponent<recollir_moneda>().monedes_totals;
        distancia.text = (monedes + puntuacio).ToString();


        if (Input.GetKeyDown(KeyCode.G)) { 
            if(GodMode) GodMode = false;
            else GodMode = true;
        }

        if (!GodMode)
        {
            if (Input.GetKey(Esquerra) && this.GetComponent<raycast_comprovacio>().comprovar_esq())
            {
                Debug.Log("esquerra");
                transform.Translate(Vector2.left * Velocitat * Time.deltaTime);
            }

            else if (Input.GetKey(Dreta) && this.GetComponent<raycast_comprovacio>().comprovar_dre())
            {
                Debug.Log("dreta");
                transform.Translate(Vector2.right * Velocitat * Time.deltaTime);
            }
            /*
            if (!Input.GetKey(Dreta) && !Input.GetKey(Esquerra))
            {
                if (actual_pos < 0)
                {
                    actual_pos += Velocitat;
                    transform.Translate(Vector2.right * Velocitat * Time.deltaTime);
                }
                if (actual_pos > 0)
                {
                    actual_pos -= Velocitat;
                    transform.Translate(Vector2.left * Velocitat * Time.deltaTime);
                }
            }
            */
        }

        else {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayLength)) {
                String tag = hit.transform.tag;

                if (tag == "salta") {
                    GameObject childWithTag = FindChildWithTag(this.transform, "Jugador");
                    Script_Salt saltar = childWithTag.GetComponent<Script_Salt>();
                    saltar.saltar();
                }

                else if (tag == "esquerra") {
                    while (this.GetComponent<raycast_comprovacio>().comprovar_esqGOD()) {
                        transform.Translate(Vector2.left * Velocitat * Time.deltaTime);
                    }
                }

                else if (tag == "dreta")
                {
                    while (this.GetComponent<raycast_comprovacio>().comprovar_dreGOD())
                    {
                        transform.Translate(Vector2.right * Velocitat * Time.deltaTime);
                    }
                }
            }
        }

    }


    GameObject FindChildWithTag(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                return child.gameObject;
            }
        }
        return null;
    }

}
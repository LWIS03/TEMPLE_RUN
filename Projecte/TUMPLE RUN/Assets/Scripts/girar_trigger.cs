
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class girar_trigger : MonoBehaviour
{
    private int esq_dre = 0;
    private int graus = 0;
    private int grausDreta = 0;
    private int grausEsquerra = 0;

    private void OnTriggerStay(Collider other)
    {
        bool godmode = this.GetComponent<Script_Moviment>().GodMode;

        if (godmode) {
            if (other.CompareTag("Pre gir"))
            {
                int randomNumber = Random.Range(1, 3);
                esq_dre = randomNumber;
                if (randomNumber == 1) grausDreta = graus + 90;
                if (randomNumber == 2) grausEsquerra = graus - 90;
            }

            if (other.CompareTag("pre_gir_dre"))
            {
                grausDreta = graus + 90;
                esq_dre = 2;
            }

            if (other.CompareTag("pre_gir_esq"))
            {
                    grausEsquerra = graus - 90;
                    esq_dre = 1;
            }
        }
        else
        {
            if (other.CompareTag("Pre gir"))
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    grausDreta = graus + 90;
                    esq_dre = 2;
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    grausEsquerra = graus - 90;
                    esq_dre = 1;
                }
            }
            if (other.CompareTag("pre_gir_dre"))
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    grausDreta = graus + 90;
                    esq_dre = 2;
                }

            }
            if (other.CompareTag("pre_gir_esq"))
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    grausEsquerra = graus - 90;
                    esq_dre = 1;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(esq_dre);
        //Debug.Log(other.tag);
        if (other.CompareTag("Gir") || other.CompareTag("Gir_dre") || other.CompareTag("Gir_esq"))
        {
            if (esq_dre == 1)
            {
                this.gameObject.GetComponent<girar_esquerra>().gir(grausEsquerra);
                graus = grausEsquerra;
            }
            if (esq_dre == 2)
            {
                this.gameObject.GetComponent<girar_dreta>().gir(grausDreta);
                graus = grausDreta;
            }
            esq_dre = 0;
        }

    }
}

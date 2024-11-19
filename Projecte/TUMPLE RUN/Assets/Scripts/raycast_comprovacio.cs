using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast_comprovacio : MonoBehaviour
{

    public float distdre = 0, distesq = 0;
    public bool comprovar_esq() { 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -this.transform.right ,out hit, 10f)) {
            Debug.DrawRay(transform.position, -this.transform.right,Color.red);

            if (hit.transform.tag == "Pared")
            {
                float distancia = hit.distance;
                distesq = distancia;
                if (distancia > 0.5f) return true;
                return false;
            }
        }
        return true;
    }

    public bool comprovar_dre()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, this.transform.right ,out hit, 10f))
        {
            Debug.DrawRay(transform.position, this.transform.right, Color.red);

            if (hit.transform.tag == "Pared")
            {
                float distancia = hit.distance;
                distdre = distancia;
                if (distancia > 0.5f) return true;
                return false;
            }
        }
        return true;
    }

    public bool comprovar_esqGOD()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -this.transform.right, out hit, 10f))
        {
            Debug.DrawRay(transform.position, -this.transform.right, Color.red);

            if (hit.transform.tag == "Pared")
            {
                float distancia = hit.distance;
                distesq = distancia;
                if (distancia > 0.75f) return true;
                return false;
            }
        }
        return false;
    }

    public bool comprovar_dreGOD()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, this.transform.right, out hit, 10f))
        {
            Debug.DrawRay(transform.position, this.transform.right, Color.red);

            if (hit.transform.tag == "Pared")
            {
                float distancia = hit.distance;
                distdre = distancia;
                if (distancia > 0.75f) return true;
                return false;
            }
        }
        return false;
    }
}

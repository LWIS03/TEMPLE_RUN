using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class moure_mapa : MonoBehaviour
{
    private GameObject[] tiles;
    public GameObject personatge;
    public float velocitat;
    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        GameObject objetoUnido = new GameObject("mapa");
        

        foreach (GameObject obj in tiles)
        {
            obj.transform.parent = objetoUnido.transform;
        }

        objetoUnido.transform.position = Vector3.zero;
        objetoUnido.transform.rotation = Quaternion.identity;
    }
}

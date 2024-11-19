using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titol_mirar_camera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Encuentra la cámara principal en la escena
    }

    void Update()
    {
        // Asegúrate de que la cámara está asignada
        if (mainCamera != null)
        {
            // Calcula la dirección desde el plano hacia la cámara
            Vector3 lookDirection = mainCamera.transform.position - transform.position;

            // Calcula la rotación necesaria para mirar hacia la cámara
            Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            // Aplica la rotación al plano
            transform.rotation = rotation;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titol_mirar_camera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Encuentra la c�mara principal en la escena
    }

    void Update()
    {
        // Aseg�rate de que la c�mara est� asignada
        if (mainCamera != null)
        {
            // Calcula la direcci�n desde el plano hacia la c�mara
            Vector3 lookDirection = mainCamera.transform.position - transform.position;

            // Calcula la rotaci�n necesaria para mirar hacia la c�mara
            Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            // Aplica la rotaci�n al plano
            transform.rotation = rotation;
        }
    }
}

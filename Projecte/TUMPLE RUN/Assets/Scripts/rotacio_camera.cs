using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacio_camera : MonoBehaviour
{
    public float orbitSpeed = 1.0f; // Velocidad de �rbita
    public float orbitRadius = 5.0f; // Radio de �rbita en el eje X
    public float centre_y = 50;
    private Vector3 orbitCenter = Vector3.zero;
    void Start()
    {
        orbitCenter = new Vector3(0, centre_y, 0); // Definir el centro de la �rbitas
    }

    // Update is called once per frame
    void Update()
    {
        // Calcular la posici�n en la �rbita
        float angle = Time.time * orbitSpeed;
        Vector3 orbitPosition = new Vector3(Mathf.Cos(angle) * orbitRadius, orbitCenter.y, Mathf.Sin(angle) * orbitRadius) + orbitCenter;

        // Establecer la posici�n de la c�mara
        transform.position = orbitPosition;

        // Hacer que la c�mara mire hacia el centro de la �rbita
        transform.LookAt(orbitCenter);
    }
}

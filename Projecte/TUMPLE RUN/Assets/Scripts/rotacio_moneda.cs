using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacio_moneda : MonoBehaviour
{
    public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

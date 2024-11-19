using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacio_titol : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Quaternion miQuaternion = Quaternion.Euler(90, Camera.main.transform.rotation.eulerAngles.y - 180, 0);
        this.transform.rotation = miQuaternion;
    }
}

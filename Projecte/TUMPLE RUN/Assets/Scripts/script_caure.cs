using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_caure : MonoBehaviour
{
    public float velocitat_caure = 5;
    public bool caic() {
        if (transform.position.y <= 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -this.transform.up, out hit))
            {
                if (hit.collider.CompareTag("Morir"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        return false;
    }


    private void Update()
    {
        if (caic()) {
            transform.Translate(-Vector3.up * velocitat_caure * Time.deltaTime);
        }
    }
}

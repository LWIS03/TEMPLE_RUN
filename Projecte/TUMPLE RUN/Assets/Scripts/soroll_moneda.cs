using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class soroll_moneda : MonoBehaviour
{
    public AudioClip monedaClip;

    public void Soroll() {
        AudioSource.PlayClipAtPoint(monedaClip, transform.position);
        Destroy(this.gameObject);
    }


    
}

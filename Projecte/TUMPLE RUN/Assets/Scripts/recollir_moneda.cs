using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recollir_moneda : MonoBehaviour
{
    public int monedes_totals = 0;
    public AudioClip monedes_audio;
    private GameObject Text;
    public GameObject particleSystemObject;
    private ParticleSystem particleSystem;

    void Start()
    {
        monedes_totals = 0; 
        Text = GameObject.FindWithTag("puntuacio");
        particleSystem = particleSystemObject.GetComponent<ParticleSystem>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Moneda")
        {
            particleSystem.Play();
            monedes_totals++;
            AudioSource.PlayClipAtPoint(monedes_audio, transform.position);
           Destroy(other.gameObject);
           Text.GetComponent<script_puntuacio>().actualitzar_monedes(monedes_totals);
            //particleSystem.Stop();
        }
    }

}

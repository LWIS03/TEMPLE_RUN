using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using static UnityEngine.GraphicsBuffer;

public class monstres_aproparse : MonoBehaviour
{
    private int vides = 2;
    public GameObject menuMorir;
    public AudioClip morir_so;
    public AudioClip so_monos;

    public Transform monstres; // El objeto hijo que se moverá
    public float distance = 6f; // La distancia a la que se moverá
    public float speed = 1f; // La velocidad de movimiento

    private Vector3 initialLocalPosition;
    private Vector3 targetLocalPosition;

    private bool redera = false;



    private void OnTriggerEnter(Collider other)
    {

        initialLocalPosition = monstres.localPosition;
        if (other.tag == "monstresAprop")
        {
            Debug.Log("els monstres s'apropen");
            targetLocalPosition = initialLocalPosition + new Vector3(0, 0, distance);
            redera = true;
            vides--;
            StartCoroutine(MoveCoroutine());
            AudioSource.PlayClipAtPoint(so_monos, transform.position);


            if (vides == 0) {
                AudioSource.PlayClipAtPoint(morir_so, transform.position);
                Time.timeScale = 0;
                menuMorir.SetActive(true);
            }

        }
        
        else if (other.tag == "AdeuMonstres" && redera)
        {
            Debug.Log("els monstres s'allunnyen");
            redera = false;
            AudioSource.PlayClipAtPoint(so_monos, transform.position);
            targetLocalPosition = initialLocalPosition + new Vector3(0, 0, -distance);

            vides++;
            StartCoroutine(MoveCoroutine());

        }
        
    }

    IEnumerator MoveCoroutine()
    {

        float elapsedTime = 0f;
        Vector3 startingPos = monstres.localPosition;

        while (elapsedTime < 0.3f)
        {
            elapsedTime += Time.deltaTime * speed;
            monstres.localPosition = Vector3.Lerp(startingPos, targetLocalPosition, elapsedTime);
            yield return null;
        }

    }

}

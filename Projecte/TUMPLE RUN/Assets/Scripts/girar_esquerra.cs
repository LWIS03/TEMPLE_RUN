using System.Collections;
using UnityEngine;

public class girar_esquerra : MonoBehaviour
{
    public float rotationTime = 1f; // Ajusta el tiempo de rotación

    public void gir(int rotacio)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, rotacio, 0);
        StartCoroutine(Rotate(startRotation, endRotation));
    }

    IEnumerator Rotate(Quaternion startRotation, Quaternion endRotation)
    {
        float time = 0;

        while (time < rotationTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, time / rotationTime);
            time += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
    }
}

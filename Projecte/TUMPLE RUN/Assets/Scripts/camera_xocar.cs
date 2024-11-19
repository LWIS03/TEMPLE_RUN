using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_xocar : MonoBehaviour
{
    public IEnumerator Shake(float duracio, float magnitud) {
        Vector3 posici_OG = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duracio) {
            float x = Random.Range(-1f, 1f) * magnitud;
            float y = Random.Range(-1f, 1f) * magnitud;

            transform.localPosition = new Vector3(x, y, posici_OG.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = posici_OG;
    }
}

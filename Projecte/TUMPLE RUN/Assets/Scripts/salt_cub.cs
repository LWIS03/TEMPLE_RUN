using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salt_cub : MonoBehaviour
{
    public float jumpHeight = 5f; // Altura del salto
    public float jumpTime = 1f; // Duración del salto
    private float startPosition;
    private bool isJumping = false;




    void Update()
    {
        if (!this.GetComponent<Script_Moviment>().GodMode)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
            {
                saltar();
            }
        }
    }

    public void saltar()
    {
        isJumping = true;
        startPosition = transform.position.y;
        StartCoroutine(Jump());
    }

    IEnumerator Jump()
    {
        float time = 0;

        while (time < jumpTime)
        {
            // Calcular la posición actual en el salto
            float currentHeight = jumpHeight * (time / jumpTime) * (1 - time / jumpTime);
            transform.position = new Vector3(transform.position.x, startPosition + currentHeight, transform.position.z);

            time += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que el objeto vuelve a su posición inicial
        transform.position = new Vector3(transform.position.x, startPosition, transform.position.z);
        isJumping = false; ;
    }
}

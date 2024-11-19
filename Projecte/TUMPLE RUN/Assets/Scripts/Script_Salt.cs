using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Salt : MonoBehaviour
{
    public float jumpHeight = 5f; // Altura del salto
    public float jumpTime = 1f; // Duración del salto
    public GameObject particleSystemObject1;
    public GameObject particleSystemObject2;
    private ParticleSystem particleSystem1;
    private ParticleSystem particleSystem2;

    private float startPosition;
    private bool isJumping = false;

    public GameObject cub;
    
    private Animator animator;

    public AudioClip saltar_so;
    public AudioClip aterrar_so;

    private void Start()
    {
        particleSystem1 = particleSystemObject1.GetComponent<ParticleSystem>();
        particleSystem2 = particleSystemObject2.GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!cub.GetComponent<Script_Moviment>().GodMode)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
            {
                saltar();
            }
        }
    }

    public void saltar() {
        particleSystem1.Stop();
        particleSystem2.Stop();
        animator.SetTrigger("Jump");
        AudioSource.PlayClipAtPoint(saltar_so, transform.position);

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
        transform.position = new Vector3 (transform.position.x, startPosition, transform.position.z);
        isJumping = false;;
        AudioSource.PlayClipAtPoint(aterrar_so, transform.position);
        animator.SetTrigger("Run");
        this.transform.position = cub.transform.position;
        this.transform.rotation = cub.transform.rotation;
        particleSystem1.Play();
        particleSystem2.Play();
    }
}

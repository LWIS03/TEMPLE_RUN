using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_lliscar : MonoBehaviour
{
    private bool lliscant = false;
    private Animator animator;
    public float moveAmount = 3.0f;
    public float tempsLliscar = 0.5f; // Duración del salto
    private BoxCollider boxCollider;
    private Transform cameraTransform;
    public float rotateAmount = 15.0f;
    public GameObject cub;

    public AudioClip lliscar_so;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        boxCollider = GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!cub.GetComponent<Script_Moviment>().GodMode)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && !lliscant)
            {
                animator.SetTrigger("Slide");
                AudioSource.PlayClipAtPoint(lliscar_so, transform.position);
                lliscant = true;

                boxCollider.center = new Vector3(0.0f, 0.015f, 0.0f);
                boxCollider.size = new Vector3(0.03f, 0.03f, 0.03f);

                StartCoroutine(lliscar());
                transform.position = cub.transform.position;
                transform.rotation = cub.transform.rotation;
            }
        }

    }

    IEnumerator lliscar()
    {
        float elapsedTime = 0f;
        float originalY = cameraTransform.localPosition.y;
        float targetY = originalY - moveAmount;
        float originalXRotation = cameraTransform.localEulerAngles.x;
        float targetXRotation = originalXRotation - rotateAmount;

        // Mover la cámara hacia abajo
        while (elapsedTime < tempsLliscar / 2)
        {
            float newY = Mathf.Lerp(originalY, targetY, elapsedTime / (tempsLliscar / 2));
            cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, newY, cameraTransform.localPosition.z);
            float newXRotation = Mathf.Lerp(originalXRotation, targetXRotation, elapsedTime / (tempsLliscar / 2));
            cameraTransform.localEulerAngles = new Vector3(newXRotation, cameraTransform.localEulerAngles.y, cameraTransform.localEulerAngles.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que la cámara llega exactamente al punto objetivo
        cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, targetY, cameraTransform.localPosition.z);
        cameraTransform.localEulerAngles = new Vector3(targetXRotation, cameraTransform.localEulerAngles.y, cameraTransform.localEulerAngles.z);

        elapsedTime = 0f;
        yield return new WaitForSeconds(tempsLliscar / 2);
        animator.SetTrigger("Run");
        // Mover la cámara de vuelta a la posición original
        while (elapsedTime < tempsLliscar / 2)
        {
            float newY = Mathf.Lerp(targetY, originalY, elapsedTime / (tempsLliscar / 2));
            cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, newY, cameraTransform.localPosition.z);
            float newXRotation = Mathf.Lerp(targetXRotation, originalXRotation, elapsedTime / (tempsLliscar / 2));
            cameraTransform.localEulerAngles = new Vector3(newXRotation, cameraTransform.localEulerAngles.y, cameraTransform.localEulerAngles.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que la cámara vuelve exactamente a la posición original
        cameraTransform.localEulerAngles = new Vector3(originalXRotation, cameraTransform.localEulerAngles.y, cameraTransform.localEulerAngles.z);
        cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, originalY, cameraTransform.localPosition.z);

        boxCollider.size = new Vector3(0.03f, 0.08f, 0.03f);
        boxCollider.center = new Vector3(0.0f, 0.04f, 0.0f);

        //animator.SetTrigger("Run");
        lliscant = false;
    }
}


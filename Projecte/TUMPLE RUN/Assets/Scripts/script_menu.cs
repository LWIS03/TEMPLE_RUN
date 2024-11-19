using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class script_menu : MonoBehaviour
{
    private bool Pausa_Oberta = false;
    public GameObject menuPausa;
    public GameObject menuMorir;
    public TextMeshProUGUI countdownText; // Asigna un Text UI desde el editor
    public GameObject personatge;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Pausa_Oberta)
        {
            Time.timeScale = 0f;
            Pausa_Oberta = true;
            menuPausa.SetActive(true);
        }
        
        else if (Input.GetKeyDown(KeyCode.Escape) && Pausa_Oberta)
        {
            
            CountDown();
            
        }
        
    }

    public void seguir() {
        SceneManager.LoadScene("Gameplay");
       // menuMorir.SetActive(false);
       // personatge.transform.position = Vector3.zero;
       // personatge.transform.rotation = Quaternion.identity;
        StartCoroutine(StartCountdown());
    }


    public void CountDown() {
        menuPausa.SetActive(false);
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        // Espera 3 segundos antes de comenzar la cuenta regresiva
        int countdownValue = 3;

        while (countdownValue > 0)
        {
            countdownText.text = countdownValue.ToString(); // Actualiza el texto UI
            yield return new WaitForSecondsRealtime(1); // Espera 1 segundo
            countdownValue--;
        }


        countdownValue = 1;
        while (countdownValue > 0)
        {
            countdownText.text = "YA!"; // Actualiza el texto UI
            yield return new WaitForSecondsRealtime(1); // Espera 1 segundo
            countdownValue--;
        }
        Time.timeScale = 1f;
        countdownText.text = "";
        Pausa_Oberta = false;
        // Una vez que la cuenta regresiva llegue a 0, oculta el texto o realiza otra acción
    }
}

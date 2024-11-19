using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canvia_escena : MonoBehaviour
{
 // Nombre de la escena a cargar (asegúrate de que el nombre sea el correcto)
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }

    public void tanca_aplicacio() { 
        Application.Quit();
        Debug.Log("aplicacio tancada");
    }
}

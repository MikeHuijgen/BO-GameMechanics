using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Zorgt ervoor als je op playbutton klikt ga je naar de volgende scene.
                                                                              //Wat je hebt ingesteld in de build. 
    }

    public void QuitGame()
    {
        Application.Quit(); // Dit zorgt ervoor dat je de game helemaal afsluit als je de game hebt gebuild. 
        Debug.Log("Quit the game");
    }
}


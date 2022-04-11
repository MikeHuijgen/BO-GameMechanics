using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzeMenu : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] bool TogglePauze;
    public bool cursorVisible;
    [SerializeField] GameObject player;

    private void Start()
    {
        canvas.enabled = false;
        TogglePauze = false;
        cursorVisible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && TogglePauze == false)
        {
            canvas.enabled = true;
            TogglePauze = true;
            cursorVisible = true;
            Pause();

        }

        CursorV();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        canvas.enabled = true;      
    }

    public void Resume()
    {
        canvas.enabled = false;
        TogglePauze = false;
        cursorVisible = false;
        Time.timeScale = 1f; 
    }

    public void Home(int SceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneID);
    }


    void CursorV()
    {
        if (cursorVisible == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

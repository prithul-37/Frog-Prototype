using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{   
    public Animator animator;
    public GameObject pauseMenuUI;
    public void loadNextLevel()
    {
        StartCoroutine(wait1SecN());    
    }

    public void loadCurrentLevel() 
    {
        StartCoroutine(wait1SecC());   
    }

    IEnumerator wait1SecN()
    {
        animator.SetTrigger("outro");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator wait1SecC()
    {
        animator.SetTrigger("outro");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }
    
    public void play()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }
}
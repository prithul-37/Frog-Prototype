using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvus : MonoBehaviour
{
    public Animator animator;


    public void play()
    {
        StartCoroutine(Load());
    }

    public void quit()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator Load()
    {
        animator.SetTrigger("Load");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    private IEnumerator QuitGame()
    {
        animator.SetTrigger("Load");
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}

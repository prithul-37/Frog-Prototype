using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{   
    public Animator animator;
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
}
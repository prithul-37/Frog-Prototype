using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Platform Section")]
    public bool iMovePlatform;
    [Range(.01f, 0.1f)]
    [Tooltip("Set te speed of platforms")]
    public float speedOfPlatforms;
    [Range(1f, 10f)]
    [Tooltip("platform will destroy after \n (6 + platformDestroyTime) seconds")]
    public float pDestroyTime;

    [Header("Obstale Section")]
    public bool iEnableObstacles;
    public bool iMoveObstale;
    //[Tooltip("Set obstacle direstion. \n set 1 on the desired axis and leave 0 to others")]
    //public Vector3 ObstacleMoveDirecton;
    [Range(.01f, 0.1f)]
    [Tooltip("Set te speed of Obstale")]
    public float speedOfObstale;
    public float xTh, yTh, zTh;

    public GameObject LevelCompleteUI;
    public GameObject LevelFailedUI;

    private void Start()
    {
        LevelCompleteUI?.SetActive(false);
        LevelFailedUI?.SetActive(false);
        PlayerEvents.playerdied += levelFailed;
        PlayerEvents.levelCompleted += levelCompleted;
    }
    public void levelCompleted()
    {
        Debug.Log("Win");
        LevelCompleteUI?.SetActive(true);
        var t = LevelCompleteUI?.transform.GetChild(0);
        t.GetComponent<TextMeshProUGUI>().text = $"{SceneManager.GetActiveScene().name}";
    }

    public void levelFailed()
    {
        Debug.Log("Died");
        LevelFailedUI?.SetActive(true);
    }

    private void OnDestroy()
    {
        PlayerEvents.playerdied -= levelFailed;
        PlayerEvents.levelCompleted -= levelCompleted;
    }

}

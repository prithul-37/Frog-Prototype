using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}

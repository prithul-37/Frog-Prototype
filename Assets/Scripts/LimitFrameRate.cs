using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFrameRate : MonoBehaviour
{
    public int frameRate;
    private void Awake()
    {
        Application.targetFrameRate = frameRate;
    }


}

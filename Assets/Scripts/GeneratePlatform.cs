using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GeneratePlatform : MonoBehaviour
{
    public GameObject platform;
    public float initialPos;
    private float nextPos;
    private int nextID = 1;

    public static int tileCount = 0;

    private void Start()
    {
        tileCount = 0;
        nextPos = initialPos;
        nextID = 1;

}

    private void Update()
    {
        while (tileCount < 10)
        {
            GameObject tile = Instantiate(platform, new Vector3(Random.Range(-4f, 4f), 0f, nextPos), Quaternion.identity);
            tile.GetComponent<MovePlatform>().id = nextID;
            nextID++;
            tileCount++;
            nextPos += Random.Range(7f, 14f);
            //Debug.Log(tileCount);
        }
    }

}

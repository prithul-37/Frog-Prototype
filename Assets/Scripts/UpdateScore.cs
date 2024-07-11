using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{   
    

    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = 00.ToString();
        PlayerEvents.UpdateScore += updateScore;
    }
    public void updateScore(int x)
    {
        GetComponent<TextMeshProUGUI>().text = x.ToString();
    }

    private void OnDestroy()
    {
        PlayerEvents.UpdateScore -= updateScore;
    }
}

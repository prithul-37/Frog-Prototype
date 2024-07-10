using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateCoinCount : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TextMeshProUGUI>().text = 00.ToString();
        PlayerInfo._coinUpdated += updateCoin;
    }

    private void OnDestroy()
    {
        PlayerInfo._coinUpdated -= updateCoin;
    }
    public void updateCoin(int x)
    {   
        //Debug.Log(x);
        GetComponent<TextMeshProUGUI>().text = x.ToString();
    }


}

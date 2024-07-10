using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private int coins;
    public static event Action<int> _coinUpdated = delegate { };

    private void Start()
    {
        coins = 0;
    }

    public void updateCoin()
    {
        coins++;
        //Debug.Log(coins);
        _coinUpdated?.Invoke(coins);

    }
}

using System;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private int coins;
    [SerializeField]private AudioClip[] audios;
    private float timer;
    public static event Action<int> _coinUpdated = delegate { };

    private void Start()
    {
        coins = 0;
        timer = UnityEngine.Random.Range(2f,7f);
    }

    private void Update()
    {   
        timer -= Time.deltaTime;
        while (timer < 0)
        {
            AudioManager.instance.playClip(audios[UnityEngine.Random.Range(0,audios.Length)],transform,1f);
            timer = UnityEngine.Random.Range(2f, 7f);
        }
    }

    public void updateCoin()
    {
        coins++;
        //Debug.Log(coins);
        _coinUpdated?.Invoke(coins);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] AudioClip colletCoin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.instance.playClip(colletCoin, transform, 1);
            other.gameObject.GetComponent<PlayerInfo>().updateCoin();
            gameObject.SetActive(false);
        }
    }

}

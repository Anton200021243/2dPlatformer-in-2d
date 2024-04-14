using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Action onAllCoinCollected;

    private int _coinCount = 0;
    private int _maxCoin = 2;

    public void AddCoin()
    {
        _coinCount++;

        if (_coinCount == _maxCoin)
        {
            onAllCoinCollected?.Invoke();
        }
    }
}

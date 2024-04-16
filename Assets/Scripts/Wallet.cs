using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Action onAllCoinCollected;

    [SerializeField] private Transform _coin;

    private int _coinCount = 0;
    private int _maxCoin = 7;

    private void Start()
    {
        _maxCoin = _coin.childCount;
    }

    public void AddCoin()
    {
        _coinCount++;

        if (_coinCount == _maxCoin)
        {
            onAllCoinCollected?.Invoke();
        }
    }
}

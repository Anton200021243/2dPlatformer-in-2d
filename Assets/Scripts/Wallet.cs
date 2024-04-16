using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Action OnAllCoinCollected;

    [SerializeField] private Transform _coin;

    private int _coinCount = 0;
    private int _maxCoin;

    private void Start()
    {
        _maxCoin = _coin.childCount;
    }

    public void AddCoin()
    {
        _coinCount++;

        if (_coinCount == _maxCoin)
        {
            OnAllCoinCollected?.Invoke();
        }
    }
}

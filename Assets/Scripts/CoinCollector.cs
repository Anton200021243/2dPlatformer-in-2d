using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Transform _coin;

    public event Action AllCoinCollected;

    private int _score = 0;
    private int _maxScore;

    private void Awake()
    {
        _maxScore = _coin.childCount;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
            AddCoin();
        }
    }

    public void AddCoin()
    {
        _score++;

        if (_score == _maxScore)
        {
            AllCoinCollected?.Invoke();
        }
    }
}

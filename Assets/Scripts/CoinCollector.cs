using UnityEngine;
using System;

public class CoinCollector : MonoBehaviour
{
    public event Action OnAllCoinCollected;

    private int _coinCount = 0;
    private int _maxCoin = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _coinCount++;
            Destroy(coin.gameObject);
        }

        if (_coinCount == _maxCoin)
        {
            OnAllCoinCollected?.Invoke();
        }
    }
}

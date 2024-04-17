using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _coin;

    private int _coinCount = 0;
    private int _maxCoinCount;

    private void Start()
    {
        _maxCoinCount = _coin.childCount;
    }

    public void AddCoin()
    {
        _coinCount++;

        if (_coinCount == _maxCoinCount)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}

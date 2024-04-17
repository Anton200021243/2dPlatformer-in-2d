using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] private CoinCollector _coinCollector;

    private void OnEnable()
    {
        _coinCollector.OnAllCoinCollected += EndGame;
    }

    private void OnDisable()
    {
        _coinCollector.OnAllCoinCollected -= EndGame;
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}

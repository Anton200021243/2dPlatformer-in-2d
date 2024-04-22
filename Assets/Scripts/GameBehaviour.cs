using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] private Player _player;

    private PlayerHealth _playerHealth;   
    private CoinCollector _playerCoinCollector;   

    private void Start()
    {
        _playerHealth = _player.GetComponent<PlayerHealth>();
        _playerCoinCollector = _player.GetComponent<CoinCollector>();
        _playerHealth.OnPlayerDeath += EndGame;
        _playerCoinCollector.OnAllCoinCollected += EndGame;
    }

    private void OnDisable()
    {
        _playerHealth.OnPlayerDeath -= EndGame;
        _playerCoinCollector.OnAllCoinCollected -= EndGame;
    }

    private void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}

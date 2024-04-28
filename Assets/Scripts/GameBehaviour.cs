using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Health _playerHealth; 
    private CoinCollector _playerCoinCollector;   

    private void Awake()
    {
        _playerHealth = _player.GetComponent<Health>();
        _playerCoinCollector = _player.GetComponent<CoinCollector>();      
        _playerCoinCollector.AllCoinCollected += EndGame;
    }

    private void OnEnable()
    {
        _playerHealth.PlayerDead += EndGame;
    }

    private void OnDisable()
    {
        _playerHealth.PlayerDead -= EndGame;
        _playerCoinCollector.AllCoinCollected -= EndGame;
    }

    private void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}

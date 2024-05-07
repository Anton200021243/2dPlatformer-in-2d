using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _endScreen;

    private Health _playerHealth; 
    private CoinCollector _playerCoinCollector;   

    private void Awake()
    {
        _playerHealth = _player.GetComponent<Health>();
        _playerCoinCollector = _player.GetComponent<CoinCollector>();      
        
    }

    private void OnEnable()
    {
        _playerHealth.PlayerDead += EndGame;
        _playerCoinCollector.AllCoinCollected += EndGame;
    }

    private void OnDisable()
    {
        _playerHealth.PlayerDead -= EndGame;
        _playerCoinCollector.AllCoinCollected -= EndGame;
    }


    private void EndGame()
    {
        _endScreen.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void RestartLevel()
    {
        _endScreen.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}

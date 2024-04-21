using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _coin;
    [SerializeField] private Player _player;

    private PlayerHealth _playerHealth;

    private int _score = 0;
    private int _maxScore;

    private void Start()
    {
        _maxScore = _coin.childCount;
        _playerHealth = _player.GetComponent<PlayerHealth>();
        _playerHealth.OnPlayerDeath += EndGame;
    }

    public void AddCoin()
    {
        _score++;

        if (_score == _maxScore)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _coin;

    private int _score = 0;
    private int _maxScore;

    private void Start()
    {
        _maxScore = _coin.childCount;
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

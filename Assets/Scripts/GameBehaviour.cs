using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    private void OnEnable()
    {
        Wallet.onAllCoinCollected += EndGame;
    }

    private void OnDisable()
    {
        Wallet.onAllCoinCollected -= EndGame;
    }

    public void EndGame()
    {
        Debug.Log("You are collected all coins");
        SceneManager.LoadScene(0);
    }
}

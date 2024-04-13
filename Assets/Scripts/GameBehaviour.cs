using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}

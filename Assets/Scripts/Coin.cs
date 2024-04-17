using UnityEngine;

public class Coin : MonoBehaviour 
{
    [SerializeField] private GameManager _gameBehaviour;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
            _gameBehaviour.AddCoin();
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _smoothBarHP;

    private PlayerHealth _playerHealth;
    private float _speedChange = 3;

    private void Awake()
    {
        _playerHealth = _player.GetComponent<PlayerHealth>();        
    }

    private void OnEnable()
    {
        _playerHealth.OnHealthChange += UpdateHealth;
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthChange -= UpdateHealth;
    }

    public void UpdateHealth()
    {
        StartCoroutine(ChangeHealth(_playerHealth.Health / _playerHealth.MaxHealth));
    }

    private IEnumerator ChangeHealth(float targetHealth)
    {
        while (_smoothBarHP.fillAmount != targetHealth)
        {
            _smoothBarHP.fillAmount = Mathf.MoveTowards(_smoothBarHP.fillAmount, targetHealth, _speedChange * Time.deltaTime);
            yield return null;
        }
    }
}

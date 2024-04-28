using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthEnemyUI : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Image _smoothBarHP;

    private EnemyHealth _enemyHealth;
    private float _speedChange = 3;

    private void Awake()
    {
        _enemyHealth = _enemy.GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        _enemyHealth.OnEnemyHealthChange += UpdateHealth;
    }

    private void OnDisable()
    {
        _enemyHealth.OnEnemyHealthChange -= UpdateHealth;
    }

    public void UpdateHealth()
    {
        StartCoroutine(ChangeHealth(_enemyHealth.Health / _enemyHealth.MaxHealth));
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

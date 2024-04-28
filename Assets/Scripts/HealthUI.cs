using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Transform _object;
    [SerializeField] private Image _smoothBarHP;

    private Health _health;
    private float _speedChange = 3;
    private Quaternion _rotation;

    private void Awake()
    {
        _health = _object.GetComponent<Health>();
        _rotation = Quaternion.identity;
    }

    private void Update()
    {
        transform.rotation = _rotation;
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealth;
    }

    public void UpdateHealth()
    {
        StartCoroutine(ChangeHealth(_health.HealthPoints / _health.MaxHealth));
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

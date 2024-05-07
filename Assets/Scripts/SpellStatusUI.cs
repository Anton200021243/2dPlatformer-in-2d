using System.Collections;
using TMPro;
using UnityEngine;

public class SpellStatusUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _spellText;
    [SerializeField] private Transform _player;

    private Vampiric _vampireSpell;
    private float _currentCouldown;

    private void Awake()
    {
        _spellText.text = "Vampiric: " + _currentCouldown;
        _vampireSpell = _player.GetComponent<Vampiric>();
    }

    private void OnEnable()
    {
        _vampireSpell.UsedSpell += UseSpell;
    }
    
    private void OnDisable()
    {
        _vampireSpell.UsedSpell -= UseSpell;
    }

    private void UseSpell()
    {
        _currentCouldown = _vampireSpell.VampiricCouldown;
        _spellText.text = "Vampiric: " + _currentCouldown;
        StartCoroutine(CounterCouldown());
    }

    private void UpdateSpellText()
    {
        _spellText.text = "Vampiric: " + _currentCouldown;
    }

    private IEnumerator CounterCouldown()
    {
        while (_currentCouldown > 0)
        {
            _currentCouldown--;
            UpdateSpellText();
            yield return new WaitForSeconds(1);
        }
    }
}

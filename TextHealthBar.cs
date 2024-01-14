using TMPro;
using UnityEngine;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        
        _health.HealthChanged += ChangeText;
    }

    private void Start()
    {
        ChangeText();
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChangeText;
    }

    private void ChangeText()
    {
        _text.text = _health.CurrentAmount.ToString() + " / " + _health.MaxAmount.ToString();
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public event UnityAction HealthEmptied;
    public event UnityAction HealthChanged;

    private float _maxAmount = 100;
    private float _minAmount = 0;
    private float _currentAmount;

    public float CurrentAmount => _currentAmount;
    public float MaxAmount => _maxAmount;

    private void Awake()
    {
        _currentAmount = _maxAmount;
    }

    public void Increace(int amount)
    {
        if (_currentAmount + amount < _maxAmount)
        {
            _currentAmount += amount;
            HealthChanged?.Invoke();
        }
        else
        {
            _currentAmount = _maxAmount;
            HealthChanged?.Invoke();
        }
    }

    public void Decreace(int amount)
    {
        if (_currentAmount > _minAmount)
        {
            _currentAmount -= amount;
            HealthChanged?.Invoke();
        }
        else if (_currentAmount <= _minAmount)
        {
            HealthEmptied?.Invoke();
        }
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _smoothSlider;

    public event UnityAction HealthEmptied;

    private float _speed = 10;
    private float _maxAmount = 100;
    private float _minAmount = 0;
    private float _currentAmount;

    private void Start()
    {
        _currentAmount = _maxAmount;
        _slider.maxValue = _maxAmount;
        _smoothSlider.maxValue = _maxAmount;
        _smoothSlider.value = _maxAmount;
        ChangeText();
        ChangeSlider();
    }

    public void Increace(int amount)
    {
        if (_currentAmount + amount <= _maxAmount)
        {
            _currentAmount += amount;
            ChangeText();
            ChangeSlider();
            StartCoroutine(ChangeSmoothSlider());
        }
        else
        {
            _currentAmount = _maxAmount;
            ChangeText();
            ChangeSlider();
            StartCoroutine(ChangeSmoothSlider());
        }
    }

    public void Decreace(int amount)
    {
        if (_currentAmount > _minAmount)
        {
            _currentAmount -= amount;
            ChangeText();
            ChangeSlider();
            StartCoroutine(ChangeSmoothSlider());
        }
        else if (_currentAmount <= _minAmount)
        {
            HealthEmptied.Invoke();
        }
    }

    private void ChangeText()
    {
        _text.text = _currentAmount.ToString() + " / " + _maxAmount.ToString();
    }

    private void ChangeSlider()
    {
        _slider.value = _currentAmount;
    }

    private IEnumerator ChangeSmoothSlider()
    {
        while(_smoothSlider.value != _currentAmount)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, _currentAmount, _speed * Time.deltaTime);

            yield return null;
        }
      
    }
}

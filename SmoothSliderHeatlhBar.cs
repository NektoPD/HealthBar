using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderHeatlhBar : MonoBehaviour
{
    [SerializeField] private Slider _smoothSlider;
    private Health _health;
    private float _speed = 10;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _smoothSlider.maxValue = _health.MaxAmount;
        _smoothSlider.value = _health.CurrentAmount;
    }

    private void OnEnable()
    {
        
        _health.HealthChanged += StartSmoothChange;
    }

    private void Start()
    {
        ChangeSlider();
    }

    private void OnDisable()
    {
        _health.HealthChanged -= StartSmoothChange;
    }

    private void StartSmoothChange()
    {
        StartCoroutine(ChangeSmoothSlider());
    }

    private IEnumerator ChangeSmoothSlider()
    {
        while (_smoothSlider.value != _health.CurrentAmount)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, _health.CurrentAmount, _speed * Time.deltaTime);

            yield return null;
        }
    }

    private void ChangeSlider()
    {
        _smoothSlider.value = _health.CurrentAmount;
    }
}

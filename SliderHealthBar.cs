using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _slider.maxValue = _health.MaxAmount;
    }

    private void OnEnable()
    {
        
        _health.HealthChanged += ChangeSlider;
    }

    private void Start()
    {
        ChangeSlider();
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChangeSlider;
    }

    private void ChangeSlider()
    {
        _slider.value = _health.CurrentAmount;
    }
}

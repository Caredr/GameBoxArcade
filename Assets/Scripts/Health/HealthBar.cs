using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private HealthSystem health;


    public void SetHeath(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

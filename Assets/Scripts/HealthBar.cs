using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image _healthBar;
    
    private void Start()
    {
        _healthBar = GetComponent<Image>();
    }

    public void UpdateBar(int health, int maxHealth)
    {
        _healthBar.fillAmount = (float)health / maxHealth;
    }
}

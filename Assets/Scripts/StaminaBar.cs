using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private Image _staminaBar;
    private void Start()
    {
        _staminaBar = GetComponent<Image>();
    }

    public void UpdateBar(float travelDistance, float maxTravelDistance)
    {
        _staminaBar.fillAmount = 1 - travelDistance / maxTravelDistance;
    }
}

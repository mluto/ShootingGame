using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private static Slider healthSlider;
    [SerializeField] private Image damageImage;
    [SerializeField] private float flashSpeed = 5f;
    [SerializeField] private Color flashColour = new Color(1f, 0f, 0f, 0.2f);
    
    private static bool damaged;

    private void Awake()
    {
        healthSlider = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        DamageFlash();
    }

    /// <summary>Show player current health on bar.</summary>
    /// <param name="actualHp">Current health.</param>
    static public void HealthLoss(int actualHp)
    {
        damaged = true;
        healthSlider.value = actualHp;
    }

    /// <summary>Show flash on screen when taked damage.</summary>
    private void DamageFlash()
    {
        if (damaged || healthSlider.value <= 0)
        {
            damageImage.color = flashColour;
            damaged = false;
        }
        else if (damageImage.color != Color.clear)
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
    }

}


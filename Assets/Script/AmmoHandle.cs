using UnityEngine;
using UnityEngine.UI;

public class AmmoHandle : MonoBehaviour
{
    public static AmmoHandle Instance;
    public int ammoValue = 0;

    [SerializeField] private Text ammoValueText;


    private void Awake()
    {
        Instance = this;
    }

    public int GetAmmo(int value)
    {
        ammoValue += value;
        UpdateAmmoValue(ammoValue);
        return ammoValue;
    }

    public int LostAmmo(int value)
    {
        if(ammoValue > 0)
        {
            ammoValue -= value;
            UpdateAmmoValue(ammoValue);
        }
        return ammoValue;

    }

    private void UpdateAmmoValue(int ammoValue)
    {
        ammoValueText.text = "Ammo: " + ammoValue;
    }
}

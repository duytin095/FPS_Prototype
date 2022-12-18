using UnityEngine.UI;
using UnityEngine;

public class UIHandle : MonoBehaviour
{
    [SerializeField] private Text nameOfStuff;
    [SerializeField] private Text ammoValueText;


    public static UIHandle Instance;
    private void Awake()
    {
        Instance = this;
    }


    public void UpdateAmmoValue(int ammoValue)
    {
        ammoValueText.text = "Ammo: " + ammoValue;
    }
}

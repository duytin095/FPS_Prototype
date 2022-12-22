using UnityEngine;
using UnityEngine.UI;

public class AmmoHandle : MonoBehaviour
{
    public static AmmoHandle Instance;
    public int ammoValue = 0;


    private void Awake()
    {
        Instance = this;
    }

    public int GetAmmo(int value)
    {
        ammoValue += value;
        UIHandle.Instance.UpdateAmmoValue(ammoValue);
        return ammoValue;
    }

    public int LostAmmo(int value)
    {
        if(ammoValue > 0)
        {
            ammoValue -= value;
            UIHandle.Instance.UpdateAmmoValue(ammoValue);
        }
        return ammoValue;

    }


}

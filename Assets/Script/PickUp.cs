using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int ammoValue;
    [SerializeField] private GameObject weapon;
    [SerializeField] private PlayerInput playerInput;

    void Start()
    {
        if (weapon.activeInHierarchy) // Make sure that object inActive at start
        {
            weapon.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo"))
        {
            AmmoHandle.Instance.GetAmmo(ammoValue);
            UIHandle.Instance.DisplayPickUpStuffName(other.tag); 
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Weapon"))
        {
            if (!weapon.activeInHierarchy)
            {
                UIHandle.Instance.DisplayPickUpStuffName(other.tag);
                weapon.SetActive(true); // Active object that already attached in player
                playerInput.enabled = true;
                Destroy(other.gameObject);
            }
        }
    }
}

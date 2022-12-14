using UnityEngine;
using UnityEngine.InputSystem;
public class PickUp : MonoBehaviour
{
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
        if (other.gameObject.CompareTag("Player"))
        {
            if (!weapon.activeInHierarchy) 
            {
                weapon.SetActive(true); // Active object that already attached in player
                playerInput.enabled = true;
                Destroy(this.gameObject);
            }
        }
    }
}

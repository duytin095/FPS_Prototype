using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
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
            }
        }
    }
}

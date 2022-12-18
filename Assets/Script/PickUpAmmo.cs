using UnityEngine;

public class PickUpAmmo : MonoBehaviour
{
    [SerializeField] private GameObject weapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AmmoHandle.Instance.GetAmmo(5);
            Destroy(this.gameObject);
        }
    }
}

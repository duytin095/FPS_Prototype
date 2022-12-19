using UnityEngine;

public class PickUpAmmo : MonoBehaviour
{
    [SerializeField] private int value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AmmoHandle.Instance.GetAmmo(value);
            Destroy(this.gameObject);
        }
    }
}

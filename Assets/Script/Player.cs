using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    [SerializeField] private float heath;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UIHandle.Instance.UpdatePlayerHeath(heath);
    }
    void Update()
    {
        
    }

    public float LostHealth(float value)
    {
        heath -= value;
        UIHandle.Instance.UpdatePlayerHeath(heath);
        return heath;
    }

}

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
        if(heath <= 0)
        {
            Debug.Log("Player Death");
        }
    }

    public float LostHealth(float value)
    {
        heath -= value;
        UIHandle.Instance.UpdatePlayerHeath(heath);
        return heath;
    }

}

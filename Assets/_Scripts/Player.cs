using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public float heath;
    public float maxHeath;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        maxHeath = heath;
    }
    void Update()
    {
        if(heath <= 0)
        {
            UIHandle.Instance.GameOver(this.transform.parent.gameObject);
        }

    }

    public float LostHealth(float value)
    {
        float temp = Random.Range(value - 10f, value - 10f);
        heath -= temp;
        //UIHandle.Instance.UpdatePlayerHeath(heath);
        UIHandle.Instance.GetHitScreen();

        return heath;
    }
    public float Heal(float value)
    {
        var lostHeath = maxHeath - heath;
        if(value > lostHeath) // Block heath go over 100 value
        {
            value = lostHeath;
        }

        heath += value;

        //UIHandle.Instance.UpdatePlayerHeath(heath);
        return heath;
    }
}

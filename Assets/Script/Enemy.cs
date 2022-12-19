using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;

    [SerializeField] private float enemyHealth;

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if(enemyHealth <= 0)
        {
            Debug.Log("Enemy Death");
            Destroy(this.gameObject);
        }
    }

    public float LostHealth(float value)
    {
        enemyHealth -= value;
        return enemyHealth;
    }
}

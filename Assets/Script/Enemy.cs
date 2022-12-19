using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;

    [SerializeField] private float enemyHealth;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if(enemyHealth <= 0)
        {
            animator.CrossFade("Dying", 0, 0);
            Destroy(this.gameObject, 7);
        }
    }

    public float LostHealth(float value)
    {
        enemyHealth -= value;
        return enemyHealth;
    }
}

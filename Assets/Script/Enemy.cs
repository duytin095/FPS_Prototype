using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;

    [SerializeField] private float enemyHealth; // 
    [SerializeField] private float maxDistance; // 
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject burstSign;
    [SerializeField] private GameObject player;


    [SerializeField] private bool isDead = false;






    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (enemyHealth <= 0)
        {
            EnemyState("Dying", 0);
            isDead = true;
            Destroy(this.gameObject, 7);
        }


        if (player)
        {
            var dist = Vector3.Distance(player.transform.position, transform.position);

            if(dist > maxDistance)
            {
                EnemyState("Breathing Idle", 0);
            }
            else
            {
                EnemyState("Aiming", 1);
            }
        }


    }

    public float LostHealth(float value)
    {
        enemyHealth -= value;
        return enemyHealth;
    }


    private void EnemyState(string animationState, float endValue)
    {
        if (!isDead)
        {
            burstSign.transform.DOScale(endValue, 0.15f);
            animator.CrossFade(animationState, 0.1f, 0);
        }
    }
}

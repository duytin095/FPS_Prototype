using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;

    [SerializeField] private float enemyHealth; // 
    [SerializeField] private float maxDistance; // Khoang cach xa nhat ma ke dich co the phat hien ra nguoi choi
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
            EnemyState("Dying", false);
            isDead = true;
            Destroy(this.gameObject, 7);
        }


        if (player)
        {
            var dist = Vector3.Distance(player.transform.position, transform.position);

            if(dist > maxDistance)
            {
                EnemyState("Breathing Idle", false);
            }
            else
            {
                EnemyState("Aiming", true);
            }
        }


    }

    public float LostHealth(float value)
    {
        enemyHealth -= value;
        return enemyHealth;
    }


    private void EnemyState(string animationState, bool isBurst)
    {
        if (!isDead)
        {
            burstSign.SetActive(isBurst);
            animator.CrossFade(animationState, 0.1f, 0);
        }
    }
}

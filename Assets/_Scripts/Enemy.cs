using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;

    [SerializeField] private float enemyHealth; // Enemy health, if this number <= 0 so enemy "Death"
    [SerializeField] private float maxDistance; // Max distance that enemy is able to see player
    [SerializeField] private float gunMaxDistance; // Max distance that enemy is able to see player
    [SerializeField] private float damageDeal; // Damage deal to player
    [SerializeField] private float coolDown;
    [SerializeField] private float coolDownLap = 4;
    [SerializeField] private bool isDead = false;

    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem muzzleEffect;
    [SerializeField] private GameObject burstSign; // Burst sign when enemy see player
    [SerializeField] private GameObject player; 
    [SerializeField] private Transform lookAtPos; // Looking position on player
    [SerializeField] private Transform aimingPos; // Aiming position on gun



    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lookAtPos = GameObject.FindGameObjectWithTag("LookAtPos").transform;
    }

    void Update()
    {
        
        coolDown -= Time.deltaTime; // Cool down time allow enemy to shooting

        if (enemyHealth <= 0)
        {
            EnemyState("Dying", 0);
            isDead = true;
            Destroy(gameObject, 7);
        }

        
        if (player)
        {
            var dist = Vector3.Distance(player.transform.position, transform.position);

            if(dist > maxDistance)
            {
                EnemyState("Breathing Idle", 0);
                coolDown = 0; // Reset cool down time allow enemy to shoot instantly if it see player again
            }
            else
            {
                EnemyState("Aiming", 1);
                

                if (!isDead)
                {
                    transform.LookAt(lookAtPos); // Make gameobject look at target (player)
                    //** Lock gameobject's rotation on x and z axis
                    Vector3 rot = Quaternion.LookRotation(lookAtPos.position - transform.position).eulerAngles;
                    rot.x = rot.z = 0;
                    transform.rotation = Quaternion.Euler(rot);
                    //**

                    if (coolDown <= 0)
                    {
                        ShootPlayer();
                    }
                }
            }
        }


    }

    public float LostHealth(float value)
    {
        enemyHealth -= value;
        transform.DOShakePosition(0.2f, 0.1f, 1);
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

    private void ShootPlayer()
    {
        
        RaycastHit raycastHit;
        Ray rayHit = new Ray(aimingPos.position, aimingPos.forward);
        if (Physics.Raycast(rayHit, out raycastHit, gunMaxDistance))
        {
            if (raycastHit.transform.CompareTag("Player"))
            {
                //** Do shoot animtion
                muzzleEffect.Play();
                //**
                SoundManager.Instance.EnemyShoot();
                Player.Instance.LostHealth(damageDeal);  // Damage to player
                coolDown = coolDownLap;
                
            }
        }
       
    }


}

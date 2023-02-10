using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource weaponPickUp, ammoPickUp, firstAidKitPickUp, shoot, hurt, surprise, empty, enemyShoot, shellHit; 
    [SerializeField] private AudioSource[] shellHitGround; 
    private void Awake()
    {
        Instance = this;
    }
    
    public void WeaponPickUp()
    {
        weaponPickUp.Play();
    }
    public void AmmoPickUp()
    {
        ammoPickUp.Play();
    }
    public void FirstAidKitPickUp()
    {
        firstAidKitPickUp.Play();
    }
    public void Shoot()
    {
        shoot.Play();
    }
    public void EmptyAmmo()
    {
        empty.Play();
    }
    public void Hurt()
    {
        hurt.Play();
    }
    public void Surprise()
    {
        surprise.Play();
    }
    public void EnemyShoot()
    {
        enemyShoot.Play();
    }

    public void ShellHitGround()
    {
        var randomVal = Random.Range(0, 3);
        shellHit.Play();
    }

}

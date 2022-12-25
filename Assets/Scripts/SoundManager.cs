using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource weaponPickUp, ammoPickUp, firstAidKitPickUp, shoot, hurt, surprise; 
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
    public void Hurt()
    {
        hurt.Play();
    }
    public void Surprise()
    {
        surprise.Play();
    }



}

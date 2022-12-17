using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private bool isShoot = true;
    [SerializeField] private ParticleSystem muzzleEffect;
    
    public void Shoot()
    {
        if (isShoot)
        {
            _anim.CrossFade("Pistol Trigger", 0, 0);
            isShoot = false;
            muzzleEffect.Play();
            StartCoroutine("ResetTrigger");
        }

    }
    IEnumerator ResetTrigger() // Back to Idel animation and start count cool down
    {
        yield return new WaitForSeconds(0.2f);
        _anim.CrossFade("Pistol Idle", 0, 0);
        isShoot = true;
    }
}

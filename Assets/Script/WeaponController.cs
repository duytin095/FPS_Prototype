using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private bool isShoot = true;
    [SerializeField] private ParticleSystem muzzleEffect;
    [SerializeField] private Transform gunMouth;
    [SerializeField] private float maxDistance;
    
    public void Shoot()
    {
        if (isShoot && AmmoHandle.Instance.ammoValue > 0)
        {
            _anim.CrossFade("Pistol Trigger", 0, 0);
            isShoot = false;
            muzzleEffect.Play();
            StartCoroutine("ResetTrigger");
            AmmoHandle.Instance.LostAmmo(1);


            RaycastHit hit;
            Ray hitRay = new Ray(gunMouth.position, gunMouth.transform.forward);

            if (Physics.Raycast(hitRay, out hit))
            {
                Debug.Log(hit.transform.name);
            }
        }

    }
    IEnumerator ResetTrigger() // Back to Idle animation and start count cool down
    {
        yield return new WaitForSeconds(0.2f);
        _anim.CrossFade("Pistol Idle", 0, 0);
        isShoot = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(gunMouth.position, gunMouth.transform.forward);
    }
}

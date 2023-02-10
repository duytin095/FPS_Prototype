using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private bool isShoot = true;

    [SerializeField] private Camera cam;
    [SerializeField] private float maxDistance;

    [Header("VFX")]
    [SerializeField] private ParticleSystem muzzleEffect;

    [SerializeField] private Shell shellPrefabs;
    [SerializeField] private ObjectPool<Shell> pool;

    private void Start()
    {
        pool = new ObjectPool<Shell>(() =>
        {
            return Instantiate(shellPrefabs);
        }, shell =>
        {
            shell.gameObject.SetActive(true);
        }, shell =>
        {
            shell.gameObject.SetActive(false);
        }, shell =>
        {
            Destroy(shell.gameObject);
        }, false, 100, 120);
    }

    public void Shoot()
    {
        if (isShoot && AmmoHandle.Instance.ammoValue > 0)
        {
            var shell = pool.Get();
            Instantiate(shell, new Vector3(0, 2, 0), Quaternion.identity);
            _anim.CrossFade("Pistol Trigger", 0, 0);
            isShoot = false;
            muzzleEffect.Play();
            StartCoroutine("ResetTrigger");
            AmmoHandle.Instance.LostAmmo(1);
            SoundManager.Instance.Shoot();

            // Track what bullet hit
            RaycastHit hit;
            Ray hitRay = new Ray(cam.transform.position, cam.transform.forward);
            if (Physics.Raycast(hitRay, out hit, maxDistance))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    //Enemy.Instance.LostHealth(3);
                    hit.transform.GetComponent<Enemy>().LostHealth(3);
                }
            }
        }
        if (isShoot && AmmoHandle.Instance.ammoValue <= 0)
        {
            SoundManager.Instance.EmptyAmmo();
            isShoot = false;
            StartCoroutine("ResetTrigger");
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
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward );
    }
}

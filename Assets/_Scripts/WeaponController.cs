using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using DG.Tweening;

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
    [SerializeField] private Transform shellOutPos;
    [SerializeField] private float shellForce;

    private void Start()
    {
        // Create shell pool
        pool = new ObjectPool<Shell>(() =>
        {
            return Instantiate(shellPrefabs, shellOutPos.position, Quaternion.identity);
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
            // Manage shell
            var shell = pool.Get();
            shell.GetComponent<Rigidbody>().AddForce(shellOutPos.transform.up * shellForce);
            shell.GetComponent<Rigidbody>().AddTorque(Vector3.left * shellForce);


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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 0)
        {
            SoundManager.Instance.ShellHitGround();
            Destroy(gameObject, 5f);
        }
    }

}

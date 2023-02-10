using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditHandle : MonoBehaviour
{
    [SerializeField]
    private float speed = 30;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}

using UnityEngine;
using System.Collections;
using DG.Tweening;

public class UIScale : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOScale(Vector3.one, 0.5f);

    }
    private void OnDisable()
    {
        ResetScale();
    }

    private void ResetScale()
    {
        transform.localScale = Vector3.zero;
    }
}

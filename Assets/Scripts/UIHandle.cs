using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class UIHandle : MonoBehaviour
{
    [SerializeField] private Text nameOfStuff;
    [SerializeField] private Text ammoValueText;
    [SerializeField] private Text heathValueText;


    public static UIHandle Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        nameOfStuff.text = "";
        nameOfStuff.transform.localScale = Vector3.zero;
    }

    public void UpdateAmmoValue(int ammoValue)
    {
        ammoValueText.text = "Ammo: " + ammoValue;
    }


    public void UpdatePlayerHeath(float heathValue)
    {
        heathValueText.text = "Heath: " + heathValue;
    }

    public void DisplayPickUpStuffName(string name)
    {
        nameOfStuff.text = name;
        nameOfStuff.gameObject.transform.DOScale(1, 0.7f);
        StartCoroutine("Deactive", nameOfStuff);
    }

    IEnumerator Deactive(Text stuffName)
    {
        yield return new WaitForSeconds(3f);
        stuffName.text = "";
        stuffName.transform.localScale = Vector3.zero;
    }
}

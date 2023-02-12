using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class UIHandle : MonoBehaviour
{
    private float defaultHeath = 100;
    private int defaultAmmo = 0;

    [SerializeField] private Text nameOfStuff;
    [SerializeField] private Text ammoValueText;
    [SerializeField] private Text heathValueText;
    

    [Space(20)]
    [Header("TIME")]

    [SerializeField] private Text hour;
    [SerializeField] private Text minute;
    [SerializeField] private float hourValue;
    [SerializeField] private float minuteValue;
    [SerializeField] private float secondValue;



    [SerializeField] private GameObject pausePanel;

    [SerializeField] private Image redFlash;
    [SerializeField] private float alphaVal;

    



    public static UIHandle Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
        }

        hour.text = hourValue.ToString("00"); // Defautl hour at start
        minute.text = minuteValue.ToString("00"); // Defautl minute at start

        nameOfStuff.transform.localScale = Vector3.zero; // Make sure this object does not show up when it doesn't need

        UpdatePlayerHeath(defaultHeath); // Defautl player's heath
        UpdateAmmoValue(defaultAmmo); // Defautl player's ammo
    }
    private void Update()
    {
        secondValue += Time.deltaTime;
        if(secondValue >= 59)
        {
            secondValue = 0; // Reset seccond value
            minuteValue++;
            minute.text = minuteValue.ToString("00");
            
        }
        if (minuteValue >= 59)
        {
            minuteValue = 0; // Reset minute value
            hourValue++;
            hour.text = hourValue.ToString("00");
        }
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
        if (nameOfStuff.gameObject.transform.localScale != Vector3.zero)
        {
            nameOfStuff.gameObject.transform.localScale = Vector3.zero;
        }

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

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GetHitScreen()
    {
        var temp = redFlash.color; // make it become a variable so we can modify it (I dunno why?)
        temp.a = alphaVal;

        redFlash.color = temp;
    }

}

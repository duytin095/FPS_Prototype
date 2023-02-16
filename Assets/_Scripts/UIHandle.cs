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
    [SerializeField] private Slider healthBar;
    

    [Space(20)]
    [Header("TIME")]

    [SerializeField] private Text minute;
    [SerializeField] private Text second;
    [SerializeField] private float minuteValue;
    [SerializeField] private float secondValue;



    [SerializeField] private GameObject pausePanel;
    [SerializeField] private bool isPause = false;

    [SerializeField] private Image redFlash;
    [SerializeField] private float alphaVal;


    float currentVelocity = 0;
    [SerializeField] private float healthChangeSpeed;

    



    public static UIHandle Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        

        minute.text = minuteValue.ToString("00"); // Defautl minute at start on scene
        second.text = secondValue.ToString("00"); // Defautl second at start on scene

        nameOfStuff.transform.localScale = Vector3.zero; // Make sure this object does not show up when it doesn't need

        UpdatePlayerHeath(defaultHeath); // Defautl player's heath
        UpdateAmmoValue(defaultAmmo); // Defautl player's ammo
    }
    private void Update()
    {
        secondValue += Time.deltaTime;
        second.text = secondValue.ToString("00"); //Update second value on scene
        if(secondValue >= 59)
        {
            secondValue = 0; // Reset second value
            minuteValue++;
            minute.text = minuteValue.ToString("00"); //Update second value on scene

        }

        UpdatePlayerHeath(Player.Instance.heath);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }

    }
    public void UpdateAmmoValue(int ammoValue)
    {
        ammoValueText.text = ""+ammoValue;
    }


    public void UpdatePlayerHeath(float heathValue)
    {
        //healthBar.value = heathValue;
        float currentHealth = Mathf.SmoothDamp(healthBar.value, heathValue, ref currentVelocity, healthChangeSpeed * Time.deltaTime);
        healthBar.value = currentHealth;
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
        isPause = true;
        Debug.Log("Pause");
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        isPause = false;
        Debug.Log("Continue");
        Time.timeScale = 1;
    }

    public void GetHitScreen()
    {
        ModifyAlphaColor(alphaVal); // turn on red flash
        StartCoroutine(nameof(ResetRedFlash)); // turn off red flash
    }

    IEnumerator ResetRedFlash()
    {
        yield return new WaitForSeconds(0.1f);
        ModifyAlphaColor(0); // change image's alpha value to 0 so the red flash disappear
    }


    public void ModifyAlphaColor(float value)
    {
        var temp = redFlash.color; // make it become a variable so we can modify it (I dunno why?)
        temp.a = value;
        redFlash.color = temp;
    }
}

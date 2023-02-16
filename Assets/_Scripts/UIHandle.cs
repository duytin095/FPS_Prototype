using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;
using StarterAssets;

public class UIHandle : MonoBehaviour
{
    private float defaultHeath = 100;
    private int defaultAmmo = 0;

    [SerializeField] private Text nameOfStuff, ammoValueText;
    [SerializeField] private Slider healthBar;
    

    [Space(20)]
    [Header("TIME")]

    [SerializeField] private Text minute;
    [SerializeField] private Text second;
    [SerializeField] private float minuteValue;
    [SerializeField] private float secondValue;


    [Space(20)]
    [Header("PANEL")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject overPanel;
    [SerializeField] private GameObject resultPanel;

    [Space(20)]
    [Header("RESULT PANEL")]
    [SerializeField] private Text executed;
    [SerializeField] private Text score;
    [SerializeField] private Text time;


    [Space(20)]
    public bool isPause = false;
    public bool isOver = false;

    [SerializeField] private Image redFlash;
    [SerializeField] private Image avatar;
    [SerializeField] private Sprite ok, notOK, danger, dead;
    [SerializeField] private float alphaVal;


    float currentVelocity = 0;
    [SerializeField] private float healthChangeSpeed;

    [SerializeField] private GameObject playerCapsule;



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
        if (!isOver)
        {
            secondValue += Time.deltaTime;
            second.text = secondValue.ToString("00"); //Update second value on scene
            if (secondValue >= 59)
            {
                secondValue = 0; // Reset second value
                minuteValue++;
                minute.text = minuteValue.ToString("00"); //Update second value on scene

            }
        }

        


        if (Input.GetKeyDown(KeyCode.Escape) && !isOver) // Press ESC to open or close Pause Menu
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

        if (isPause) // if the game IS PAUSED, check keyboard input to manage the game
        {
            if (Input.GetKeyDown(KeyCode.M)) // press M = click "Main Menu" button on scene (but you actually can't click the buton on scene)
            {
                BackToMainMenu();
                ContinueGame();
            }
            if (Input.GetKeyDown(KeyCode.S)) // press S = click "Setting" button on scene (but you actually can't click the buton on scene)
            {
                Setting();
            }
        }
        if (isOver) // if the game IS OVER, check keyboard input to manage the game
        {
            if (Input.GetKeyDown(KeyCode.R)) // press R = click "Restart" button on scene (but you actually can't click the buton on scene)
            {
                Restart();
            }
            if (Input.GetKeyDown(KeyCode.M)) // press M = click "Main Menu" button on scene (but you actually can't click the buton on scene)
            {
                BackToMainMenu();
                ContinueGame();
            }

        }

        UpdatePlayerHeath(Player.Instance.heath);
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
        AvatarChanger(heathValue);
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
        Time.timeScale = 0;
        playerCapsule.GetComponent<FirstPersonController>().enabled = false; // Disable rotate camera when the game is paused
    }
    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        isPause = false;
        Time.timeScale = 1;
        playerCapsule.GetComponent<FirstPersonController>().enabled = true; // Give back normal control for player when the game is paused
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 0;
        isOver = false;
    }

    public void GameOver(GameObject player)
    {
        isOver = true;
        overPanel.SetActive(true);
        player.SetActive(false); 
        
    }
    public void ResultBoard()
    {
        resultPanel.SetActive(true);
        Time.timeScale = 0;
        isOver = true;
        isPause = true; //this is for make sure player can shoot when the level is end

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Setting()
    {

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

    public void AvatarChanger(float heal)
    {
        if(heal <= 100 && heal >= 50)
        {
            avatar.sprite = ok;
        }else if(heal <= 50 && heal > 30)
        {
            avatar.sprite = notOK;
        }else if(heal <= 30 && heal > 0)
        {
            avatar.sprite = danger;
        }
        else
        {
            avatar.sprite = dead;
        }
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandle : MonoBehaviour
{

    [SerializeField] private GameObject mainPanel, mainTitle, selectStatePanel, selectStateTitle, loadingScreen;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private float outPos; // position to move OUT center the scene
    [SerializeField] private float inPos; // position to move INTO center the scene

    private void Start()
    {
        Cursor.visible = true;
    }
    public void Play()
    {
        LoadScene("Level1");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

#else
        Application.Quit(); //original code to quit Unity player
#endif
    }


    public void SelectState()
    {
        MovingX(outPos, mainPanel);
        MovingX(outPos, mainTitle);

        MovingX(inPos, selectStatePanel);
        MovingX(inPos, selectStateTitle);

    }
    public void BackToMain()
    {
        MovingX(inPos, mainPanel);
        MovingX(inPos, mainTitle);


        MovingX(outPos, selectStatePanel);
        MovingX(outPos, selectStateTitle);

    }

    private void MovingX(float targetPos, GameObject gameObject)
    {
        gameObject.GetComponent<RectTransform>().DOLocalMoveX(targetPos, 0.7f, true);
    }

    public void LoadScene(string name)
    {
        StartCoroutine(LoadSceneAsync(name));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progressValue;
            yield return null;
        }
    }


}

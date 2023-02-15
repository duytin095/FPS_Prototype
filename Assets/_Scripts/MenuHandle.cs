using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandle : MonoBehaviour
{

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject selectStatePanel;
    [SerializeField] private float targetPosMainPanel;
    [SerializeField] private float targetPosStatePanel;
    public void Play()
    {
        SceneManager.LoadScene("Level1");
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
        mainPanel.GetComponent<RectTransform>().DOMoveX(targetPosMainPanel, 0.7f, true);
        selectStatePanel.GetComponent<RectTransform>().DOLocalMoveX(targetPosStatePanel, 0.7f, true);
    }
}

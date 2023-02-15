using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandle : MonoBehaviour
{

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject mainTitle;
    [SerializeField] private GameObject selectStatePanel;
    [SerializeField] private GameObject selectStateTitle;
    [SerializeField] private float outPos; // position to move OUT center the scene
    [SerializeField] private float inPos; // position to move INTO center the scene
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
        mainPanel.GetComponent<RectTransform>().DOLocalMoveX(outPos, 0.7f, true);
        mainTitle.GetComponent<RectTransform>().DOLocalMoveX(outPos, 0.7f, true);


        selectStatePanel.GetComponent<RectTransform>().DOLocalMoveX(inPos, 0.7f, true);
        selectStateTitle.GetComponent<RectTransform>().DOLocalMoveX(inPos, 0.7f, true);
    }
    public void BackToMain()
    {
        mainPanel.GetComponent<RectTransform>().DOLocalMoveX(inPos, 0.7f, true);
        mainTitle.GetComponent<RectTransform>().DOLocalMoveX(inPos, 0.7f, true);


        selectStatePanel.GetComponent<RectTransform>().DOLocalMoveX(outPos, 0.7f, true);
        selectStateTitle.GetComponent<RectTransform>().DOLocalMoveX(outPos, 0.7f, true);
    }
}

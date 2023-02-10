using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Changescene(string name)
    {
        SceneManager.LoadScene(name);
    }

} 

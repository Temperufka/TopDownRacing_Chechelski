using UnityEngine.SceneManagement;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    public static GUIController instance;

    [SerializeField] private GameObject[] GUIPanels;

    private int currentScene = 0;
    private int currentPanel = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SetTimeScale(1);
    }

    public void NextLevel()
    {
    
        if (currentScene < SceneManager.sceneCountInBuildSettings-1)
        {
            currentScene += 1;
            SceneManager.LoadScene(currentScene);
        }
        else
            SceneManager.LoadScene(0);
    }

    public void OpenNextPanel()
    {
        if (currentPanel < GUIPanels.Length)
        {
            GUIPanels[currentPanel].SetActive(false);
            currentPanel++;
            GUIPanels[currentPanel].SetActive(true);
        }
    }

    public void OpenPreviousPanel()
    {
        if (currentPanel > 0)
        {
            GUIPanels[currentPanel].SetActive(false);
            currentPanel--;
            GUIPanels[currentPanel].SetActive(true);
        }
    }

    public void OpenPanelByIndex(int index)
    {
        currentPanel = index;
        GUIPanels[index].SetActive(true);
    }

    public void DisablePanelByIndex(int index)
    {
        GUIPanels[index].SetActive(false);
        currentPanel = 0;
    }

    public void OpenSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void OnSettingsButton()
    {
        OpenPanelByIndex(3);
        SetTimeScale(0);
    }

    public void OnResumeButton()
    {
        DisablePanelByIndex(currentPanel);
        SetTimeScale(1);
    }


    private void SetTimeScale(float timeScale) => Time.timeScale = timeScale;
}

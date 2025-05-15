using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public string gameSceneName;
    public string gameScenePath;

    public Button resumeButton;

    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        resumeButton.onClick.AddListener(Resume);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameSceneName);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameScenePath);
    }
}

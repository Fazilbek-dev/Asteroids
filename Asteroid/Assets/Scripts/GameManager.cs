using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerShipController _player;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _mouseCotrollerText;
    [SerializeField] private Health _healthScore;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _bestScore;
    [SerializeField] private GameObject _settings;



    private void Awake()
    {
        PlayerPrefs.SetInt("MouseOn", 1);
        _scoreText.text = "Score: 0";
        _healthText.text = "Health: 0";
    }

    private void Update()
    {
        PlayerPrefs.SetInt("BestScore", Score._score);

        if(PlayerPrefs.GetInt("Score") >= PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", Score._score);
        }

        _scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
        _healthText.text = "Health: " + _healthScore._health;
    }

    public void BackGame()
    {
        Time.timeScale = 1f;
        _player.enabled = true;
        _menu.SetActive(false);
    }

    public void Respawn()
    {
        this.transform.position = Vector3.zero;
    }

    public void MainBest()
    {
        _menu.SetActive(false);
        _bestScore.SetActive(true);
        _scoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore");
    }
    public void MainBack()
    {
        _menu.SetActive(true);
        _bestScore.SetActive(false);
        _settings.SetActive(false);
    }

    public void MenuSettings()
    {
        _menu.SetActive(false);
        _settings.SetActive(true);
    }

    public void MouseControllerON()
    {
        if(PlayerPrefs.GetInt("MouseOn") >= 1)
        {
            PlayerPrefs.SetInt("MouseOn", 0);
            _mouseCotrollerText.text = "OFF";
        }
        else
        {
            PlayerPrefs.SetInt("MouseOn", 1);
            _mouseCotrollerText.text = "ON";
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void MenuNewGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        enabled = true;
        Score._score = 0;
    }

    public void NewGame()
    {
        Time.timeScale = 1f;
        enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

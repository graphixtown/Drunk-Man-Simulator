using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _QuitButton;

    private void Awake()
    {
        _playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Level1");
        });
        _QuitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    public void CallLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}

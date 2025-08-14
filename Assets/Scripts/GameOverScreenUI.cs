using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public void Restart()
    {
        SceneManager.LoadScene(1);
        GameManager.instance.StartGame();
    }

    void Start()
    {
        scoreText.text = $"{GameManager.instance.nickname}'s score is {GameManager.instance.score}";
    }
}

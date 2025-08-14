using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreenUI : MonoBehaviour
{
    public void GoToMain(string nickname)
    {
        SceneManager.LoadScene(1);
        GameManager.instance.nickname = nickname;
        GameManager.instance.StartGame();
    }
}

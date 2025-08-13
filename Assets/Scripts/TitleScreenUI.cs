using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreenUI : MonoBehaviour
{
    public void GoToMain()
    {
        SceneManager.LoadScene(1);
    }
}

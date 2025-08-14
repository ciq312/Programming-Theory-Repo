using TMPro;
using UnityEngine;

public class MainScreenUI : MonoBehaviour
{
    public TMP_Text scoreText;
    
    public void UpdateScoreText()
    {
        scoreText.text = $"Score: {GameManager.instance.score}";
    }
}

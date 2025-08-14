using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string nickname;
    
    public bool gameIsProccessing;

    [SerializeField] public int score {get; private set;}

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
            Destroy(gameObject);
    }

    public void StartGame()
    {
        score = 0;
        UpdateScore(score);
        gameIsProccessing = true;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
    
    
}

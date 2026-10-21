using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int lives = 5;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public void AddLives(int value)
    {
        // Se va sumando el valor
        lives += value;
        // Si vidas son menor o igual a 0 el jugador pierde
        if (lives <=0)
        {
            livesText.text = "Lives: " + lives;
            // Se establece en valor en cero para evitar puntajes en negativo
            lives = 0;
        }

        livesText.text = "Lives: " + lives;
    }

    public void AddScore(int value)
    {
        // Se va sumando el valor
        score += value;
        scoreText.text = "Score: " + score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager1 : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static Vector2 lastCheckPointPosition = new Vector2(-9,-3);
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;


    private void Awake()
    {
        //numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins");// Isso salva aquantidade de moedas, ativar nos scripts PlayerManager1 e Coins
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPosition;
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = numberOfCoins.ToString();
        
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

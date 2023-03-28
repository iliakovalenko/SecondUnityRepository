using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int playerHealth;   
    public static bool gameOver;
    public TextMeshProUGUI playerHealthText;
    public GameObject redOverlay;
    public GameObject deathScreen;
   


    void Start()
    {
        playerHealth = 100;       
        gameOver = false;
    }


    void Update()
    {
       
        playerHealthText.text = "" + playerHealth;
        if (gameOver)
        {
            SceneManager.LoadScene("SampleScene" + deathScreen );
        } 
        else if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "SampleScene")
        {
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }    
        
        


    }



    public IEnumerator Damage(int damageCount)
    {
        redOverlay.SetActive(true);
        playerHealth -= damageCount;
        if (playerHealth <= 0)
        {

            gameOver = true;
            deathScreen.SetActive(true);

        }       
        
            yield return new WaitForSeconds(.5f);
            redOverlay.SetActive(false);       
                                
    }   
                            
}

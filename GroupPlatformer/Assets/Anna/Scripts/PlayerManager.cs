using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    //declare two variables one max and one current health
    public int currentHealth;
    public int maxHealth;

    PlayerMovement playerMovement;
    public int coinCount;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            PauseGame();
        }
    }
    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Currency":
                coinCount++;
                return true;
            case "speed+":
                playerMovement.SpeedPowerUp();
                return true;

            default:
                Debug.Log("no tag or reference is set for this game object");
                return false;
        }

    }

    public void TakeDamage()
    {
        currentHealth -= 1;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }



}

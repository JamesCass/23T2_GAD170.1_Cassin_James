using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    //Base enemy variables 
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int healthIncreasePerLevel = 2;
    [SerializeField] private int currentHealth;
    [SerializeField] private int level;
    
  
    //Decided the enemy level randomly between 1,21 and increases the enemy health based on their level - base being 100.
    private void Start()
    {
        level = Random.Range(1, 21);
        currentHealth = maxHealth + (level - 1) * healthIncreasePerLevel;
    }


    //Allows the enemy to take damage from the player based on the players attack. Also debugs how much damage was recieved as well as the enemy health remaining.
    //Checks also if the enemy has less that 0 health that they are dead.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy recieved " + damage + " damage from the player. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            die();
        }

    }

  
    //Takes place when an enemy dies. Rewards the player with a random ammount of experience points and debugs how much they recieved.
    //Also calls for a new enemy to respawn when the last one is defeated. 
    public void die()
    {
        int experience = Random.Range(25, 61);
        Debug.Log("Enemy Defeated! Gained " + experience + " experience points.");
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();
        player.GainExperience(experience);

        Respawn();
    }

 
    //check to see if the enemy is dead. Is used by the player in the DealDamage to check if a new enemy needs to be resapawned. 
    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    
    //Respawns a new enemy with a random level between 1,21 and debugs to the player that a new enemy has respawned.
    //Specifies the level and health of the new enemy to the player.
    public void Respawn()
    {
        level = Random.Range(1, 21);
        currentHealth = maxHealth + (level - 1) * healthIncreasePerLevel;
        Debug.Log("A new enemy has arrived! Level: " + level + " Health: " + currentHealth);
    }

}

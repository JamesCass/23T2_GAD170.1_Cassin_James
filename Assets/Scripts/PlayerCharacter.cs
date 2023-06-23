using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerCharacter : MonoBehaviour
{
    //basic player variables. Includes base stats 
    [SerializeField] private float attack = 10f;
    [SerializeField] private int experience = 0;
    [SerializeField] private float LevelUpThreshold = 100f;
    [SerializeField] private int level = 1;

    //Detects if the player is pressing the space key to attack the enemy
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DealDamageToEnemy();
        }

    }
  

    //A method for dealing damage to the enemy based on the players current attack value.
    //Also checks if the enemy is dead in order to respawn another one. 
    private void DealDamageToEnemy()
    {
        EnemyCharacter enemy = FindObjectOfType<EnemyCharacter>();
        enemy.TakeDamage(Mathf.RoundToInt(attack));


        if (enemy.IsDead())
        {
            enemy.Respawn();

        }
    }
   

    //A method allowing for the player to level up when their exeperience meets the threshold.
    public void GainExperience(int amount)
    {
        experience += amount;

        if (experience >= LevelUpThreshold)
        {
            LevelUp();
           
        }
    }
  

    //A Method that specifies what happens when the player levels up.
    //The player gains more attack and the threshold for the next level is increased.
    //Also debugs to  the player that they have leveled up and specifies the increase in their attack as well as prompting the player to press space to continue. 
    //Also checks if the player has reached level 5 and if so will debug Game Over and that the player has won the game. 
    private void LevelUp()
    {
        Debug.Log("Level up! You are now " + level + " level. Press space to confirm!");
        if (Input.GetKeyDown(KeyCode.Space))

            
        level++;
        float previousAttack = attack;
        attack *= 1.25f;
        LevelUpThreshold *= 1.25f;
        experience = 0;

        if (level >= 5)
        {
            Debug.Log("Game Over, You win!");
        }
        else
        {
            Debug.Log("Attack increased from " + previousAttack + " to " + attack);
        }
    }

}

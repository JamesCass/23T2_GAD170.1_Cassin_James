using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int attack = 10;
    [SerializeField] private int level = 1;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space));
        {
            Debug.Log("Player has hit spacebar");
            level++;
        }

        if (level == 5) ;
    }
}

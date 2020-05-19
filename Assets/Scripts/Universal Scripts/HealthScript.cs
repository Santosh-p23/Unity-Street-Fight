using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript: MonoBehaviour
{
    public float health = 100f;

    private CharacterAnimations animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;

    public bool is_Player;

    private HealthUI health_UI;


    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimations>();

        if(is_Player)
            health_UI = GetComponent<HealthUI>();
    }
   
    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;

        health -= damage;
       
      

        if(health <= 0)
        {
            animationScript.Death();
            characterDied = true;

            if (is_Player)
            {
                health_UI.DisplayHealth(health);
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
            }
            return;
        }

         else if (!is_Player)
        {
            if (knockDown)
            {
                if(Random.Range(0,2) > 0)
                {
                    animationScript.KnockDown();
                }

                else
                {
                    if(Random.Range(0,3) > 1)
                    {
                        animationScript.Hit();
                    }
                }
            }

            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    animationScript.Hit();
                }
            }
        }
    }
}

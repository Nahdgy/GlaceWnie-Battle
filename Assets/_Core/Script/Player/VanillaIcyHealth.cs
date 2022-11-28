using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanillaIcyHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 3;
    [SerializeField]
    public int currentHealth;
    [SerializeField]
    public HealthBar healthBar;

    [SerializeField]
    public bool isInvisible = false;
    [SerializeField]
    public SpriteRenderer coloring;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.H))
        {

            TakeDamage(1);
        }
        
    }

    public void TakeDamage(int damage)
    
    
    { 
        if(!isInvisible)
        {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        }

        

    }
public void InvicibilityFlash()
    {
       while(isInvisible)
       {
          coloring.color = new Color(192f,0f,38f,255f);
          coloring.color = new Color(192f, 120f, 38f, 255f);
       }

    }
}

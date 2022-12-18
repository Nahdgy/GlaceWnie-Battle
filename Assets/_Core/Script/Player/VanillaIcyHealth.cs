using JetBrains.Annotations;
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
    public float invicibilityFlashDelay = 0.05f;
    [SerializeField]
    public float invicibilyTimer;
    [SerializeField]
    public bool isInvisible = false;

    [SerializeField]
    public SpriteRenderer coloring;

    public static VanillaIcyHealth instance;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.H))
        {

            TakeDamagePlayer(1);
        }
        
    }

    public void TakeDamagePlayer(int damage)
    
    
    { 
        if(!isInvisible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if(currentHealth <= 0)
            {
                Die();
                return;
            }
            isInvisible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(InvicibilityTimer());
        }

        

    }
    public void Die()
    {
        PlayerControllerVanillaIcy.instance.enabled = false;
        PlayerControllerVanillaIcy.instance.animator.SetTrigger("Die");
        PlayerControllerVanillaIcy.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerControllerVanillaIcy.instance.vanillaIcyCollider.enabled = false;
        StartMenu.instance.VanillaGameEnd();
    }

    public void HealPlayer(int amount)
    {
        if((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        
        healthBar.SetHealth(currentHealth);
    }


public IEnumerator InvicibilityFlash()
    {
       while(isInvisible)
       {
          coloring.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
          coloring.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }

    }
public IEnumerator InvicibilityTimer()
    {
        yield return new WaitForSeconds(invicibilyTimer);
        isInvisible = false;
    }
}

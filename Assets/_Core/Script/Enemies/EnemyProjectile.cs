using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D projectilerRb;
    [SerializeField]
    private float shootForce;

    [SerializeField]
    private int projectileDamage = 1;

    [SerializeField]
    private float destroytimer;

    [SerializeField]
    private int playerC = 0;
    [SerializeField]
    private int ground = 6;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        projectilerRb = GetComponent<Rigidbody2D>();
        //Apply a force to this Rigidbody in direction of this GameObjects up axis
        projectilerRb.AddForce(transform.right * -1 * shootForce);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        VanillaIcyHealth player = collision.GetComponent<VanillaIcyHealth>();
      
        if (collision.transform.CompareTag("VanillaIcy"))
        {
            player.TakeDamagePlayer(projectileDamage);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == ground)
        {
            Destroy(gameObject);
        }
    }
}

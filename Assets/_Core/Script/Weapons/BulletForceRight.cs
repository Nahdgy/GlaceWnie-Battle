using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForceRight : MonoBehaviour
{
    [SerializeField]
    private Rigidbody BulletRigidbody;
    
    public float shootForce = 720f;

    [SerializeField]
    private int bulletDammage = 1;

    [SerializeField]
    private PlayerControllerVanillaIcy position;


    void Start()
    {

        //Fetch the Rigidbody from the GameObject with this script attached
        BulletRigidbody = GetComponent<Rigidbody>();
        //Apply a force to this Rigidbody in direction of this GameObjects up axis
        BulletRigidbody.AddForce(transform.right * shootForce);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController _enemy = collision.GetComponent<EnemyController>();
        if (_enemy != null)
        {
            _enemy.TakeDammage(bulletDammage);
        }
    }
}

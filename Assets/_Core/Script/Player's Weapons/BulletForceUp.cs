using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForceUp : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D BulletRigidbody;

    public float shootForce = 720f;

    [SerializeField]
    private int roof = 9;

    [SerializeField]
    private int bulletDammage = 1;

    [SerializeField]
    private float destroytimer;

    void Start()
    {

        //Fetch the Rigidbody from the GameObject with this script attached
        BulletRigidbody = GetComponent<Rigidbody2D>();
        //Apply a force to this Rigidbody in direction of this GameObjects up axis
        BulletRigidbody.AddForce(transform.up * shootForce);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController _enemy = collision.GetComponent<EnemyController>();
        Debug.Log("collision");
        if (collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("in IF");
            _enemy.TakeDamageEnemy(bulletDammage);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == roof)
        {
            StartCoroutine(Suppression());
        }

    }
    private IEnumerator Suppression()
    {
        yield return new WaitForSeconds(destroytimer);
        Destroy(gameObject);
    }
}

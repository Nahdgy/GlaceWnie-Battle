using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed;
    public Transform[] Waypoint;
    private Transform target;
    private int destPoint;

    [SerializeField]
    private int Health;
    
    void Start()
    {
        target = Waypoint[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % Waypoint.Length;
            target = Waypoint[destPoint];
        }
        if (Input.GetKeyDown(KeyCode.J))
        {

            TakeDammage(1);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("VanillaIcy"))
        {
            VanillaIcyHealth health = collision.transform.GetComponent<VanillaIcyHealth>();
            health.TakeDamage(1);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    public void TakeDammage(int _dammage)
    {
        Health -= _dammage;
        if (Health <= 0) Die();
    }

    private void ShootIce(GameObject bullet, Transform shootPosition)
    {
        Instantiate(bullet, shootPosition.position, Quaternion.identity);

    }


}
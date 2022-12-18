using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Speed"), Space(5)]

    public float _speed;
    public Transform[] Waypoint;
    private Transform target;
    private int destPoint;

    [SerializeField]
    private int _health;

    public float Speed { get { return _speed; } 
        private set {
            _speed = (value > 0) ? value : 0; } 
    }

    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private GameObject portal;
    [SerializeField]
    private Transform shootPosition;
   

    [SerializeField, Header("Timer settings")]
    private float beginTime;
    [SerializeField]
    private float countDown;
    [SerializeField]
    private bool canCount = true;
    [SerializeField]
    bool doOnce;


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
            TakeDamageEnemy(1);
        }
        TimeToCount();
        Shoot();
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("VanillaIcy"))
        {
            VanillaIcyHealth health = collision.transform.GetComponent<VanillaIcyHealth>();
            health.TakeDamagePlayer(1);
            
        }
    }
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("IsInstance");
            Instantiate(projectile, shootPosition.position, Quaternion.identity);
        }

    }
    void TimeToCount()
    {
        if (countDown >= 0.0f && canCount)
        {
            countDown -= Time.deltaTime;
        }
        else if (countDown <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            countDown = 0.0f;
            Debug.Log("IsInstance");
            Instantiate(projectile, shootPosition.position, Quaternion.identity);
            ResetTimer();
        }
        
    }
    void ResetTimer()
    {
        countDown = beginTime;
        canCount = true;
        doOnce = false;
        
    }
    private void PortalActive()
    {
        portal.SetActive(true);
    }

    void Die()
    {
        PortalActive();
        Destroy(gameObject);
    }

    public void TakeDamageEnemy(int _damage)
    {
        _health -= _damage;
        if (_health <= 0)
        {
            Die();
        }
    }
}
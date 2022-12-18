using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private GameObject otherPortal;
    [SerializeField]
    private GameObject ennemy;
    [SerializeField]
    private GameObject portal;

    public bool IsActive = false;
    private void OnTriggerEnter2D(Collider2D _collider)
    {
        if (_collider.CompareTag("VanillaIcy") && otherPortal.GetComponent<Portal>().IsActive)
        {
            Rigidbody2D _rigidbody = _collider.GetComponent<Rigidbody2D>();
            Vector3 _exitVelocity = otherPortal.transform.forward * _rigidbody.velocity.magnitude;
            _rigidbody.velocity = _exitVelocity;
            _collider.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 5;
        }
        if (_collider.CompareTag("VanillaIcy"))
        {
            ennemy.SetActive(true);  
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForceUp : MonoBehaviour
{
    Rigidbody BulletRigidbody;
    public float shootForce = 720f;
    PlayerControllerVanillaIcy position;

    void Start()
    {

        //Fetch the Rigidbody from the GameObject with this script attached
        BulletRigidbody = GetComponent<Rigidbody>();
        //Apply a force to this Rigidbody in direction of this GameObjects up axis
        BulletRigidbody.AddForce(transform.up * shootForce);
        
    }
}

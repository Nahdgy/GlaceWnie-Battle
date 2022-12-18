using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    //[SerializeField]
    //Camera _camera;

    [SerializeField]
    Rigidbody2D playerRigidBody2D;

    //[SerializeField]
    //GameObject playerRigidBody2DPrefab;

    [SerializeField]
    Transform PlayerTarget;

    [SerializeField, Range(0f, 5f)]
    float moveSpeed = 2f;

    [SerializeField]
    private float speed = 0;

    [SerializeField, Range(0f, 0.1f)]
    float smoothSpeed = 0.05f;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    float transformPosition;
    private void Start()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        Vector3 _desiredPosition = new Vector3(PlayerTarget.position.x + offset.x, PlayerTarget.position.y + offset.y, -2 - offset.z);
        Vector3 _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, smoothSpeed);
        transform.position = _smoothedPosition;
    }
}

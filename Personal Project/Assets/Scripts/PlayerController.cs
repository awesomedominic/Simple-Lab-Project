using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10.0f;
    private Rigidbody _playerRb;
    private float _zBound = 6;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

        void MovePlayer()
        {
            // Makes Player move according to arrow keys
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            _playerRb.AddForce(Vector3.forward * Speed * verticalInput);
            _playerRb.AddForce(Vector3.right * Speed * horizontalInput);
        }

        void ConstrainPlayerPosition()
        {
            // Keeps the Player within boundaries
            if (transform.position.z < -_zBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -_zBound);
            }

            if (transform.position.z > _zBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, _zBound);
            }
        }
}

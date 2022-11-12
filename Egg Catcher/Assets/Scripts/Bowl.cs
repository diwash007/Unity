using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if (move > 0.2 || move < -0.2)
            transform.position += new Vector3(move * movementSpeed * Time.deltaTime, 0, 0);
        transform.rotation = Quaternion.identity;
    }
}

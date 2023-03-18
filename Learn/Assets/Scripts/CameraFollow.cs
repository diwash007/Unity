using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    PlayerController target;
    [SerializeField]
    private float followSpeed;
    public float yOffset = 2f;
    public float xOffset = 5f;

    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.transform.position.x + xOffset * target.direction, target.transform.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime); 
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    PlayerController target;
    [SerializeField]
    private float followSpeed;
    public float xOffset = 2f;
    public float yOffset = 2f;
    private Vector3 cameraPos;

    private void Start()
    {
        cameraPos.y = transform.position.y + yOffset;
    }
    private void LateUpdate()
    {
        if (target.direction > 0)
        {
            cameraPos = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x + xOffset, transform.position.y), Time.deltaTime * followSpeed);
        }
        else if (target.direction < 0)
        {
            cameraPos = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x - xOffset, transform.position.y), Time.deltaTime * followSpeed);
        }
        else
        {
            cameraPos = Vector2.MoveTowards(transform.position, transform.position, Time.deltaTime * followSpeed);
        }
        cameraPos.z = -10f;

        if (target.transform.position.x > -4.5f)
            transform.position = cameraPos;
    }
}

using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    public Vector3 moveOffset;
    private Vector3 targetPos;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the target position.
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Did we reach the target position?
        if (transform.position == targetPos)

        {
            // Ping pong between startPos and startPos + moveOffset.
            if (targetPos == startPos)
            {
                targetPos = startPos + moveOffset;
            }
            else
            {
                targetPos = startPos;
            }
        }
    }
}

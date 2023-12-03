using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    Transform startPoint;
    Transform endPoint;
    GameObject platform;

    public int direction { get; private set; }
    [SerializeField] float speed = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        startPoint = transform.Find("Start");
        endPoint = transform.Find("End");
        platform = transform.Find("Platform").gameObject;
    }

    Vector2 currentTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    // Update is called once per framex
    void FixedUpdate()
    {
        Vector2 target = currentTarget();

        platform.transform.position = Vector2.Lerp(platform.transform.position, target, speed);

        float distance = (target - (Vector2)platform.transform.position).magnitude;

        if (distance < 0.1f) 
        {
            direction *= -1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    Transform startPoint;
    Transform endPoint;
    GameObject platform;

    public int direction { get; private set; }
    float speed = 0;

    [SerializeField] float UpSpeed = 0.03f;
    [SerializeField] float DownSpeed = 0.03f;

    bool switchState;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        startPoint = transform.Find("Start");
        endPoint = transform.Find("End");
        platform = transform.Find("Platform").gameObject;
        switchState = false;
        speed = DownSpeed;
    }

    // Update is called once per framex
    void FixedUpdate()
    {
        Vector2 target;
        switchState = GetComponentInChildren<SwitchController>().isActive;
        if(switchState)
        {
            target = (Vector2)endPoint.position;
        }
        else
        {
            target = (Vector2)startPoint.position;
        }
        platform.transform.position = Vector2.MoveTowards(platform.transform.position, target, speed);

        float distance = (target - (Vector2)platform.transform.position).magnitude;

        if (target == (Vector2)startPoint.position && distance <= 0.1)
        {
            speed = 0;
        }
        else if (target == (Vector2)startPoint.position)
        {
            speed = DownSpeed;
        }
        else if(target == (Vector2)endPoint.position)
        {
            speed = UpSpeed;
        }
    }
}

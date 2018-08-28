using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float g = 9.8f;

    public Vector3 targetPos;
    public float speed = 10;
    private float verticalSpeed;
    private Vector3 moveDirection;

    private float angleSpeed;
    private float angle;
    void Start()
    {
        float tmepDistance = Vector3.Distance(transform.position, targetPos);
        float tempTime = tmepDistance / speed;
        float riseTime, downTime;
        riseTime = downTime = tempTime / 2;
        verticalSpeed = g * riseTime;
        transform.LookAt(targetPos);

        float tempTan = verticalSpeed / speed;
        double hu = Mathf.Atan(tempTan);
        angle = (float)(180 / Mathf.PI * hu);
        transform.eulerAngles = new Vector3(0, 0, -angle);
        angleSpeed = angle / riseTime;

        moveDirection = targetPos - transform.position;
    }
    private float time;
    void Update()
    {
        if (transform.position.y < targetPos.y)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        time += Time.deltaTime;
        float test = verticalSpeed - g * time;
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * test * Time.deltaTime, Space.World);
        float testAngle = -angle + angleSpeed * time;
        transform.eulerAngles = new Vector3(0, 0, testAngle);
    }
}
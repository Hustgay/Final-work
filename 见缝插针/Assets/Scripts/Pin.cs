using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float speed = 5;
    private bool isFly = false;
    private bool isReach = false;
    private Transform startPoint;
    private Vector3 targetCirclePos;
    private Transform circle;


	
	void Start () {
        startPoint = GameObject.Find("StartPoint").transform;
        circle = GameObject.FindGameObjectWithTag("Circle").transform;
        targetCirclePos = circle.position;
        targetCirclePos.y -= 1.55f;
        
    }

    void Update ()
    {
        if (isFly == false) //针从生成位置移动到启动位置
        {
            if (isReach == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, startPoint.position) < 0.05f)
                {
                    isReach = true;
                }
            }
        }
        else
        {   //针从启动位置移动到大球位置
            transform.position = Vector3.MoveTowards(transform.position, targetCirclePos, speed * Time.deltaTime);
            if(Vector3.Distance( transform.position,targetCirclePos) < 0.05f)
            {
                transform.position = targetCirclePos;
                transform.parent = circle;
                isFly = false;
            }
        }
	}

    public void StartFly()
    {
        isFly = true;
        isReach = true;
    }
}

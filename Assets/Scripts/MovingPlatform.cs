using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;
    public int _currentWayPointIndex = 0;



    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length > 0)
        {
            Vector2 targetposition = waypoints[_currentWayPointIndex].position;
            transform.position = Vector2.MoveTowards(transform.position, targetposition, speed * Time.deltaTime);     
            
            if (Vector2.Distance(transform.position, targetposition) < 0.1f)
            {
                _currentWayPointIndex  = (_currentWayPointIndex + 1) % waypoints.Length;
            }
        }
        }
         
    }


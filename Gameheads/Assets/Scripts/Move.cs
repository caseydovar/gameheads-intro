using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentSpeed = Vector3.zero; //very general so can be applied to all

        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentSpeed.z = -speed.z;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentSpeed.z = speed.z;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentSpeed.x = -speed.x;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentSpeed.x = speed.x;
        }

        if (Input.GetKey(KeyCode.LeftBracket))
        {
            currentSpeed.y = speed.y;
        }

        if (Input.GetKey(KeyCode.RightBracket))
        {
            currentSpeed.y = -speed.y;
        }

        gameObject.transform.Translate(currentSpeed);
    }
}
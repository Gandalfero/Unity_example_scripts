using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float movementSpeed;
    [SerializeField]
    float normalMovementSpeed;
    [SerializeField]
    float fastMovementSpeed;
    [SerializeField]
    float movementTime;
    [SerializeField]
    float borderXMin;
    [SerializeField]
    float borderXMax;
    [SerializeField]
    float borderYMin;
    [SerializeField]
    float borderYMax;
    float  zoom;
    [SerializeField]
    Camera ortographicCamera;


    public Vector3 newPosition;
    void Start()
    {
        newPosition = transform.position;
    }

   
    void Update()
    {
        zoom = ortographicCamera.orthographicSize;
        CameraHandler();
    }
    void CameraHandler()
    { if (((newPosition.y < borderYMax) && (newPosition.y > borderYMin)) && ((newPosition.x < borderXMax) && (newPosition.x > borderXMin)))
           
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    movementSpeed = fastMovementSpeed;
                }
                else
                {
                    movementSpeed = normalMovementSpeed;
                }
                if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow)))
                {
                    newPosition += (transform.up * movementSpeed);
                }
                if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow)))
                {
                    newPosition += (-transform.up * movementSpeed);
                }
                if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
                {
                    newPosition += (transform.right * movementSpeed);
                }
                if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
                {
                    newPosition += (-transform.right * movementSpeed);
                }

                transform.position = Vector3.Lerp(transform.position, newPosition, movementTime * Time.deltaTime);

            if ((zoom >= 1) && (zoom <= 5))
            {
                if (Input.GetKeyDown(KeyCode.KeypadMinus))
                {
                    if (zoom < 5)
                    {
                        ortographicCamera.orthographicSize += 1;
                    }
                }
                if (Input.GetKeyDown(KeyCode.KeypadPlus))
                {
                    if (zoom > 1)
                    {
                        ortographicCamera.orthographicSize -= 1;
                    }
                }
            } 
         
        }
        
    else
        {
            if (newPosition.y > borderYMax)
            {
                newPosition.y -= 2;
            }
            if (newPosition.y < borderYMin)
            {
                newPosition.y += 2;
            }
            if (newPosition.x > borderXMax)
            {
                newPosition.x -= 2;
            }
            if (newPosition.x < borderXMin)
            {
                newPosition.x += 2;
            }
        }
    }
}

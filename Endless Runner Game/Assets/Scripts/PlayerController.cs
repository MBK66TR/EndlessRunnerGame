using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController characterController;
    private Vector3 direction;
    public int speed;

    private int lane = 1;// 0:left 1:mid 2:left
    public float lanedistance = 4; //lane distance

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = speed;



        // left right Move input
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            lane++;
            if(lane == 3)
            {
                lane= 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lane--;
            if (lane == -1)
            {
                lane = 0;
            }
        }

        //calculate where in future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y* transform.up;

        if (lane == 0)
        {
            targetPosition += Vector3.left * lanedistance;
        }else if (lane == 2)
        {
            targetPosition += Vector3.right * lanedistance;
        }


        transform.position = targetPosition;// lerp kullanabilirim duruma göre
    }

    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }
}

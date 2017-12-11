using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    // Use this for initialization
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float speedYCamera = 5.0F;
    public float speedXCamera = 5.0F;

    public Camera cameraT;

    public AudioSource sourceWalk;
    
    

    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }

        

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        Turning();

        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !sourceWalk.isPlaying)
        {
            //Debug.LogWarning("PLay son");
            sourceWalk.Play();
        }
        else if ((Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0))
        {
            sourceWalk.Stop();
        }
    }

    void Turning()
    {
        float h = speedXCamera * Input.GetAxis("Mouse X");
        float v = speedYCamera * Input.GetAxis("Mouse Y");
        /*
        if (h == 0 && v == 0)
        {
            h = speedXCamera * Input.GetAxis("JoyD X");
            v = speedYCamera * Input.GetAxis("JoyD Y");
        }*/
        

        
        cameraT.transform.Rotate(-v, 0, 0);
        transform.Rotate(0, h, 0);
    }
}

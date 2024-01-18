using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMove : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    Rigidbody rb;
    public float speed = 10f;
    public float rotateSpeed = 10f;
    ChangeColor colorChange;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        colorChange = GetComponent<ChangeColor>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * verticalMove * speed);
        if (verticalMove>0)
        {
            transform.Rotate(Vector3.up * rotateSpeed * horizontalMove * 2 * Time.deltaTime);
        }
        if (verticalMove < 0)
        {
            transform.Rotate(Vector3.up * -rotateSpeed * horizontalMove * 2 * Time.deltaTime);

        }
        if(transform.position.y<-2)
        {
            transform.position = new Vector3(0, 0.5f, 0);
        }
        
    }
    public void increaseScale()
    {
        transform.localScale *= 1.4f;
        rb.mass = 5;
        speed *= 5;
        //change texture as well
        colorChange.changePlayerColor();
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            
        }
    }
}

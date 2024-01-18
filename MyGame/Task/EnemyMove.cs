using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody enemyRB;
    BugMove player;
    public UIScore score;
    public float enemySpeed = 10f;
    public static float point =1;
    public float time=0f;
    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<BugMove>();
        //score = GameObject.Find("Canvas").GetComponent<UIScore>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * enemySpeed);
        if (start)
        {
            Invoke("timer", 3);
            start = false;
        }
        
        

    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            start = true;
        }
    }
    void timer()
    {
        if (transform.position.y < -2)
        {
            score.incrementScore(point);
            player.increaseScale();
            Destroy(gameObject);
        }
    }

}



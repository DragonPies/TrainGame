using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public GameObject point1,player;
    public Rigidbody rb;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveTrain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveTrain()
    {
        //float distance = Vector3.Distance(transform.position, point1.transform.position);
        //float t = distance / speed;
        while(transform.position.x != point1.transform.position.x)
        rb.linearVelocity = new Vector3(speed, 0, 0);
        if (player != null)
        {
            player.GetComponent<Rigidbody>().linearVelocity = new Vector3(speed, 0, 0);
        }
    }

    
}

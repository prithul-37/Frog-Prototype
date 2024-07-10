using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float change = .05f;
    private float dir = 1;
    private Rigidbody rb;
    private FixedJoint joint;
    private bool once = true;

    public int id;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {   if (transform.position.x > 3.9)
        {
            dir = -1;
        }
        else if (transform.position.x < -3.9)
        {
            dir = 1;
        }
        else
        {

        }
        
        rb.position = new Vector3(transform.position.x +  change * dir, transform.position.y,transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && once) 
        {
            //dir = 0;
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.rigidbody;
            joint.breakForce = 100;
            joint.breakTorque = 100;
            once = false;
            var playerDrag = collision.gameObject.GetComponent<ClickEvent>();
            playerDrag.Shooted += removeJoint;
            gameObject.GetComponent<Animator>().SetTrigger("PlayerJumpedOn");
            GeneratePlatform.tileCount--;
            //Debug.Log(GeneratePlatform.tileCount);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.tag == "Player") dir = 1;
    }

    void removeJoint()
    {
        Destroy(joint);
    }
}

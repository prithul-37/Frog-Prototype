using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private float speed = .05f;
    private float dir;
    private Rigidbody rb;
    private FixedJoint joint;
    private bool once = true;
    private int doMove = 0;

    public int id;
    public bool activeCoin;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = Random.Range(-2, 2);
        dir = (dir < 0) ? -1 : 1;
        var lvlManager = GameObject.FindGameObjectWithTag("LevelManager")?.GetComponent<LevelManager>();
        if (lvlManager != null && lvlManager.iMovePlatform) 
        { 
            doMove = 1;
            speed = lvlManager.speedOfPlatforms;
        }
        transform.GetChild(1).gameObject.SetActive(activeCoin);

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
        
        rb.position = new Vector3(transform.position.x +  speed * dir * doMove, transform.position.y,transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && once) 
        {
            //Joint Creation
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.rigidbody;
            once = false;

            //Destroy Joint Menually
            var playerDrag = collision.gameObject.GetComponent<ClickEvent>();
            playerDrag.Shooted += removeJoint;
            gameObject.GetComponent<Animator>().SetTrigger("PlayerJumpedOn");

        }
    }

    private void OnCollisionExit(Collision collision)
    {
       
    }

    void removeJoint()
    {
        Destroy(joint);
    }
}

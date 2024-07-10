using UnityEngine;

public class ObstacleMovement1 : MonoBehaviour
{

    private float speed = 10;
    private float direction = 1;
    private Rigidbody rb;
    private Vector3 moveDirVector = Vector3.zero;
    public bool X, Y, Z;

    private float xTh,yTh,zTh;

    private float iX,iY,iZ;//initial pos

    void Start()
    {   
        iX = transform.position.x;
        iY = transform.position.y;
        iZ = transform.position.z;

        rb = GetComponent<Rigidbody>();
        var lvlManager = GameObject.FindGameObjectWithTag("LevelManager")?.GetComponent<LevelManager>();
        if (lvlManager != null)
        {
            xTh = lvlManager.xTh;
            yTh = lvlManager.yTh;
            zTh = lvlManager.zTh;
            if (lvlManager.iEnableObstacles)
            {
                if (lvlManager.iMoveObstale) 
                {
                    moveDirVector = new Vector3(X? 1 : 0, Y ? 1 : 0, Z ? 1 : 0);
                    speed = lvlManager.speedOfObstale;
                    moveDirVector *= speed;
                }
            } 
            else gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (X)
        {
            if (iX - transform.position.x > xTh)
            {
                direction = 1;
            }
            else if (iX - transform.position.x < -xTh)
            {
                direction = -1;
            }
        }
        else if(Y)
        {
            if (iY - transform.position.y > yTh)
            {
            direction = 1;
            }
            else if (iY -  transform.position.y < 4.5f)
            {
            direction = -1;
            }
        }

        else
        {
            if (iZ - transform.position.z > zTh)
            {
                direction = 1;
            }
            else if (iZ - transform.position.z < -zTh)
            {
                direction = -1;
            }
        }
        rb.position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + moveDirVector* direction;
    }

}

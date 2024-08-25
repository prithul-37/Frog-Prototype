using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerDrag : MonoBehaviour
{
    

    private Vector3 mPos1;
    private Vector3 mPos2;
    private bool isDrag = false;

    public int lineSegments = 20;
    public GameObject pointObj;
    public float force;

    Rigidbody rb;

    //Trajectory Draw area

    //private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>(); 
    private List<GameObject> pointHolder = new List<GameObject>();
    private float HowManyToShow = 20;
    private Vector3 forceVector = Vector3.zero;
    private float mass;

    bool once = true; // it prevent gound checking more than once after lanfing..!

    public int MaxJump = 1;
    private int JumpLeft;

    //Ripple Effect
    public GameObject rippleEffect;


    void Start()
    {
        //lineRenderer = GetComponent<LineRenderer>();
        mass = GetComponent<Rigidbody>().mass;
        rb = GetComponent<Rigidbody>();
        JumpLeft = MaxJump;
    }


    private void FixedUpdate()
    {
        //Debug.Log(JumpLeft);

        if (isDrag)
        {
            drawTrajectory();
        }
    }

    private void OnMouseDown()
    {
        if (JumpLeft > 0)
        {
            mPos1 = Input.mousePosition;
            isDrag = true;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true; 
        }
        
        
    }

    private void OnMouseUp()
    {
        if (JumpLeft > 0)
        {
            mPos2 = Input.mousePosition;
            isDrag = false;
            foreach (GameObject go in pointHolder)
            {
                Destroy(go);
            }
            if(mPos1 != Vector3.zero && mPos2 != Vector3.zero)
                shoot(mPos1 - mPos2);

            mPos1 = Vector3.zero;
            mPos2 = Vector3.zero;
        }
        
        
    }

    void shoot(Vector2 dir)
    {
        rb.isKinematic = false;
        rb.AddForce(new Vector3(dir.x,dir.y,dir.y)* force, ForceMode.Impulse);
        JumpLeft--;
        Invoke("HasJumped",.1f);
    }

    void drawTrajectory()
    {
        foreach (GameObject go in pointHolder) {
            Destroy(go);
        }

        var dir = Input.mousePosition - mPos1;
        forceVector = new Vector3(dir.x,dir.y, dir.y) * force;
        //Debug.Log($"forceVector:{forceVector}");

        Vector3 Velocity = (forceVector/mass);
        float flightDuration = (2 * Velocity.y) / Physics.gravity.y;
        float stepTime = flightDuration / lineSegments;
        points.Clear();
        pointHolder.Clear();

        //Debug.Log($"Velocity:{Velocity}");
        //Debug.Log($"flightDuration{flightDuration}");
        //Debug.Log($"step time{stepTime}");

        int h = 0;
        for (float i = 0f; i <= lineSegments; i++) {
            float passedTime = stepTime * i;
            Vector3 moveVector = new Vector3(Velocity.x * passedTime,
                                             Velocity.y * passedTime - 0.5f * Physics.gravity.y * passedTime * passedTime,
                                             Velocity.z * passedTime);
            //Debug.Log(moveVector);
            h++;
            if (h < HowManyToShow) {
                GameObject obj = Instantiate(pointObj, -moveVector + transform.position, Quaternion.identity);
                pointHolder.Add(obj);
            }
            

            points.Add(-moveVector + transform.position);
        }
        //lineRenderer.positionCount = lineSegments;
        //lineRenderer.SetPositions(points.ToArray());
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(once)
        {
            if (collision.gameObject.tag == "Platform")
            {
                rb.velocity = Vector3.zero;
                JumpLeft = MaxJump;
                once = false;
            }
        }

    }


    IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void HasJumped()
    {
        once = true;
    }

    public void GetExtraJump() 
    {
        JumpLeft++;
    }
}

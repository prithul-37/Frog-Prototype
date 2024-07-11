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


    //Trajectory Draw area
    //private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>(); 
    private List<GameObject> pointHolder = new List<GameObject>();
    private float HowManyToShow = 20;
    private Vector3 forceVector = Vector3.zero;
    private float mass;
    private float gravity;
    private bool once = true;
    private bool onGround;

    //Ripple Effect
    public GameObject rippleEffect;


    void Start()
    {
        //lineRenderer = GetComponent<LineRenderer>();
        mass = GetComponent<Rigidbody>().mass;
        gravity = Physics.gravity.y;
        onGround = true;
    }


    private void FixedUpdate()
    {
        if (isDrag)
        {
            drawTrajectory();
        }
    }

    private void OnMouseDown()
    {
        if (onGround)
        {
            mPos1 = Input.mousePosition;
            isDrag = true;
        }
        
        
    }

    private void OnMouseUp()
    {
        if (onGround)
        {
            mPos2 = Input.mousePosition;
            isDrag = false;
            foreach (GameObject go in pointHolder)
            {
                Destroy(go);
            }
            shoot(mPos1 - mPos2);
        }
        
        
    }

    void shoot(Vector2 dir)
    {   
        once = true;
        onGround = false;
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(dir.x,dir.y,dir.y)* force, ForceMode.Impulse);
        
    }

    void drawTrajectory()
    {
        foreach (GameObject go in pointHolder) {
            Destroy(go);
        }

        //Debug.Log("INNN");
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
        if (once)
        {
            if (collision.gameObject.tag == "Platform")
            {
                StartCoroutine(stopMotion());
                once = false;
            }
        }

    }

    IEnumerator stopMotion()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        yield return null;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        onGround = true;
    }

    IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

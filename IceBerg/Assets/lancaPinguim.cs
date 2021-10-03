using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class lancaPinguim : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Rigidbody rb;
    private bool isShoot, CanShoot;
    public bool pode;
    [SerializeField]private float forceMultiplier;
    private GameObject gameController;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnMouseDown()
    {
        if(pode){
            mousePressDownPos = Input.mousePosition;
        }
    }
    private void OnMouseDrag(){
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, z: forceInit.y))*forceMultiplier;

        if(!isShoot){
            if(transform.position.z < 0 &&forceInit.y >0){
                CanShoot = true;
                DrawTrajectory.Instance.UpdateLine(forceV, rb, transform.position);
            }else if(transform.position.z > 0 &&forceInit.y <0){
                CanShoot = true;
                DrawTrajectory.Instance.UpdateLine(forceV, rb, transform.position);
            }else{
                DrawTrajectory.Instance.HideLine();
                CanShoot = false;
            }
        }
    }

    private void OnMouseUp()
    {
        if(CanShoot){
            DrawTrajectory.Instance.HideLine();
            if(pode){
                mouseReleasePos = Input.mousePosition;
                Shoot(mouseReleasePos-mousePressDownPos);
            }
        }
    }

    void Shoot(Vector3 Force)
    {
        if(isShoot)    
            return;
        rb.AddForce(new Vector3(Force.x,Force.y,Force.y) * forceMultiplier);
        isShoot = true;
        rb.useGravity = true;
        gameController.GetComponent<GameController>().pinguimLancado();
    }


}

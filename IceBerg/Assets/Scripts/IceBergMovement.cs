using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBergMovement : MonoBehaviour
{
    [SerializeField][Tooltip("Defina a velocidade de giro do Ice Berg")]private float VeloDeGiro;

    private void FixedUpdate(){
        transform.Rotate(0f,VeloDeGiro*Time.deltaTime , 0f);
    }
}

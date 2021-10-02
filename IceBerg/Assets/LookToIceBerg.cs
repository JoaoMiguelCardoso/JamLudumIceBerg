using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToIceBerg : MonoBehaviour
{
    [SerializeField][Tooltip("coloque o iceberg aqui")]private Transform iceberg;
    
    void Start()
    {
        transform.LookAt(iceberg);
    }
}

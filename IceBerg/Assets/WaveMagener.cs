using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMagener : MonoBehaviour
{
    public static WaveMagener instance;

    public float amplitude= 1f;
    public float speed= 2f;
    public float length= 1f;
    public float offset= 0f;

    public void Awake(){
        if(instance == null){
            instance = this;
        }else if(instance != null){
            Destroy(this);
        }
    }

    private void Update(){
        offset+= Time.deltaTime * speed;
    }

    public float GaveWaveHeigth(float x){
        return amplitude * Mathf.Sin(x/length+offset);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lacador : MonoBehaviour
{
    [SerializeField][Tooltip("defina a velocidade de rotação do angulo")]private float RotacaoSpeed;
    [SerializeField][Tooltip("defina os limites para a rotação do angulo; 0 e 1 para o z , 2 e 3 para o y")]private float[] LimitesAngulos;
    [SerializeField][Tooltip("defina os limites da força de lançamento")]private float[] LimintesForca;
    private GameObject Pinguim;
    [SerializeField][Tooltip("coloque o ponto de lançamento dos pinguins")]private Transform ShootPoint;
    [SerializeField][Tooltip("coloque o iceberg aqui")]private Transform Iceberg;
    private GameObject gameController;
    private bool selecionado;
    private float alguloX;
    private void Start(){
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
    private void FixedUpdate(){
        if(selecionado){
            anguloX();
            anguloY();
        }
    }
    private void anguloX(){
        if(transform.rotation.eulerAngles.x < LimitesAngulos[0] && transform.rotation.eulerAngles.x  > LimitesAngulos[1]){
            alguloX = Input.mouseScrollDelta.y * RotacaoSpeed;
            Debug.Log("9>x>-80"+ transform.rotation.eulerAngles.x);
        }else if(transform.rotation.eulerAngles.x  >= LimitesAngulos[0] && Input.mouseScrollDelta.y < 0){
            alguloX = Input.mouseScrollDelta.y * RotacaoSpeed;
            Debug.Log("9<x" + transform.rotation.eulerAngles.x);
        }else if(transform.rotation.eulerAngles.x <= LimitesAngulos[1] && Input.mouseScrollDelta.y > 0){
            alguloX = Input.mouseScrollDelta.y * RotacaoSpeed;
            Debug.Log("x<-80"+ transform.rotation.eulerAngles.x);
        }else{
            alguloX = 0;
        }
        transform.Rotate(new Vector3(alguloX, 0f,0f),Space.Self);
    }

    private void anguloY(){

    }
    private void Forca(){

    }

    private void lanca(){

    }
    public void PinguimSelecionado(){
        Pinguim = gameController.GetComponent<GameController>().pinguim;
        transform.position = Pinguim.transform.position;
        transform.LookAt(Iceberg);
        selecionado = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lacador : MonoBehaviour
{
    [SerializeField][Tooltip("defina a velocidade de rotação do angulo")]private float RotacaoSpeed;
    [SerializeField][Tooltip("defina os limites para a rotação do angulo")]private float LimitesAngulos;
    [SerializeField][Tooltip("defina a variação da força de lançamento")]private float ForcaVari;
    [SerializeField][Tooltip("defina a velocidade variação da força de lançamento")]private float ForcaVelo;
    [SerializeField][Tooltip("coloque os pinguins aqui")]private GameObject[] Pinguins;
    [SerializeField][Tooltip("coloque o ponto de lançamento dos pinguins")]private Transform ShootPoint;
    private bool ShootRodando = true, ForcaIndo= false;
    private float pingpong;

    private void FixedUpdate(){
        pingpong = Mathf.PingPong(Time.time*RotacaoSpeed, LimitesAngulos)+10;
        if(ShootRodando==true){
            ShootPoint.rotation= Quaternion.Euler(0f, 0f , pingpong);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            ShootRodando = false;
            ForcaIndo = true;
        }
    }
}

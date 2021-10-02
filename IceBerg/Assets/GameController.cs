using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera camere;
    public GameObject pinguim;
    public bool pinguimSelecionado;
    private GameObject lacador;

    private void Start(){
        lacador = GameObject.FindGameObjectWithTag("lancador");
    }
    void Update()
    {
        if(pinguimSelecionado== false){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                Raymouse();
            }
        }
    }
    private void Raymouse(){
        Ray ray = camere.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.tag.Equals("pinguim"))
            {
                pinguim = hitInfo.transform.gameObject;
                pinguim.transform.GetChild(0).gameObject.SetActive(true);
                pinguimSelecionado = true;
                StartCoroutine(waitcamera());
            }
        }
    }
    
    private IEnumerator waitcamera(){
        yield return new WaitForSeconds(1f);
        pinguim.transform.GetComponent<lancaPinguim>().pode = true;
    }
    public void pinguimLancado(){
        pinguim.transform.GetChild(0).gameObject.SetActive(false);
        pinguimSelecionado = false;
    }
}

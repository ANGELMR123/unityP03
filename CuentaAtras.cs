using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CuentaAtras : MonoBehaviour
{

    public Button btn;
    public Image img;

    public Text tContador;

    public Sprite[] numeros;

    private int mostrar = 3;

    private bool contar;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(Pulsado);
        contar = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(contar){
            switch(mostrar){
                case 3:
                    Debug.Log("3");
                    img.sprite = numeros[2];
                    tContador.text = "3";
                    break;
                case 2:
                    Debug.Log("2");
                    img.sprite = numeros[1];
                    tContador.text = "2";
                    break;
                case 1:
                    Debug.Log("1");
                    img.sprite = numeros[0];
                    tContador.text = "1";
                    break;
                default:
                    Debug.Log("Saltar a otra escena");
                    SceneManager.LoadScene("segundoNivel");
                    break;
            }
            StartCoroutine(Esperar());
            contar = false;
            mostrar--;
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(1);
        contar = true;
    }

    void Pulsado()
    {
        img.gameObject.SetActive(true);
        tContador.gameObject.SetActive(true);
        btn.gameObject.SetActive(false);
        contar = true;
    }
}

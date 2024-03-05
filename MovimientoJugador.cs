using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public GameObject prefabSuelo;
    public Camera cam;
    public int velocidad;

    private Vector3 offset;
    private float miX, miZ;
    private Rigidbody rb;
    private Vector3 direccionActual;

    // Start is called before the first frame update
    void Start()
    {
        offset = cam.transform.position;
        miX = 0;
        miZ = 0;
        rb = GetComponent<Rigidbody>();
        direccionActual = Vector3.forward;

        SueloInicial();
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = this.transform.position + offset;

        if(Input.GetKeyUp(KeyCode.Space)){
            if(direccionActual == Vector3.forward) direccionActual = Vector3.right;
            else direccionActual = Vector3.forward; 
        }
        float tiempo = velocidad * Time.deltaTime;

        rb.transform.Translate(direccionActual * tiempo);
    }

    void SueloInicial(){
        for(int i = 0; i < 3; i++){
            miZ += 6.0f;
            GameObject elcubo = Instantiate(prefabSuelo, new Vector3(miX, 0, miZ), Quaternion.identity) as GameObject;
        }
    }


    void OnCollisionExit(Collision other) {
    if (other.transform.CompareTag("suelo")) {
        StartCoroutine(CrearSuelo(other));
    }
}

    IEnumerator CrearSuelo(Collision col){
        yield return new WaitForSeconds(0.5f);
        col.rigidbody.isKinematic = false;
        col.rigidbody.useGravity = true;

        yield return new WaitForSeconds(0.5f);

        float ran = Random.Range(0f, 1f);
        if(ran < 0.5f) miX += 6.0f;
        else miZ += 6.0f;
        
        GameObject elcubo = Instantiate(prefabSuelo, new Vector3(miX, 0, miZ), Quaternion.identity) as GameObject;
    }

}

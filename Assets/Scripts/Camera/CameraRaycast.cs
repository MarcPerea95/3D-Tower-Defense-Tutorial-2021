using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public PlayerMovement playerMovement; //esta variable hace referencia al componente playerMovement (el script)
    public LayerMask groundLayer;

    Ray ray; //rayo con punto de origen y dirección que uso para detectar un gameobjects (necesitan tener un componente collider)
    RaycastHit hit; //aquí me guardo la información de choque entre el rayo y el gameobject

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si pulso el botón derecho del rátón
        if (Input.GetMouseButtonDown(1))
        {
            //Camera.main hace referencia a la cámara de la escena que tenga el tag "MainCamera"
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //este if nos devuelve true si el raycast está chocando con un gameobject que tenga un collider y que esté en la capa suelo
            //si no se cumple devuelve un false
            if (Physics.Raycast(ray, out hit, 100, groundLayer))
            {
                playerMovement.posToGo = hit.point;
                playerMovement.Turning(hit.point);
            }
        }
    }
}

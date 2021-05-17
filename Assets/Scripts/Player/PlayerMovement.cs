using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int turnSpeed;
    public Vector3 posToGo;

    Animator anim;
    Quaternion rotation;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        posToGo = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == posToGo)
        {
            anim.SetBool("IsRunning", false);
        }
        else
        {
            anim.SetBool("IsRunning", true);
        }
        transform.position = Vector3.MoveTowards(transform.position, posToGo, speed * Time.deltaTime);
        //esto es para que la rotación sea gradual, que no haga la rotación de golpe
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }
    public void Turning(Vector3 target)
    {
        //vector direction = vector resultante de restar el punto al que quiero ir y el punto del player
        Vector3 direction = target - transform.position;
        //creo una rotación, pasándole el Vector3 de la dirección. Lo que hace es alinear el forward del personaje
        //(es decir, hacia donde está mirando) con el vector que le pasamos (direction)
        rotation = Quaternion.LookRotation(direction);
    }
}

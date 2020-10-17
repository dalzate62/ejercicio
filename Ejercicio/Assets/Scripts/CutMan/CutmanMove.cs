using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutmanMove : MonoBehaviour
{
    [Header("Vision")]
    public float visionRadius;

    //se guarda el jugador
    GameObject Player, Enemy;

    //variable para guardar la pocision inicial
    Vector3 inicialPosicion;
    
    [Header("Movement")]
    public float maxSpeed;
    public float horizontalForce;

    [Header("Physics")]
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //Recuperamos al jugador Gracias al Tag
        Player = GameObject.FindGameObjectWithTag("Player");
        //Guarda Posicion inicial
        inicialPosicion = transform.position;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //nuestro objetivo siempre sera nuestra posicion inicial
        Vector3 target = inicialPosicion;

        //si nuestro objetivo es menor ala distancia del player el player sera nuestro objetivo
        float dist = Vector3.Distance(Player.transform.position, transform.position);

        if (dist < visionRadius)
        {
            target = Player.transform.position;
            float cambio = Player.transform.localScale.x;

            //finalmente movemos al enemigo ala direccion del target
            float fixedSpeed = maxSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
            Enemy.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(ForceDirection(transform.localScale.x) * horizontalForce, ForceMode2D.Force);

        LimitVelocity();
    }

    private void LimitVelocity()
    {
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
    }

    private Vector2 ForceDirection(float sign)
    {
        Vector2 vector;
       if (sign > 0)
            vector = Vector2.left;
        else
            vector = Vector2.right;

        return vector;
    }
}
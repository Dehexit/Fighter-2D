using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{

    // Use this for initialization
    Player jug; 
    AI ia; 

    public virtual void Attack()
    {
        Debug.Log("Ataque de Character");

    }


    void Start()
    {
        jug = new Player();
        ia = new AI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            jug.Attack();
            Debug.Log("A pulsado"); 
        }

        if (Input.GetKey(KeyCode.D))
        {
            ia.Attack();
            Debug.Log("D pulsado");

        }
    }
    
}

public class Player : Characters
{
    public override void Attack()
    {
        Debug.Log("Ataque de Player"); 
    }
}

public class AI : Characters
{
    public override void Attack()
    {
        Debug.Log("Ataque de IA");
    }
}

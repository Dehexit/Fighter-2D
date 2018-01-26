using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public int lives;

    public Attack current_attack;

    // Use this for initialization
    //Player jug; 
    //AI ia; 

    public virtual void DoAttack()
    {
        Debug.Log("Ataque de Character");

    }


    //void Start()
    //{
    //    jug = new Player();
    //    ia = new AI(jug);
    //}
    
}


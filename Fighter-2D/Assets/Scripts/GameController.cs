using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance = null;   //To make GameController a singleton

    private Attack attack;
    private bool gameOver;
    private List<Character> characters;

    public Player player;
    public AI ai;

    // Use this for initialization
    void Awake () {

        //Singleton behaviour
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        characters = new List<Character>(new Character[] { player, ai });
        attack = new Attack();
        gameOver = false;

        //Mover a EndTurn?
        
        while(!gameOver) {

            foreach(Character currentCharacter in characters) {
                currentCharacter.Attack();
            }

            if(CheckWinner() != null)
                gameOver = true;
        }

        //Game end behaviour

    }

    internal static void EndTurn(Character character) {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns winner Character or null
    /// </summary>
    /// <returns></returns>
    public Character CheckWinner() {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update () {
		
	}
}



//Debug.Log(attack.WinsTo(Attack.Attacks.A));
//Debug.Log(attack.WinsTo(Attack.Attacks.B));
//Debug.Log(attack.WinsTo(Attack.Attacks.C));

//Debug.Log(attack.LosesTo(Attack.Attacks.A));
//Debug.Log(attack.LosesTo(Attack.Attacks.B));
//Debug.Log(attack.LosesTo(Attack.Attacks.C));
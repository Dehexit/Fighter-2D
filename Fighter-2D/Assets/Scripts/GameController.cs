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

        ai.initialize(player);

        //Initialise in a menu
        characters = new List<Character>(new Character[] { player, ai });
        attack = new Attack();
        gameOver = false;

        //foreach (Player player in characters)
            StartCoroutine(WaitForInput(player));
        
    }

    private IEnumerator WaitForInput(Player player) {

        Debug.Log("Waiting for input");

        player.current_attack_string = "";

        while(player.current_attack_string == "") {
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("El jugador ha elegido" + player.current_attack_string);
        Turn();
    }

    public void Turn() {

        foreach (Character current in characters) {
            current.DoAttack();
        }

        //Comparar ataques
        if(characters[0].current_attack.WinsTo() == characters[1].current_attack.type) {
            //First character wins round
            Debug.Log("Gana jugador 1");
            characters[1].lives--;
        }else if(characters[0].current_attack.type == characters[1].current_attack.type) {
            //Tie
            Debug.Log("Empate");
        } else  {
            //Second character wins round
            Debug.Log("Gana jugador 2");
            characters[1].lives--;
        }

        if(CheckWinner() != null) {
            gameOver = true;
            Debug.Log("GAME OVER");
        } else {
            StartCoroutine(WaitForInput(player));
        }

    }

    /// <summary>
    /// Returns winner Character or null                ESTÁ MAL!!
    /// </summary>
    /// <returns></returns>
    public Character CheckWinner() {

        if(player.lives <= 0)
            return ai;
        else if(ai.lives <= 0)
            return player;
        else
            return null;


        //foreach(Character character in characters) {
        //    if (character.lives <= 0)
        //}

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
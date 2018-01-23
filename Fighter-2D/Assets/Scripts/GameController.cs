using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance = null;   //To make GameController a singleton

    private Attack attack;
    public string player_attack;
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

        //Initialise in a menu
        characters = new List<Character>(new Character[] { player, ai });
        player_attack = "";
        attack = new Attack();
        gameOver = false;

        StartCoroutine(WaitForInput());
        
    }

    private IEnumerator WaitForInput() {

        player_attack = "";

        while(player_attack == "") {
            yield return new WaitForEndOfFrame();
        }

        Turn();
    }

    public void Turn() {

        foreach (Character current in characters) {
            current.Attack();
        }

        //Comparar ataques
        if(characters[0].current_attack.WinsTo() == characters[1].current_attack.attack) {
            //First character wins round
            characters[0].lives--;
        } else  {
            //Second character wins round
            characters[1].lives--;
        }

        if(CheckWinner() != null)
            gameOver = true;
        else
            StartCoroutine(WaitForInput());

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
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance = null;   //To make GameController a singleton

    private Attack attack;
    private bool gameOver;
    private List<Character> characters;

    public Player player;
    public AI ai;

    public Text p1_lives;
    public Text p2_lives;
    public Text time_text;
    public Text winner_text;
    public Text percentage_guess_element_UI; 

    public float timeOut = 10;
    

    // Use this for initialization
    void Awake () {

        //Singleton behaviour
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        player.initialize();
        ai.initialize(player);

        //Initialise in a menu
        characters = new List<Character>(new Character[] { player, ai });
        attack = new Attack();
        gameOver = false;
        winner_text.enabled = false;
        
        winner_text.text = "EMPTY!";


        //foreach (Player player in characters)
            StartCoroutine(WaitForInput(player));
        
    }

    private IEnumerator WaitForInput(Player player) {

        Debug.Log("Waiting for input");

        player.current_attack_string = "";

        float currentTimeOut = timeOut;

        while(player.current_attack_string == "") {

            currentTimeOut -= .1f;
            time_text.text = Math.Round(currentTimeOut, 3).ToString();

            if(currentTimeOut <= 0) {
                player.current_attack_string = "A";
                break;
            }

            yield return new WaitForSeconds(.1f);
        }
        Debug.Log("El jugador ha elegido" + player.current_attack_string);
        StartCoroutine(Turn());
    }

    public IEnumerator Turn() {

        //Each of the characters attacks
        foreach (Character current in characters) {
            current.GetComponent<Animator>().SetBool("attacked", false);
            current.DoAttack();
            current.GetComponent<Animator>().Play("attack");
        }

        yield return new WaitForSeconds(1.8f); 

        //Compare attack moves
        if(characters[0].current_attack.WinsTo() == characters[1].current_attack.type) {
            //First character wins round
            Debug.Log("Gana jugador 1");
            winner_text.text = "P1";
            characters[1].lives--;
            //characters[1].GetComponent<Animator>().Play("damaged");
            characters[1].GetComponent<Animator>().SetBool("attacked", true);
        } else if(characters[0].current_attack.type == characters[1].current_attack.type) {
            //Tie
            winner_text.text = "DRAW";
            Debug.Log("Empate");
        } else  {
            //Second character wins round
            Debug.Log("Gana jugador 2");
            winner_text.text = "P2";
            characters[0].lives--;
            //characters[0].GetComponent<Animator>().Play("damaged");
            characters[0].GetComponent<Animator>().SetBool("attacked", true);
             
        }

        //Show text during x seconds. 
        //Yield return that lasts x seconds.

        winner_text.enabled = true;
        yield return new WaitForSeconds(1);
        //Hide text when coroutine ends.
        winner_text.enabled = false; 
        
        Character winner = CheckWinner();
        if(winner != null) {
            gameOver = true;
            Debug.Log("GAME OVER");
            if(winner == characters[0]) {
                Debug.Log("PLAYER 1 WINS");
          
            } else {
                Debug.Log("PLAYER 2 WINS");
            }
        } else {
            StartCoroutine(WaitForInput(player));
        }

    }

    /// <summary>
    /// Returns winner Character or null
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

        p1_lives.text = ("VIDAS\n" + characters[0].lives);
        p2_lives.text = ("VIDAS\n" + characters[1].lives);

    }
}



//Debug.Log(attack.WinsTo(Attack.Attacks.A));
//Debug.Log(attack.WinsTo(Attack.Attacks.B));
//Debug.Log(attack.WinsTo(Attack.Attacks.C));

//Debug.Log(attack.LosesTo(Attack.Attacks.A));
//Debug.Log(attack.LosesTo(Attack.Attacks.B));
//Debug.Log(attack.LosesTo(Attack.Attacks.C));
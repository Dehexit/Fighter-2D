using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: Character {

    public string current_attack_string;

    public void initialize() {
        lives = 3;
    }

    public override void DoAttack() {
        Debug.Log("Ataque de Player");
        //StartCoroutine(waitForInput());

        current_attack = new Attack(Attack.stringToAttack(current_attack_string));

    }

    public void setCurrentAttack(string s_attack) {

        current_attack_string = s_attack;
        
    }

}

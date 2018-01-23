using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: Character {

    public string current_attack_string;

    public override void Attack() {
        Debug.Log("Ataque de Player");
        //StartCoroutine(waitForInput());

        switch(current_attack_string) {

            case "attack1":
                current_attack = new Attack(global::Attack.Attacks.A);
                break;
            case "attack2":
                current_attack = new Attack(global::Attack.Attacks.B);
                break;
            case "attack3":
                current_attack = new Attack(global::Attack.Attacks.C);
                break;
            default:
                Debug.Log("Error in attack buttons");
                break;
        }

    }

    public void setCurrentAttack(string s_attack) {

        current_attack_string = s_attack;
        
    }

}

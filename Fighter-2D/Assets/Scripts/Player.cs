using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: Character {

    public override void Attack() {
        Debug.Log("Ataque de Player");
        StartCoroutine(waitForInput());
    }

    private IEnumerator waitForInput() {

        current_attack = null;

        while(current_attack == null) {
            yield return new WaitForEndOfFrame();
        }

        GameController.EndTurn(this);
    }

    public void setCurrentAttack(string s_attack) {

        switch(s_attack) {

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

}

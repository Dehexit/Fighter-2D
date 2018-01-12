using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private Attack attack;

    // Use this for initialization
    void Start () {

        attack = new Attack();

        Debug.Log(attack.WinsTo(Attack.Attacks.A));
        Debug.Log(attack.WinsTo(Attack.Attacks.B));
        Debug.Log(attack.WinsTo(Attack.Attacks.C));

        Debug.Log(attack.LosesTo(Attack.Attacks.A));
        Debug.Log(attack.LosesTo(Attack.Attacks.B));
        Debug.Log(attack.LosesTo(Attack.Attacks.C));

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

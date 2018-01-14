using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack {

    public int num_attacks = 3;

	public enum Attacks {
        A,
        B,
        C
    }
    Attacks attack;

    public Attack() {
    }

    public Attack(Attacks _attack) {
        attack = _attack;
    }

    public Attacks WinsTo(Attacks attack)
    {
        if ((int)attack - 1 == -1)
            return (Attacks)num_attacks - 1;
        else
            return attack - 1;
    }

    public Attacks LosesTo(Attacks attack)
    {
        if ((int)attack + 1 == num_attacks)
            return (Attacks)0;
        else
            return attack + 1;
    }

}

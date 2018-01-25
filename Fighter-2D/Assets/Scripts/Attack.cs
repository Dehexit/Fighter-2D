using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack {

    public int num_attacks = 3;

	public enum AType {
        A,
        B,
        C
    }
    public AType type;

    public Attack() {
    }
    public Attack(AType _attack) {
        type = _attack;
    }

    public AType WinsTo() {
        if((int)type == 0)
            return (AType)num_attacks - 1;
        else
            return type - 1;
    }
    public AType WinsTo(AType attack)
    {
        if ((int)attack == 0)
            return (AType)num_attacks - 1;
        else
            return attack - 1;
    }

    public AType LosesTo() {
        if((int)type + 1 == num_attacks)
            return (AType)0;
        else
            return type + 1;
    }
    public AType LosesTo(AType attack)
    {
        if ((int)attack + 1 == num_attacks)
            return (AType)0;
        else
            return attack + 1;
    }

    public static AType stringToAttack(string s_attack) {

        switch(s_attack) {

            case "A":
                return AType.A;
            case "B":
                return AType.B;
            case "C":
                return AType.C;
            default:
                Debug.Log("Error in attack buttons");
                throw new System.Exception("Error in attack buttons");
        }
    }
    
    //public override string ToString() {

    //    switch(type) {

    //        case AType.A:
    //            return "A";
    //        case AType.B:
    //            return "B";
    //        case AType.C:
    //            return "C";
    //        default:
    //            Debug.Log("Error in attack buttons");
    //            throw new System.Exception("Error in attack buttons");
    //    }
    //}

}

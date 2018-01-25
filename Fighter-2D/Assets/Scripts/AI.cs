using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI: Character {

    public Player player;

    private string opc = "";
    private string totalElecs = "", predictGuess = "", registerGuess = "";
    private int windowSize = 2;
    private int total = 0, rightGuess = 0;

    private Dictionary<string, DataRecord> data;
    private string possibleActions;

    public void initialize(Player player) {
        this.player = player;
        lives = 3;
        data = new Dictionary<string, DataRecord>();
        possibleActions = "ABC";
    }

    public string GetMostLikely(string actions) {
        DataRecord keyData;
        int highestValue = 0;
        char bestAction = ' ';
        if(data.ContainsKey(actions)) {

            keyData = data[actions];
            foreach(char action in keyData.counts.Keys) {
                if(keyData.counts[action] > highestValue) {
                    highestValue = keyData.counts[action];
                    bestAction = action;
                }
            }
        } else {
            bestAction = possibleActions[Random.Range(0,possibleActions.Length)];
        }
        return bestAction.ToString();
    }

    public void RegisterSecuence(string actions) {
        string key = actions.Substring(0, actions.Length - 1);
        char value = actions[actions.Length - 1];

        if(!data.ContainsKey(key)) {
            data[key] = new DataRecord();
        }

        DataRecord keyData = data[key];

        if(!keyData.counts.ContainsKey(value)) {
            keyData.counts[value] = 0;
        }

        keyData.counts[value]++;
        keyData.total++;

    }

    public override void DoAttack() {
        //Debug.Log("Ataque de IA");

        opc = player.current_attack.type.ToString();
        total++;

        string prediction = GetMostLikely(predictGuess);
        Attack guess_attack = new Attack(Attack.stringToAttack(prediction));
        current_attack = new Attack(guess_attack.LosesTo());
        Debug.Log("AI guess: " + prediction + "; AI plays: " + current_attack.type.ToString());

        if (prediction == opc) {
            rightGuess++;
            Debug.Log("AI guessed rigth");
        } else {
            Debug.Log("AI failed guessing");
        }
        Debug.Log("Correct guess rate: " + (100 * (float)rightGuess / total));

        totalElecs += opc;

        if(totalElecs.Length - windowSize < 0) {
            predictGuess += opc;
        } else {
            predictGuess = totalElecs.Substring(totalElecs.Length - windowSize);
        }

        if(totalElecs.Length - windowSize - 1 < 0) {
            registerGuess += opc;
        } else {
            registerGuess = totalElecs.Substring(totalElecs.Length - (windowSize + 1));
            RegisterSecuence(registerGuess);
        }

        Debug.Log("Total guesses: " + totalElecs);
        Debug.Log("Prediction guesses: " + predictGuess);
        Debug.Log("Register guesses: " + registerGuess);
    }
}
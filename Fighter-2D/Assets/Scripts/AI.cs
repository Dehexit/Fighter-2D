using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI: Character {

    private Dictionary<string, DataRecord> data;
    private string possibleActions;

    public AI() {
        data = new Dictionary<string, DataRecord>();
        possibleActions = "";
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

    public override void Attack() {
        Debug.Log("Ataque de IA");
    }
}
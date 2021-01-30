using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "TurbioSO/Texts")]
public class ConversationsSO : ScriptableObject
{
    public RandomPhrases randomPhrases = new RandomPhrases();
}
[System.Serializable]
public class RandomPhrases{
    public List<string> phrases;
    public RandomPhrases(){
        phrases = new List<string>();
        phrases.Add("Más turbio hechale agua");
        phrases.Add("Anda a yorale al virus chaino");
    }
}
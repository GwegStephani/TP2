using System.Collections;
using System.Collections.Generic;

public class TwineLine {

    private ArrayList _phrases;

    public TwineLine() {
        _phrases = new ArrayList();
    }

    public void AddPhrase(TwineLinePhrase phrase) {
        _phrases.Add(phrase);
    }
}

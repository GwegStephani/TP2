using System.Collections;
using System.Collections.Generic;

public class TwineLine {

    private ArrayList phrases;

    public TwineLine() {
        phrases = new ArrayList();
    }

    public void AddPhrase(TwineLinePhrase phrase) {
        phrases.Add(phrase);
    }
}

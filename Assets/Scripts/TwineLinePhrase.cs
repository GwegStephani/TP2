using System.Collections;
using System.Collections.Generic;

public class TwineLinePhrase {
    string text;
    string link;

    public TwineLinePhrase(string text) {
        this.text = text;
    }

    public void AddLink(string link) {
        this.link = link;
    }
}

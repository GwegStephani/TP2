using System.Collections;
using System.Collections.Generic;

public class TwineLinePhrase {
    string _text;
    string _link;

    public TwineLinePhrase(string text) {
        _text = text;
    }

    public void AddLink(string link) {
        _link = link;
    }
}

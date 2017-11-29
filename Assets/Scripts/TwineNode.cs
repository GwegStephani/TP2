using System.Collections;
using System.Collections.Generic;

public class TwineNode {

    private string title;
    private string tags;
    private ArrayList lines;

    public TwineNode(string title) {
        lines = new ArrayList();

        // set the title
        this.title = title;
    }

    public void AddLine(TwineLine line) {
        lines.Add(line);
    }
}

using System.Collections;
using System.Collections.Generic;

public class TwineStory {

    ArrayList twineNodes;

    public TwineStory() {
        twineNodes = new ArrayList();
    }

    public void AddNode(TwineNode node) {
        twineNodes.Add(node);
    }
}

using System.Collections;
using System.Collections.Generic;

public class TwineStory {

    private ArrayList _twineNodes;

    public TwineStory() {
        _twineNodes = new ArrayList();
    }

    public void AddNode(TwineNode node) {
        _twineNodes.Add(node);
    }

	public ArrayList getNodes() {
		return _twineNodes;
	}
}

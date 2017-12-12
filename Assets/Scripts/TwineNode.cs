using System.Collections;
using System.Collections.Generic;

public class TwineNode {

    private string _title;
    private string _tags;
    private ArrayList _lines;

    public TwineNode(string title) {
        _lines = new ArrayList();

        // set the title
        _title = title;
    }

    public void AddLine(TwineLine line) {
        _lines.Add(line);
    }


	public string title {
		get {
			return _title;
		}
	}
}

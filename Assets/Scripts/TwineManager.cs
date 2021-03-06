﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwineManager : MonoBehaviour {

    private static string TWINE_KEY_WORD_STORY_TITLE = ":: StoryTitle";
    private static string TWINE_KEY_WORD_USER_SCRIPT = ":: UserScript[script]";
    private static string TWINE_KEY_WORD_USER_STYLESHEET = ":: UserStylesheet[stylesheet]";

	private string[] _twineStories = {"sample_twine_file"};
    private TwineStory _tempStory = null;
    private TwineNode _tempNode = null;


	private Dictionary<string, TwineStory> _loadedStories = new Dictionary<string, TwineStory>();
	private TwineStory _currentStory = null;
	private TwineNode _currentNode = null;

	// Use this for initialization
	void Start () {
        
		// load all stories
		foreach (string twineStoryID in _twineStories) {
            TwineStory loadedStory = LoadTwineFile(twineStoryID);
            _loadedStories.Add (twineStoryID, loadedStory);
		}

        // TEST
        TwineNode xxx = StartTwine("sample_twine_file");
        int x = 30;
        xxx = ProcessLink("killurself");
        x = 20;
        // TEST END
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	TwineNode StartTwine(string twineID) {
        if (_loadedStories.ContainsKey(twineID)) {
            // set current story
            _currentStory = _loadedStories[twineID];
            
            // get first node and return it
            if (_currentStory.getNodes().Count > 0) {
                _currentNode = _currentStory.getNodes()[0] as TwineNode;
                return _currentNode;
            }
        }

        return null;
    }


    TwineNode ProcessLink(string linkID) {
        if (linkID != null) {
            foreach (TwineNode node in _currentStory.getNodes()) {
                // found match
                if (node.title.Contains (linkID)) {
                    // set current node
                    _currentNode = node;
                    return _currentNode;
                }
            }
        }

        return null;
    }


    private TwineStory LoadTwineFile(string file) {
        // create new Twine Story object
        TwineStory newTwineStory = new TwineStory();

        // assign current story to the new created story
        _tempStory = newTwineStory;

        // load the twine file into memory
        TextAsset twineFile = Resources.Load<TextAsset>(file);

        if (twineFile) {
            // split file by lines
            string [] lines = twineFile.text.Split('\n');

            // iterate over each line
            foreach (string line in lines) {
                // remove any goofy characters
                ProcessLine(line.TrimEnd('\r'));
            }
        }

        return _tempStory;
    }

    private void ProcessLine(string line) {
        // skip if length is zero
        if (line.Length == 0) {
            return;
        }

        if (line.IndexOf(TWINE_KEY_WORD_STORY_TITLE) == 0) {
            // found the story title
        } else if (line.IndexOf(TWINE_KEY_WORD_USER_SCRIPT) == 0) {
            // found the user script section
        } else if (line.IndexOf(TWINE_KEY_WORD_USER_STYLESHEET) == 0) {
            // found the user style sheet section
        } else if (line.IndexOf(":: ") == 0) {
            // start of a new node
            // extract title of node
            string title = line.Remove(0, 3);

            // create new TwinNode object
            TwineNode newNode = new TwineNode(title);

            // assign the current node to the newly create node
			_tempNode = newNode;

            // add node to the current story
            _tempStory.AddNode(newNode);

        } else {
            // do we have an active node
			if (_tempNode != null) {

                // create new TwineLine object
                TwineLine currentLine = new TwineLine();

                // add new TwineLine to the current node
				_tempNode.AddLine(currentLine);

                // helloo [[link]] more tet [[

                // set up phrase variables
                string currentPhrase = "";
                bool foundOpenBracket = false;
                bool foundCloseBracket = false;
                bool foundLink = false;

                // iterate over each character
                foreach (char character in line) {

                    if (character == '[') {
                        if (foundOpenBracket == false) {
                            foundOpenBracket = true;
                            continue;
                        } else {
                            // start of a link
                            foundLink = true;

                            if (currentPhrase.Length > 0) {
                                // create a new TwineLinePhrase
                                TwineLinePhrase phrase = new TwineLinePhrase(currentPhrase);

                                // add this phrase to the current Line
                                currentLine.AddPhrase(phrase);

                                // reset phrase variables
                                currentPhrase = "";
                                foundOpenBracket = false;
                                foundCloseBracket = false;
                            }
                        }

                    } else if (character == ']') {
                        if (foundCloseBracket == false) {
                            foundCloseBracket = true;
                            continue;
                        } else {
                            if (foundLink == false) {
                                /// hello how are ]] you!
                                // add in closed brackets we skipped over
                                currentPhrase = currentPhrase + "]]";
                            } else {
                                if (currentPhrase.Length > 0) {
                                    // create a new TwineLinePhrase
                                    TwineLinePhrase phrase = new TwineLinePhrase(currentPhrase);

                                    // add link
                                    phrase.AddLink(currentPhrase);

                                    // add this phrase to the current Line
                                    currentLine.AddPhrase(phrase);

                                    // reset phrase variables
                                    currentPhrase = "";
                                    foundOpenBracket = false;
                                    foundCloseBracket = false;
                                }
                            }
                        }

                    } else {
                        foundOpenBracket = false;
                        foundCloseBracket = false;

                        // insert bracket that we skipped over
                        if (foundOpenBracket == true) {
                            currentPhrase = currentPhrase + "[";
                        }

                        // insert bracket that we skipped over
                        if (foundCloseBracket == true) {
                            currentPhrase = currentPhrase + "]";
                        }

                        // add character to the current phrase
                        currentPhrase = currentPhrase + character.ToString();
                    }
                }

                // handle any leftovers
                if (currentPhrase.Length > 0) {
                    // create a new TwineLinePhrase
                    TwineLinePhrase phrase = new TwineLinePhrase(currentPhrase);

                    // add this phrase to the current Line
                    currentLine.AddPhrase(phrase);
                }
            }
        }
    }
        
}

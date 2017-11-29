using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwineManager : MonoBehaviour {

    private static string TWINE_KEY_WORD_STORY_TITLE = "StoryTitle";
    private static string TWINE_KEY_WORD_USER_SCRIPT = "UserScript";
    private static string TWINE_KEY_WORD_USER_STYLESHEET = "UserStyleSheet";


    private TwineStory currentStory = null;
    private TwineNode currentNode = null;

	// Use this for initialization
	void Start () {
        
        LoadTwineFile("sample_twine_file");

        int x = 30;

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void LoadTwineFile(string file) {
        // create new Twine Story object
        TwineStory newTwineStory = new TwineStory();

        // assign current story to the new created story
        currentStory = newTwineStory;

        // load the twine file into memory
        TextAsset twineFile = Resources.Load<TextAsset>(file);

        if (twineFile) {
            // split file by lines
            string [] lines = twineFile.text.Split('\n');

            // iterate over each line
            foreach (string line in lines) {
                ProcessLine(line);
            }
        }
    }

    private void ProcessLine(string line) {
        if (line.IndexOf(":: StoryTitle") == 0) {
            // found the story title
        } else if (line.IndexOf(":: UserScript[script]") == 0) {
            // found the user script section
        } else if (line.IndexOf(":: UserStylesheet[stylesheet]") == 0) {
            // found the user style sheet section
        } else if (line.IndexOf(":: ") == 0) {
            // start of a new node
            // extract title of node
            string title = line.Remove(0, 3);

            // create new TwinNode object
            TwineNode newNode = new TwineNode(title);

            // assign the current node to the newly create node
            currentNode = newNode;

            // add node to the current story
            currentStory.AddNode(newNode);

        } else {
            // do we have an active node
            if (currentNode != null) {

                // create new TwineLine object
                TwineLine currentLine = new TwineLine();

                // add new TwineLine to the current node
                currentNode.AddLine(currentLine);

                /// helloo [[link]] more tet [[

                // 2 choices
                // 1 - it is just plain text
                // 2 - it is a choice/link with text



                // set up phrase variables
                string currentPhrase = "";
                bool foundOpenBracket = false;
                bool foundCloseBracket = false;
                bool foundLink = false;

                // remove any goofy characters
                line = line.TrimEnd('\r');

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    Dictionary<string, string> inventory = new Dictionary<string, string>();

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddItem(string itemName) {
        inventory.Add(itemName, itemName);
    }

    public bool HasItem(string itemName) {
        return inventory.ContainsKey(itemName);
    }

    public void RemoveItem(string itemName) {
        inventory.Remove(itemName);
    }

}

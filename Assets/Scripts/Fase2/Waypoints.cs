using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {
	public static Transform[] waypoints;

	void Awake() {
		waypoints = new Transform[transform.childCount]; //creates a transfor array with its number of children as a size.

		for(int i = 0; i < waypoints.Length; i++) {	//Gets all children (all of this gameObject children will have their position consider a waypoint).
			waypoints[i] = transform.GetChild(i);
		}
	}
}

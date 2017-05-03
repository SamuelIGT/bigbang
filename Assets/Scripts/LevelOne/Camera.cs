using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	private Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 novaPosicao = new Vector3 (player.position.x, player.position.y + 48.0f, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, novaPosicao, Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevelThree : MonoBehaviour {
	private Transform player;
    private float deslocamento = 8;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalDist = gameObject.transform.position.x - player.position.x;
        Debug.Log(horizontalDist);
        if (horizontalDist < -13.0f || horizontalDist > 13.0f) {
            Vector3 novaPosicao = new Vector3(player.position.x, player.position.y + deslocamento, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.time);
        }
	}
}

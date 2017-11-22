using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFase3 : MonoBehaviour
{
	private Transform player;
	private float deslocamento = 7.5f;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update ()
	{
		float horizontalDist = gameObject.transform.position.x - player.position.x;
		if (horizontalDist < -10.0f || horizontalDist > 10.0f) {
			Vector3 novaPosicao = new Vector3 (player.position.x, player.position.y + deslocamento, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, novaPosicao, Time.time);
		}
	}
}

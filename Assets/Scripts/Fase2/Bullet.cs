using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
	public float speed = 70f;
	public GameObject impactEffect;
	//Particle effect when the bullet hits something.
	private int damage;
	// Use this for initialization
	void Start() {
		
	}

	public void Seek(Transform target) { // Sets the bullet target.
		this.target = target;
	}

	public void SetDamage(int damage) { // Sets how much damage the bullet will take.
		this.damage = damage;
	}
	
	// Update is called once per frame
	void Update() {
		if(target == null) { //If the target doesn't exist anymore (if it was destroyed), destroy the bullet gameObject.
			Destroy(gameObject);
			return;
		}

		Vector3 direction = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime; //the actual distance that the this gameobject will move this frame;

		if(direction.magnitude <= distanceThisFrame) { //the distance of the bullet from the target is equal to the magniture of the direction. Is this is less or iqual to the distance that the bullet will move this frame, then the target was hitted.
			HitTarget();
			return;
		}

		transform.Translate(direction.normalized * distanceThisFrame, Space.World);
	}

	public void HitTarget() {
		target.gameObject.GetComponent<QuarkController>().Hit(damage); //add the damage to the target life.
		if(impactEffect != null) { //if the bullet has an impact fx...
			GameObject impactEffectIns = Instantiate(impactEffect, transform.position, transform.rotation) as GameObject; //intantiate the effect.
			Destroy(impactEffectIns, 2f); //Destroys the impact effect after 0.2f secs.
		}

		Destroy(gameObject); //Destroy the bullet.
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuarkController : MonoBehaviour {
	public int startHealth = 1;
	public float speed = 10f;
	public int healingStrength = 1;
	public float healingRate = 1f;
	public int health;

	private Image healthBar;
	private GameObject healthBarGameObject;

	public bool isProtected = false;
	private Transform target;
	private int waypointIndex = 0;
	private GameStatusController gameStatusController;
	private Collider[] quarksAround = null;
	private float quarksOffset = 0;
	private LayerMask quarkMask = 1 << 8;

	// Use this for initialization
	void Start() {
		health = startHealth;
		gameStatusController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStatusController>();
		target = Waypoints.waypoints[0];
		quarksOffset = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorFilaQuarks>().distanciaEntreQuarks.y;
	}
	
	// Update is called once per frame
	void Update() {
		//positions the health bar at the right place
		healthBarGameObject.transform.position = (Vector3.up) + transform.position * 1f;

		if(gameStatusController.GetGameStarted()) {
			Vector3 direction = target.position - transform.position;
			transform.Translate(direction.normalized * (speed * Time.deltaTime));

			if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
				getNextWaypoint();
			}

			if(health <= 0) {
				Destroy(gameObject);
			}

			if(this.gameObject.CompareTag("Quark_Top") || this.gameObject.CompareTag("Quark_Charm")) {
				if(quarksAround == null) {
					UpdateQuarksAround();
				}
			}
		}
	}

	private void UpdateQuarksAround() {
		quarksAround = Physics.OverlapSphere(transform.position, (Mathf.Abs(quarksOffset) + 0.2f), quarkMask);
		Debug.Log("Quarks Around: " + quarksAround.Length);
		if(this.gameObject.CompareTag("Quark_Charm")) {
			InvokeRepeating("Heal", 0f, healingRate);
		} else {
			Protect();
		}
	}

	private void getNextWaypoint() {
		if(waypointIndex == Waypoints.waypoints.Length - 1) {
			Destroy(gameObject);
			return;
		}

		waypointIndex++;
		target = Waypoints.waypoints[waypointIndex];

	}

	public void Hit(int damage) {
		if(!isProtected) {
			health = health - damage;
			healthBar.fillAmount = (float)health / (float)startHealth;
			if(health <= 0) {
				if(CompareTag("Quark_Top")) {
					foreach(Collider quark in quarksAround) {
						if(quark.gameObject.GetInstanceID() != this.gameObject.GetInstanceID()) {
							quark.GetComponent<QuarkController>().SetProtection(false);
						}
					}
				}
				GameObject.FindWithTag("GameController").GetComponent<GerenciadorFilaQuarks>().removeQuark(gameObject);
				Destroy(gameObject);
				Destroy(healthBarGameObject);
			}
		}
	}

	private void Heal() {
		
		if(quarksAround != null && quarksAround.Length > 1) {
			foreach(Collider quark in quarksAround) {
				//Debug.Log ("GameObject ID:" + this.gameObject.GetInstanceID () + " |-| Healed quark id: " + quark.gameObject.GetInstanceID ());
				if(quark.gameObject.GetInstanceID() != this.gameObject.GetInstanceID()) {
					QuarkController enemy = quark.GetComponent<QuarkController>();
					enemy.health = enemy.health + healingStrength;
				}
			}
		}
	}

	private void Protect() {
		if(quarksAround != null && quarksAround.Length > 1) {
			foreach(Collider quark in quarksAround) {
				//Debug.Log ("GameObject ID:" + this.gameObject.GetInstanceID () + " |-| Healed quark id: " + quark.gameObject.GetInstanceID ());
				if(quark.gameObject.GetInstanceID() != this.gameObject.GetInstanceID()) {
					quark.GetComponent<QuarkController>().SetProtection(true);
				}
			}
		}
	}

	private void SetProtection(bool isProtecting) {
		isProtected = isProtecting;
	}

	public void SetHealthBar(GameObject healthBarGameObject) {
		this.healthBarGameObject = healthBarGameObject;
		this.healthBar = healthBarGameObject.transform.GetChild(0).GetComponent<Image>();
	}

	public GameObject getHealthBar() {
		return healthBarGameObject;
	}
}

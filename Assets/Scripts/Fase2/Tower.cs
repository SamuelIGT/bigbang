using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	[Header("Atributes")]
	public float turnSpeed = 10f;
	public float fireRate = 1f;
	public int damage = 1;
	public float range = 15f;
	public bool isStangePrioriser = false;
	public bool isUpDownPrioriser = false;


	[Header("Link Fields")]
	public Transform target;
	//Just to seed on the editor if the when the target is getted
	//public string[] targetsTAGs;
	public string bottomQuarkTag = "Quark_Bottom";
	public string topQuarkTag = "Quark_Top";
	public Transform partToRotate;
	public GameObject bulletPrefab;
	public Transform firepoint;

	private float fireCountDown = 0.0f;
	private Collider[] objectsInRange;
	private LayerMask targetMask = 1 << 8;

	// Use this for initialization
	void Start() {
		if(gameObject.tag.Equals("AREA_DAMAGE_TOWER")) {
			InvokeRepeating("UpdateTargetsInArea", 0.0f, 0.5f);
		} else {
			InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
		}
	}

	// Update is called once per frame
	void Update() {
		if(gameObject.tag.Equals("AREA_DAMAGE_TOWER")) {
			if(fireCountDown <= 0) {

				HitArea();//shot

				fireCountDown = 1f / fireRate;
			}
			fireCountDown -= Time.deltaTime;
		} else {
			if(target == null) {
				return;
			}
				
	
//			Debug.Log ("Tower Foward: " + partToRotate.forward);
			partToRotate.LookAt(new Vector3(target.transform.position.x, target.transform.position.y, partToRotate.position.z), new Vector3(0, 0, -1));
			/*Vector3 targetDir = target.position - transform.position;
			float step = turnSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0F);
			Quaternion rotation = Quaternion.LookRotation (newDir);
			partToRotate.rotation = Quaternion.Euler (rotation.x, rotation.y, rotation.z);*/

			//Vector3 direction = target.position - transform.position;
			//Quaternion lookRotation = Quaternion.LookRotation (direction);
			//Vector3 rotation = Quaternion.Lerp (partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
			//partToRotate.rotation = Quaternion.Euler (0, rotation.y, 0);
			if(fireCountDown <= 0) {
				Shoot();
				fireCountDown = 1f / fireRate;
			}
			fireCountDown -= Time.deltaTime;
		}
	}

	void Shoot() {
		if(firepoint == null) {
			return;
		}

		GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation) as GameObject;
		Bullet bulletScript = bullet.GetComponent<Bullet>();
		bulletScript.SetDamage(damage);

		if(bulletScript != null) {
			bulletScript.Seek(target);
		}
	}

	void HitArea() {
		if(objectsInRange.Length > 0) {
			for(int i = 0; i < objectsInRange.Length; i++) {
				QuarkController enemy = objectsInRange[i].GetComponent<QuarkController>();
				if(enemy != null) {
					//Debug.Log ("Enemies inside the area: " + objectsInRange.Length); // Shows on console how many enemies are inside the range.
					Debug.Log("Impact!");
					GameObject impact = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
					Destroy(impact, 1.1f);
					enemy.Hit(damage);
					if(objectsInRange[i].CompareTag("Quark_Top") && i != objectsInRange.Length - 1) {//If is the Quark Top and it is NOT the last one on the array
						i++;																			//jump the next quak in array. (This will prevent from hit the next quak imediatly after the Top stops protecting);
					} 
				}
			}
		}
	}

	void UpdateTarget() {
		GameObject[] bottomEnemies = GameObject.FindGameObjectsWithTag(bottomQuarkTag);
		if(bottomEnemies.Length > 0) {
			setClosestTarget(bottomEnemies, null);

		} else {
			Collider[] enemies = Physics.OverlapSphere(transform.position, 100f, targetMask);		//GameObject.FindGameObjectsWithTag(enemyTAG);
			setClosestTarget(null, enemies);
		}
	}

	private void setClosestTarget(GameObject[] gameObjectArray, Collider[] ColliderArray) { //Solução menos custosa.
		float shortestDistance = Mathf.Infinity;
		GameObject closestEnemy = null;

		if(gameObjectArray == null) {
			foreach(Collider enemy in ColliderArray) {
				float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

				if(distanceToEnemy < shortestDistance) {
					shortestDistance = distanceToEnemy;
					closestEnemy = enemy.gameObject;
				}
			}
		} else {
			foreach(GameObject enemy in gameObjectArray) {
				float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

				if(distanceToEnemy < shortestDistance) {
					shortestDistance = distanceToEnemy;
					closestEnemy = enemy;
				}
			}
		}

		if(closestEnemy != null && shortestDistance <= range) {
			target = closestEnemy.transform;
		} else {
			target = null;
		}
	}

	void UpdateTargetsInArea() {
		
		objectsInRange = Physics.OverlapSphere(transform.position, range, targetMask);
		/*foreach (Collider col in objectsInRange)
		{
			Enemy enemy = col.GetComponent<Enemy>();
			if (enemy != null) //Apply damage
			{
				//float proximity = (gameObject.transform.position - enemy.transform.position).magnitude;
				//float effect = 1 - (proximity / range);
				enemy.DecreaseLife(damage);
			}
		}*/
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);

	}
}
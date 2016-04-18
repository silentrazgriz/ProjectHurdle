using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public Vector3 spawnPosition;
	public GameObject[] obstacles;
	public float score;
	public float minTime, maxTime;
	private float _nextTime;

	void Start () {
		getNextTime ();
	}

	void Update () {
		if (Time.time > _nextTime) {
			spawnObstacle ();
		}
	}

	void getNextTime () {
		_nextTime += Random.Range (minTime, maxTime);
	}

	void spawnObstacle () {
		int index = Random.Range (0, obstacles.Length);
		GameObject obj = (GameObject)Instantiate (obstacles[index], spawnPosition, Quaternion.identity);
		obj.transform.parent = this.transform;
		getNextTime ();
	}

	public void addScore () {
		score++;
	}
}

using UnityEngine;
using System.Collections;

public class FormationController2 : MonoBehaviour {
	public GameObject enemyPrefab;
	public GameObject enemyPrefab2;
	public GameObject enemyPrefab3;
	public GameObject enemyPrefab4;
	
	public float width = 10;
	public float height = 5;
	public float speed = 5.0f;
	public float padding = 1;
	public float spawnDelaySeconds = 1f;
	
	private int direction = 1;
	private float boundaryRightEdge, boundaryLeftEdge;
	
	private int numRounds;
	private int firstWave;
	private int secondWave;
	private int thirdWave;
	private int fourthWave;
	
	private bool winConditionsMet = false;
	private float timeDelay = 0;
	
	private LevelManager levelmanager;
	
	// Use this for initialization
	void Start () {
		numRounds = 1;
		firstWave = 3;
		secondWave = 5;
		thirdWave = 8;
		fourthWave = 9;

		
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		boundaryLeftEdge = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		boundaryRightEdge = camera.ViewportToWorldPoint(new Vector3(1,1,distance)).x - padding;
		SpawnUntilFull();
	}
	
	void OnDrawGizmos(){
		
		
		float xmin,xmax,ymin,ymax;
		xmin = transform.position.x - 0.5f * width;
		xmax = transform.position.x + 0.5f * width;
		ymin = transform.position.y - 0.5f * height;
		ymax = transform.position.y + 0.5f * height;
		Gizmos.DrawLine(new Vector3(xmin,ymin,0), new Vector3(xmin,ymax));
		Gizmos.DrawLine(new Vector3(xmin,ymax,0), new Vector3(xmax,ymax));
		Gizmos.DrawLine(new Vector3(xmax,ymax,0), new Vector3(xmax,ymin));
		Gizmos.DrawLine(new Vector3(xmax,ymin,0), new Vector3(xmin,ymin));
	}
	
	// Update is called once per frame
	void Update () {
		
		print(numRounds);
		
		float formationRightEdge = transform.position.x + 0.5f * width;
		float formationLeftEdge = transform.position.x - 0.5f * width;
		if (formationRightEdge > boundaryRightEdge){
			direction = -1;
		}
		if (formationLeftEdge < boundaryLeftEdge){
			direction = 1;
		}
		transform.position += new Vector3(direction * speed * Time.deltaTime,0,0);
		
		if(AllMembersAreDead()){
			Debug.Log("My formation is empty :(");
			
		
			if(!winConditionsMet)
			{
				if(numRounds < firstWave)
				{
					print("first wave");
					numRounds = numRounds + 1;
					SpawnUntilFull();
					
				}
				else if(numRounds < secondWave)
				{
					print("Second wave");
					numRounds = numRounds + 1;
					SpawnNextUntilFull();
				}
				else if(numRounds < thirdWave)
				{
					print("Third wave");
					numRounds = numRounds + 1;
					SpawnThirdUntilFull();
				}
				else if(numRounds < fourthWave)
				{
					print("Fourth wave");
					numRounds = numRounds + 1;
					SpawnFourthUntilFull();
				}
				else if(numRounds >= fourthWave)
				{
					print("win conditions met");
					winConditionsMet = true;
					timeDelay = Time.time + 1.5f;
				
				}
			}
			
				if(winConditionsMet && Time.time > timeDelay)
				{
					levelmanager = GameObject.FindObjectOfType<LevelManager>();

					levelmanager.LoadLevel("Win Screen");
					winConditionsMet = false;
				}
			
		}
	}

	void SpawnUntilFull(){
		
		Transform freePos = NextFreePosition();
		GameObject enemy = Instantiate(enemyPrefab, freePos.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = freePos;
		if(FreePositionExists()){
			Invoke("SpawnUntilFull", spawnDelaySeconds);
			
		}

		
	}
	
		void SpawnNextUntilFull(){
		
		Transform freePos = NextFreePosition();
		GameObject enemy2 = Instantiate(enemyPrefab2, freePos.position, Quaternion.identity) as GameObject;


		enemy2.transform.parent = freePos;
		
		if(FreePositionExists()){
			Invoke("SpawnNextUntilFull", spawnDelaySeconds);
			
		}

		
	}
	
	void SpawnThirdUntilFull(){
		
		Transform freePos = NextFreePosition();
		GameObject enemy3 = Instantiate(enemyPrefab3, freePos.position, Quaternion.identity) as GameObject;
		enemy3.transform.parent = freePos;
		if(FreePositionExists()){
			Invoke("SpawnThirdUntilFull", spawnDelaySeconds);
			
		}

		
	}
	
	void SpawnFourthUntilFull(){
		
		Transform freePos = NextFreePosition();
		GameObject enemy4 = Instantiate(enemyPrefab4, freePos.position, Quaternion.identity) as GameObject;
		enemy4.transform.parent = freePos;
		if(FreePositionExists()){
			Invoke("SpawnFourthUntilFull", spawnDelaySeconds);
			
		}

		
	}
	
	bool FreePositionExists(){
		foreach(Transform position in transform){
			if(position.childCount <= 0){
				return true;
			}
		}
		return false;
	}
	
	Transform NextFreePosition(){
		foreach(Transform position in transform){
			if(position.childCount <= 0){
				return position;
			}
		}
		return null;
	}

	bool AllMembersAreDead(){
		foreach(Transform position in transform){
			if(position.childCount > 0){
				return false;
			}
		}
		
		return true;
	}
}
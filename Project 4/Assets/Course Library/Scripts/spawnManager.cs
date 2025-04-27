using UnityEngine;

public class spawnManager : MonoBehaviour
{       
    public GameObject enemyPrefab;          //declares an GameObject variable for enemyPrefab
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;           //sets the spawn range number for the position x and z      
    public int enemyCount;
    public int waveNumber = 1;                  //total enemies to spawn each wave
      
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
     SpawnEnemy(waveNumber);             //SpawnEnemy method called with the enemiesToSpawn values set to 3

    Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);           //uses instantiate to clone enemies. also calls the method GenerateSpawnPosition

    }


    void SpawnEnemy(int enemiesToSpawn){                    //takes in an int parameter called enemiesToSpawn
        
        for (int i = 0; i < enemiesToSpawn; i++){        //create a for loop to constantly spawn enemy at a specific rate
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);           //uses instantiate to clone enemies. also calls the method GenerateSpawnPosition

        }
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<enemy>(FindObjectsSortMode.None).Length;             //uses the variable enemyCount to assign a counter detection to detect the amount of enemies currently spawned in the game

        if (enemyCount == 0){                                                               //if the total number of enemies is equal to 0 then:  
            SpawnEnemy(waveNumber++);                                                       //continue spawning more objects in the game with adding 1 to each new waves
            Instantiate(powerupPrefab,GenerateSpawnPosition(), powerupPrefab.transform.rotation);   //instantiate powerupPrefab, using GenerateSpawnPosition to get random position for the powerup and rotation.

        }

        
    }


    private Vector3 GenerateSpawnPosition(){                                            //creates a vector3 method for storing the positions generate to spawn
        float spawnPosX = Random.Range(-spawnRange, spawnRange);                        //creates a float for the spawn position on x axis
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);                        //creates a float for the spawn position on z axis

        Vector3 randomPos = new Vector3 (spawnPosX, 0, spawnPosZ);                     //Creates a new vector3 for storing the spawn position of X and Z axis for enemies

        return randomPos;
    }
}

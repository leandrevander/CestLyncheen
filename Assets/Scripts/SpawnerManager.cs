using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public  float      spawnTimer;
    private GameObject player;

    [Header("Insert cooldowns of enemies spawners")]
    public float activationSnailSpawner;
    public float activationSharkSpawner;
    public float activationDolphinSpawner;
    public float activationSeagullSpawner;

    [Header("Put Spawner's GameObject")]
    public SnailSpawner snailSpawner;
    public SharkSpawner sharkSpawner;
    public DolphinSpawner dolphinSpawner;
    public SeagullSpawner seagullSpawner;

    [Header("Select the spawners that you want to activate")]
    public bool activateSnailSpawner = true;
    public bool activateSharkSpawner = true;
    public bool activateDolphinSpawner = true;
    public bool activateSeagullSpawner = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        snailSpawner = GameObject.FindWithTag("Player").GetComponent<SnailSpawner>();
        sharkSpawner = GameObject.FindWithTag("Player").GetComponent<SharkSpawner>();
        dolphinSpawner = GameObject.FindWithTag("Player").GetComponent<DolphinSpawner>();
        seagullSpawner = GameObject.FindWithTag("Player").GetComponent<SeagullSpawner>();
        player       = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= activationSnailSpawner && activateSnailSpawner && player != null)
        {
            snailSpawner.enabled = true;
        }
        
        if (spawnTimer >= activationSharkSpawner &&  activateSharkSpawner && player != null)
        {
            sharkSpawner.enabled = true;
        }
        
        if (spawnTimer >= activationDolphinSpawner && activateDolphinSpawner && player != null)
        {
            dolphinSpawner.enabled = true;
        }
        
        if (spawnTimer >= activationSeagullSpawner && activateSeagullSpawner && player != null)
        {
            seagullSpawner.enabled = true;
        }
        
    }
}

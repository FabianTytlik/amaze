using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PrefabRepository PrefabRepository;
    public MazeGenerator MazeGenerator;
    public Maze ActiveMaze;
    // Start is called before the first frame update
    void Start()
    {
        GetComponents();
        ActiveMaze = MazeGenerator.GenerateNewMaze(100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetComponents()
    {
        PrefabRepository = gameObject.GetComponent(typeof(PrefabRepository)) as PrefabRepository;
        MazeGenerator = gameObject.GetComponent(typeof(MazeGenerator)) as MazeGenerator;
        MazeGenerator.LoadPrefabRepository(this.PrefabRepository);
    }
}

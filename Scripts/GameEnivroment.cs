using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnivroment 
{
    private static GameEnivroment instance;//point of this class is it cant be instantiated and instead it is a blueprint
    private List<GameObject> checkpoints = new List<GameObject>();
    public List<GameObject> Checkpoints { get { return checkpoints; } }
    public static GameEnivroment Singleton
    {//grabs checkpoints
        get
        {
            if (instance == null)
            {
                instance = new GameEnivroment();
                instance.Checkpoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnivroment 
{
    //This class acts as a blueprint for other classes to inherit from
    //Purpose of this script is to have a checkpoint system which Ai iterates over for it's path.
    private static GameEnivroment instance;
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
 
}

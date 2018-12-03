using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class CheckpointPlus : Checkpoint
{
    public int checkpointValue;

    public void changeCheckpoint()
    {
        int currentCheckpoint = PlayerPrefs.GetInt("reachedCheckpoints", 0);
        if (checkpointValue > currentCheckpoint)
        {
            PlayerPrefs.SetInt("reachedCheckpoints", checkpointValue);
        }
    }
}

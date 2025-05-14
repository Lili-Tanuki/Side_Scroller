using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    private Vector3 lastCheckpointPosition;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            lastCheckpointPosition = Vector3.zero;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpointPosition = position;
        Debug.Log("Checkpoint sauvegardé à : " + position);
    }

    public Vector3 GetCheckpoint()
    {
        return lastCheckpointPosition;
    }
}

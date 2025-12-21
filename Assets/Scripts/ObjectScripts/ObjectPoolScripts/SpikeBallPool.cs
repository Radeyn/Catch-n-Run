using UnityEngine;

public class SpikeBallPool : ObjectPool
{

    int spikePoolSize;

    private void Start()
    {
        spikePoolSize = objectPool.Count;
    }
}


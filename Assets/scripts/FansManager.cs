using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class FanButtonPair
{
    public Fan Fan;
    public GameObject Button;
}

public class FansManager : MonoBehaviour
{
    [SerializeField] private FanButtonPair[] _fanButtonPair;

    public void ActivateFan(GameObject button)
    {
        foreach (FanButtonPair fanButtonPair in _fanButtonPair)
        {
            if (fanButtonPair.Button == button) fanButtonPair.Fan.enabled = true;
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

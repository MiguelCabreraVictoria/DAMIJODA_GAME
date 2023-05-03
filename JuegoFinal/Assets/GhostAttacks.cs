using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GhostState {
        FOLLOWINGPROYECTILES,
        PROYECTILEHELL
    }

public class GhostAttacks : MonoBehaviour
{
    public GhostState status;
    public float attCh;
    
    // Start is called before the first frame update
    void Start()
    {
        status = GhostState.FOLLOWINGPROYECTILES;
    }

    IEnumerator GhostStatuses(){
        yield return new WaitForSeconds(attCh);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

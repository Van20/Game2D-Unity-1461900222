using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Lawan : MonoBehaviour
{
    public bool hadapKanan = true;
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x > 0f && hadapKanan == true){
            transform.Rotate(0f, 180f, 0f);
            hadapKanan = false;
        }else if(aiPath.desiredVelocity.x < 0f && hadapKanan == false){
            transform.Rotate(0f, 180f, 0f);
            hadapKanan = true;
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class OpponentsComponent : MonoBehaviour
{
    //
    // OpponentContainer is a gameobject that will have children
    //    which are the orange opponent cars
    //    Will attach Assets/Resources/Opponent to this 
    //
    public Transform spawnOrigin;       //player car location - used as offset 
    public int maxCars = 6;             //number of opponents to spawn
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)

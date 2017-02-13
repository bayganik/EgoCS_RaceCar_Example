using UnityEngine;

[DisallowMultipleComponent]
public class SpeedComponent : MonoBehaviour
{
    public float speed;
    public float maxSpeed;

    public SpeedComponent(float sp, float maxsp)
    {
        speed = sp;
        maxSpeed = maxsp;
    }
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)

using UnityEngine;

[DisallowMultipleComponent]
public class UIComponent : MonoBehaviour
{
    //
    // Add a "EgoComponent" to "GameOverPanel"
    // Add this component to "Canvas" gameobject
    // Drag "GameOverPanel" to UICompoent script for "Game Over Panel" public value
    //
    public EgoComponent gameOverPanel;
}

//DO NOT ADD MONOBEHAVIOUR MESSAGES (Start, Update, etc.)

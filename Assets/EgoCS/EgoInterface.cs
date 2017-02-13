using UnityEngine;
using System.Collections.Generic;

public class EgoInterface : MonoBehaviour
{
	static EgoInterface()
	{
        
        //Add Systems here:
        EgoSystems.Add(
            new InitializeOpponentSystem()
            , new EndOfGameSystem()
            , new InitializePlayerSystem()
            , new PlayerCarSystem()
            , new OpponentCarSystem()
            , new EndOfLineSystem()
        );
    }

    void Start()
	{
		EgoSystems.Start(); 
	}
	
	void Update()
	{
		EgoSystems.Update();
	}
	
	void FixedUpdate()
	{
		EgoSystems.FixedUpdate();
	}
}

using UnityEngine;

public class EndOfGameEvent : EgoEvent
{
    public bool gameOver;

    public EndOfGameEvent(bool gameEnds)
	{
        this.gameOver = gameEnds;
	}
}

using UnityEngine;

public class CheckEndOfLineEvent : EgoEvent
{
    public readonly EgoComponent car;

	public CheckEndOfLineEvent(EgoComponent carComponent)
	{
        //
        // Position of the cars as they approach the End of Line
        // The event alerts the End of line system
        //
        this.car = carComponent;

	}
}

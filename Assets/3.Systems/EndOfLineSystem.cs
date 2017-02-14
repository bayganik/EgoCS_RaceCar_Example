using UnityEngine;

public class EndOfLineSystem : EgoSystem<EgoConstraint<EndOfLineComponent>>
{
    public override void Start()
    {
        //
        // if any cars cross the finish line then handle 
        // Checking of end of line event
        //
        EgoEvents<CheckEndOfLineEvent>.AddHandler(Handle);
    }

    public override void Update()
	{

    }

	public override void FixedUpdate()
	{
		
	}
    private void Handle(CheckEndOfLineEvent e)
    {
        //
        // Check to see if Ego entity "car" or "opps_x" has crossed the finish line
        //
        constraint.ForEachGameObject(
        (egoComp, endofline) =>
            {
                //
                // If any car crosses the finish line, then game ends
                //
                if (e.car.transform.position.y > endofline.transform.position.y)
                {
                    //
                    // Following is a play line to see how to add a component to an entity
                    // Issue the pause component to the car the just crossed the finish line
                    //
                    Ego.AddComponent<PauseComponent>(egoComp);
                    //
                    // Invoke the event that causes the EndOfGameSystem to turn on "Game Over" text 
                    //
                    EgoEvents<EndOfGameEvent>.AddEvent(new EndOfGameEvent(true));
                }
            }
            );

            
    }

}
using UnityEngine;

public class EndOfLineSystem : EgoSystem<EgoConstraint<Transform, EndOfLineComponent>>
{
    Transform finishLine;


    public override void Start()
    {
        constraint.ForEachGameObject(
            (ego, transform, endofline) =>
            {
                finishLine = endofline.transform;
                //
                // if any cars cross the finish line then handle
                //
                EgoEvents<CheckEndOfLineEvent>.AddHandler(Handle);
            }
            );
    }

    public override void Update()
	{
        constraint.ForEachGameObject(
            (ego, transform,  endofline) =>
            {
            
            }
            );
    }

	public override void FixedUpdate()
	{
		
	}
    private void Handle(CheckEndOfLineEvent e)
    {
        //
        // If any car crosses the finish line, then game ends
        //
        if (e.car.transform.position.y > finishLine.transform.position.y)
        {
            //
            // Issue the pause component to the car the just crossed the finish line
            //
            Ego.AddComponent<PauseComponent>(e.car);
            //
            // Invoke the event that looks for PauseComponent and stops the game
            //
            EgoEvents<EndOfGameEvent>.AddEvent(new EndOfGameEvent(true));
        }
            
    }

}
using UnityEngine;

public class OpponentCarSystem : EgoSystem<EgoConstraint<OpponentCarComponent, SpeedComponent>>
{
    bool gameIsOver = false;

    public override void Start()
	{
        //
        // Register to listen to EndOfGame broadcast
        //
        EgoEvents<EndOfGameEvent>.AddHandler(Handle);
    }

	public override void Update()
	{
        constraint.ForEachGameObject(
            (ego, opponentcar, speed) =>
            {

                if (gameIsOver)
                {
                    // do nothing is game is over
                }
                else
                {
                    Vector3 now = opponentcar.transform.position;
                    opponentcar.transform.position = new Vector3(now.x, now.y + speed.speed, now.z);
                    //
                    // invoke an event to check if the car has crossed the line
                    //     ego is the current GameObject / EgoComponent (happens to be Opps_x car)
                    //
                    var eve = new CheckEndOfLineEvent(ego);
                    EgoEvents<CheckEndOfLineEvent>.AddEvent(eve);
                }
            }
            );
    }

	public override void FixedUpdate()
	{
		
	}
    void Handle(EndOfGameEvent e)
    {
        if (e.gameOver)
            gameIsOver = true;
        else
            gameIsOver = false;
    }
}
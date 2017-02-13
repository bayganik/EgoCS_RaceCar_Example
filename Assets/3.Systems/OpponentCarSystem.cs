using UnityEngine;

public class OpponentCarSystem : EgoSystem<EgoConstraint<OpponentCarComponent, SpeedComponent>>
{
    EgoComponent carComp;
    bool gameIsOver = false;

    public override void Start()
	{
        constraint.ForEachGameObject(
            (ego, opponentcar, speed) =>
            {
                carComp = ego;
            }
            );
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
                carComp = ego;

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
                        //
                        var eve = new CheckEndOfLineEvent(carComp);
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
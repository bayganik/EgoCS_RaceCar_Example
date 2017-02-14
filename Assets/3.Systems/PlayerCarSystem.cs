using UnityEngine;

public class PlayerCarSystem : EgoSystem<EgoConstraint<PlayerComponent>>
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
            (ego, player) =>
            {

                float moveVertical = Input.GetAxis("Vertical");
                if (gameIsOver)
                {
                    // do nothing is game is over
                }
                else
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        Vector3 now = player.transform.position;
                        player.transform.position = new Vector3(now.x, now.y + player.speed, now.z);
                        //
                        // invoke an event to check if the player car has crossed the line
                        //
                        if (ego.gameObject.name == "Player")
                        {
                            var eve = new CheckEndOfLineEvent(ego);
                            EgoEvents<CheckEndOfLineEvent>.AddEvent(eve);
                        }

                    }
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
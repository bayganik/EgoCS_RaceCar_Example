using UnityEngine;

public class PlayerCarSystem : EgoSystem<EgoConstraint< Transform, PlayerComponent>>
{
    EgoComponent playerComp;
    bool gameIsOver = false;

    public override void Start()
	{
        //var egoComponent = GameObject.GetComponent<EgoComponent>();
        constraint.ForEachGameObject(
            (ego, transPlayer, player) =>
            {
                //
                // Test to make sure we have the "Player" gameobject
                // Set PlayerComponent to the proper gameobject
                //
                if (ego.gameObject.name == "Player")
                    playerComp = ego;
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
            (ego, trans, player) =>
            {
                //Debug.Log(player.transform.position.y + ", " + finishline.transform.position.y);
                //if (transform.position.y > finishline.transform.position.y)
                //{
                //    Debug.Log("Crossed the finish line.");
                //    return;
                //}
                //Debug.Log("Update player");
                float moveVertical = Input.GetAxis("Vertical");
                if (gameIsOver)
                {
                    // do nothing is game is over
                }
                else
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        //Debug.Log("player speed:" + "  vertical:" + moveVertical);
                        Vector3 now = player.transform.position;
                        player.transform.position = new Vector3(now.x, now.y + player.speed, now.z);
                        //
                        // invoke an event to check if the car has crossed the line
                        //
                        var eve = new CheckEndOfLineEvent(playerComp);
                        EgoEvents<CheckEndOfLineEvent>.AddEvent(eve);
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
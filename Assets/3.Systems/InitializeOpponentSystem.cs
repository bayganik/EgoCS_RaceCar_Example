using UnityEngine;
using System.Collections;

public class InitializeOpponentSystem : EgoSystem<EgoConstraint<Transform, OpponentsComponent>>
{
    //
    // Opponents become childrend of game object "OpponentContainer"
    // OpponentContainer
    //      +-- Opps_0
    //      +-- Opps_1
    //      ...
    //      +-- Opps_5
    //
    public override void Start()
	{
        Reset_The_Opponents();
    }

    private void Reset_The_Opponents()
    {
        //
        // Creation of Opponents under OpponentContainer
        //
        constraint.ForEachGameObject(
            (egoComp, transform, opponents) =>
            {
                //
                // Player's car is the origin of the spawn point for all others
                // The opponents use the Player's car as offset to place themselves
                //
                var spawnX = opponents.spawnOrigin.position.x + Mathf.Abs(opponents.spawnOrigin.position.x / 2.0f);
                var spawnY = opponents.spawnOrigin.position.y;
                //
                // destroy all the kids (if any)
                //
                for (int i = 0; i < transform.childCount; i++)
                {
                    Ego.DestroyGameObject(transform.GetChild(i).GetComponent<EgoComponent>());
                }
                //
                //  Setup of opponent cars as children
                //
                for (int cnt = 0; cnt < opponents.maxCars; cnt++)
                {
                    //
                    // create object from prefabs in Assets/Resources folder
                    //      Give it a name starting with "Opps_" plust a number
                    //      Give it a sprite renderer so it can be displayed
                    //      Give it a position offset on x-axis from the player car
                    //
                    GameObject oppsObj = GameObject.Instantiate(Resources.Load("Opponent", typeof(GameObject))) as GameObject;
                    oppsObj.name = "Opps_" + cnt.ToString();
                    oppsObj.transform.parent = transform;
                    //
                    // Get the sprite renderer component & change the location
                    //
                    SpriteRenderer oppsRender = oppsObj.GetComponent<Renderer>() as SpriteRenderer;
                    //
                    // Add spawn X to width of the car multiply by count
                    //
                    var x = (spawnX) + ((oppsRender.bounds.extents.x * 3.0f) * cnt);
                    var y = spawnY;
                    oppsRender.transform.localPosition = new Vector2(x, y);
                    //
                    // Add OpponentCarComponent & SpeedComponent to this GameObject
                    //
                    oppsObj.AddComponent<OpponentCarComponent>();
                    oppsObj.AddComponent<SpeedComponent>();
                    //
                    // Get the SpeedComponent
                    var sc = oppsObj.GetComponent<SpeedComponent>();
                    sc.speed = (Random.value * 0.02f);
                    //
                    // Tell EgoCS about this GameObject
                    //
                    var oppsEgo = Ego.AddGameObject(oppsObj);
                }
            }

            );
    }
	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		
	}
}
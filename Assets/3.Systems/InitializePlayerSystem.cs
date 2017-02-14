using UnityEngine;

public class InitializePlayerSystem : EgoSystem<EgoConstraint<PlayerComponent>>
{
    //
    // The player's car is "Acceleratable" because it has that component
    //                  is "MoveAble" because that component was added also
    //
	public override void Start()
	{
        constraint.ForEachGameObject(
            ( egoComp,  player) =>
            {
                player.speed = .030f;
                
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
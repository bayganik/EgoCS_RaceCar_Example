using UnityEngine;

public class EndOfGameSystem : EgoSystem<EgoConstraint<UIComponent>>
{
	public override void Start()
	{
        //
        // turn off the panel with "Game Over"
        //
        constraint.ForEachGameObject((ego, ui) =>
        {
            ui.gameOverPanel.gameObject.SetActive(false);
        });

        EgoEvents<EndOfGameEvent>.AddHandler(Handle);
    }

	public override void Update()
	{
		
	}

	public override void FixedUpdate()
	{
		
	}

    void Handle(EndOfGameEvent e)
    {
        constraint.ForEachGameObject((ego, ui) =>
        {
            if (e.gameOver)
            {
                ui.gameOverPanel.gameObject.SetActive(true);
                Application.Quit();
            }
        });
    }
}
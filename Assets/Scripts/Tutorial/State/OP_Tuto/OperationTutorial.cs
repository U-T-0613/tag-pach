using UnityEngine;

[CreateAssetMenu(fileName = "OperationTutorial", menuName = "Tutorial/State/OperationTutorial")]
public class OperationTutorial : TutorialState
{
    [SerializeField] private DialogueData startDialogue;
    private bool missionDisplayed = false;
    private bool missionCleared = false;
    public void SetClear(bool cleared)
    {
        missionCleared = cleared;
    }

    public override void EnterState(TutorialManager tutorialManager)
    {
        base.EnterState(tutorialManager);
        Dialogue.Instance.DisplayDialogue(startDialogue);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (!Dialogue.Instance.Active && !missionDisplayed)
        {
            Mission.Instance.DisplayMission("åıÇ¡ÇƒÇ¢ÇÈÉ}ÉXÇ…èÊÇÈ");
            missionDisplayed = true;
        }

        if(missionDisplayed && missionCleared)
        {
            Debug.Log("Player pressed Attack, clearing mission.");
            Mission.Instance.ClearMission();
        }

        if(Mission.Instance.IsFinishedMission() && missionDisplayed)
        {
            tutorialManager.ChangeState(this.NextStateKey);
        }


    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }

    public override void LateUpdateState()
    {
        base.LateUpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}

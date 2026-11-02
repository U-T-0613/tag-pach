using UnityEngine;

[CreateAssetMenu(fileName = "OperationTutorial", menuName = "Tutorial/State/OperationTutorial")]
public class OperationTutorial : TutorialState
{
    [SerializeField] private DialogueData startDialogue;

    public override void EnterState(TutorialManager tutorialManager)
    {
        base.EnterState(tutorialManager);
        Dialogue.Instance.DisplayDialogue(startDialogue);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (!Dialogue.Instance.Active)
        {
            Debug.Log($"OperationTutorial: Dialogue finished, changing to next state.: {this.NextStateKey}");
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

using UnityEngine;

[CreateAssetMenu(fileName ="TestState",menuName ="TutorialState/TestState")]
public class TestState : TutorialState
{
    [SerializeField] private DialogueData dialogueData;

    public override void EnterState(TutorialManager tutorialManager)
    {
        base.EnterState(tutorialManager);

        Dialogue.Instance.DisplayDialogue(dialogueData);
    }

    public override void UpdateState() 
    {
    }

    public override void FixedUpdateState() 
    {
    }

    public override void LateUpdateState() 
    {
    }

    public override void ExitState() 
    {
    }
}

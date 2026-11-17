using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "OpeMove_Tutorial", menuName = "Tutorial/State/OpeMove_Tutorial")]
public class OpeMove_Tutorial : TutorialState
{
    [SerializeField] private DialogueData startDialogueData;
    [SerializeField] private DialogueData DialogueData_2;

    [SerializeField] private Vector2Int[] lightingTileCordinate;

    public override void EnterState(TutorialManager tutorialManager)
    {
        base.EnterState(tutorialManager);

        Dialogue.Instance.DisplayDialogue(startDialogueData);
        currentStep = TutorialStep.Step1;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        switch (currentStep)
        {
            case TutorialStep.Step1: // ダイアログ1が終了 -> ミッションの表示
                if (startDialogueData.IsFinished)
                {// ダイアログが消えて且つまだミッションを表示していないならミッションを表示する
                    Mission.Instance.DisplayMission("光っているマスに乗る");
                    HelpIcon.Instance.Move.gameObject.SetActive(true);
                    ChangeStep(TutorialStep.Step2);
                }
                break;

            case TutorialStep.Step2: // ミッションのクリア判定をチェック

                HelpIcon.Instance.Move.SetInput(tutorialManager.GetPlayerInputOsh().MoveValue, tutorialManager.GetPlayerInputMag().MoveValue);

                bool mag_OnTile = false;
                bool osh_OnTile = false;

                foreach (Vector2Int coordinate in lightingTileCordinate)
                {
                    FieldTile tile = FieldManager.Instance.GetFieldTile(coordinate);

                    if (tile != null)
                    {
                        tile.SetSpotLightMaterial();
                    }

                    var playerMag = tutorialManager.GetPlayerMag();
                    var playerOsh = tutorialManager.GetPlayerOsh();
                    if (tile != null && (playerMag.OnStandingPiece == tile))
                    {
                        mag_OnTile = true;
                    }
                    if(tile != null && (playerOsh.OnStandingPiece == tile))
                    {
                        osh_OnTile = true;
                    }
                }

                if(mag_OnTile && osh_OnTile)
                {
                    HelpIcon.Instance.Move.gameObject.SetActive(false);
                    ChangeStep(TutorialStep.Step3);
                }

                break;

            case TutorialStep.Step3: // ミッションをクリアしたらミッションを消す
                Mission.Instance.ClearMission();
                ChangeStep(TutorialStep.Step4);
                break;

            case TutorialStep.Step4: // ミッションのアニメーション終了チェック
                if (Mission.Instance.IsFinishedMission())
                {// ミッションがクリアされて且つミッションを表示していたなら次のステートに遷移する
                    Dialogue.Instance.DisplayDialogue(DialogueData_2);
                    ChangeStep(TutorialStep.Step5);
                }
                break;

            case TutorialStep.Step5:
                if(DialogueData_2.IsFinished)
                {
                    tutorialManager.ChangeState(this.NextStateKey);
                    ChangeStep(TutorialStep.Step6);
                }
                break;

            case TutorialStep.Step6:
                break;
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

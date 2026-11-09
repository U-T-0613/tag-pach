using UnityEngine;

public class TutorialState : ScriptableObject
{
    protected TutorialManager tutorialManager;

    public string Key { get; private set; }
    public string NextStateKey { get;  private set; }

    protected bool missionDisplayed = false;
    protected bool missionCleared = false;
    public void SetClear(bool cleared)
    {
        missionCleared = cleared;
    }


    public void SetKey(string key, string nextStateKey)
    {
        this.Key = key;
        this.NextStateKey = nextStateKey;
    }


    public virtual void EnterState(TutorialManager tutorialManager)
    {
        this.tutorialManager = tutorialManager;
        missionCleared = false;
    }

    public virtual void UpdateState(){}

    public virtual void FixedUpdateState(){}

    public virtual void LateUpdateState(){}

    public virtual void ExitState(){}
}

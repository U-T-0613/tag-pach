using UnityEngine;

public class TutorialState : ScriptableObject
{
    protected TutorialManager tutorialManager;

    public string Key { get; private set; }
    public string NextStateKey { get;  private set; }


    public void SetKey(string key, string nextStateKey)
    {
        this.Key = key;
        this.NextStateKey = nextStateKey;
    }


    public virtual void EnterState(TutorialManager tutorialManager)
    {
        this.tutorialManager = tutorialManager;
    }

    public virtual void UpdateState(){}

    public virtual void FixedUpdateState(){}

    public virtual void LateUpdateState(){}

    public virtual void ExitState(){}
}

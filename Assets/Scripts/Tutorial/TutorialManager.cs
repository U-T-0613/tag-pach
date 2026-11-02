using UnityEngine;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }

    [Header("Tutorial Setting")]
    [SerializeField] private TutorialStateList stateList;
    [SerializeField] private string initialStateKey;

    private TutorialState currentState;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;

        stateList.CreateRunTimeCopies();

    }

    private void OnDestroy()
    {
        stateList.DestroyRunTimeCopies();
    }

    void Start()
    {
        ChangeState(initialStateKey);
    }

    void Update()
    {
        currentState?.UpdateState();
    }
    
    void FixedUpdate()
    {
        currentState?.FixedUpdateState();
    }

    void LateUpdate()
    {
        currentState?.LateUpdateState();
    }

    public void ChangeState(string nextStateKey)
    {
        if(string.IsNullOrWhiteSpace(nextStateKey))
        {
            Debug.LogError("TutorialManager: nextStateKey is null or empty.");
            return;
        }
        if(!stateList.TryGetRuntimeState(nextStateKey, out var nextState))
        {
            Debug.LogError($"TutorialManager: nextStateKey '{nextStateKey}' is not found.");
            return;
        }
        
        if (currentState == nextState)
        {
            return;
        }

        currentState?.ExitState();
        currentState = nextState;
        currentState.EnterState(this);
        
    }
}

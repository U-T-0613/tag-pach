using UnityEngine;

public class HelpIcon : MonoBehaviour
{
    public static HelpIcon Instance { get; private set; }

    // インスタンス一覧
    [Header("Ref")]
    [SerializeField] private Help_Move move; public Help_Move Move => move;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        // 全非表示
        move.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        move = null;
    }
}
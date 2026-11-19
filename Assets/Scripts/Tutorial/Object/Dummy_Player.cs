using UnityEngine;

public class Dummy_Player : MonoBehaviour
{
    private Player attackedOwner = null;

    void Start()
    {
        attackedOwner = null;
    }


    public void HitAttack(Player owner)
    {
        attackedOwner = owner;
    }

    public Player GetAttackOwner()
    {
        return attackedOwner;
    }

}

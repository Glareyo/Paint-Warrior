using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{

    //Private Variables
    Animator anim;
    private PlayerInputController playerInputController;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerInputController = GetComponent<PlayerInputController>();
    }

    void Update()
    {
        if (playerInputController.MoveDirection == Vector2.zero)
        {
            TriggerIdle();
        }
        else
        {
            TriggerWalk();
        }
    }

    void TriggerWalk()
    {
        anim.SetTrigger("isWalking");
    }

    void TriggerIdle()
    {   
        anim.SetTrigger("isIdle");
    }
}

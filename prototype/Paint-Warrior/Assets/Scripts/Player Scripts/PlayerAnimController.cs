using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] Animator playerAnim;


    //Private Variables
    private PlayerInputController playerInputController;

    void Awake()
    {
        playerInputController = GetComponent<PlayerInputController>();
    }
    void Start()
    {
        
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
        playerAnim.SetTrigger("isWalking");
    }

    void TriggerIdle()
    {   
        playerAnim.SetTrigger("isIdle");
    }
}

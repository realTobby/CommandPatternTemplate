using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;

    public int DamageValue = 1;
    public int DefenseValue = 1;
    public float SpeedValue = 3f;

    public Vector2 moveDirection;

    public Vector2 CurrentMousePosition;

    private CommandExecuter cmdExecuter = new CommandExecuter();
    public bool canDash = true;
    public float dashCooldown = 3f;

    public DashState dashState = DashState.Ready;
    public float dashTimer;
    public float maxDash = 20f;
    public Vector2 savedVelocity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        RotateToMouse();
    }




    void RotateToMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        CurrentMousePosition = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void FixedUpdate()
    {
        
        Move();
    }

    /// <summary>
    /// Create a Command for ProcessingInputs and Moving the Player, encapsulate it from the PlayerBehaviour
    /// </summary>
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            cmdExecuter.ExecuteCommand(new Spell_Fireball(this.gameObject));
        }

        if(Input.GetKeyUp(KeyCode.Mouse1) && canDash == true)
        {
            cmdExecuter.ExecuteCommand(new Spell_Dash(this.gameObject));
            StartCoroutine(WaitForDash());
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * SpeedValue, moveDirection.y * SpeedValue);
    }

    /// <summary>
    ///  TODO: implement cooldown inside the Spell_Dash and not PlayerBehaviour
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitForDash()
    {
        dashCooldown = 3f;
        canDash = false;
        while(dashCooldown > 0f)
        {
            dashCooldown -= Time.deltaTime;
            yield return null;
        }
        canDash = true;
    }



}




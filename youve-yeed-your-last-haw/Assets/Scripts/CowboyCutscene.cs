using UnityEngine;

public class CowboyCutscene : MonoBehaviour
{
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        EventManager.CowboySlideEvent += this.CowboySlide;
    }

    void OnDisable()
    {
        EventManager.CowboySlideEvent -= this.CowboySlide;
    }

    public void StopSlide()
    {
        animator.enabled = false;
        EventManager.ChangeGameState(GameState.Draw);
    }

    public void CowboySlide()
    {
        animator.SetTrigger("Slide");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    private Animator animator;

    void Awake() 
    {
        animator = GetComponent<Animator>();    
    }

    public void LoadSelectedScene(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }

    public void OpenCredits() 
    {
        animator.SetBool("credits", true);
    }

    public void CloseCredits() 
    {
        animator.SetBool("credits", false);
    }
}

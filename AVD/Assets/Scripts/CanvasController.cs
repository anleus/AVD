using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public Animator titleAnimator;

    public void LoadSelectedScene(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }

    public void TitleAction()
    {
        titleAnimator.SetTrigger("touched");
    }
}

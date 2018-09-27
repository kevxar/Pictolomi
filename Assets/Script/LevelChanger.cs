using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    //Controller animator fade in/out
    public Animator animator;

    public int SceneId;
    /// <summary>
    /// Aplica animacion de fade para cambiar a la scene indicada
    /// </summary>
    public void ChangerFade()
    {
        animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(SceneId);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimationEnd : MonoBehaviour
{
    public void SetFlagFalse()
    {
        GetComponentInParent<LoadScene>().EndLoadingAnimation();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneController: MonoBehaviour
{
    public void Pause()
    {
        Application.LoadLevel("MainMenu");
    }
}



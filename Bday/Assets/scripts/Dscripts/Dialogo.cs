using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogo
{
    [TextArea(1, 10)]
    public string[] parrafos;
    public string[] nombres;
    public bool arriba;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : BaseUI
{
    // ������ UI�� Close ��� �ֱ� ������ �θ𿡼� ������־���.
    public void Close()
    {
        Manager.UI.ClosePopUpUI();
    }
}

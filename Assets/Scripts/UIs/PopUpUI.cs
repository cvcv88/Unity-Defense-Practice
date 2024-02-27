using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : BaseUI
{
    // 웬만한 UI는 Close 기능 있기 때문에 부모에서 만들어주었다.
    public void Close()
    {
        Manager.UI.ClosePopUpUI();
    }
}

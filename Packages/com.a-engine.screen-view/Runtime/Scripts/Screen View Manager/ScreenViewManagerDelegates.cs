using UnityEngine;

namespace AEngine
{
    public delegate void OpenScreenView(string screenView, ParamsData paramsData);
    public delegate void DeactivateScreenView();
    public delegate void CloseScreenView();
}
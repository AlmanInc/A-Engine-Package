using System;
using UnityEngine;

namespace AEngine
{
    public abstract class ScreenView : MonoBehaviour
    {
        [SerializeField] private GameObject screenViewPanel;

        private bool isInitialized;


        public abstract string Kind { get; }

        public bool IsActive { get; private set; }


        private void Awake()
        {
            if (!isInitialized)
            {
                Initialize();
                isInitialized = true;
            }
        }

        private void OnDestroy()
        {
            ScreenViewManager.OnOpenScreenView -= ActivateInvoke;
            ScreenViewManager.OnDeactivateScreenView -= DeactivateInvoke;
            ScreenViewManager.OnCloseScreenView -= CloseScreenView;
        }

        protected virtual void Initialize() 
        {
            ScreenViewManager.OnOpenScreenView += ActivateInvoke;
            ScreenViewManager.OnDeactivateScreenView += DeactivateInvoke;
            ScreenViewManager.OnCloseScreenView += CloseScreenView;
        }

        public virtual void Activate(ParamsData data)
        {
            if (screenViewPanel != null)
            {
                screenViewPanel.SetActive(true);
            }
        }

        public virtual void Deactivate() { }

        private void ActivateInvoke(string screenView, ParamsData paramsData)
        {
            if (!IsActive && screenView == Kind)
            {
                Activate(paramsData);
                IsActive = true;
            }
        }

        private void DeactivateInvoke()
        {
            if (IsActive)
            {
                Deactivate();
                IsActive = false;                
            }
        }

        private void CloseScreenView()
        {
            if (screenViewPanel != null)
            {
                screenViewPanel.SetActive(false);
            }
        }
    }
}
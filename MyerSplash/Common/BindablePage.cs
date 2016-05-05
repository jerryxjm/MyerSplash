﻿using JP.Utils.Framework;
using JP.Utils.Helper;
using System;
using System.Diagnostics;
using Windows.ApplicationModel.Core;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace MyerSplash.Common
{
    public class BindablePage : Page
    {
        public event EventHandler<KeyEventArgs> GlobalPageKeyDown;

        public BindablePage()
        {
            SetUpPageAnimation();
            SetUpNavigationCache();
            IsTextScaleFactorEnabled = false;
            this.Loaded += BindablePage_Loaded;
        }

        private void BindablePage_Loaded(object sender, RoutedEventArgs e)
        {
            if(this.DataContext is INavigable)
            {
                (this.DataContext as INavigable).OnLoaded();
            }
        }

        protected virtual void SetUpTitleBarExtend()
        {
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
        }

        protected virtual void SetUpPageAnimation()
        {
            TransitionCollection collection = new TransitionCollection();
            NavigationThemeTransition theme = new NavigationThemeTransition();

            NavigationTransitionInfo info;
            if (DeviceHelper.IsMobile)
            {
                info = new EntranceNavigationTransitionInfo();
            }
            else info = new ContinuumNavigationTransitionInfo();

            theme.DefaultNavigationTransitionInfo = info;
            collection.Add(theme);
            Transitions = collection;
        }

        protected virtual void SetUpNavigationCache()
        {
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected virtual void SetUpStatusBar()
        {

        }

        protected virtual void SetNavigationBackBtn()
        {
            if(this.Frame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        protected virtual void RegisterHandleBackLogic()
        {
            try
            {
                SystemNavigationManager.GetForCurrentView().BackRequested += BindablePage_BackRequested;
                if (ApiInformationHelper.HasHardwareButton)
                {
                    HardwareButtons.BackPressed += HardwareButtons_BackPressed;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        protected virtual void UnRegisterHandleBackLogic()
        {
            try
            {
                SystemNavigationManager.GetForCurrentView().BackRequested -= BindablePage_BackRequested;
                if (ApiInformationHelper.HasHardwareButton)
                {
                    HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame != null)
            {
                if (Frame.CanGoBack)
                {
                    e.Handled = true;
                    Frame.GoBack();
                }
            }
        }

        private void BindablePage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame != null)
            {
                if (Frame.CanGoBack)
                {
                    e.Handled = true;
                    Frame.GoBack();
                }
            }
        }

        /// <summary>
        /// 全局下按下按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            GlobalPageKeyDown(sender, args);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (DataContext is INavigable)
            {
                var NavigationViewModel = (INavigable)DataContext;
                if (NavigationViewModel != null)
                {
                    NavigationViewModel.Activate(e.Parameter);
                }
            }

            SetNavigationBackBtn();

            RegisterHandleBackLogic();

            Window.Current.SetTitleBar(null);

            //resolve global keydown
            if (GlobalPageKeyDown != null)
            {
                Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            }
            UmengSDK.UmengAnalytics.TrackPageStart(this.GetType().ToString());
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (DataContext is INavigable)
            {
                var NavigationViewModel = (INavigable)DataContext;
                if (NavigationViewModel != null)
                {
                    NavigationViewModel.Deactivate(null);
                }
            }
            UnRegisterHandleBackLogic();

            //resolve global keydown
            if (GlobalPageKeyDown != null)
            {
                Window.Current.CoreWindow.KeyDown -= CoreWindow_KeyDown;
            }
            UmengSDK.UmengAnalytics.TrackPageEnd(this.GetType().ToString());
        }
    }
}

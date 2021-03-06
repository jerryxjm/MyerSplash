﻿using JP.Utils.Helper;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyerSplash.UC
{
    public sealed partial class TitleBarControl : UserControl
    {
        public event Action OnClickBackBtn;

        public bool ShowBackBtn
        {
            get { return (bool)GetValue(ShowBackBtnProperty); }
            set { SetValue(ShowBackBtnProperty, value); }
        }

        public static readonly DependencyProperty ShowBackBtnProperty =
            DependencyProperty.Register("ShowBackBtn", typeof(bool), typeof(TitleBarControl),
                new PropertyMetadata(true, (sender, e) =>
                 {
                     if ((bool)e.NewValue)
                     {
                         (sender as TitleBarControl).BackBtn.Visibility = Visibility.Visible;
                     }
                     else
                     {
                         (sender as TitleBarControl).BackBtn.Visibility = Visibility.Collapsed;
                     }
                 }));

        public TitleBarControl()
        {
            this.InitializeComponent();
            if (DeviceHelper.IsDesktop)
            {
                if (DeviceHelper.IsDesktop)
                {
                    Window.Current.SetTitleBar(backGrdRect);
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            OnClickBackBtn?.Invoke();
        }
    }
}

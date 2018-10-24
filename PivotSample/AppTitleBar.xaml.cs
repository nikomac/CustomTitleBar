using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.ApplicationModel.Core;

namespace PivotSample
{
    public partial class AppTitleBar : UserControl
    {

        public AppTitleBar()
        {
            InitializeComponent();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            UpdateTitleBarLayout(coreTitleBar);

            // Set XAML element as a draggable region.
            Window.Current.SetTitleBar(TitleBarField);

            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;
            coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;
        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            UpdateTitleBarLayout(sender);
        }

        private void UpdateTitleBarLayout(CoreApplicationViewTitleBar coreTitleBar)
        {
            this.Height = coreTitleBar.Height;
        }

        private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            if (sender.IsVisible)
                this.Visibility = Visibility.Visible;
            else
                this.Visibility = Visibility.Collapsed;
            
        }


    }
}

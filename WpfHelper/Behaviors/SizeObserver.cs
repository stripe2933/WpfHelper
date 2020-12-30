using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfHelper.Behaviors
{
    /// <summary>
    /// Observe FrameworkElement's size changing.
    /// </summary>
    public class SizeObserver : DependencyObject
    {
        #region Attached Properties

        public static bool GetObserve(DependencyObject obj)
        {
            return (bool)obj.GetValue(ObserveProperty);
        }

        public static void SetObserve(DependencyObject obj, bool value)
        {
            obj.SetValue(ObserveProperty, value);
        }

        public static readonly DependencyProperty ObserveProperty =
            DependencyProperty.RegisterAttached("Observe", typeof(bool), typeof(SizeObserver), new PropertyMetadata(OnObserveChanged));

        private static void OnObserveChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is FrameworkElement target && target != null)
            {
                if ((bool)e.NewValue)
                {
                    target.SizeChanged += Target_SizeChanged;
                }
                else
                {
                    target.SizeChanged -= Target_SizeChanged;
                }
            }
        }

        public static double GetObservedWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(ObservedWidthProperty);
        }

        public static void SetObservedWidth(DependencyObject obj, double value)
        {
            obj.SetValue(ObservedWidthProperty, value);
        }

        public static readonly DependencyProperty ObservedWidthProperty =
            DependencyProperty.RegisterAttached("ObservedWidth", typeof(double), typeof(SizeObserver));


        public static double GetObservedHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(ObservedHeightProperty);
        }

        public static void SetObservedHeight(DependencyObject obj, double value)
        {
            obj.SetValue(ObservedHeightProperty, value);
        }

        public static readonly DependencyProperty ObservedHeightProperty =
            DependencyProperty.RegisterAttached("ObservedHeight", typeof(double), typeof(SizeObserver));

        #endregion

        private static void Target_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var dependencyObject = (DependencyObject)sender;
            if (e.WidthChanged)
            {
                SetObservedWidth(dependencyObject, e.NewSize.Width);
            }
            if (e.HeightChanged)
            {
                SetObservedHeight(dependencyObject, e.NewSize.Height);
            }
        }
    }
}

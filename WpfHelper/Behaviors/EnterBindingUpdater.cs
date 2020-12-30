using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace WpfHelper.Behaviors
{
    /// <summary>
    /// Update Binding of given DependencyProperty source when enter key pressed.
    /// </summary>
    public class EnterBindingUpdater : DependencyObject
    {
        #region DependencyProperty

        public static DependencyProperty GetBindingSource(DependencyObject obj)
        {
            return (DependencyProperty)obj.GetValue(BindingSourceProperty);
        }

        public static void SetBindingSource(DependencyObject obj, DependencyProperty value)
        {
            obj.SetValue(BindingSourceProperty, value);
        }

        public static readonly DependencyProperty BindingSourceProperty =
            DependencyProperty.RegisterAttached("BindingSource", typeof(DependencyProperty), typeof(EnterBindingUpdater), new PropertyMetadata(OnBindingSourceChanged));

        private static void OnBindingSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is UIElement element)
            {
                if (e.OldValue != null)
                {
                    element.PreviewKeyDown -= Target_PreviewKeyDown;
                }
                if (e.NewValue != null)
                {
                    element.PreviewKeyDown += new KeyEventHandler(Target_PreviewKeyDown);
                }
            }
        }

        #endregion

        private static void Target_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UpdateBindingSource(e.Source);
            }
        }

        private static void UpdateBindingSource(object source)
        {
            if (GetBindingSource(source as DependencyObject) is DependencyProperty property &&
                source is UIElement element &&
                BindingOperations.GetBindingExpression(element, property) is BindingExpression binding)
            {
                binding.UpdateSource();
            }
        }
    }
}

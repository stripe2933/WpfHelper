using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WpfHelper.Controls
{
    //public class DropDownButton : ToggleButton
    //{
    //    #region Dependency Properties

    //    public UIElement DropDownContent
    //    {
    //        get { return (UIElement)GetValue(DropDownContentProperty); }
    //        set { SetValue(DropDownContentProperty, value); }
    //    }

    //    public static readonly DependencyProperty DropDownContentProperty =
    //        DependencyProperty.Register("DropDownContent", typeof(UIElement), typeof(DropDownButton));

    //    #endregion

    //    public override void OnApplyTemplate()
    //    {
    //        base.OnApplyTemplate();
            
    //        var border = (Border)GetTemplateChild("border");
    //        border.MouseLeftButtonDown += (s, e) =>
    //        {
    //            IsChecked = !IsChecked;
    //            e.Handled = true;
    //        };

    //        var dropDownContent = (ContentControl)GetTemplateChild("dropDownContent");
    //        dropDownContent.MouseLeftButtonDown += (s, e) =>
    //        {
    //            IsChecked = false;
    //        };
    //    }

    //    public DropDownButton()
    //    {
    //    }

    //    static DropDownButton()
    //    {
    //        DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownButton), new FrameworkPropertyMetadata(typeof(DropDownButton)));
    //    }
    //}
}

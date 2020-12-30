using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfHelper.Controls
{
    public class NumericUpDown : Control
    {
        #region Dependency Properties

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(NumericUpDown), new PropertyMetadata(100));

        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0, OnValuePropertyChanged));

        private static void OnValuePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var numericUpDown = obj as NumericUpDown;
            if (numericUpDown == null)
            {
                return;
            }

            numericUpDown.ValueChanged.Invoke(numericUpDown, EventArgs.Empty);
        }

        public int Increment
        {
            get { return (int)GetValue(IncrementProperty); }
            set { SetValue(IncrementProperty, value); }
        }

        public static readonly DependencyProperty IncrementProperty =
            DependencyProperty.Register("Increment", typeof(int), typeof(NumericUpDown), new PropertyMetadata(1));

        #endregion

        #region Commands

        public ICommand IncreaseValueCommand { get; set; }
        private void IncreaseValue()
        {
            Value += Increment;
        }
        private bool CanIncreaseValue()
        {
            return Value + Increment <= Maximum;
        }

        public ICommand DecreaseValueCommand { get; set; }
        private void DecreaseValue()
        {
            Value -= Increment;
        }
        private bool CanDecreaseValue()
        {
            return Value - Increment >= Minimum;
        }

        #endregion

        #region Events

        public event EventHandler ValueChanged;

        #endregion

        public NumericUpDown()
        {
            IncreaseValueCommand = new Commands.RelayCommand(IncreaseValue, CanIncreaseValue);
            DecreaseValueCommand = new Commands.RelayCommand(DecreaseValue, CanDecreaseValue);
        }

        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }
    }
}

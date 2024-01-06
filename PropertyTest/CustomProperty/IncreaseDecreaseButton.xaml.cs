﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YukkuriMovieMaker.Commons;

namespace PropertyTest.CustomProperty
{
    /// <summary>
    /// UserControl1.xaml の相互作用ロジック
    /// </summary>
    public partial class IncreaseDecreaseButton : UserControl, IPropertyEditorControl
    {
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(int), typeof(IncreaseDecreaseButton), new PropertyMetadata(0));

        public event EventHandler? BeginEdit;
        public event EventHandler? EndEdit;

        public ICommand IncreaseCommand { get; }
        public ICommand DecreaseCommand { get; }

        public IncreaseDecreaseButton()
        {
            InitializeComponent();

            IncreaseCommand = new ActionCommand(
                _ => true,
                _ =>
                {
                    //値の変更前にBeginEdit、変更後にEndEditを呼ぶ
                    BeginEdit?.Invoke(this, EventArgs.Empty);
                    Value++;
                    EndEdit?.Invoke(this, EventArgs.Empty);
                });
            DecreaseCommand = new ActionCommand(
                _ => true,
                _ =>
                {
                    //値の変更前にBeginEdit、変更後にEndEditを呼ぶ
                    BeginEdit?.Invoke(this, EventArgs.Empty);
                    Value--;
                    EndEdit?.Invoke(this, EventArgs.Empty);
                });
        }
    }
}

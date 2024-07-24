using System.Windows.Input;

namespace App.Controls.Buttons;

public partial class Tag : ContentView
{
	#region properties

	public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Tag), string.Empty, BindingMode.OneTime);

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}

	public static readonly BindableProperty AccessibilityHelpTextProperty = BindableProperty.Create(nameof(AccessibilityHelpText), typeof(string), typeof(Tag), string.Empty, BindingMode.OneTime);
	public string AccessibilityHelpText
	{
		get => (string)GetValue(AccessibilityHelpTextProperty);
		set => SetValue(AccessibilityHelpTextProperty, value);
	}

	#endregion properties

	#region Events

	public event EventHandler? Clicked;

	#endregion Events

	public Tag()
	{
		InitializeComponent();
	}

	void StateButton_Clicked(object sender, EventArgs e)
	{
		Clicked?.Invoke(this, EventArgs.Empty);
	}
}
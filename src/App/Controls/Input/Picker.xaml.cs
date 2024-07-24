using System.Collections;
using Microsoft.Maui.Handlers;

namespace App.Controls.Inputs;

public partial class Picker : ContentView
{
	#region properties

	public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(Picker), string.Empty, BindingMode.OneTime);

	public string Title
	{
		get => (string)GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}

	public static readonly BindableProperty ShowTitleLabelProperty = BindableProperty.Create(nameof(ShowTitleLabel), typeof(bool), typeof(Picker), true, BindingMode.OneTime);

	public bool ShowTitleLabel
	{
		get => (bool)GetValue(ShowTitleLabelProperty);
		set => SetValue(ShowTitleLabelProperty, value);
	}

	public static readonly BindableProperty IsEnabledPickerProperty = BindableProperty.Create(nameof(IsEnabledPicker), typeof(bool), typeof(Picker), true);

	public bool IsEnabledPicker
	{
		get => (bool)GetValue(IsEnabledPickerProperty);
		set => SetValue(IsEnabledPickerProperty, value);
	}

	public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(Picker), null, BindingMode.OneWay);

	public IList ItemsSource
	{
		get => (IList)GetValue(ItemsSourceProperty);
		set => SetValue(ItemsSourceProperty, value);
	}

	public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(Picker), -1, BindingMode.TwoWay);

	public int SelectedIndex
	{
		get => (int)GetValue(SelectedIndexProperty);
		set => SetValue(SelectedIndexProperty, value);
	}

	public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(Picker), default, BindingMode.TwoWay);

	public object SelectedItem
	{
		get => GetValue(SelectedItemProperty);
		set => SetValue(SelectedItemProperty, value);
	}

	// TODO: Is this needed?
	public BindingBase ItemDisplayBinding
	{
		get => PickerControl.ItemDisplayBinding;
		set => PickerControl.ItemDisplayBinding = value;
	}

	public static readonly BindableProperty ErrorsProperty = BindableProperty.Create(nameof(Errors), typeof(ICollection<string>), typeof(Picker), new List<string>(), BindingMode.TwoWay, null, HandleBindingPropertyChangedDelegate);
	public ICollection<string> Errors
	{
		get => (ICollection<string>)GetValue(ErrorsProperty);
		set => SetValue(ErrorsProperty, value);
	}

	#endregion properties

	#region Events

	public event EventHandler? SelectedIndexChanged;

	#endregion Events

	public Picker()
	{
		InitializeComponent();
	}

	void Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		SelectedIndexChanged?.Invoke(this, e);
	}

	void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
	{
#if ANDROID
		if(PickerControl.Handler is IPickerHandler handler)
		{
			handler.PlatformView.PerformClick();
		}
#else
		if(PickerControl is IView view)
		{
			view.IsFocused = false;
		}
		PickerControl.Focus();
#endif
	}

	static void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
	{
		if(bindable is not Picker control)
		{
			return;
		}

		if(control.Errors.Count > 0)
		{
			control.PickerBorder.SetDynamicResource(Border.StrokeProperty, "WarningColor");
		}
		else
		{
			control.PickerBorder.SetDynamicResource(Border.StrokeProperty, "UnfocusedColour");
		}
	}
}
---------------------------------------------------------
------ Xam.Plugin.Validators ----------------------------
---------------------------------------------------------

To use this package, declare the following in the following namespace in in your .xaml file:-

	xmlns:v="clr-namespace:Xam.Plugin.Validators;assembly=Xam.Plugin.Validators"

The add the validators to your entries as attached properties:-

	<Entry Text="{Binding Name}" 
			v:Validation.Validator="{v:Validator Type=EntryRequired, IsValid={Binding IsNameValid, Mode=OneWayToSource}, ErrorLabel={Reference NameInvalid} }"
			/>

and add an optional label to display the error message:-

	<Label x:Name="NameInvalid" Text="Please enter a name" TextColor="Red" HorizontalOptions="Center" />

Finally, the Xam.Plugin.Validators must be loaded at runtime. Either add the line

	[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

to your AssemblyInfo.cs file to make Xamarin compile the xaml at build time (which in my opinion is by far the best appeoach),
or add:-

	Validation.Init();

to the constructor of the app. e.g.

	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			Validation.Init();

			MainPage = new MainPage { BindingContext = new MainPageViewModel () };
		}

		...

I would really appreciate any feedback on how to make this plugin more useful. Just raise an issue on GutHub and I'll try and accommodate your request.

Cheers

Jason

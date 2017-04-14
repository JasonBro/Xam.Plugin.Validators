using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Xam.Plugin.Validators
{
	/// <summary>
	/// Class CompareEntryValidator.
	/// </summary>
	/// <seealso cref="AtYourDoor.ClientApp.Validators.EntryValidatorBase" />
	[Preserve(AllMembers = true)]
	public class CompareEntryValidator : EntryValidatorBase
	{
		/// <summary>
		/// The compare value property
		/// </summary>
		public static readonly BindableProperty CompareValueProperty = BindableProperty.Create("CompareValue", typeof(string), typeof(CompareEntryValidator), default(string), propertyChanged: OnCompareValuePropertyChanged);

		/// <summary>
		/// Called when the compare value property changes.
		/// </summary>
		/// <param name="bindable">The bindable.</param>
		/// <param name="oldValue">The old value.</param>
		/// <param name="newValue">The new value.</param>
		static void OnCompareValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			// revalidate the entry
			ValidateEntry(bindable as CompareEntryValidator);
		}

		/// <summary>
		/// Gets or sets the compare value.
		/// </summary>
		/// <value>The compare value.</value>
		public string CompareValue
		{
			get { return (string)base.GetValue(CompareValueProperty); }
			set { base.SetValue(CompareValueProperty, value); }
		}


		/// <summary>
		/// Validates the text.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <returns><c>true</c> if the text matches the CompareValue, <c>false</c> otherwise.</returns>
		protected override bool ValidateText(string text)
		{
			return (text == CompareValue);
		}
	}
}

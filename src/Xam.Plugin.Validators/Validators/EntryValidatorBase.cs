using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Xam.Plugin.Validators
{
	/// <summary>
	/// Class EntryValidatorBase.
	/// </summary>
	[Preserve(AllMembers = true)]
	public abstract class EntryValidatorBase : ValidatorBase<Entry>
	{
		/// <summary>
		/// Gets or sets the error label.
		/// </summary>
		/// <value>The error label.</value>
		public Label ErrorLabel { get; set; }

		/// <summary>
		/// Returns the object created from the markup extension.
		/// </summary>
		/// <param name="serviceProvider">The service provider.</param>
		/// <returns>The validator</returns>
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			// set the label
			if (ErrorLabel != null)
			{
				ErrorLabel.BindingContext = this;
				ErrorLabel.SetBinding(Label.IsVisibleProperty, "DisplayErrorMessage");
			}

			return this;
		}


		/// <summary>
		/// The update display
		/// </summary>
		bool updateDisplay;

		/// <summary>
		/// Attaches to the superclass and then calls the <see cref="M:Xamarin.Forms.Behavior`1.OnAttachedTo(T)" /> method on this object.
		/// </summary>
		/// <param name="bindable">To be added.</param>
		/// <remarks>To be added.</remarks>
		protected override void OnAttachedTo(Entry bindable)
		{
			if (bindable != null)
			{
				bindable.TextChanged += HandleTextChanged;
				bindable.Unfocused += Entry_Unfocused;
			}
		}

		/// <summary>
		/// Calls the <see cref="M:Xamarin.Forms.Behavior`1.OnDetachingFrom(T)" /> method and then detaches from the superclass.
		/// </summary>
		/// <param name="bindable">To be added.</param>
		/// <remarks>To be added.</remarks>
		protected override void OnDetachingFrom(Entry bindable)
		{
			if (bindable != null)
			{
				bindable.TextChanged -= HandleTextChanged;
				bindable.Unfocused -= Entry_Unfocused;
			}
		}

		/// <summary>
		/// Handles the text changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
		void HandleTextChanged(object sender, TextChangedEventArgs e)
		{
			var entry = sender as Entry;
			CallValidateEntry(entry);
		}

		/// <summary>
		/// Handles the Unfocused event of the Entry control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="FocusEventArgs"/> instance containing the event data.</param>
		void Entry_Unfocused(object sender, FocusEventArgs e)
		{
			var entry = sender as Entry;
			updateDisplay = true;
			CallValidateEntry(entry);
		}

		/// <summary>
		/// Validates the entry.
		/// </summary>
		/// <param name="entryValidatorBase">The entry validator base.</param>
		protected static void ValidateEntry(EntryValidatorBase entryValidatorBase)
		{
			entryValidatorBase.CallValidateEntry(entryValidatorBase.AttachedObject);
		}

		/// <summary>
		/// Calls the validate entry.
		/// </summary>
		/// <param name="entry">The entry.</param>
		void CallValidateEntry(Entry entry)
		{
			var text = entry.Text ?? String.Empty;

			IsValid = ValidateText(text);
			DisplayErrorMessage = !IsValid && updateDisplay;

			entry.TextColor = (!DisplayErrorMessage || IsValid) ? Color.Default : Color.Red;
		}

		/// <summary>
		/// Validates the text.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <returns><c>true</c> if the text is valid, <c>false</c> otherwise.</returns>
		protected abstract bool ValidateText(string text);
	}
}

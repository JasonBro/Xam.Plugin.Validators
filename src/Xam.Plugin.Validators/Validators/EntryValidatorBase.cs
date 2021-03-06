﻿using System;
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
		/// The previous color
		/// </summary>
		Color _previousColor;

		/// <summary>
		/// The previous style
		/// </summary>
		Style _previousStyle;

		/// <summary>
		/// Should we update the display to show the error condition
		/// </summary>
		bool _updateDisplay;

		/// <summary>
		/// The error color property
		/// </summary>
		public static readonly BindableProperty ErrorColorProperty = BindableProperty.Create("ErrorColor", typeof(Color), typeof(EntryValidatorBase), Color.Red);

		/// <summary>
		/// Gets or sets the error label.
		/// </summary>
		/// <value>The error label.</value>
		public Label ErrorLabel { get; set; }

		/// <summary>
		/// Gets or sets the color of the error.
		/// </summary>
		/// <value>The color of the error.</value>
		public Color ErrorColor
		{
			get { return (Color)base.GetValue(ErrorColorProperty); }
			set { base.SetValue(ErrorColorProperty, value); }
		}

		/// <summary>
		/// Returns the object created from the markup extension.
		/// </summary>
		/// <param name="serviceProvider">The service provider.</param>
		/// <returns>The validator</returns>
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			//// set the label
			if (ErrorLabel != null)
			{
				ErrorLabel.IsVisible = false;
			}

			return this;
		}



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

				_previousColor = bindable.TextColor;
				_previousStyle = bindable.Style;
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

				bindable.TextColor = _previousColor;
				bindable.Style = _previousStyle;
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
			_updateDisplay = true;
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
			DisplayErrorMessage = !IsValid && _updateDisplay;

			// use the style if we have one
			if (ErrorStyle != null)
			{
				entry.Style = (!DisplayErrorMessage || IsValid) ? _previousStyle : ErrorStyle;
			}
			else
			{
				// otherwise use the color
				entry.TextColor = (!DisplayErrorMessage || IsValid) ? _previousColor : ErrorColor;
			}

			if (ErrorLabel != null)
			{
				ErrorLabel.IsVisible = DisplayErrorMessage;
			}

		}

		/// <summary>
		/// Validates the text.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <returns><c>true</c> if the text is valid, <c>false</c> otherwise.</returns>
		protected abstract bool ValidateText(string text);
	}
}

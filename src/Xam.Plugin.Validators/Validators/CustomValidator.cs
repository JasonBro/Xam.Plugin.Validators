using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam.Plugin.Validators
{
	public class CustomValidator : EntryValidatorBase
	{
		/// <summary>
		/// The validation function property
		/// </summary>
		public static readonly BindableProperty ValidationFunctionProperty = BindableProperty.Create("ValidationFunction", typeof(Func<string, bool>), typeof(CustomValidator), null);

		/// <summary>
		/// Gets or sets the validation function.
		/// </summary>
		/// <value>The validation function.</value>
		public Func<string, bool> ValidationFunction
		{
			get { return (Func<string, bool>)base.GetValue(ValidationFunctionProperty); }
			set { base.SetValue(ValidationFunctionProperty, value); }
		}

		/// <summary>
		/// Validates the text.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <returns><c>true</c> if the text is valid, <c>false</c> otherwise.</returns>
		/// <exception cref="System.NotImplementedException"></exception>
		protected override bool ValidateText(string text)
		{
			// call the function if we have one, otherwise. if there is no predicate, then the text is valid
			return ValidationFunction?.Invoke(text) ?? true;
		}
	}
}

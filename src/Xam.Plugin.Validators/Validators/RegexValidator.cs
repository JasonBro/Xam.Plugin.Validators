using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam.Plugin.Validators
{
	/// <summary>
	/// Class RegexValidator.
	/// </summary>
	/// <seealso cref="AtYourDoor.ClientApp.Validators.EntryValidatorBase" />
	public class RegexValidator : EntryValidatorBase
	{
		/// <summary>
		/// The validation expression property
		/// </summary>
		public static readonly BindableProperty ValidationExpressionProperty = BindableProperty.Create("ValidationExpression", typeof(string), typeof(RegexValidator), default(string));

		/// <summary>
		/// Gets or sets the validation expression.
		/// </summary>
		/// <value>The validation expression.</value>
		public string ValidationExpression
		{
			get { return (string)base.GetValue(ValidationExpressionProperty); }
			set { base.SetValue(ValidationExpressionProperty, value); }
		}

		/// <summary>
		/// Validates the text.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <returns><c>true</c> if the text is valid, <c>false</c> otherwise.</returns>
		protected override bool ValidateText(string text)
		{
			// get the current value
			string validationExpression = ValidationExpression;

			return String.IsNullOrEmpty(validationExpression) || (Regex.IsMatch(text, validationExpression, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
		}
	}
}

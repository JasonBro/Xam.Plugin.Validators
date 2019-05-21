using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Xam.Plugin.Validators
{
	/// <summary>
	/// Class EditorRegexValidator.
	/// </summary>
	/// <seealso cref="Xam.Plugin.Validators.EditorRegexValidator" />
	[Preserve(AllMembers = true)]
	public class EditorRegexValidator : EditorValidatorBase
	{
		/// <summary>
		/// The validation expression property
		/// </summary>
		public static readonly BindableProperty RegexProperty = BindableProperty.Create("Regex", typeof(string), typeof(EditorRegexValidator), default(string));

		/// <summary>
		/// Gets or sets the validation regex.
		/// </summary>
		/// <value>The regex.</value>
		public string Regex
		{
			get { return (string)base.GetValue(RegexProperty); }
			set { base.SetValue(RegexProperty, value); }
		}

		/// <summary>
		/// Validates the text.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <returns><c>true</c> if the text is valid, <c>false</c> otherwise.</returns>
		protected override bool ValidateText(string text)
		{
			// get the current value
			string validationExpression = Regex;

			return String.IsNullOrEmpty(validationExpression) || (System.Text.RegularExpressions.Regex.IsMatch(text, validationExpression, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
		}
	}
}

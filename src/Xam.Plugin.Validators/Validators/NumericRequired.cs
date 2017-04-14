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
	/// Class NumericRequired.
	/// </summary>
	/// <seealso cref="AtYourDoor.ClientApp.Validators.EntryValidatorBase" />
	[Preserve(AllMembers = true)]
	public class NumericRequired : EntryValidatorBase
	{
		/// <summary>
		/// Validates the text.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <returns><c>true</c> if the text is valid, <c>false</c> otherwise.</returns>
		protected override bool ValidateText(string text)
		{
			double value;
			return !String.IsNullOrWhiteSpace(text) && double.TryParse(text, out value);
		}
	}
}

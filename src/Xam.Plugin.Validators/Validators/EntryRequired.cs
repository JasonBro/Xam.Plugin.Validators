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
	/// Class EntryRequired.
	/// </summary>
	/// <seealso cref="AtYourDoor.ClientApp.Validators.EntryValidatorBase" />
	[Preserve(AllMembers = true)]
	public class EntryRequired : EntryValidatorBase, IMarkupExtension
	{
		/// <summary>
		/// Returns the object created from the markup extension.
		/// </summary>
		/// <param name="serviceProvider">The service provider.</param>
		/// <returns>The validator</returns>
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return base.ProvideValue(serviceProvider);
		}

		/// <summary>
		/// Validates the text.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <returns><c>true</c> if the text is valid, <c>false</c> otherwise.</returns>
		protected override bool ValidateText(string text)
		{
			return !String.IsNullOrWhiteSpace(text);
		}
	}
}

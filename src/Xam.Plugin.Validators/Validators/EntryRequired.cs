﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam.Plugin.Validators
{
	/// <summary>
	/// Class EntryRequired.
	/// </summary>
	/// <seealso cref="AtYourDoor.ClientApp.Validators.EntryValidatorBase" />
	public class EntryRequired : EntryValidatorBase
	{
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

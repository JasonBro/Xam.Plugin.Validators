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
	/// Class that implements the Validator attached property.
	/// </summary>
	[Preserve(AllMembers = true)]
	public class Validation
	{
		/// <summary>
		/// The validator attached property
		/// </summary>
		public static readonly BindableProperty ValidatorProperty = BindableProperty.CreateAttached("Validator", typeof(Behavior), typeof(Validation), null, propertyChanged: OnValidatorChanged);

		/// <summary>
		/// Initializes the Validation framework.
		/// </summary>
		public static void Init()
		{
			// don;t do anything - this is just for the linker to load this assembly for use with reflection
		}

		/// <summary>
		/// Called when the validator is changed.
		/// </summary>
		/// <param name="bindable">The bindable.</param>
		/// <param name="oldValue">The old value.</param>
		/// <param name="newValue">The new value.</param>
		static void OnValidatorChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (newValue != null)
			{
				if (newValue == null)
				{
					throw new InvalidOperationException($"Unable to add a null validator");
				}

				if (!(newValue is Behavior))
				{
					throw new InvalidOperationException($"Validators must be derived from Behavior");
				}

				var visualElement = bindable as VisualElement;
				visualElement.Behaviors.Add(newValue as Behavior);
			}
		}

		/// <summary>
		/// Gets the validator.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <returns>System.Object.</returns>
		public static Behavior GetValidator(BindableObject view)
		{
			return view.GetValue(ValidatorProperty) as Behavior;
		}

		/// <summary>
		/// Sets the validator.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="value">The value.</param>
		public static void SetValidator(BindableObject view, Behavior value)
		{
			view.SetValue(ValidatorProperty, value);
		}
	}
}

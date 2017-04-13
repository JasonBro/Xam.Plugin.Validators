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
	/// Class that implements the Validator markup extension.
	/// </summary>
	/// <seealso cref="Xamarin.Forms.Xaml.IMarkupExtension" />
	[Preserve(AllMembers = true)]
	public class Validator : IMarkupExtension
	{
		/// <summary>
		/// Gets or sets the type of validator.
		/// </summary>
		/// <value>The type.</value>
		public string Type { get; set; }

		/// <summary>
		/// The binding to a a boolean variable that is set to indicate whether this entry is valid or not.
		/// </summary>
		/// <value>The is valid.</value>
		public BindingBase IsValid { get; set; }

		/// <summary>
		/// Gets or sets the error label.
		/// </summary>
		/// <value>The error label.</value>
		public Label ErrorLabel { get; set; }

		/// <summary>
		/// Gets or sets the validation expression.
		/// </summary>
		/// <value>The validation expression.</value>
		public object ValidationExpression { get; set; }

		/// <summary>
		/// Gets or sets the validation function.
		/// </summary>
		/// <value>The validation function.</value>
		public Func<string, bool> ValidationFunction { get; set; }

		/// <summary>
		/// Gets or sets the compare value.
		/// </summary>
		/// <value>The compare value.</value>
		public object CompareValue { get; set; }

		/// <summary>
		/// Returns the object created from the markup extension.
		/// </summary>
		/// <param name="serviceProvider">To be added.</param>
		/// <returns>The object</returns>
		public virtual object ProvideValue(IServiceProvider serviceProvider)
		{
			// create the validator
			var validator = ValidatorFactory(Type);

			// have we created a validator, if not, return null so that a subclass could have a go
			if (validator == null)
			{
				return null;
			}

			// set the IsValid property
			if (IsValid != null)
			{
				validator.SetBinding(EntryRequired.IsValidProperty, IsValid);
			}

			// set the label
			if (ErrorLabel != null)
			{
				ErrorLabel.BindingContext = validator;
				ErrorLabel.SetBinding(Label.IsVisibleProperty, "DisplayErrorMessage");
			}

			// and return the validator
			return validator;
		}

		/// <summary>
		/// Creates a validator.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>The validator Behavior.</returns>
		/// <exception cref="System.InvalidOperationException">
		/// </exception>
		protected virtual Behavior ValidatorFactory(string type)
		{
			switch (type)
			{
				case "EntryRequired":
					return new EntryRequired();

				case "NumericRequired":
					return new NumericRequired();

				case "Regex":
					var regexValidator = new RegexValidator();

					if (ValidationExpression != null)
					{
						if (ValidationExpression is BindingBase)
						{
							regexValidator.SetBinding(RegexValidator.ValidationExpressionProperty, ValidationExpression as BindingBase);
						}
						else if (ValidationExpression is string)
						{
							regexValidator.ValidationExpression = ValidationExpression as string;
						}
						else
						{
							throw new InvalidOperationException($"Unknown ValidationExpression {CompareValue}");
						}
					}
					return regexValidator;

				case "Custom":
					return new CustomValidator() { ValidationFunction = ValidationFunction };

				case "CompareEntry":
					var compareEntryValidator = new CompareEntryValidator();
					if (CompareValue != null)
					{
						if (CompareValue is BindingBase)
						{
							compareEntryValidator.SetBinding(CompareEntryValidator.CompareValueProperty, CompareValue as BindingBase);
						}
						else if (CompareValue is string)
						{
							compareEntryValidator.CompareValue = CompareValue as string;
						}
						else
						{
							throw new InvalidOperationException($"Unknown CompareValue {CompareValue}");
						}
					}
					return compareEntryValidator;

				default:
					throw new InvalidOperationException($"Unknown validator {type}");
			}
		}
	}
}

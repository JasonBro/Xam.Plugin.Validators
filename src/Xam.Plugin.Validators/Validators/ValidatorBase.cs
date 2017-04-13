using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam.Plugin.Validators
{
	/// <summary>
	/// Class ValidatorBase.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="Xamarin.Forms.Behavior{T}" />
	public abstract class ValidatorBase<T> : Behavior<T> where T : BindableObject
	{
		// add bindable properties
		/// <summary>
		/// The is valid property key
		/// </summary>
		static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EntryRequired), false);
		/// <summary>
		/// The is valid property
		/// </summary>
		public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

		/// <summary>
		/// The display error message property key
		/// </summary>
		static readonly BindablePropertyKey DisplayErrorMessagePropertyKey = BindableProperty.CreateReadOnly("DisplayErrorMessage", typeof(bool), typeof(RegexValidator), false);
		/// <summary>
		/// The display error message property
		/// </summary>
		public static readonly BindableProperty DisplayErrorMessageProperty = DisplayErrorMessagePropertyKey.BindableProperty;

		/// <summary>
		/// Gets the attached object.
		/// </summary>
		/// <value>The attached object.</value>
		protected T AttachedObject { get; private set; }

		/// <summary>
		/// Accesses the IsValid bindable property.
		/// </summary>
		/// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
		public bool IsValid
		{
			get { return (bool)base.GetValue(IsValidProperty); }
			protected set { base.SetValue(IsValidPropertyKey, value); }
		}

		/// <summary>
		/// Accesses the DisplayErrorMessage bindable property.
		/// </summary>
		/// <value><c>true</c> if we should display an error message; otherwise, <c>false</c>.</value>
		public bool DisplayErrorMessage
		{
			get { return (bool)base.GetValue(DisplayErrorMessageProperty); }
			protected set { base.SetValue(DisplayErrorMessagePropertyKey, value); }
		}

		// handle binding context changes
		/// <summary>
		/// Called when this behavior is attached.
		/// </summary>
		/// <param name="bindable">The bindable.</param>
		protected override void OnAttachedTo(BindableObject bindable)
		{
			base.OnAttachedTo(bindable);
			AttachedObject = bindable as T;

			bindable.BindingContextChanged += Bindable_BindingContextChanged;
			BindingContext = bindable.BindingContext;
		}

		/// <summary>
		/// Called when the behaviour is detached.
		/// </summary>
		/// <param name="bindable">The bindable.</param>
		protected override void OnDetachingFrom(BindableObject bindable)
		{
			bindable.BindingContextChanged -= Bindable_BindingContextChanged;

			base.OnDetachingFrom(bindable);
			AttachedObject = null;
		}

		/// <summary>
		/// Handles the BindingContextChanged event of the Bindable control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void Bindable_BindingContextChanged(object sender, EventArgs e)
		{
			var bindable = sender as BindableObject;
			if (bindable != null)
			{
				BindingContext = bindable.BindingContext;
			}
		}
	}
}

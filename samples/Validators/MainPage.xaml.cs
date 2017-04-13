using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Validators
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnBindingContextChanged()
		{
			var bindingContext = this.BindingContext;

			WalkContent(this.Content);

			base.OnBindingContextChanged();
		}

		void WalkContent(View view)
		{
			var viewContainer = view as IViewContainer<View>;

			if (viewContainer != null)
			{
				foreach (var childView in viewContainer.Children)
				{
					WalkContent(childView);
				}
			}
		}
	}
}

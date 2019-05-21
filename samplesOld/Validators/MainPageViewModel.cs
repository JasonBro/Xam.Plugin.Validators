using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
	/// <summary>
	/// Class MainPageViewModel.
	/// </summary>
	/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
	public class MainPageViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// The email regex
		/// </summary>
		public const string _emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
			@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";


		/// <summary>
		/// Gets or sets the email regex.
		/// </summary>
		/// <value>The email regex.</value>
		public string EmailRegex { get { return _emailRegex; } }


		/// <summary>
		/// Gets the custom validate function.
		/// </summary>
		/// <value>The custom validate.</value>
		public Func<string, bool> CustomValidate
		{
			get
			{
				// Only valid it the text equals Hello
				return (text) => text == "Hello";
			}
		}


		/// <summary>
		/// Is the password valid
		/// </summary>
		bool _isPasswordValid;

		/// <summary>
		/// Gets or sets a value indicating whether this password is valid.
		/// </summary>
		/// <value><c>true</c> if this password is valid; otherwise, <c>false</c>.</value>
		public bool IsPasswordValid
		{
			get { return _isPasswordValid; }
			set
			{
				if (_isPasswordValid != value)
				{
					_isPasswordValid = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsPasswordValid"));
				}
			}
		}

		/// <summary>
		/// Is the name valid
		/// </summary>
		bool _isNameValid;

		/// <summary>
		/// Gets or sets a value indicating whether this instance is name valid.
		/// </summary>
		/// <value><c>true</c> if this instance is name valid; otherwise, <c>false</c>.</value>
		public bool IsNameValid
		{
			get { return _isNameValid; }
			set
			{
				if (_isNameValid != value)
				{
					_isNameValid = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsNameValid"));
				}
			}
		}

		/// <summary>
		/// Is the age valid
		/// </summary>
		bool _isAgeValid;

		/// <summary>
		/// Gets or sets a value indicating whether the age is valid.
		/// </summary>
		/// <value><c>true</c> if the age is valid; otherwise, <c>false</c>.</value>
		public bool IsAgeValid
		{
			get { return _isAgeValid; }
			set
			{
				if (_isAgeValid != value)
				{
					_isAgeValid = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsAgeValid"));
				}
			}
		}

		/// <summary>
		/// The is email valid
		/// </summary>
		bool _isEmailValid;

		/// <summary>
		/// Gets or sets a value indicating whether this instance is email valid.
		/// </summary>
		/// <value><c>true</c> if this instance is email valid; otherwise, <c>false</c>.</value>
		public bool IsEmailValid
		{
			get { return _isEmailValid; }
			set
			{
				if (_isEmailValid != value)
				{
					_isEmailValid = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEmailValid"));
				}
			}
		}

		/// <summary>
		/// The email
		/// </summary>
		public string _email;

		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>The email.</value>
		public string Email
		{
			get { return _email; }
			set
			{
				if (_email != value)
				{
					_email = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
				}
			}
		}

		/// <summary>
		/// The Name
		/// </summary>
		public string _name;

		/// <summary>
		/// Gets or sets the Name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return _name; }
			set
			{
				if (_name != value)
				{
					_name = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
				}
			}
		}

		/// <summary>
		/// The Age
		/// </summary>
		public string _age;

		/// <summary>
		/// Gets or sets the age.
		/// </summary>
		/// <value>The age.</value>
		public string Age
		{
			get { return _age; }
			set
			{
				if (_age != value)
				{
					_age = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
				}
			}
		}

		/// <summary>
		/// The Password
		/// </summary>
		public string _password;

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public string Password
		{
			get { return _password; }
			set
			{
				if (_password != value)
				{
					_password = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
				}
			}
		}
	}
}

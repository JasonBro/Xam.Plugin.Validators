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
		/// The test entry
		/// </summary>
		string _testEntry;


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
		/// Gets or sets the test entry.
		/// </summary>
		/// <value>The test entry.</value>
		public string TestEntry
		{
			get { return _testEntry; }
			set
			{
				if (_testEntry != value)
				{
					_testEntry = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TestEntry"));
				}
			}
		}


		/// <summary>
		/// The is password valid
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
		/// The is name valid
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
	}
}

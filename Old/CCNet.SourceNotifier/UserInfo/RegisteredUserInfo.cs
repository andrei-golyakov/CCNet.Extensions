﻿using System;
using System.DirectoryServices.AccountManagement;

namespace CCNet.SourceNotifier.UserInfo
{
	/// <summary>
	/// UserInfo implementation for registered users (ones with accounts in AD).
	/// </summary>
	public class RegisteredUserInfo : IUserInfo, IEquatable<RegisteredUserInfo>
	{
		private readonly UserPrincipal m_userPrincipal;

		/// <summary>
		/// Gets a value indicating whether there is some additional information on this user or not.
		/// Always returns true.
		/// </summary>
		public bool IsRegistered
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Gets display name.
		/// </summary>
		public string DisplayName
		{
			get
			{
				return m_userPrincipal.DisplayName;
			}
		}

		/// <summary>
		/// Gets a value indicating whether there is some known email for this user or not.
		/// </summary>
		public bool HasEmail
		{
			get
			{
				return !String.IsNullOrEmpty(EmailAddress);
			}
		}

		/// <summary>
		/// Gets the user first name.
		/// </summary>
		public string FirstName
		{
			get
			{
				return m_userPrincipal.GivenName;
			}
		}

		/// <summary>
		/// Gets the email address.
		/// </summary>
		public string EmailAddress
		{
			get
			{
				return m_userPrincipal.EmailAddress;
			}
		}

		/// <summary>
		/// Gets the last AD account logon time, if any.
		/// </summary>
		public DateTime? LastLogon
		{
			get
			{
				return m_userPrincipal.LastLogon;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the AD account is locked out.
		/// </summary>
		public bool IsLockedOut
		{
			get
			{
				return m_userPrincipal.IsAccountLockedOut();
			}
		}

		/// <summary>
		/// Gets user description.
		/// </summary>
		public string Description
		{
			get
			{
				return m_userPrincipal.Description;
			}
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public RegisteredUserInfo(UserPrincipal userPrincipal)
		{
			m_userPrincipal = userPrincipal;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		bool IEquatable<RegisteredUserInfo>.Equals(RegisteredUserInfo other)
		{
			return m_userPrincipal == other.m_userPrincipal;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		bool IEquatable<IUserInfo>.Equals(IUserInfo other)
		{
			return (other is RegisteredUserInfo) && ((IEquatable<RegisteredUserInfo>)this).Equals((RegisteredUserInfo)other);
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
		/// </summary>
		public override bool Equals(object obj)
		{
			return (obj is RegisteredUserInfo) && ((IEquatable<RegisteredUserInfo>)this).Equals((RegisteredUserInfo)obj);
		}

		/// <summary>
		/// Serves as a hash function for a particular type.
		/// </summary>
		public override int GetHashCode()
		{
			return m_userPrincipal.GetHashCode();
		}
	}
}

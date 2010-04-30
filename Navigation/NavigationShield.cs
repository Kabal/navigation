using System.Collections.Specialized;
using System.Configuration;

namespace Navigation
{
	/// <summary>
	/// Provides the base functionality for Url protection mechanisms e.g. to prevent tampering or
	/// to obfuscate query string parameters. Regardless of the mechanism the state query string
	/// parameter, c0, is always present
	/// </summary>
	public abstract class NavigationShield : ConfigurationSection
	{
		/// <summary>
		/// Overridden by derived classes to return a protected set of query string parameters
		/// </summary>
		/// <param name="data">An unprotected set of key/value pairs prior to the formation
		/// of the querty string</param>
		/// <param name="historyPoint">Identifies if the Url is being built as a result of
		/// a call to <see cref="StateController.AddHistoryPoint"/></param>
		/// <returns>Protected set of query string parameters</returns>
		public abstract NameValueCollection Encode(NameValueCollection data, bool historyPoint);

		/// <summary>
		/// Overridden by derived classes to return an unprotected set of query string parameters
		/// </summary>
		/// <param name="data">A protected set of key/value pairs produced by the <see cref="Encode"/>
		/// method</param>
		/// <param name="historyPoint">Identifies if the Url is being decoded as a result of
		/// a call to <see cref="StateController.RestoreHistoryPoint"/></param>
		/// <returns>Unprotected set of query string parameters</returns>
		public abstract NameValueCollection Decode(NameValueCollection data, bool historyPoint);
	}
}

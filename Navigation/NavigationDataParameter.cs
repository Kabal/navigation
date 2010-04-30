﻿using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navigation
{
	/// <summary>
	/// Binds the value of a <see cref="Navigation.NavigationData"/> item to a parameter object
	/// </summary>
	public class NavigationDataParameter : Parameter
	{
		/// <summary>
		/// Initializes a new unnamed instance of the <see cref="Navigation.NavigationDataParameter"/> 
		/// class
		/// </summary>
		public NavigationDataParameter()
		{
		}

		/// <summary>
		/// Initializes a new unnamed instance of the <see cref="Navigation.NavigationDataParameter"/> 
		/// class, using the values of the instance that is specified by the <paramref name="original"/>
		/// parameter
		/// </summary>
		/// <param name="original">A <see cref="Navigation.NavigationDataParameter"/> instance from which
		/// the current instance is initialized</param>
		public NavigationDataParameter(NavigationDataParameter original)
			: base(original)
		{
			Key = original.Key;
		}

		/// <summary>
		/// Initializes a new named instance of the <see cref="Navigation.NavigationDataParameter"/> 
		/// class, using the <paramref name="key"/> to identify which <see cref="Navigation.NavigationData"/>
		/// item to bind to. If the <paramref name="key"/> is null the <paramref name="name"/> will
		/// be used instead
		/// </summary>
		/// <param name="name">The name of the parameter</param>
		/// <param name="key">The name of the <see cref="Navigation.NavigationData"/> item that the 
		/// parameter object is bound to</param>
		public NavigationDataParameter(string name, string key)
			: base(name)
		{
			Key = key;
		}

		/// <summary>
		/// Returns a duplicate of the current <see cref="Navigation.NavigationDataParameter"/> instance
		/// </summary>
		/// <returns>A duplicate of the current instance</returns>
		protected override Parameter Clone()
		{
			return new NavigationDataParameter(this);
		}

		/// <summary>
		/// Gets or sets the key of the <see cref="Navigation.NavigationData"/> item that the parameter 
		/// binds to. If this is null the Name property is used instead
		/// </summary>
		public string Key
		{
			get
			{
				return (string)base.ViewState["Key"];
			}
			set
			{
				if (this.Key != value)
				{
					ViewState["Key"] = value;
					OnParameterChanged();
				}
			}
		}

		/// <summary>
		/// Returns the value of the <see cref="Navigation.NavigationData"/> item identified by 
		/// the <see cref="Key"/>
		/// </summary>
		/// <param name="context">The current <see cref="System.Web.HttpContext"/> instance of the
		/// request</param>
		/// <param name="control">This parameter is ignored as not relevant</param>
		/// <returns>The current value of the <see cref="Navigation.NavigationData"/> item. If the
		/// context or the request is null, it returns null</returns>
		protected override object Evaluate(HttpContext context, Control control)
		{
			if (context == null || context.Request == null)
				return null;
			return StateContext.Data[Key ?? Name];
		}
	}
}

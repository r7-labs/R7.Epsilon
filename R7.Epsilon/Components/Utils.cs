//
//  Utils.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2014-2016 Roman M. Yagodin
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
//
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.Text;

namespace R7.Epsilon.Components
{
    public static class Utils
	{
		/// <summary>
		/// Formats the list of arguments, excluding empty
		/// </summary>
		/// <returns>Formatted list.</returns>
		/// <param name="separator">Separator.</param>
		/// <param name="args">Arguments.</param>
		public static string FormatList (string separator, params object[] args)
		{
			var sb = new StringBuilder (args.Length * 16);

			var i = 0;
			foreach (var a in args)
			{
                if (a != null && !string.IsNullOrWhiteSpace (a.ToString ()))
				{
					if (i++ > 0)
						sb.Append (separator);

					sb.Append (a);
				}
			}

			return sb.ToString ();
		}

        public static string FormatList<T> (string separator, IEnumerable<T> args) where T: struct
        {
            var sb = new StringBuilder ();

            var i = 0;
            foreach (var a in args) {
                if (!string.IsNullOrWhiteSpace (a.ToString ())) {
                    if (i++ > 0) {
                        sb.Append (separator);
                    }

                    sb.Append (a);
                }
            }

            return sb.ToString ();
        }
	}
}

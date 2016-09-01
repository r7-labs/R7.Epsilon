//
//  LayoutChecker.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016 Roman M. Yagodin
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

using System;
using System.Collections.Generic;
using System.Linq;
using R7.Epsilon.Models;

namespace R7.Epsilon.Components
{
    public static class LayoutChecker
    {
        public static bool IsValid (Layout layout)
        {
            var havePanes = false;
            var haveSingleContentPane = false;
            var allPanesDistinct = false;

            // layout contains some panes
            havePanes = layout.Panes.Count > 0;

            if (havePanes) {
                // layout contains single ContentPane
                haveSingleContentPane = layout.Panes.SingleOrDefault (p => string.Equals (p.ID, "ContentPane", StringComparison.OrdinalIgnoreCase)) != null;

                // all panes have distinct names
                allPanesDistinct = layout.Panes.Count == layout.Panes.Distinct (new PaneEqualityComparer ()).Count ();
            }

            return havePanes && haveSingleContentPane && allPanesDistinct;
        }
    }
}

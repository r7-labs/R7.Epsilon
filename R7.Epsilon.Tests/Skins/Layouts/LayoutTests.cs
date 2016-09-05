//
//  LayoutTests.cs
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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using R7.Epsilon.Components;

namespace R7.Epsilon.Tests.Skins.Layouts
{
    public class LayoutTests
    {
        [Theory]
        [MemberData (nameof (LayoutFiles))]
        public void LayoutTest (string layoutFile)
        {
            Assert.True (LayoutValidator.IsValid (File.ReadAllText (layoutFile)));
        }

        public static IEnumerable<object []> LayoutFiles
        {
            get {
                var layoutFiles = Directory.GetFiles (Path.Combine ("..", "..", "..", "R7.Epsilon", "Skins", "Layouts"), "*.xml");
                return layoutFiles.Select (lf => new object [] { lf });
            }
        }
    }
}

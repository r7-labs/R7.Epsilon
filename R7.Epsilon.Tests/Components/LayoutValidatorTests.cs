//
//  LayoutValidatorTests.cs
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

using R7.Epsilon.Components;
using Xunit;

namespace R7.Epsilon.Tests.Components
{
    public class LayoutValidatorTests
    {
        [Fact]
        public void LayoutValidatorFormattingTest ()
        {
            // formatting error - no closing tag
            Assert.False (LayoutValidator.IsValid (
                @"<div class=""row"">
                    <div id=""ContentPane"" runat=""server"" /> 
                <div>"
            ));
        }

        [Fact]
        public void LayoutValidatorContentPaneTest ()
        {
            // no content pane
            Assert.False (LayoutValidator.IsValid (
                @"<div class=""row"">
                    <div id=""AsidePane"" runat=""server"" /> 
                </div>"
            ));
        }

        [Fact]
        public void LayoutValidatorUniquePanesTest ()
        {
            // two panes with same 
            Assert.False (LayoutValidator.IsValid (
                @"<div class=""row"">
                    <div id=""ContentPane"" runat=""server"" />
                    <div id=""AsidePane"" runat=""server"" />
                    <div id=""AsidePane"" runat=""server"" />
                </div>"
            ));
        }
    }
}

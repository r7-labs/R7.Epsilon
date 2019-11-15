//
//  File: EpsilonUrlHelperTests.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2019 Roman M. Yagodin, R7.Labs
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

using System.Collections.Specialized;
using Xunit;
using R7.Epsilon.Components;

namespace R7.Epsilon.Tests.Components
{
    public class EpsilonUrlHelperTests
    {
        [Fact]
        public void ReplaceOptionalArgumentsTest ()
        {
            var queryString1 = new NameValueCollection ();

            var queryString2 = new NameValueCollection ();
            queryString2.Add ("arg2", "value2");
            queryString2.Add ("arg3", "value3");

            var queryString3 = new NameValueCollection ();
            queryString3.Add ("arg1", "value1");
            queryString3.Add ("arg3", "value3");

            Assert.Equal ("http://someurl.com",
                EpsilonUrlHelper.FormatUrlWithOptArgs ("http://someurl.com", new NameValueCollection ()));

            Assert.Equal ("http://someurl.com?arg1=value1",
                EpsilonUrlHelper.FormatUrlWithOptArgs ("http://someurl.com?arg1=value1{?arg2}", queryString1));

            Assert.Equal ("http://someurl.com?arg1=value1&arg2=value2",
                EpsilonUrlHelper.FormatUrlWithOptArgs ("http://someurl.com?arg1=value1{?arg2}", queryString2));

            Assert.Equal ("http://someurl.com?arg2=value2",
                EpsilonUrlHelper.FormatUrlWithOptArgs ("http://someurl.com{?arg1}{?arg2}", queryString2));

            Assert.Equal ("http://someurl.com?arg1=value1",
                EpsilonUrlHelper.FormatUrlWithOptArgs ("http://someurl.com?arg1=value1{?arg2}", queryString3));
        }
    }
}

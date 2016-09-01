//
//  DynamicPane.cs
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

namespace R7.Epsilon.Models
{
    public class DynamicPane
    {
        public string Tag { get; set; }

        public string ID { get; set; }

        public string CssClass { get; set; }

        public string ContainerType { get; set; }

        public string ContainerName { get; set; }

        public string ContainerSrc { get; set; }

        public string MarkupBefore { get; set; }

        public string MarkupAfter { get; set; }

        public DynamicPane ()
        {
        }

        public DynamicPane (string markup)
        {
            Tag = MarkupParser.ParseTag (markup);
            ID = MarkupParser.ParseAttribute (markup, "id");
            CssClass = MarkupParser.ParseAttribute (markup, "class");
            ContainerType = MarkupParser.ParseAttribute (markup, "containertype");
            ContainerName = MarkupParser.ParseAttribute (markup, "containername");
            ContainerSrc = MarkupParser.ParseAttribute (markup, "containersrc");
        }
    }
}

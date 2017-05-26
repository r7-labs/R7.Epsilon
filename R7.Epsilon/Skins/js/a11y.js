//
//  ally.js
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2017 Roman M. Yagodin
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

(function ($, window, document) {
    $(function() {
        // replace all popup links with simple ones
        $("a[href^='javascript:dnnModal']").each (function () {
            var url = $(this).attr ("href");
            var urlEnd = url.indexOf ("?popUp=");
            var urlStart = url.indexOf ("http://");
            if (urlStart >= 0 && urlEnd >= 0) {
                $(this).attr ("href", url.substring (urlStart, urlEnd));
            }
        });

        // remove onclick handlers from login/register links
        $("a[id$='_loginLink']").prop ("onclick", null).off ("click");
        $("a[id$='_enhancedLoginLink']").prop ("onclick", null).off ("click");
        $("a[id$='_enhancedRegisterLink']").prop ("onclick", null).off ("click");
    });
}) (jQuery, window, document);
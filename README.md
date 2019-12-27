# About R7.Epsilon

[![BCH compliance](https://bettercodehub.com/edge/badge/roman-yagodin/R7.Epsilon)](https://bettercodehub.com/)
[![Join the chat at https://gitter.im/roman-yagodin/R7.Epsilon](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/roman-yagodin/R7.Epsilon?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

*R7.Epsilon* is an opensource responsive skin (theme) for DNN Platform based on Bootstrap 3.
See it in action at http://www.volgau.com!

# Features

- Admins can define website-specific configuration options via <del>XML</del> YAML file.
- Users can switch between a11y and normal theme. In the a11y mode DNN modal popups are blocked (if they are enabled).
- Variety of containers, including DNN-style messages, Bootstrap alerts, panels, thumbnails, callouts, etc.
- Default, Simple, Home, Edit, Inside, Popup and Error skin variants, reusable through all portals.
- Social group icons (including a11y versions) for Facebook, Twitter, Google+, YouTube, VK.com, Instagram, Linkedin.
- Social share buttons for Facebook, Twitter, Google+, VK.com.
- Completely localizable parts (full Russian translation included).
- Website and host admins can customize and website-wide and host-wide content using language editor.
- Devs can define styles using <del>Less</del> SCSS.
- Devs can use [Paletton.com](http://paletton.com) to create and customize palettes.
- Integration with feedback forms including passing user-selected content.
- Google Adsense adaptive banners support for different screen sizes with automatic loading on window resize.
- [Blueimp Gallery](https://blueimp.github.io/Gallery/) support.
- Optional [cnt.sputnik.ru](https://cnt.sputnik.ru/) analytics support.

## Site-specific (portal level) custom skins (WIP)

With *R7.Epsilon*, you can create custom skins/layouts based on stock ones, adopted and available for specific website only:

1. Copy selected skin files (e.g. `Home.ascx`) and corresponding layout files (`Layouts/_home.ascx`) from `~/Portals/_default/Skins/R7.Zeta` host skin folder to the `~/Portals/X-System/Skins/R7.Epsilon` folder (or `~/Portals/X/Skins/R7.Epsilon` folder), there `X` is a portal number for your website.
2. Copy also `skin.doctype.xml` to set proper HTML Doctype, or make sure that *Fallback Theme Doctype* in Host settings is set to HTML5.
3. Now, if you just want to change panes layout, you can do that by editing layout file contents.
5. Select your custom skin from *Appearance* tab in *Page Settings*. It will be something like *Site: R7.Epsilon - Home*.

Do not copy entire `~/Portals/_default/Skins/R7.Zeta` folder - your site-specific skins will still reference JS, CSS, images and will use localization resources from host skin folder.

Note that layout files are reusable - any number of skin files could reference single layout file. So it's probably better to make a copy of layout file and reference it in your custom skin if you planning to do any changes.

Note also then you update *R7.Epsilon* package, there is a chance that some things in your custom skin will break.
Please always test updates in non-production environment first!

# Install

- Install [LazyAds javascript library](https://github.com/roman-yagodin/R7.Dnn.JavaScriptLibraries/releases/tag/lazyads-v1.1.10) dependency.
- Install [Rangy javascript library](https://github.com/roman-yagodin/R7.Dnn.JavaScriptLibraries/releases/tag/rangy-v1.3.0) dependency.
- Install latest *R7.Epsilon* version from [releases](https://github.com/roman-yagodin/R7.Epsilon/releases).

Note that though you can use *R7.Epsilon* for Admin/Host pages, we strongly recommend to use one of the pre-installed DNN themes for that -
just to be sure that you will always have access to Admin/Host pages.

## Basic blueimp Gallery support

Each static image with `data-gallery=""` attribute on the enclosing `A` tag will be displayed in "each own" lightbox:

```HTML
<a href="/images/orange.jpg" title="Image of orange in the default gallery" data-gallery="">
    <img src="/images/thumbnails/orange.jpg" alt="Orange" />
</a>
<a href="/images/peach.jpg" title="Image of peach in the default gallery" data-gallery="">
    <img src="/images/thumbnails/peach.jpg" alt="Peach" />
</a>
```

Of cause, you can also have any number of additional lightboxes (galleries, carousels) on the page,
but you'll need to add lightboxes markup for them manually. See more in the [blueimp Gallery readme](https://github.com/blueimp/Gallery).

# License

[![AGPLv3](https://www.gnu.org/graphics/agplv3-155x51.png)](https://www.gnu.org/licenses/agpl-3.0.html)

The *R7.Epsilon* is free software: you can redistribute it and/or modify it under the terms of
the GNU Affero General Public License as published by the Free Software Foundation, either version 3 of the License,
or (at your option) any later version.

## License for assets

Social icons based on Stephen Hutchings's [Typicons](https://github.com/stephenhutchings/typicons.font),
published under the terms of [CC BY-CA](http://creativecommons.org/licenses/by-sa/3.0/) license.

Google translate and A11y icons based on Xaviju's [Inkscape Open Symbols](https://github.com/Xaviju/inkscape-open-symbols),
the source of which is published under [GPLv2](http://opensource.org/licenses/GPL-2.0) license.

# Customization

As you should already know, any website skin is more like a template which should be customized (sometimes very heavily)
before using it in production. The *R7.Epsilon* skin developed with per-DNN-portal reuse, configuration and customization in mind,
so (hopefully) you can configure and customize it for your website pretty fast.

Some links to allow you to get started:

- The section about customization in the [project wiki](https://github.com/roman-yagodin/R7.Epsilon/wiki/Customization)
- Example of customization project: [volgau/R7.Epsilon.Customizations](https://github.com/volgau/R7.Epsilon.Customizations)

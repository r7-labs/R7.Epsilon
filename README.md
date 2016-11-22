# About R7.Epsilon

[![Join the chat at https://gitter.im/roman-yagodin/R7.Epsilon](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/roman-yagodin/R7.Epsilon?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

*R7.Epsilon* is a opensource responsive skin for DNN Platform based on Bootstrap 3.

See *R7.Epsilon* skin in action at http://www.volgau.com

# Features

- Admins can define portal-specific settings via <del>XML</del> YAML file.
- Users can switch between a11y and normal theme.
- In the a11y mode DNN modal popups are blocked (if they are enabled).
- Variety of containers, including DNN-style messages, Bootstrap thumbnail, callouts, etc.
- Home, Edit, Admin + Universal skin variants, reusable through all host portals.
- Social group icons (including a11y versions) for Facebook, Twitter, Google+, YouTube, VK.com.
- Social share buttons for Facebook, Twitter, Google+, VK.com.
- Completely localizable parts (full Russian translation included).
- Portal / host admins can customize footer content using language editor.
- Devs can define styles using <del>Less</del> SCSS.
- SCSS and JS preprocessing integrated into the build process.
- Devs can use [Paletton.com](http://paletton.com) to create and customize palettes.
- Various adjustments for mobile screens.
- Google Adsense 728x90 banners support.
- Feedback link with user-selected content (uses [Rangy](https://github.com/timdown/rangy) JavaScript library).

## Custom pane layouts feature

Admins can create and modify custom pane layouts using *LayoutManager* module, then apply them to the page 
using new *Select Layout* command from *Edit Page* menu in the control panel. Selected layout name and kind (host or portal)
are stored in the page settings. Additional layout can be set to use in a11y mode.

This feature currently available only if *Custom* skin is selected for a page.

## Features considered temporary (could be removed in any subsequent release):

- *Flowplayer HTML5* support (must be installed to `~/Resources/Shared/components/flowplayer`).

## Some planned features:

- BlueImp gallery support (at least for Home skin).
- Ability to add (some) skin panes dynamically.
- Switch from Less to SASS (SCSS).
- Integration of Bootstrap into skin build process.
- Google Adsense mobile-friendly banners support. 

# Install

- Get latest install package from the [releases](https://github.com/roman-yagodin/R7.Epsilon/releases).
- Go to the *DNN* &gt; *Host* &gt; *Extensions*, click *Install Extension*.
- Optionally replace `Global.asax` file in the application root folder with one shipped alongside skin install package
(this will enable more advanced `VaryByCustom` cache options for skin controls - by PortalId, by UserRoles).

# Acknowledgements

Project code originates from Chris Hammond's [HammerFlex](https://github.com/ChrisHammond/HammerFlex) skin 
and utilizes some ideas from [Tidy](http://tidy.codeplex.com/) skin. You should really try them too!

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

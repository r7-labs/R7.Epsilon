# About R7.Epsilon

[![Join the chat at https://gitter.im/roman-yagodin/R7.Epsilon](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/roman-yagodin/R7.Epsilon?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

*R7.Epsilon* is a opensource responsive skin for DNN Platform based on Bootstrap 3.

See *R7.Epsilon* skin in action at http://www.volgau.com

# Features

- Admins can define portal-specific settings via <del>XML</del> YAML file.
- Users can switch between a11y and normal theme.
- In the a11y mode DNN modal popups are blocked (if they are enabled.
- Variety of containers, including DNN-style messages, Bootstrap thumbnail, callouts, etc.
- Home, Edit, Admin + Universal skin variants, reusable through all host portals.
- Social group icons (including a11y versions) for Facebook, Twitter, Google+, YouTube, VK.com.
- Social share buttons for Facebook, Twitter, Google+, VK.com.
- Completely localizable parts (full Russian translation included).
- Portal / host admins can customize footer content using language editor.
- Devs can define styles using Less.
- Less and UglifyJS integrated into the build process.
- Devs can use [Paletton.com](http://paletton.com) to create and customize palettes.
- Various adjustments for mobile screens.
- Google Adsense 728x90 banners support. 
- Feedback link with user-selected content (*rangy* library must be installed to `~/Resources/Shared/scripts/rangy`).

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

# Assets License

Social icons based on Stephen Hutchings's [Typicons](https://github.com/stephenhutchings/typicons.font), 
published under the terms of [CC BY-CA](http://creativecommons.org/licenses/by-sa/3.0/) license.

Google translate and A11y icons based on Xaviju's [Inkscape Open Symbols](https://github.com/Xaviju/inkscape-open-symbols),
the source of which is published under [GPLv2](http://opensource.org/licenses/GPL-2.0) license.
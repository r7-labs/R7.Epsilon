# Customization

The better way to start with skin customization is to fork a R7.Epsilon repository and then make changes in a fork.
But there are other ways. Below I want to explain available customization options and "extension points".

## Portal-level config

Unlike many other skin, R7.Epsilon could be configured per portal. 
Portal-level options could be set via editing `R7.Epsilon.config` file in portal root directory.

Portal config file is generic .NET config file with key-value pairs. Most important ones described in the table:

Setting Name | Value | Default Value | Description
------------ | ----- | ------------- | -----------
SkinCss | css/default-skin.min.css | | Path to main CSS file (relative to Skins folder)
SkinA11yCss | css/a11y-skin.min.css | | Path to accesibility version of CSS file (relative to Skins folder)

# Customization

The better way to start with skin customization is to fork a *R7.Epsilon* repository and then make changes in a fork.
But there are other ways. Below I'll try to explain available customization options and "extension points".

## Portal-level config

Unlike many other skin, *R7.Epsilon* could be configured per portal. 
Portal-level options could be set via editing `R7.Epsilon.yml` file located in the portal root directory.

Portal config file is YAML file. Most important ones described in the table:

Setting Name  | Default value            | Description
------------- | ------------------------ | -------------
skin-css      | css/default-skin.min.css | Path to main CSS file (relative to the `Skins` folder)
skin-a11y-css | css/a11y-skin.min.css    | Path to accesibility version of CSS file (relative to the `Skins` folder)
menu-url-type | 0                        | Type of URLs used in menus. 0 - default (friendly) URLs, 1 - `/Default.aspx?TabId=xxx` URLs, 2 - `/TabId/xxx` URLs

## Control redirect type for short menu URLs

If you choose to use short menu URLs of type 2, in some cases  it would be useful 
to adjust *Host &gt; Advanced &gt; Friendly URL Settings* rule for `[^?]*/TabId?(\d+)(.*)`
by replacing `~/Default.aspx?TabID=$1` with `~/LinkClick.aspx?link=$1`.

Note that the `Default.aspx` rule will produce 301 redirects - which is faster, but may cause problems with browser history if page URL changes.
And the `LinkClick.aspx` rule will produce 302 redirects - which is slower, but more reliable in case of page URL changes.


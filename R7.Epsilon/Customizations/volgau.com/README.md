# Customizations for volgau.com

## After install

1. Install / upgrade main skin package.
2. Unpack content of *this* archive to the host root directory, replacing existing files.
3. First time install: add one of the following rules to *Host &gt; Advanced &gt; Friendly URL Settings* to allow short URLs like http://www.some-company.com/p1245 in the menu:

* `[^?]*/p?(\d+)(.*)` => `~/Default.aspx?TabID=$1` to use 301 redirects (faster, but may cause problems on page URL changes);
* `[^?]*/p?(\d+)(.*)` => `~/LinkClick.aspx?link=$1` to use 302 redirects (slower, but reliable).

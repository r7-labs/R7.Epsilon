# Customizations for volgau.com

## After install

1. Install / upgrade main skin package.
2. Unpack content of *this* archive to the host root directory, replacing existing files.
2. First time install: add `[^?]*/p(\d+)(.*)` => `~/Default.aspx?TabID=$1` rule to *Host &gt; Advanced &gt; Friendly URL Settings* 
to allow short URLs like http://www.some-company.com/p1245 in the menu.

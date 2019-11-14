<?xml version="1.0" encoding="UTF-8"?>
<!--

 Mega2Epsilon.xslt
 
 Author:
      Roman M. Yagodin <roman.yagodin@gmail.com>

 Copyright (c) 2015 Roman M. Yagodin

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU Affero General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU Affero General Public License for more details.

 You should have received a copy of the GNU Affero General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.
-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ddr="urn:ddrmenu" exclude-result-prefixes="ddr">
	<xsl:output method="html"/>
	<xsl:param name="ControlID" />
	<xsl:param name="Options" />
    <xsl:param name="enableTopLinks">1</xsl:param>
    <xsl:param name="hamburgerMenu">0</xsl:param>
    <xsl:param name="resourceKey">LocalMenu</xsl:param>
	<xsl:param name="urlType">0</xsl:param>
	<xsl:param name="subMenuColumns">3</xsl:param>
    <xsl:param name="pointer"></xsl:param>
    <xsl:template match="/*">
		<xsl:apply-templates select="root" />
	</xsl:template>
	<xsl:template match="root">
        <script type="text/javascript">
			<!-- TODO: Move to menu.js, pass subMenuColumns via data attribute -->
			jQuery(document).ready(function() {
				skinSplitSubMenu(jQuery, &quot;<xsl:value-of select="$ControlID" />&quot;, <xsl:value-of select="$subMenuColumns"/>);
			});
	    </script>
        <ul class="megamenu navbar-nav">
            <xsl:attribute name="id"><xsl:value-of select="$ControlID" /></xsl:attribute>
            <xsl:apply-templates select="node">
				<xsl:with-param name="level" select="0"/>
			</xsl:apply-templates>
		</ul>
	</xsl:template>
	<xsl:template match="node">
		<xsl:param name="level" />
		<xsl:choose>
			<xsl:when test="$level=0">
				<li>
					<xsl:attribute name="class">level0 nav-item</xsl:attribute>
                    <a class="nav-link">
						<xsl:call-template name="menuLink">
                            <xsl:with-param name="enabled" select="$enableTopLinks = 1 and not ($hamburgerMenu = 1)" />
                        </xsl:call-template>
                        <xsl:choose>
                            <xsl:when test="$hamburgerMenu = 1">
                                <xsl:value-of select="ddr:GetString(concat($resourceKey,'.Text'),'Portals/_default/Skins/R7.Epsilon/App_LocalResources/SharedResources.resx')" disable-output-escaping="yes" />
                            </xsl:when>
                            <xsl:otherwise>
                                <xsl:value-of select="@text" />
						        <xsl:if test="node">
							        <xsl:value-of select="$pointer" disable-output-escaping="yes"/>
						        </xsl:if>
                            </xsl:otherwise>
                        </xsl:choose>
					</a>
					<!--
					<xsl:if test="node">
						<div class="sub">
							<xsl:apply-templates select="node">
								<xsl:with-param name="level" select="$level + 1" />
							</xsl:apply-templates>
							<a href="#" role="button" class="sub-close">
								<xsl:attribute name="title"><xsl:value-of select="ddr:GetString('SubMenuClose.Text','Portals/_default/Skins/R7.Epsilon/App_LocalResources/SharedResources.resx')" disable-output-escaping="yes" /></xsl:attribute>
								&#215;
							</a>
						</div>
					</xsl:if>
					-->
				</li>
			</xsl:when>
			<xsl:when test="$level=1">
                <ul>
                    <li>
                        <a>
                            <xsl:call-template name="menuLink"/>
                            <xsl:value-of select="@text"/>
                        </a>
                    </li>
					<xsl:if test="node">
						<xsl:apply-templates select="node">
							<xsl:with-param name="level" select="$level + 1"/>
						</xsl:apply-templates>
					</xsl:if>
				</ul>
			</xsl:when>
			<xsl:otherwise>
                <li>
                    <a>
                        <xsl:call-template name="menuLink"/>
                        <xsl:value-of select="@text"/>
                    </a>
                </li>
				<xsl:if test="node">
					<xsl:apply-templates select="node">
						<xsl:with-param name="level" select="$level + 1"/>
					</xsl:apply-templates>
				</xsl:if>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
    <xsl:template name="menuLink">
        <xsl:param name="enabled"><xsl:value-of select="true()"/></xsl:param>
	    <xsl:choose>
            <xsl:when test="@enabled = 1 and $enabled">
                <xsl:choose>
                    <xsl:when test="$urlType = 1 and @id &gt; 0">
                        <xsl:attribute name="href">/Default.aspx?TabId=<xsl:value-of select="@id"/></xsl:attribute>
                    </xsl:when>
                    <xsl:when test="$urlType = 2 and @id &gt; 0">
                        <xsl:attribute name="href">/TabId/<xsl:value-of select="@id"/></xsl:attribute>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:attribute name="href"><xsl:value-of select="@url"/></xsl:attribute>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:when>
            <xsl:otherwise>
                <xsl:attribute name="href">#</xsl:attribute>
                <xsl:attribute name="onclick">return false</xsl:attribute>
            </xsl:otherwise>
		</xsl:choose>
		<xsl:attribute name="data-id"><xsl:value-of select="@id"/></xsl:attribute>
    </xsl:template>
</xsl:stylesheet>

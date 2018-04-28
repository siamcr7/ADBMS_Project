Rem
Rem $Header: aspnetproviders/sql/UninstallOracleSiteMap.sql pdsilva_format_issue_12.2_new_1/2 2017/05/25 02:18:13 pdsilva Exp $
Rem
Rem UninstallOracleSiteMap.sql
Rem
Rem Copyright (c) 2007, 2017, Oracle and/or its affiliates. 
Rem All rights reserved.
Rem
Rem    NAME
Rem      UninstallOracleSiteMap.sql - Drops procedure & table from the Database.
Rem
Rem    DESCRIPTION
Rem      Drops OracleSiteMapProvider specific stored procedure & table from the Database.
Rem
Rem    NOTES
Rem      <other useful comments, qualifications, etc.>
Rem
Rem    MODIFIED   (MM/DD/YY)
Rem    aruns       03/09/07 - Drop roles and synonyms.
Rem    aruns       02/25/07 - Created
Rem

-- drop the sitemap provider specific stored procedure from the database.
DROP PROCEDURE ora_aspnet_GetSiteMapData;

-- drop the sitemap provider specifc table from the database.
DROP TABLE ora_aspnet_SiteMap;

-- Drop roles
DROP ROLE ora_aspnet_Smap_FullAccess;

-- Drop public synonym. Drop public synonym privilege is required.
DROP PUBLIC SYNONYM ora_aspnet_GetSiteMapData;

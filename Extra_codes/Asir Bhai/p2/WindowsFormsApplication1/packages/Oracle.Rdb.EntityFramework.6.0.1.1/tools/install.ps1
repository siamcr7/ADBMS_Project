# Runs every time a package is installed in a project

param($installPath, $toolsPath, $package, $project)

Add-EFDefaultConnectionFactory $project 'Oracle.DataAccess.RdbClient.Entity.RdbConnectionFactory, Oracle.Rdb.EntityFramework, Version=7.3.2.6, Culture=neutral, PublicKeyToken=24caf6849861f483'
Add-EFProvider $project 'Oracle.DataAccess.RdbClient' 'Oracle.DataAccess.RdbClient.RdbProviderServices, Oracle.Rdb.EntityFramework, Version=7.3.2.6, Culture=neutral, PublicKeyToken=24caf6849861f483'

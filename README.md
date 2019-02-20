# SEO Analyser
An SEO Analyser web application that crawls the site, counts words in the body of the site or text.

#### Getting Started
Import project into Visual Studio (or alternative IDE). Make sure all NuGet Packages downloaded properly.

#### Running the tests
Wrote sample test senario for tesing AnalyserService functionality. Tests are written using MSTest. Use any runner which supports MSTest to run tests.

#### Using the app
The web application does not require any authorization. Open your browser and drop text or link for SEO analyze. There is have four options: By default, all is selected. 

Markup : * Show number of words
         * Filter out stop words
         * Show number of meta tags in Url
         * Show number of external links

Results show the bottom of the content as a table.
The table has sort, search and paging functionality.

#### Implementation details

-- used Bootstrap 4
-- used JQuery 3.3.1
-- used CDN JQuery DataTable
-- used HtmlAgilityPack for parsing HTML
-- default ASP.NET MVC 5 template is used for project creation. It may contain unused files.

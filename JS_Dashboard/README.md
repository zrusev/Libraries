A template dashboard which copies the component-based approach for fetching data without any deployed server using IE and ActiveX model only.
Fully tested for SQL and local access database servers.

In order to avoid the CORS mechanism the index file should be placed within the user's C:\\ drive (use the attached powershell file: install.ps1 to install it to any desired directory). The rest scripts could reside on a shared directory.

Several data visualization libraries are incorporated for demo purpose:

Template: https://startbootstrap.com/template-overviews/sb-admin/
Dependencies: fontawesome,
			  datatables,
			  jquery (jquery-ui, jquery-csv, jquery-easing),
			  chart.js,
			  pivottable,
			  canvasjs,
			  accessdb
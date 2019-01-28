const canvas = function () { 
  let dataPoints = [];
  let currentDate = new Date().toISOString().slice(0, 10);
  let countryName = $('#countryName').val();
  $('#countryName').val('');

  let chart = new CanvasJS.Chart("chartContainer", {
    animationEnabled: true,
    theme: "light2",
    title: {
      text: currentDate + ' Daily Records'
    },
    axisY: {
      title: "Records Count",
      titleFontSize: 24
    },
    data: [{
      type: "column",
      showInLegend: true,
      legendMarkerColor: "grey",
      legendText: "Users",
      yValueFormatString: "#,### Transactions",
      dataPoints: dataPoints
    }]
  });

  function addData(data) {
    for (let i = 0; i < data.length; i++) {
      dataPoints.push({
        y: data[i].TransCount,
        label: data[i].UserName
      });
    }
    chart.render();
  }
  
  let query = "SELECT [User] AS [UserName], COUNT([User]) AS [TransCount] FROM [schema].[Table1] WHERE Country = '" + countryName + "';";

  addData(provider.getData('sqlserver', query));  
}

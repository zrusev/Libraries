const constants = (function () {
  const hostDir = "C:\\Users\\{USER}\\Desktop\\JS_Dashboard";
  
  return {
    body: hostDir + "\\layouts\\shared\\body.html",
    welcome: hostDir + "\\layouts\\home\\welcome.html",
    chartWrapper: hostDir + "\\layouts\\components\\chart.html",
    tableWrapper: hostDir + "\\layouts\\components\\table.html",
    pageDataWrapper: hostDir + "\\layouts\\components\\tranCountForm.html",
    pivot: hostDir + "\\layouts\\components\\pivot.html"
  }  
}) ()
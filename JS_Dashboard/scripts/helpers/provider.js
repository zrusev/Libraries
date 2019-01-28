const provider = (function () {
  function getData(server, query) {
    let accessDatabase = {
      provider: "Microsoft.ACE.OLEDB.12.0",
      dataSrc: "C:\\Users\\{USER}\\Desktop\\MSAccess.accdb",
      dataBs: '',
      persist: false,
      user: '',
      password: '',
      showErrors: true
    }

    let sqlDatabase = {
      provider: "sqloledb",
      dataSrc: "",
      dataBs: '',
      persist: false,
      user: '',
      password: '',
      showErrors: true
    }

    let myDB = new ACCESSdb(server === 'local' ? accessDatabase : sqlDatabase);

    return myDB.query(query);
  }

  function getFile(url) {
    let xmlhttp = new ActiveXObject("Msxml2.XMLHTTP.3.0");
    xmlhttp.open('GET', url, false);
    xmlhttp.send();
    return xmlhttp.responseText;
  }

  return {
    getData: getData,
    getFile: getFile
  }
})();
const pivotService = function () {
    generator.load('#content-wrapper', constants.pivot);

    let query = "SELECT TOP 100 * FROM [Table1];";
   
    let data = provider.getData('local', query);

    $("#output").pivotUI(data, {
        unusedAttrsVertical: false,
        
        cols: ["Items", "Ageing"],
        rows: ["User"]
    });    
}
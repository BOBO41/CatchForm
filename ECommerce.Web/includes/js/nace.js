var naceArray = {};

function addNaceCode(nace)
{
    naceArray[nace] = nace;
}

function removeNaceCode(nace)
{
    delete naceArray[nace];
}

function getNaceCodeString()
{
    var naceString = "+";
    
    for(var naceCode in naceArray)
    {
        naceString += " " + naceArray[naceCode];
    }
    
    return naceString.replace("+ ", "");
}

function clearNaceCodes()
{
    for(var naceCode in naceArray)
    {
        removeNaceCode(naceCode);
    }
    
    $('#anzic-selection-container, #selection-container').html('');
}

//ADDED BY Richard - Lol: The new improved KISS version... 112 lines down to 19 - Mwah!
function addSelectedSicCodes() {

    var $selectedElements = $('#sicCode option:selected');
    
    $selectedElements.each(function(){
        
        if(this.value != 0)
        {
            addNaceCode(this.value);

            addNace(this);
        }
        
    });
    
    $('#SIC').val(getNaceCodeString());
    
//What?! Thats it!? What about all that other code in the old function!??? What did that do?... F knows!
}

function clearSelectedSicCodes() {

    clearNaceCodes();
    
    $('#sicCode option').prop('selected', false);

    $('#SIC').val('');

    $('#IND_DESC').val('');

    if ($('#INDUSTRY').val() != null)
    {
        $('#INDUSTRY').val(0);
    }
    
    $('#selection-container').html('');
    
    if(anzsic_codes){
        anzsic_codes = false;
    }

}

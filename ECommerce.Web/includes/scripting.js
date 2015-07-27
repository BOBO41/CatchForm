/* CONSOLE.LOG FIX */
if(!window.console) console = {log: function() {}};

var nacesAdded = {};

$(document).ready(function() {
    
    $('.remove-nace').live('click', function() {

        var naceNumber = $(this).siblings('.nace-value').val();

        removeNaceCode(naceNumber);
        
        $('#SIC').val(getNaceCodeString());

        $(this).parent().remove();

        getSampleSize();
    });


    $('.remove-anzsic').live('click', function() {

        var naceNumber = $(this).siblings('.nace-value').val();
        
        var anzsicNumber = $(this).siblings('.nace-number').text();

        var contents = $('#SIC').val();

        var naceCodes = getNaceCodesForANZSIC(anzsicNumber);
        
        for(var i in naceCodes)
        {
            var naceCodeData = naceCodes[i];
            
            contents = contents.replace(naceCodeData['data-value'], '');
        }
        
        if(anzsic_codes)
        {
            delete anzsic_codes[anzsicNumber];
        }
//        contents = contents.replace(' ' + ' ', '');
        contents = contents.replace(/\s{2,}/g, ' ');

        var selector = '#selected-anzsic-codes option[id='+anzsicNumber.trim()+']';

        $optionToRemove = $(selector);

        $optionToRemove.remove();

        $('#SIC').val(contents);

        $(this).parent().remove();

        getSampleSize();
        
    });
    
    $('.formRow').last().css('margin-bottom', '20px');


    $('.remove-anzsic').live('click', function() {

        var naceNumber = $(this).siblings('.nace-value').val();
        
        var anzsicNumber = $(this).siblings('.nace-number').text();

        var contents = $('#SIC').val();

        var naceCodes = getNaceCodesForANZSIC(anzsicNumber);
        
        for(var i in naceCodes)
        {
            var naceCodeData = naceCodes[i];
            
            contents = contents.replace(naceCodeData['data-value'], '');
        }
        
//        contents = contents.replace(' ' + ' ', '');
        contents = contents.replace(/\s{2,}/g, ' ');

        var selector = '#selected-anzsic-codes option[id='+anzsicNumber.trim()+']';

        $optionToRemove = $(selector);

        $optionToRemove.remove();

        $('#SIC').val(contents);

        $(this).parent().remove();

        getSampleSize();
        
    });

});

// Jeevan 26/05/2006: Declaring the variable. Its checked in the checkSicCode function to see if sample size is fetched.
var isSampleSizeReady = false;
/*
 Added by Abhaya on 17/03/2006
 Done in order to disable link once report gen. link has been clicked once
 */
function cancelLink() {
    return false;
}


function getNaceCodesForANZSIC(anzsicNumber)
{
    return nacesAdded[anzsicNumber];
}


function disableLink(context, link) {
    if (link.onclick) {
        link.oldOnClick = link.onclick;
    }
    link.onclick = cancelLink;
    //send to action
    location.href = context + '/downloadReport.do';
    if (link.style) {
        link.style.cursor = 'default';
    }
}

function disableLinkIampei(context, link) {
    if (link.onclick) {
        link.oldOnClick = link.onclick;
    }
    link.onclick = cancelLink;
    //send to action
    location.href = context + '/downloadReportIampei.do';
    if (link.style) {
        link.style.cursor = 'default';
    }
}

//added by abhaya on 080306 to by pass updating DB each time a user goes throught TIT
function setUpdated() {

    if (document.forms[0].updated.value == 'NO') {
        document.forms[0].updated.value = 'YES';
    }

    return;
}

function saveFinancialServiceMiniAndExit(context) {
    document.forms[0].action = context + "/saveFinancialServiceMiniAndExit.do";
    document.forms[0].submit();
    return;
}

function saveCustomerServiceMiniAndExit(context) {
    document.forms[0].action = context + "/saveCustomerServiceMiniAndExit.do";
    document.forms[0].submit();
    return;
}

function saveProcessServiceMiniAndExit(context) {
    document.forms[0].action = context + "/saveProcessServiceMiniAndExit.do";
    document.forms[0].submit();
    return;
}

function saveDevelopmentServiceMiniAndExit(context) {
    document.forms[0].action = context + "/saveDevelopmentServiceMiniAndExit.do";
    document.forms[0].submit();
    return;
}

function saveFinancialManufacturingMiniAndExit(context) {
    document.forms[0].action = context + "/saveFinancialManufacturingMiniAndExit.do";
    document.forms[0].submit();
    return;
}

function saveCustomerManufacturingMiniAndExit(context) {
    document.forms[0].action = context + "/saveCustomerManufacturingMiniAndExit.do";
    document.forms[0].submit();
    return;
}

function saveProcessManufacturingMiniAndExit(context) {
    document.forms[0].action = context + "/saveProcessManufacturingMiniAndExit.do";
    document.forms[0].submit();
    return;
}

function saveDevelopmentManufacturingMiniAndExit(context) {
    document.forms[0].action = context + "/saveDevelopmentManufacturingMiniAndExit.do";
    document.forms[0].submit();
    return;
}

function saveFinancialServiceMaxiAndExit(context) {
    document.forms[0].action = context + "/saveFinancialServiceMaxiAndExit.do";
    document.forms[0].submit();
    return;
}

function saveCustomerServiceMaxiAndExit(context) {
    document.forms[0].action = context + "/saveCustomerServiceMaxiAndExit.do";
    document.forms[0].submit();
    return;
}

function saveProcessServiceMaxiAndExit(context) {
    document.forms[0].action = context + "/saveProcessServiceMaxiAndExit.do";
    document.forms[0].submit();
    return;
}

function saveDevelopmentServiceMaxiAndExit(context) {
    document.forms[0].action = context + "/saveDevelopmentServiceMaxiAndExit.do";
    document.forms[0].submit();
    return;
}

function saveFinancialManufacturingMaxiAndExit(context) {
    document.forms[0].action = context + "/saveFinancialManufacturingMaxiAndExit.do";
    document.forms[0].submit();
    return;
}

function saveCustomerManufacturingMaxiAndExit(context) {
    document.forms[0].action = context + "/saveCustomerManufacturingMaxiAndExit.do";
    document.forms[0].submit();
    return;
}

function saveScoBmDetailsAndExit(context) {
//Added by Navin 11-06-2005: Save n Exit for Scottish Domain diagnostic page
//	document.forms[0].action = context+"/saveCustomerManufacturingMaxiAndExit.do";
    document.forms[0].action = context + "/saveScoBmDetailsAndExit.do";
    document.forms[0].submit();
    return;
}

function saveProcessManufacturingMaxiAndExit(context) {
    document.forms[0].action = context + "/saveProcessManufacturingMaxiAndExit.do";
    document.forms[0].submit();
    return;
}

function saveDevelopmentManufacturingMaxiAndExit(context) {
    document.forms[0].action = context + "/saveDevelopmentManufacturingMaxiAndExit.do";
    document.forms[0].submit();
    return;
}



// Added By AdamB 03-Mar-2008
// This function is to replace all the functions like
// saveWM2FinancialManufacturingMaxiAndExit
function updateFormActionAndSubmit(newAction) {
    metricChangesRequireWarning = false

    document.forms[0].action = newAction;
    document.forms[0].submit();
}

function formatEmps()
{
    if ((document.forms[0].EMP1.value == "NULL") && (document.forms[0].EMP2.value == "NULL")) {
        document.forms[0].NO_EMPS.value = "";
    } else if ((document.forms[0].EMP1.value != "NULL") && (document.forms[0].EMP2.value == "NULL")) {
        document.forms[0].NO_EMPS.value = " >= " + document.forms[0].EMP1.value;
    } else if ((document.forms[0].EMP1.value == "NULL") && (document.forms[0].EMP2.value != "NULL")) {
        document.forms[0].NO_EMPS.value = " <= " + document.forms[0].EMP2.value;
    } else {
        //Jeevan 26/05/2006: If valueOf(number of employees more than) > valueOf(number of employees less than) show error
        var emp1 = document.forms[0].EMP1.value;
        var emp2 = document.forms[0].EMP2.value;
        if (parseInt(emp1) > parseInt(emp2))
        {
            alert(document.getElementById("errEmpOneGrtTwo").value);
            document.forms[0].EMP1.options[0].selected = true;
            //document.forms[0].EMP2.options[0].selected = true;
        }
        //Jeevan 26/05/2006: If valueOf(number of employees more than) = valueOf(number of employees less than) show error
        else if (parseInt(emp1) == parseInt(emp2))
        {
            alert(document.getElementById("errEmpOneEqlTwo").value);
            document.forms[0].EMP2.options[0].selected = true;
        } else {
            document.forms[0].NO_EMPS.value = document.forms[0].EMP1.value + " - " + document.forms[0].EMP2.value;
        }
    }

}

function formatBLY() {
    if (document.forms[0].BLY_CLUSTER.value == null ||
            document.forms[0].BLY_CLUSTER.value == "NULL"
            ) {
        document.forms[0].BLY_CLUSTER.value = "0"; // No clusters 9=inclusive 1-3/
    }
}


function formatTurnover()
{
    if ((document.forms[0].TURN1.value == "NULL") && (document.forms[0].TURN2.value == "NULL")) {
        document.forms[0].TURNOVER.value = "";
    } else if ((document.forms[0].TURN1.value != "NULL") && (document.forms[0].TURN2.value == "NULL")) {
        document.forms[0].TURNOVER.value = " >= " + document.forms[0].TURN1.value;
    } else if ((document.forms[0].TURN1.value == "NULL") && (document.forms[0].TURN2.value != "NULL")) {
        document.forms[0].TURNOVER.value = " <= " + document.forms[0].TURN2.value;
    } else {
        //Jeevan 26/05/2006: If valueOf(turnover more than) > valueOf(turnover less than) show error
        var turn1 = document.forms[0].TURN1.value;
        var turn2 = document.forms[0].TURN2.value;
        if (parseFloat(turn1) > parseFloat(turn2))
        {
            alert(document.getElementById("errTurnOneGrtTwo").value);
            document.forms[0].TURN1.options[0].selected = true;
        }
        //Jeevan 26/05/2006: If valueOf(turnover more than) = valueOf(turnover less than) show error
        else if (parseFloat(turn1) == parseFloat(turn2))
        {
            alert(document.getElementById("errTurnOneEqlTwo").value);
            document.forms[0].TURN2.options[0].selected = true;
        }
        else
        {
            document.forms[0].TURNOVER.value = document.forms[0].TURN1.value + " - " + document.forms[0].TURN2.value;
        }
    }
}

function getCreateCompSICCode(context, action, status) {
    if (eval(status) == 1) {
        if (document.forms[0].ind1.selectedIndex != 0) {
            document.forms[0].action = context + "/" + action + ".do";
            document.forms[0].submit();
            return true;
        }
    }
    if (eval(status) == 2) {
        if (document.forms[0].td1.selectedIndex != 0) {
            document.forms[0].action = context + "/" + action + ".do";
            document.forms[0].submit();
            return true;
        }
    }
}

function getEditCompSICCode(context, action, status) {
    if (eval(status) == 1) {
        document.forms[0].action = context + "/" + action + ".do";
        document.forms[0].submit();
        return true;
    }
    if (eval(status) == 2) {
        if (document.forms[0].td1.selectedIndex != 0) {
            document.forms[0].action = context + "/" + action + ".do";
            document.forms[0].submit();
            return true;
        }
    }
}

function getCriteriaSICCode(context, action, status) {
    if (eval(status) == 1) {
        if (document.forms[0].ind1.selectedIndex != 0) {
            document.forms[0].action = context + "/" + action + ".do";
            document.forms[0].submit();
            return true;
        }
    }
    if (eval(status) == 2) {
        if (document.forms[0].td1.selectedIndex != 0) {
            document.forms[0].action = context + "/" + action + ".do";
            document.forms[0].submit();
            return true;
        }
    }
}

function getSicCodeList(context, val) {

    if (eval(val) == 2) {
        document.forms[0].siccode.value = "";
        if (document.forms[0].list1.selectedIndex != 0) {
            document.forms[0].action = context + "/getSicCode2.do";
            document.forms[0].list.value = val;
            document.forms[0].submit();
        }
    }

    if (eval(val) == 3) {
        document.forms[0].siccode.value = "";
        if (document.forms[0].list2.selectedIndex != 0) {
            document.forms[0].action = context + "/getSicCode3.do";
            document.forms[0].list.value = val;
            document.forms[0].submit();
        }
    }

    if (eval(val) == 4) {
        if (document.forms[0].list3.selectedIndex != 0) {
            document.forms[0].siccode.value = document.forms[0].list3.value;
            document.forms[0].list.value = val;
            //document.forms[0].action = context+"/nextAction.do";
            //document.forms[0].submit();
        }
        else
        {
            document.forms[0].siccode.value = "";
        }
    }

    return true;
}

function getCriteriaRegion(context, action, status) {
    if (eval(status) == 1) {
        if (document.forms[0].COUNTRY.selectedIndex != 0) {
            document.forms[0].action = context + "/" + action + ".do";
            document.forms[0].submit();
            return true;
        }
    }
}

function invokeAction(context, action, type) {
    document.forms[0].action = context + "/" + action + ".do?type=" + type;
    document.forms[0].submit();
    return true;
}

var sicOpen = false;
function displaySICWindow(context) {
    // Open a popup-window when user clicks	"Search sic" link 
    if (window.sicWin && !sicWin.closed)
    {
        sicWin.focus();
    }
    else
    {
        var busiareas = document.getElementById("INDUSTRY").value;
        sicWin = window.open(context + "/searchSicCode1.do?list=1&ba=" + busiareas, "", "toolbar=no,menubar=no,scrollbars=no,resizable=no,status=yes,location=no,directories=no,copyhistory=no,height=420,width=560,top=80,left=200");
        sicOpen = true;
    }
}

function searchSicCodeList(context, val) {
    //Jeevan: get the selected business area
    var busiareas = window.opener.document.getElementById("INDUSTRY").value;
    if (eval(val) == 2) {
        if (document.forms[0].list1.selectedIndex != 0) {
            document.forms[0].action = context + "/searchSicCode2.do?ba=" + busiareas;
            document.forms[0].list.value = val;
            document.forms[0].submit();
        }
    }

    if (eval(val) == 3) {
        if (document.forms[0].list2.selectedIndex != 0) {
            document.forms[0].action = context + "/searchSicCode3.do?ba=" + busiareas;
            document.forms[0].list.value = val;
            document.forms[0].submit();
        }
    }

    return true;
}

// Jeevan 340: For selecting more than one SIC codes
function clearSicCodes()
{
    var confirmDel = confirm(document.forms[0].clearalert_hidden.value);
    if (confirmDel == true)
    {
        document.forms[0].SIC.value = "";
    }
    document.forms[0].SIC.focus();
}

// Jeevan 340: For selecting more than one SIC codes
function getSelectedSicCodes()
{
    var prevSIC = window.opener.document.forms[0].SIC.value;
    var newSIC = document.forms[0].siccode.value;
    if (newSIC.length < prevSIC.length)
    {
        document.forms[0].siccode.value = window.opener.document.forms[0].SIC.value;
    }
}

// Jeevan 340: For selecting more than one SIC codes
function selectSICCodeOnClose()
{
    window.opener.document.forms[0].SIC.value = document.forms[0].siccode.value;
    window.close();
    window.opener.document.forms[0].SIC.focus();
}


// Jeevan 340: For selecting more than one SIC codes
function selectSICCode()
{
    if (document.forms[0].list3.selectedIndex != 0)
    {
        var selSIC = document.forms[0].list3.value;
        var prevSIC = document.forms[0].siccode.value;
        // Select All selected
        if (selSIC == 1)
        {
            selSIC = "";
            //alert("Inside Select All");
            for (i = 2; i < document.forms[0].list3.length; i++)
            {
                selSIC += document.forms[0].list3[i].value + " ";
            }
            //alert("Selected: " + selSIC);	 				
        }
        else
        {
            selSIC = "";
            //alert("Not select all");
            for (i = 2; i < document.forms[0].list3.length; i++)
            {
                if (document.forms[0].list3[i].selected == true)
                {
                    selSIC += document.forms[0].list3[i].value + " ";
                }
            }
            //alert("Selected: " + selSIC);
        }

        //alert("Previous length: " + prevSIC.length);

        // Check to see if the SIC code is previously selected
        if (prevSIC.length == 0)
        {
            // Check if limit of 25 SIC codes has reached
            if (selSIC.length > 150)
            {
                alert(window.opener.document.forms[0].maxalert_hidden.value);
            }
            else
            {
                document.forms[0].siccode.value = selSIC;
            }
        }
        else
        {
            var prev_arr = prevSIC.split(" ");
            var sic_arr = selSIC.split(" ");
            //alert("Prev sic codes: "+prev_arr.length);
            //alert("Selected sic codes: "+sic_arr.length);

            for (i = 0; i < sic_arr.length; i++)
            {
                for (j = 0; j < prev_arr.length; j++)
                {
                    //alert("Prev: "+prev_arr[j] + " " +"Sel: "+sic_arr[i]);
                    if (sic_arr[i] == prev_arr[j])
                    {
                        break;
                    }
                }
                if (j == prev_arr.length)
                {
                    // Check if limit of 25 SIC codes has reached	      	 			
                    var len_chk = document.forms[0].siccode.value;
                    if (len_chk.length == 150)
                    {
                        alert(window.opener.document.forms[0].maxalert_hidden.value);
                        break;
                    }
                    else
                    {
                        // SIC Not present in the list already
                        document.forms[0].siccode.value += sic_arr[i] + " ";
                    }
                }
            }
        }
    }
}

function popPdf(url, title) {
    var OpenWindow;
    if (document.all)
        var xMax = screen.width, yMax = screen.height;
    else
    if (document.layers || document.getElementById)
        var xMax = window.outerWidth, yMax = window.outerHeight;
    else
        var xMax = 800, yMax = 600;
    var xOffset = (xMax - 800) / 2, yOffset = ((yMax - 600) / 2);
    var OpenWindow = window.open(url, '', 'width=794,height=546,toolbar=0,location=0,directories=0,status=0,menuBar=0,scrollBars=0,resizable=1,top=' + yOffset + ',left=' + xOffset + '')

    if (window.focus) {
        OpenWindow.focus();
    }
}

function cancelTranslation(context) {
    document.forms[0].action = context + "/gotoHome.do";
    document.forms[0].submit();
}

function saveTranslation() {
    document.forms[0].navigation.value = "SAVE";
    document.forms[0].submit();
    return;
}

function continueTranslation() {
    document.forms[0].navigation.value = "CONTINUE";
    document.forms[0].submit();
    return;
}

function autoCommit(servlet) {
    alert(servlet);
    if (servlet.indexOf('I18n.do') != -1) {
        timerID = setTimeout('doCommit()', 5000)

    }
}
function doCommit() {
    //document.forms[0].action

    alert('commit done');
}


var req;
var which;
var ajaxSection = 0;
function getSampleSize(context)
{
    // Jeevan 26/05/2006: This variables is set to true after AJAX has returned the sample size
    isSampleSizeReady = false;
    var country = document.getElementById("hiddenCountry").value;
    var reg = document.getElementById("hiddenRegion").value;
    var numEmp = formatEmpsSampleSize();
    var turnover = formatTurnoverSampleSize();
    var sic = document.getElementById("SIC").value;


//    console.log(sic);
//    console.log(escape(sic));
//    
    var industries = document.getElementById("IND_DESC").value;

//    console.log(industries);



    var hratio = getHratio();
    var blyClust = document.getElementById("blyClust").value;
    if (blyClust == null) {
        blyClust = '0';
    }
    
    var qryStr = "country=" + escape(country) + "&numEmp=" + escape(numEmp) + "&turnover=" + escape(turnover) + "&sic=" + escape(sic) + "&hratio=" + escape(hratio) + "&industries=" + escape(industries) + "&regions=" + escape(reg) + "&blyCluster=" + escape(blyClust);
    
    ajaxSection = 1;

    call_ajax_sample_size(qryStr, 'sampleValue', 'bmSampleValue');

    //retrieveURL(context+"/getSampleSize.do?"+qryStr);
}

function getSampleSizeAndWait(context)
{
    // Jeevan 26/05/2006: This variables is set to true after AJAX has returned the sample size
    isSampleSizeReady = false;
    var country = document.getElementById("hiddenCountry").value;
    var reg = document.getElementById("hiddenRegion").value;
    var numEmp = formatEmpsSampleSize();
    var turnover = formatTurnoverSampleSize();
    var sic = document.getElementById("SIC").value;
    var industries = document.getElementById("IND_DESC").value;
    var hratio = getHratio();
    var blyClust = document.getElementById("blyClust").value;
    if (blyClust == null) {
        blyClust = '0';
    }
    //alert("sic code from getSampleSize function is " + sic);
    //alert("industry from getSampleSize function is " + industries);

    // Jeevan 20/04/2007: Commenting out the compId, not required anymore for Sample Size
    //var comp = document.getElementById("compId").value;
    //var qryStr = "comp="+escape(comp)+"&country="+escape(country)+"&numEmp="+escape(numEmp)+"&turnover="+escape(turnover)+"&sic="+escape(sic)+"&hratio="+escape(hratio)+"&industries="+escape(industries); 

    var qryStr = "country=" + escape(country) + "&numEmp=" + escape(numEmp) + "&turnover=" + escape(turnover) + "&sic=" + escape(sic) + "&hratio=" + escape(hratio) + "&industries=" + escape(industries) + "&regions=" + escape(reg) + "&blyCluster=" + escape(blyClust);
    //alert("query string is " + qryStr);
    //if (document.getElementById("hiddenRegion") != undefined) {
    //	var reg = getRegionInfo();
    //	qryStr += "&regions="+escape(reg);
    //alert(qryStr);
    //}
    ajaxSection = 1;
    var url = context + "/getSampleSize.do?" + qryStr;
    if (window.XMLHttpRequest) { // Non-IE browsers
        req = new XMLHttpRequest();
    } else if (window.ActiveXObject) { // IE  
        req = new ActiveXObject("Microsoft.XMLHTTP");
    }
    try {
        req.open("POST", url, false);
    } catch (e) {
        //alert(e);
    }
    req.onreadystatechange = processStateChange;
    //req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    req.send(null);
}


function fixTurnoverForSubmit(context) {
    var hf1 = document.getElementById("HF1").value;
    var hf2 = document.getElementById("HF2").value;
    var hf28 = document.getElementById("HF28").value;
    if (hf1 != "" && hf2 != "" && hf28 == "") {
        calculateCurrentTotalTurnover(context);
        return false;
    }

    var ghf1 = document.getElementById("GHF1").value;
    var ghf2 = document.getElementById("GHF2").value;
    var ghf28 = document.getElementById("GHF28").value;
    if (ghf1 != "" && ghf2 != "" && ghf28 == "") {
        calculatePreviousTotalTurnover(context);
        return false;
    }

    return true;
}


function is_numeric(input) {
    return !isNaN(input);
}

function clearInputDataOnYear(changeText) {
    if (confirm(changeText)) {
        for (i = 0; i < document.WM2FinancialServiceMaxiForm.length; i++) {
            if (document.WM2FinancialServiceMaxiForm[i].type == "text") {
                document.WM2FinancialServiceMaxiForm[i].value = "";
            }
        }
        document.getElementById("reset_input").value = "1";
    }
}

function calculateCurrentTotalTurnover(context) {
    document.getElementById("HF28").value = "";
    var hf1 = document.getElementById("HF1").value;
    var hf2 = document.getElementById("HF2").value;
    /*
     if(hf1 && hf1){
     var answer = Number(hf1.replace(",","")) + Number(hf2.replace(",",""));
     if(is_numeric(answer)){
     document.getElementById("HF28").value = answer.toFixed(3);
     }
     }
     */
    var xmlhttp;
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    xmlhttp.onreadystatechange = function() {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            document.getElementById("HF28").value = xmlhttp.responseText;
        }
    }

    xmlhttp.open("GET", "turnover_ajax.php?var1=" + hf1 + "&var2=" + hf2, true);
    xmlhttp.send();
}


function calculatePreviousTotalTurnover(context) {
    document.getElementById("GHF28").value = "";
    var ghf1 = document.getElementById("GHF1").value;
    var ghf2 = document.getElementById("GHF2").value;
    /*
     if(hf1 && hf1){
     var answer = Number(hf1.replace(",","")) + Number(hf2.replace(",",""));
     if(is_numeric(answer)){
     //num.toFixed(3);
     document.getElementById("GHF28").value = answer.toFixed(3);
     }
     }
     */
    var xmlhttp;
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    xmlhttp.onreadystatechange = function() {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            document.getElementById("GHF28").value = xmlhttp.responseText;
        }
    }

    xmlhttp.open("GET", "turnover_ajax.php?var1=" + ghf1 + "&var2=" + ghf2, true);
    xmlhttp.send();
}


function retrieveURL(url) {

    if (window.XMLHttpRequest) { // Non-IE browsers
        req = new XMLHttpRequest();
    } else if (window.ActiveXObject) { // IE  
        req = new ActiveXObject("Microsoft.XMLHTTP");
    }
    try {
        req.open("POST", url, true);
    } catch (e) {
        //alert(e);
    }
    req.onreadystatechange = processStateChange;
    //req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    req.send(null);
}

function LtrimFull(trimString) {
    for (ii = 0; ii < trimString.length; ++ii) {
        switch (trimString.charAt(ii)) {
            case ' ':
            case '\n':
            case '\r':
            case '\t':
                break;
            default:
                return trimString.substring(ii);
        }

    }
}

function RtrimFull(trimString) {
    for (ii = trimString.length - 1; ii >= 0; --ii) {
        switch (trimString.charAt(ii)) {
            case ' ':
            case '\n':
            case '\r':
            case '\t':
                break;
            default:
                return trimString.substring(0, ii + 1);
        }

    }
}

function processStateChange() {
    if (req.readyState == 4) { // Complete
        if (req.status == 200) { // OK response
            switch (ajaxSection) {
                case 1:
                    areSicCodesValid(req.responseText);
                    break;
                case 2:
                    document.getElementById("HF28").value = LtrimFull(RtrimFull(req.responseText));
                    break;
                case 3:
                    document.getElementById("GHF28").value = LtrimFull(RtrimFull(req.responseText));
                    break;
                case 4:
                    doRegions(req.responseText);
                    break;
                case 5:
                    populateAddRemoveCountryRegionSelection(req.responseText);
                    break;
                case 6:
                    getFilteredBusinessAreasAJAX(req.responseText);
                    break;
                case 7:
                    displaySubIndustriesAJAX(req.responseText);
                    break;
                case 8:
                    displaySicCodesAJAX(req.responseText);
                    break;
            }
        } else {
            ; //alert("Problem: " + req.status);
        }
    }
}


function changeTurnoverCheckBox(checkBoxName) {
    var box = document.getElementById(checkBoxName + 'CheckBox');
    box.checked = !box.checked;
    handleTurnoverCheckBoxChange(checkBoxName, true);
}

function handleTurnoverCheckBoxChange(checkBoxName, clearValues) {
    var box = document.getElementById(checkBoxName + 'CheckBox');
    var calcBox = document.getElementById(checkBoxName);
    if (checkBoxName == "GHF28") {
        var ref1 = document.getElementById("GHF1");
        var ref2 = document.getElementById("GHF2");
    }
    else {
        var ref1 = document.getElementById("HF1");
        var ref2 = document.getElementById("HF2");
    }


    if (box.checked) {
        if (clearValues) {
            ref2.value = ref1.value = "";
        }
        ref2.style.border = ref1.style.border = "0px none";
        calcBox.style.border = "1px solid #636363";
        calcBox.readOnly = false;
        ref1.readOnly = ref2.readOnly = true;
    }
    else {
        ref2.style.border = ref1.style.border = "1px solid #636363";
        calcBox.style.border = "0px none";
        if (clearValues) {
            calcBox.value = "";
        }
        calcBox.readOnly = true;
        ref1.readOnly = ref2.readOnly = false;
    }
}



function setManuallyEnteredBox(BoxName) {

    var hf1;
    var hf2;
    if (BoxName == "GHF28") {
        hf1 = document.getElementById("GHF1").value;
        hf2 = document.getElementById("GHF2").value;
    }
    else {
        hf1 = document.getElementById("HF1").value;
        hf2 = document.getElementById("HF2").value;
    }

    var hf28 = document.getElementById(BoxName).value;
    var box = document.getElementById(BoxName + "CheckBox");
    var newVal;
    newVal = (hf1 == "" && hf2 == "" && hf28 != "");
    box.checked = newVal;
    handleTurnoverCheckBoxChange(BoxName, false);
}

function setManuallyEnteredBoxes() {
    setManuallyEnteredBox("HF28");
    setManuallyEnteredBox("GHF28");
}

function getCountryInfo() {
    if (document.forms[0].COUNTRY.options[0].value == 0)
    {
        return 'all';
    }
    var countryList = '';
    for (i = 0; i < document.forms[0].COUNTRY.options.length; i++) {
        if (document.forms[0].COUNTRY.options[i].selected) {
            countryList += document.forms[0].COUNTRY.options[i].value + ',';
        }
    }
    countryList = countryList.substring(0, (countryList.length - 1));
    return countryList;
}

function getRegionInfo() {
    if (document.forms[0].REGION.options[0].value == 0)
    {
        return 'all';
    }

    var regionList = '';
    for (i = 0; i < document.forms[0].REGION.options.length; i++) {
        if (document.forms[0].REGION.options[i].selected) {
            regionList += document.forms[0].REGION.options[i].value + ',';
        }
    }
    regionList = regionList.substring(0, (regionList.length - 1));
    return regionList;
}

function getRegionInfoSco() {
    //Added by Navin on 17/01/2005 to get RegionInfo for Scottish domain
    if (document.forms[0].REGION.options[0].selected) {
        return 'all';
    }
    var regionList = '';
    for (i = 0; i < document.forms[0].REGION.options.length; i++) {
        if (document.forms[0].REGION.options[i].selected) {
            regionList += document.forms[0].REGION.options[i].value + ',';
        }
    }
    regionList = regionList.substring(0, (regionList.length - 1));
    return regionList;
}

function formatEmpsSampleSize()
{
    var val = ""

    if ((document.forms[0].EMP1.value == "NULL") && (document.forms[0].EMP2.value == "NULL")) {
        val = "";
    } else if ((document.forms[0].EMP1.value != "NULL") && (document.forms[0].EMP2.value == "NULL")) {
        val = " >= " + document.forms[0].EMP1.value;
    } else if ((document.forms[0].EMP1.value == "NULL") && (document.forms[0].EMP2.value != "NULL")) {
        val = " <= " + document.forms[0].EMP2.value;
    } else {
        val = document.forms[0].EMP1.value + " - " + document.forms[0].EMP2.value;
    }
    return val;
}

function formatTurnoverSampleSize()
{
    var val = "";
    if ((document.forms[0].TURN1.value == "NULL") && (document.forms[0].TURN2.value == "NULL")) {
        val = "";
    } else if ((document.forms[0].TURN1.value != "NULL") && (document.forms[0].TURN2.value == "NULL")) {
        val = " >= " + document.forms[0].TURN1.value;
    } else if ((document.forms[0].TURN1.value == "NULL") && (document.forms[0].TURN2.value != "NULL")) {
        val = " <= " + document.forms[0].TURN2.value;
    } else {
        val = document.forms[0].TURN1.value + " - " + document.forms[0].TURN2.value;
    }
    return val;
}

function getHratio() {
    var val = 0;
    if (document.forms[0].HRATIO_B.length != null)
    {

        for (i = 0; i < document.forms[0].HRATIO_B.length; i++) {
            if (document.forms[0].HRATIO_B[i].checked) {
                val = document.forms[0].HRATIO_B[i].value;
                break;
            }
        }
    }
    else {
        val = document.forms[0].HRATIO_B.value;
    }

    return val;
}

var sicOpen = false;
function displayINDUSTRYWindow(context) {
    // Open a popup-window when user clicks	"BUSINESS AREAS" link 
    if (window.sicWin && !sicWin.closed)
    {
        sicWin.focus();
    }
    else
    {
        var sicCodes = document.getElementById("SIC").value;
        sicWin = window.open(context + "/searchIndustries.do?sic=" + sicCodes, "", "toolbar=no,menubar=no,scrollbars=no,resizable=no,status=yes,location=no,directories=no,copyhistory=no,height=360,width=560,top=80,left=200");
        sicOpen = true;
    }
}

// Jeevan: In the pop-up of Business areas, mark the ones which are already selected.
function markSelectedBusinessAreas()
{
    var prevBA = window.opener.document.forms[0].INDUSTRY.value;
    var prevBA_arr = prevBA.split(" ");
    //alert("Selected BAs: "+prevBA_arr.length);
    for (var i = 0; i < prevBA_arr.length; i++)
    {
        for (var j = 0; j < document.forms[0].industry.options.length; j++)
        {
            if (document.forms[0].industry.options[j].value == prevBA_arr[i])
            {
                //alert(document.forms[0].industry.options[j].value);
                document.forms[0].industry.options[j].selected = true;
            }
        }
    }
}

// Jeevan: function added to clear the selected business areas
function clearBusinessAreas()
{
    var confirmDel = confirm(document.forms[0].clearbusialert_hidden.value);
    if (confirmDel == true)
    {
        document.getElementById("IND_DESC").value = "";
        document.forms[0].INDUSTRY.value = "";
        document.forms[0].INDUSTRY.focus();
    }
}

// Jeevan: clear the IND_DESC which is used to calculate sampleSize
function updateIndDescField()
{
    if (document.forms[0].INDUSTRY.value == "")
    {
        document.getElementById("IND_DESC").value = "";
    }
}

function selectIndustryCode() {

    var industryString = "";
    var hiddenString = "";
    for (var counter = 0; counter < document.forms[0].industry.options.length; counter++) {

        if (document.forms[0].industry.options[counter].selected) {
            industryString += document.forms[0].industry.options[counter].value + " ";
            hiddenString += "/" + document.forms[0].industry.options[counter].value + "/,";
        }
    }

    window.opener.document.forms[0].INDUSTRY.value = industryString;
    window.location.reload();
    window.close();
    // POPULATE HIDDEN STRING IN FORM
    window.opener.document.forms[0].IND_DESC.value = hiddenString;
    window.opener.document.forms[0].INDUSTRY.focus();
}


var ajaxSection = 0;
function getRegions(context) {
    var country = getCountryInfo();
    var qryStr = "country=" + escape(country);
    ajaxSection = 4;
    retrieveURL(context + "/getCriteriaRegionsAjax.do?" + qryStr);
}


function doRegions(regStr) {
    regStr = regStr.replace(/^\s*|\s*$/g, "");
    var tempCode = '';
    var tempVal = '';
    var count = eval(regStr.substring(0, regStr.indexOf(",")));
    var comma = 1;
    if (count >= 10)
        comma = 2;
    document.forms[0].REGION.options.length = 1;
    for (i = 1; i <= count; i++) {
        var code = regStr.substring(comma + 1, regStr.length);
        var comma = code.indexOf(',');
        tempCode = code.substring(0, comma);
        var val = code.substring(comma + 1);
        if (i == count) {
            tempVal = val.substring(0);
        } else {
            comma = val.indexOf(',');
            tempVal = val.substring(0, comma);
        }
        var opt = new Option(tempVal, tempCode);
        document.forms[0].REGION.options[i] = opt;
        if (i < count) {
            regStr = val.substring(comma + 1);
            comma = -1;
            tempCode = '';
            tempVal = '';
        }
    }
}

function populateSelectedCountries() {

    var tmpString = '';
    for (i = 0; i < document.forms[0].COUNTRY.options.length; i++) {
        if (document.forms[0].COUNTRY.options[i].selected) {
            tmpString += document.forms[0].COUNTRY.options[i].value + ",";
        }
    }
    document.forms[0].COUNTRY_HIDDEN.value = tmpString;
}

// Jeevan: 102 - To display contextual help in the Super user page.
function displayContextualHelp(selection)
{
    switch (selection)
    {
        case 1:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help1.value;
            break;
        case 2:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help2.value;
            break;
        case 3:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help3.value;
            break;
        case 4:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help4.value;
            break;
        case 5:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help5.value;
            break;
        case 6:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help6.value;
            break;
        case 7:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help7.value;
            break;
        case 8:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help8.value;
            break;
        case 9:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help9.value;
            break;
        case 10:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help10.value;
            break;
        case 11:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help11.value;
            break;
        case 12:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help12.value;
            break;
        case 13:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help13.value;
            break;
        case 14:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help14.value;
            break;
        case 15:
            document.getElementById("contextHelp").innerHTML = document.forms[0].help15.value;
            break;
        case 99:
            document.getElementById("contextHelp").innerHTML = "";
            break;
    }
}

// Jeevan: To display a popup for choosing country and regions
var sicOpen = false;
function displayCountryRegionWindow(context)
{
    // Open a popup-window when user clicks	"Search sic" link 
    if (window.sicWin && !sicWin.closed)
    {
        sicWin.focus();
    }
    else
    {
        sicWin = window.open(context + "/popupCountryRegions.do?country=all", "", "toolbar=no,menubar=no,scrollbars=no,resizable=no,status=yes,location=no,directories=no,copyhistory=no,height=360,width=350,top=80,left=200");
        sicOpen = true;
    }
}

// Jeevan: get the selected countries and regions from the criteria page and populate the 'selected country' and 'selected region' in popup window
function getSelectedCountryAndRegions()
{
    var selCon = window.opener.document.forms[0].COUNTRY.length;
    var selReg = window.opener.document.forms[0].REGION.length;
    var i = 0;
    // Fetch countries selected from the main page
    if (window.opener.document.forms[0].COUNTRY.options[0].value != 0)
    {
        for (i = 0; i < selCon; i++)
        {
            document.forms[0].selCountry.options[i] = new Option(window.opener.document.forms[0].COUNTRY.options[i].text, window.opener.document.forms[0].COUNTRY.options[i].value);
        }
    }

    // fetch regions selected from the main page
    if (window.opener.document.forms[0].REGION.options[0].value != 0)
    {
        for (i = 0; i < selReg; i++)
        {
            document.forms[0].selRegions.options[i] = new Option(window.opener.document.forms[0].REGION.options[i].text, window.opener.document.forms[0].REGION.options[i].value);
        }
    }
}

// Jeevan: Retrieve all the regions for the selected country after clicking 'get regions' link
function retrieveRegions(context)
{
    // Mark the entries as selected, so that the action can pick the selections
    for (var i = 0; i < document.forms[0].selCountry.options.length; i++)
    {
        document.forms[0].selCountry.options[i].selected = true;
    }
    for (var i = 0; i < document.forms[0].selRegions.options.length; i++)
    {
        document.forms[0].selRegions.options[i].selected = true;
    }

    document.forms[0].submit();
}

// Jeevan: Select the chosen countries and regions in POPUP
// Used to copy countries and regions in the POPUP window
function selectCountriesAndRegions()
{
    // clear the country and region boxes
    //clearAllCountryAndRegions();

    // Checking if both contry and regions boxes have some values to transfer to the selected boxes
    if (document.forms[0].country.options.length > 0 && document.forms[0].regions.options.length > 0)
    {
        // GETTING THE SELECTED COUNTRIES
        for (var i = 0; i < document.forms[0].country.options.length; i++)
        {
            if (document.forms[0].country.options[i].selected == true)
            {
                for (var j = 0; j < document.forms[0].selCountry.options.length; j++)
                {
                    // This country is already present in the selected countries
                    if (document.forms[0].country.options[i].value == document.forms[0].selCountry.options[j].value)
                    {
                        break;
                    }
                }
                // Need to add this country to the selected countries
                if (j == document.forms[0].selCountry.options.length)
                {
                    document.forms[0].selCountry.options[j] = new Option(document.forms[0].country.options[i].text, document.forms[0].country.options[i].value);
                }
            }
        }

        // GETTING THE SELECTED REGIONS
        // All regions option is selected
        if (document.forms[0].regions.options[0].selected)
        {
            for (var i = 1; i < document.forms[0].regions.options.length; i++)
            {
                for (var j = 0; j < document.forms[0].selRegions.options.length; j++)
                {
                    // This region is present in the selected regions
                    if (document.forms[0].regions.options[i].value == document.forms[0].selRegions.options[j].value)
                    {
                        break;
                    }
                }
                // Need to add this region to the selected regions
                if (j == document.forms[0].selRegions.options.length)
                {
                    document.forms[0].selRegions.options[j] = new Option(document.forms[0].regions.options[i].text, document.forms[0].regions.options[i].value);
                }
            }
        }
        // Specific regions selected
        else
        {
            for (var i = 1; i < document.forms[0].regions.options.length; i++)
            {
                if (document.forms[0].regions.options[i].selected == true)
                {
                    for (var j = 0; j < document.forms[0].selRegions.options.length; j++)
                    {
                        // This region is present in the selected regions
                        if (document.forms[0].regions.options[i].value == document.forms[0].selRegions.options[j].value)
                        {
                            break;
                        }
                    }
                    // Need to add this region to the selected regions
                    if (j == document.forms[0].selRegions.options.length)
                    {
                        document.forms[0].selRegions.options[j] = new Option(document.forms[0].regions.options[i].text, document.forms[0].regions.options[i].value);
                    }
                }
            }
        } // End of else
    } // End of if 'checking if both country and regions boxes have something to select'
}

// Jeevan: Revert the country and regions selections back to default, on criteria page
function clearCountryRegions()
{
    var confirmDel = confirm(document.forms[0].clearcountregsalert_hidden.value);
    if (confirmDel == true)
    {
        // Remove all countries
        for (var i = document.forms[0].COUNTRY.options.length; i >= 0; i--)
        {
            document.forms[0].COUNTRY.options[i] = null;
        }

        // Remove all regions  	
        for (var i = document.forms[0].REGION.options.length; i >= 0; i--)
        {
            document.forms[0].REGION.options[i] = null;
        }

        // Add all countries and all regions
        document.forms[0].COUNTRY.options[0] = new Option("All countries", 0, true, true);
        document.forms[0].REGION.options[0] = new Option("All regions", 0, true, true);
        document.forms[0].COUNTRY.focus();
    }
}

// Jeevan: Clear the selected countries and regions, in POPUP
function clearSelectedCountriesAndRegions()
{
    // Remove selected countries, and remove the corresponding regions
    for (var i = 0; i < document.forms[0].selCountry.options.length; i++)
    {
        if (document.forms[0].selCountry.options[i].selected)
        {
            var cCode = document.forms[0].selCountry.options[i].value;
            // Remove all regions for the selected country	
            for (var j = document.forms[0].selRegions.options.length - 1; j >= 0; j--)
            {
                var rCode = document.forms[0].selRegions.options[j].value;
                // E.g. cCode = UK and rCode = UK123
                if (rCode.indexOf(cCode) != -1)
                {
                    document.forms[0].selRegions.options[j] = null;
                }
            }
            // Remove this country
            document.forms[0].selCountry.options[i] = null;
        }
    }

    // Remove the selected regions
    for (var i = document.forms[0].selRegions.options.length - 1; i >= 0; i--)
    {
        if (document.forms[0].selRegions.options[i].selected)
        {
            document.forms[0].selRegions.options[i] = null;
        }
    }

    // Check all the countries if they have atleast one region present in the regions box, if not, remove the country
    for (var i = document.forms[0].selCountry.options.length - 1; i >= 0; i--)
    {
        for (var j = document.forms[0].selRegions.options.length - 1; j >= 0; j--)
        {
            var cCode = document.forms[0].selCountry.options[i].value;
            var rCode = document.forms[0].selRegions.options[j].value;
            // E.g. cCode = UK and rCode = UK123
            if (rCode.indexOf(cCode) != -1)
            {
                break;
            }
        }
        // no regions present for this country, remove it from the list
        if (j < 0)
        {
            document.forms[0].selCountry.options[i] = null;
        }
    }
}

// Jeevan: To Clear all the selections from the country and regions, in POPUP window
function clearAllCountryAndRegions()
{
    // Remove all countries
    for (var i = document.forms[0].selCountry.options.length; i >= 0; i--)
    {
        document.forms[0].selCountry.options[i] = null;
    }

    // Remove all regions  	
    for (var i = document.forms[0].selRegions.options.length; i >= 0; i--)
    {
        document.forms[0].selRegions.options[i] = null;
    }
}

// Jeevan: save the selected countries and regions from the popup window into the criteria page
function saveAndExitSelectedCountriesRegions()
{
    if ((document.forms[0].selCountry.options.length > 0) && (document.forms[0].selRegions.options.length > 0))
    {
        // Removing all the entries from the criteria page (country and regions field)		
        window.opener.document.forms[0].COUNTRY.options.length = 0;
        window.opener.document.forms[0].REGION.options.length = 0;
        // Copy all the selected countries from popup window onto the criteria page			
        for (var i = 0; i < document.forms[0].selCountry.options.length; i++)
        {
            // addCountry function defined in the createBMCriteriaDetails.jsp page
            // this is required for select box !!! the function to add new option must be in the same jsp page
            window.opener.addCountry(document.forms[0].selCountry.options[i].text, document.forms[0].selCountry.options[i].value);
        }

        // Copy all the selected regions from popup window onto the criteria page	  	
        for (var i = 0; i < document.forms[0].selRegions.options.length; i++)
        {
            // addRegion function defined in the createBMCriteriaDetails.jsp page
            // this is required for select box !!! the function to add new option must be in the same jsp page
            window.opener.addRegion(document.forms[0].selRegions.options[i].text, document.forms[0].selRegions.options[i].value);
        }
    }
    window.opener.document.forms[0].COUNTRY.focus();
    window.close();
}


// Jeevan: Generating popup in case of system maintenance
function maintenancePopup(context)
{
    document.getElementById("userId").disabled = true;
    document.getElementById("password").disabled = true;
    sicWin = window.open(context + "/systemError.jsp", "", "toolbar=no,menubar=no,scrollbars=no,resizable=no,status=yes,location=no,directories=no,copyhistory=no,height=240,width=560,top=80,left=200");
    sicOpen = true;
}

//DARREN 09/02/2006: AUTOMATICALLY OPEN A POP-UP AFTER A PDF OUTPUT REPORT HAS BEEN GENERATED
function openPDFWindow(serverString, url, title) {
    if (url == 1) {
        /*var mine = window.open('','','width=1,height=1,left=1,top=1,scrollbars=no');
         if(mine != null) {
         var popUpsBlocked = false;
         mine.close();
         }
         else {
         var popUpsBlocked = true;
         alert(warningText);
         }*/
        ;
    }
    else {
        popPdf(serverString + url, title);
    }
}

// Jeevan 08/05/2006: Check if the country and regions are all filled in. Used from Country/Region translation interface.
function chkIfCountryRegionIsEmpty()
{
    var countryRegNames = document.getElementById("countryRegNames").value;
    var elementNames = countryRegNames.split(",");
    var isError = false;
    //alert(countryRegNames);
    //alert(elementNames.length);

    for (var i = 0; i < elementNames.length; i++)
    {
        var val = document.getElementById(elementNames[i]).value;
        val = RTrim(val);
        val = LTrim(val);
        //alert(val);

        if (val == "")
        {
            isError = true;
            document.getElementById(elementNames[i]).value = "";
        }
    }

    if (isError == false)
    {
        document.forms[0].submit();
    }
    else
    {
        alert(document.getElementById("emptyErrorMsg").value);
    }
}

// Jeevan 09/05/2006: This function will trim off the Right spaces from the String
function RTrim(VALUE)
{
    var w_space = String.fromCharCode(32);
    var v_length = VALUE.length;
    var strTemp = "";
    if (v_length < 0)
    {
        return"";
    }

    var iTemp = v_length - 1;
    while (iTemp > -1)
    {
        if (VALUE.charAt(iTemp) == w_space)
        {
        }
        else
        {
            strTemp = VALUE.substring(0, iTemp + 1);
            break;
        }
        iTemp = iTemp - 1;
    }

    return strTemp;
}

// Jeevan 09/05/2006: This function will trim off the Left spaces from the String
function LTrim(VALUE)
{
    var w_space = String.fromCharCode(32);
    if (v_length < 1)
    {
        return"";
    }

    var v_length = VALUE.length;
    var strTemp = "";
    var iTemp = 0;
    while (iTemp < v_length)
    {
        if (VALUE.charAt(iTemp) == w_space)
        {
        }
        else
        {
            strTemp = VALUE.substring(iTemp, v_length);
            break;
        }
        iTemp = iTemp + 1;
    }

    return strTemp;
}

// Jeevan 26/05/2006: Function called from the Criteria page to check if there are any invalid SIC codes selected
function submitCheckInvalidSiccodes()
{
    var chkSic = document.getElementById("sampleSize").innerHTML;
    // This condidtion checks if the sample size function has executed and got back the sample size.
    // This is done as it might get back with invalid sic codes
    if (isSampleSizeReady == true)
    {
        // If the sample size is a numeric value, then its a valid SIC code
        if (parseInt(chkSic) == chkSic)
        {
            isSampleSizeReady = false;
            document.forms[0].submit();
        }
        else
        {
            alert(chkSic);
        }
    }
}


/*ADDED BY DARREN H 26/05/2006: ER-527-0031 REQUIRES BENCHMARK COMPANY TO POSSIBLY HAVE 2 SIC-CODES*/
/*THEREFORE NEED POP-UP TO SELECT THE SIC-CODES*/
var sicOpen = false;
function selectSicCode(context, nace) {

    /* GET VALUE OF SIC-CODE FROM THE FORM */
    var formNaceVal = document.getElementById(nace).value;
    if (window.sicWin && !sicWin.closed)
    {
        sicWin.focus();
    }
    else if (formNaceVal == '') {
        /*IF VALUE IN FORM IS EMPTY STRING THEN FORWARD USER TO TOP LEVEL SIC-CODE SELECTION JSP*/
        sicWin = window.open(context + "/BMCompanyAndSic.do?list=1&nace=" + nace, "", "toolbar=no,menubar=no,scrollbars=no,resizable=no,status=yes,location=no,directories=no,copyhistory=no,height=500,width=695,top=40,left=400");
        sicOpen = true;
    }
    else {
        /* FORM CONTAINS A SIC-CODE. FORWARD USER TO THIRD LEVEL SIC-CODE SELECTION JSP */
        sicWin = window.open(context + "/editBMCompanyNoCurrencyAndSic.do?list=1&nace=" + nace + "&formNaceVal=" + formNaceVal, "", "toolbar=no,menubar=no,scrollbars=no,resizable=no,status=yes,location=no,directories=no,copyhistory=no,height=500,width=695,top=40,left=400");
        sicOpen = true;
    }
}

/*ADDED BY DARREN H 26/05/2006: ER-527-0031 REQUIRES BENCHMARK COMPANY TO POSSIBLY HAVE 2 SIC-CODES*/
/*THIS FUNCTION SETS THE VALUE OF THE SELECTED SI-CODE, EG SIC1 OR SIC2, IN THE PARENT WINDOW FORM*/
function saveSelectedSICCode(nace)
{
    /* GET VALUE OF SIC-CODE FROM THE PARENT WINDOW */
    var formNaceVal = window.opener.document.getElementById(nace).value;
    /* GET VALUE OF SIC-CODE FROM THE POP-UP */
    var sicCodeValue = document.forms[0].siccode.value;
    /* TRIM THE SIC-CODE STRING */
    sicCodeValue = LTrim(sicCodeValue);
    sicCodeValue = RTrim(sicCodeValue);
    /* IF NACE = NACE THEN THE USER HAS SELECTED sic1 */
    if (nace == 'nace') {
        window.opener.document.getElementById("nace").value = sicCodeValue;
    } else { /* THE USER HAS SELECTED sic2 */
        window.opener.document.getElementById("nace2").value = sicCodeValue;
    }
    window.close();
}

/* DARREN H 09/06/2006: ER-527-0020 FUNCTION CALLED IN HTML OUTPUT REPORT PAGES TO SEND USER BACK TO CRITERIA PAGE TO ALTER BENCHMARKING CRITERIA */
function backToCriteria(context, bmtype, count, comp) {
    var compId = comp;
    var urlString = context + "/setupBMCriteria.do?category=" + bmtype + "&compId=" + compId;
    if (count < 3) {
        //SEND USER TO URL
        window.location = urlString;
    } else {
        //DISPLAY CONFIRM BOX TO USER
        var confirmString = confirm(beanmessage);
        if (confirmString == true) {
            window.location = urlString;
        }
    }
}
function MybackToCriteria(comp, sectors) {

    var urlString = "/benchmark/setupbmcriteria.php?compId=" + comp + "&sectors=" + sectors;
    //alert(urlString);
    window.location = urlString;
}

// Jeevan: This function is used in the Suspend Adviser Companies and Suspend Adviser Functionality
// This is done to identify only those users or adviser companies whose status has been updated and then use this in DAO to update
// This saves on lots of redundant database connections and unnecessary Updates.
function hasStatusChanged(id) {
    document.getElementById("suspendFlag_" + id).value = 1;
}

/* ADDED BY DARREN 04/07/2007: FUNCTION TO PASS SELECTED SIC CODES TO STRUTS ACTION. 
 THE BUSINESS AREAS ARE THEN FILTERED OFF ACCORDINGLY */
var ajaxSection = 0;
function getBusinessAreasExcludingSicCodesAjax(context) {

    var sic = document.getElementById("SIC").value;
    var qryStr = "sic=" + sic;
    ajaxSection = 6;
    retrieveURL(context + "/getBusinessAreasExcludingSicCodesAjax.do?" + qryStr);
}

/* ADDED BY DARREN 06/07/2007: FUNCTION USED TO POPULATE FILTERED BUSINESS AREAS VIA AJAX */
function getFilteredBusinessAreasAJAX(responseText) {

    //alert(responseText);
    var businessAreasArray = eval(responseText);
    if (businessAreasArray != null) {

        //clear the options from the INDUSTRY select box
        for (var i = document.forms[0].INDUSTRY.options.length; i >= 0; i--)
        {
            document.forms[0].INDUSTRY.options[i] = null;
        }

        /* THIS FUNCTION IS CALLED FROM WITHIN THE createBMCriteriaDetails.jsp AND IS USED TO ADD BUSINESS AREAS TO THE MULTI-SELECT BOX */
        addFilteredBusinessAreas(businessAreasArray);
    } else {
        alert(responseText);
    }

}


/* ADDED BY DARREN 06/07/2007: FUNCTION TO GET THE SUB-INDUSTRY OF THE SELECTED INDUSTRY VIA A STRUTS ACTION */
var ajaxSection = 0;
function getSubIndustriesAjax(id) {

    //var industryCode = document.getElementById("list1").value;
    var industryCode = document.forms[0].list1.value;
    //clear the options from the SUB-INDUSTRY select box
    for (var i = document.forms[0].subIndustry.options.length; i >= 0; i--)
    {
        document.forms[0].subIndustry.options[i] = null;
    }

    //clear the options from the SIC-CODE select box
    for (var i = document.forms[0].sicCode.options.length; i >= 0; i--)
    {
        document.forms[0].sicCode.options[i] = null;
    }

    if (industryCode != 0) { /* SUB-INDUSTRY HAS BEEN SELECTED */

        var qryStr = "sub=1&industryCode=" + industryCode;
        call_ajax_sic_code(qryStr, id)
        //retrieveURL(context+"/getSubIndustriesAjax.do?"+qryStr);

    }
}

/* ADDED BY DARREN 06/07/2007: FUNCTION USED TO DISPLAY THE SUB-INDUSTRY(S) LINKED TO THE SELECTED INDUSTRY CODE */
function displaySubIndustriesAJAX(responseText) {

    var subIndustriesArray = eval(responseText);
    //clear the options from the SUB-INDUSTRY select box
    for (var i = document.forms[0].subIndustry.options.length; i >= 0; i--)
    {
        document.forms[0].subIndustry.options[i] = null;
    }

    /* THIS FUNCTION IS CALLED FROM WITHIN THE createBMCriteriaDetails.jsp AND IS USED TO ADD SUB INDUSTRIES TO THE MULTI-SELECT BOX */
    addSubIndustriesToSelectBox(subIndustriesArray);
}

/* ADDED BY DARREN: FUNCTION USED TO GET THE SIC CODES FOR THE SELECTED SUB-INDUSTRY */
var ajaxSection = 0;
function getSicCodesAjax(id) {

    //var subIndustryCode = document.getElementById("list2").value;
    var subIndustryCode = document.forms[0].list2.value;
    //clear the options from the SIC-CODE select box
    for (var i = document.forms[0].sicCode.options.length; i >= 0; i--)
    {
        document.forms[0].sicCode.options[i] = null;
    }

    if (subIndustryCode != 0) {
        var qryStr = "sub=2&industryCode=" + subIndustryCode;
        call_ajax_sic_code(qryStr, id);
        //var qryStr = "subIndustryCode="+subIndustryCode;
        //ajaxSection = 8;

        //retrieveURL(context+"/getSicCodesAjax.do?"+qryStr);

    }

}

/* ADDED BY DARREN: FUNCTION USED TO DISPLAY THE SIC CODES RELATED TO THE SELECTED SUB INDUSTRY */
function displaySicCodesAJAX(responseText) {

    var sicCodesArray = eval(responseText);
    //clear the options from the SIC-CODES select box
    for (var i = document.forms[0].sicCode.options.length; i >= 0; i--)
    {
        document.forms[0].sicCode.options[i] = null;
    }

    /* THIS FUNCTION IS CALLED FROM WITHIN THE createBMCriteriaDetails.jsp AND IS USED TO ADD SIC CODES TO THE MULTI-SELECT BOX */
    addSicCodesToSelectBox(sicCodesArray);
}

// Jeevan: This function is used in the createBMCriteriaDetails.jsp page
// This is an AJAX call to add selected contry(s) and region(s)
// Called when the ADD button of Country/Regions clicked
function addSelectedCountryRegionCriteria(context)
{
    //alert('hello');
    //alert(document.forms[0].selected_country_regions.options[0].value);
    //ajaxSection = 5;
    var qryStr = "fn=add&toAdd=";
    //var qrySelected = "&selected=";

    for (var i = 0; i < document.forms[0].country_regions.options.length; i++)
    {
        if (document.forms[0].country_regions.options[i].selected == true)
        {
            qryStr = qryStr + document.forms[0].country_regions.options[i].value + ",";
            document.forms[0].country_regions.options[i].selected = false;
        }
    }

    //if(document.forms[0].selected_country_regions.options[0].value=="0") 
    //{
    //	flushAllCountryAndRegions();
    //}

    for (var i = 0; i < document.forms[0].selected_country_regions.options.length; i++)
    {
        my_string = document.forms[0].selected_country_regions.options[i].value;
        if (my_string.indexOf('_') != -1)
        {
            qryStr = qryStr + document.forms[0].selected_country_regions.options[i].value + ",";
        }
    }

    get = qryStr;
    id = 'selections';
    //alert(get+" : "+id);

    call_ajax_add_countries(get, id);
    //retrieveURL(context+"/addRemoveSelectedCountryRegionCriteriaAjax.do?"+qryStr+qrySelected);
}

// Jeevan: This function is used in the createBMCriteriaDetails.jsp page
// This is an AJAX call to remove selected contry(s) and region(s)
// Called when the REMOVE button of Country/Regions clicked
function removeSelectedCountryRegionCriteria(context)
{
    //ajaxSection = 5;
    var qryStr = "fn=remove&toRemove=";
    var qrySelected = "&selected=";
    var anySelected = 0;
    id = 'selections';
    // loop through to check if any selected
    for (var i = 0; i < document.forms[0].selected_country_regions.options.length; i++)
    {
        if (document.forms[0].selected_country_regions.options[i].selected == true)
        {
            anySelected = 1;
            qrySelected = qrySelected + document.forms[0].selected_country_regions.options[i].value + ",";
        }
    }
    // if none selected do nothing
    if (anySelected == 0)
    {
        return;
    }

    for (var i = 0; i < document.forms[0].selected_country_regions.options.length; i++)
    {
        if (document.forms[0].selected_country_regions.options[i].selected == false)
        {
            qryStr = qryStr + document.forms[0].selected_country_regions.options[i].value + ",";
        }
    }

    document.getElementById(id).innerHTM = '<select name="selected_country_regions" multiple="multiple" size="4" id="selected_country_regions"></select>';
    qryStr = qryStr + qrySelected;
    //alert(qryStr);
    call_ajax_add_countries(qryStr, id);
}

// Jeevan: This funtion is called after the AJAX action is returned. 
// This function, depending upon the Tokens strip the Country and Region values and populate the Country_Region dropdown in Criteria page
function populateAddRemoveCountryRegionSelection(addRemoveCountryRegionAjax)
{
    // eval function evaluates the code passed to it. In this case 'addRemoveCountryRegionAjax' is a string formatted in the javascript Array format.
    // eval function will convert it to an Array that Javascript can work with.
    var ajaxArray = eval(addRemoveCountryRegionAjax);
    var hiddenCountryStr = "";
    var hiddenRegionStr = "";
    flushAllCountryAndRegions();
    // If ajaxArray = null or undefined, which is what returned from the 'eval' function, that means it was not a valid string to evaluate
    // It can be the case if 'addRemoveCountryRegionAjax' is an empty string.
    if (ajaxArray != null)
    {
        // Tokens:
        // #$# : seperates Country and Regions
        // #-# : seperates a code and its description for both country and regions
        // E.g.: An array element will contain: UK#-#United Kingdon#$#UK_111#-#London,UK_222#-#Midland
        for (var i = 0; i < ajaxArray.length; i++)
        {
            var arrayElement = ajaxArray[i];
            var elementArray = arrayElement.split("#$#"); // Seperate Country and Regions 
            var countryArray = elementArray[0].split("#-#"); // Seperates Country_Code and Country_Description
            var regionArray = elementArray[1].split(","); // Seperates Regions

            // Add the Country in 'Selected_Country_Regions'
            addCountryRegionElement(countryArray[1], countryArray[0]);
            // Form a ',' seperated string of Country_Ids
            hiddenCountryStr = hiddenCountryStr + countryArray[0] + ",";
            // Add Regions from the Country
            for (var j = 0; j < regionArray.length; j++)
            {
                var regionElement = regionArray[j].split("#-#"); // Seperates Region_id and Region_Description
                // Add the Region in 'Selected_Country_Regions'
                addCountryRegionElement("   " + regionElement[1], regionElement[0]);
                // Form a ',' seperated string of Region_Ids
                hiddenRegionStr = hiddenRegionStr + regionElement[0] + ",";
            }
        }

        hiddenCountryStr = hiddenCountryStr.substring(0, (hiddenCountryStr.length - 1));
        hiddenRegionStr = hiddenRegionStr.substring(0, (hiddenRegionStr.length - 1));
        //document.forms[0].selected_country_regions.options[0].selected=true;
    }

    // If everything is removed from the 'selected_country_regions' box, insert all country and regions option
    if (document.forms[0].selected_country_regions.options.length == 0)
    {
        addCountryRegionElement("All countries and regions", "0");
        document.forms[0].hiddenCountry.value = "all";
        document.forms[0].hiddenRegion.value = "all";
    }
    else
    {
        // Populate the hidden variables for Country and Region, this will be used for Sample Saize calculation.
        document.forms[0].hiddenCountry.value = hiddenCountryStr;
        document.forms[0].hiddenRegion.value = hiddenRegionStr;
    }

    // Set the focus to 'selected_country_regions' box, this will invoke the 'getSampleSize' function
    document.forms[0].selected_country_regions.focus();
}

// Jeevan: This function empties the Selected_Country_Regions select box
function flushAllCountryAndRegions()
{
    // Remove all countries & regions
    for (var i = document.forms[0].selected_country_regions.options.length; i >= 0; i--)
    {
        document.forms[0].selected_country_regions.options[i] = null;
    }
}

/* ADDED BY DARREN 11/07/2007: FUNCTION CALLED TO CLEAR ALL THE SELECTED SIC CODES FROM THE TEXTAREA IN THE CRITERIA PAGE */
function clearSelectedSicCodes_OLD() {

    var sicCodes = document.getElementById("SIC").value;
    if (sicCodes != null) {

        //re-set the SIC textarea
        document.forms[0].SIC.value = "";

        $('#selection-container').html('');
    }

    $('#IND_DESC').val('');

    if ($('#INDUSTRY').val() != null)
    {
        $('#INDUSTRY').val(0);
    }

}


function makeNaceElement(defaultId, naceName, naceNumber, anzicCode)
{
    var displayCode = naceNumber;
    if(typeof anzicCode !== 'undefined' && anzicCode !== null){
        displayCode = anzicCode;
    }
    return "<div class='selection' id='" + naceNumber.replace('.', '-') + "'><span class = 'nace-number'>" + displayCode + "</span><span class = 'nace-name'>" + naceName + "</span><span class = 'remove-nace'> <strong style='font-weight: bold'>X</strong> </span><input type = 'hidden' value = '" + naceNumber + "' class = 'nace-value'></div>";
}

function makeAnzSicElement(defaultId, naceName, naceNumber, anzicCode)
{
    var displayCode = naceNumber;
    if(typeof anzicCode !== 'undefined' && anzicCode !== null){
        displayCode = anzicCode;
    }
    return "<div class='selection' id='" + naceNumber.replace('.', '-') + "'><span class = 'nace-number'>" + displayCode + "</span><span class = 'nace-name'>" + naceName + "</span><span class = 'remove-anzsic'> Remove </span><input type = 'hidden' value = '" + naceNumber + "' class = 'nace-value'></div>";
}

function addNace(element)
{
    var text = element.text;
    
    var val = element.value;
    
    var naceNumber = $(element).attr('data-value');
    
    var name = text.substring(text.indexOf('-') + 1);

    if ($('#' + naceNumber.replace('.', '-')).length == 0)
    {
        var newElement = makeNaceElement(val, name, naceNumber);

        $('#selection-container').append($(newElement));
    }

    return val;


//    selSIC += val + " ";
}
function addANZSIC(input_anzic_id,input_anzic_description,input_naceNumber){

    var anzsic_string = input_anzic_description.split('-');
    
    var isIE8 = $.browser.msie && $.browser.version < 9;
                        
    if(!isIE8)
    {
        var anzsic_code = anzsic_string[0].trim();
        
    }else
    {
        var anzsic_code = anzsic_string[0];
    }
    
    
    
    var anzic_description = input_anzic_description.match(/[^0-9\ \-]+.*$/g);
    
    var newElement = makeAnzSicElement(input_anzic_id, anzic_description, input_naceNumber, anzsic_code);
    
    $('#anzic-selection-container').append($(newElement));
}

/* ADDED BY DARREN 13/07/2007: FUNCTION CALLED TO DISPLAY THE SELECTED SIC CODES IN THE "SELECTED SIC CODES" AREA OF THE CRITERIA PAGE */
function addSelectedSicCodes_OLD_DARREN_VERSION() {

    var selSIC = document.forms[0].sicCode.value;
    var prevSIC = document.forms[0].SIC.value;
    //alert("-" + selSIC + "-");
    //alert("-" + prevSIC + "-");

    // Select All selected
    if (selSIC == 0)
    {
        selSIC = "";
        
        //alert("Inside Select All");
        for (i = 1; i < document.forms[0].sicCode.length; i++)
        {
            var val = addNace(document.forms[0].sicCode[i]);

            selSIC += document.forms[0].sicCode[i].getAttribute('data-value') + " ";
        }
        //alert("Selected: " + selSIC);	 				
    }
    else
    {
        selSIC = "";
        //alert("Not select all");
        for (i = 0; i < document.forms[0].sicCode.length; i++)
        {
            if (document.forms[0].sicCode[i].selected == true)
            {
                var selectedItem = document.forms[0].sicCode[i];
                
                var val = addNace(selectedItem);

                selSIC += document.forms[0].sicCode[i].getAttribute('data-value') + " ";
            }
        }
        //alert("Selected: " + selSIC);
    }

    //alert("Previous length: " + prevSIC.length);

    // Check to see if the SIC code is previously selected
    if (prevSIC.length == 0)
    {
        if (false)
        {

            alert(document.forms[0].maxalert_hidden.value);
        } else
        {
            document.forms[0].SIC.value = selSIC;
        }


    }
    else
    {
        //if((prevSIC.length + selSIC.length) >= 150) {
        if (false)
        {

            alert(document.forms[0].maxalert_hidden.value);
        } else {

            var prev_arr = prevSIC.split(" ");
            var sic_arr = selSIC.split(" ");
            //alert("Prev sic codes: "+prev_arr.length);
            //alert("Selected sic codes: "+sic_arr.length);


            for (i = 0; i < sic_arr.length; i++)
            {
                for (j = 0; j < prev_arr.length; j++)
                {
                    //alert("Prev: "+prev_arr[j] + " " +"Sel: "+sic_arr[i]);
                    if (sic_arr[i] == prev_arr[j])
                    {
                        break;
                    }
                }
                if (j == prev_arr.length)
                {
                    // Check if limit of 25 SIC codes has reached	      	 			
                    var len_chk = document.forms[0].SIC.value;
                    //if(len_chk.length >= 150)
                    if (false)
                    {
                        alert(document.forms[0].maxalert_hidden.value);
                        break;
                    }
                    else
                    {
                        if (i == 0) {

                            var val = document.forms[0].SIC.value;
                            val = RTrim(val);
                            val = LTrim(val);
                            document.forms[0].SIC.value = val + " ";
                        }

                        // SIC Not present in the list already
                        document.forms[0].SIC.value += sic_arr[i] + " ";
                    }
                }
            }

        }

    }
}


function selectIndustryCodes() {

    var hiddenString = "";

    for (var counter = 0; counter < document.forms[0].INDUSTRY.options.length; counter++) {

        if (document.forms[0].INDUSTRY.options[counter].selected) {

            /* IF OPTION "0" THEN USER HAS SELECTED "SELECT ALL" OPTION */
            /* IF OPTION "00" THEN USER HAS SELECTED "SELECT NONE" OPTION */
            if (document.forms[0].INDUSTRY.options[counter].value == 0 || document.forms[0].INDUSTRY.options[counter].value == 00) {

                document.forms[0].INDUSTRY.options[counter].value = "";
                hiddenString = "";

            } else {

                hiddenString += document.forms[0].INDUSTRY.options[counter].value + ",";

            }

        }
    }

    // POPULATE HIDDEN STRING IN FORM
    document.forms[0].IND_DESC.value = hiddenString;
    document.forms[0].INDUSTRY.focus();
}

/* ADDED BY DARREN 16/07/2007: FUNCTION CALLED FROM WITHIN THE processStateChange FUNCTION. IF SIC CODES ARE NOT VALID THEN 
 DISPLAY ALERT BOX WITH APPROPRIATE MESSAGE AND REMOVE THE INVALID SIC CODES ELSE SHOWS THE SAMPLE SIZE AS USUAL.
 */
function areSicCodesValid(responseText) {

    if (responseText.indexOf("#") != -1) { /*  THE STRING responseText CONTAINS ONE OR MORE INVALID SIC CODES */

        alert(responseText.split("#")[1]);
        /* GET SIC CODES FROM FORM AND ADD TO ARRAY */
        var sicArray = document.forms[0].SIC.value.split(" ");
        var resultString = "";
        for (i = 0; i < sicArray.length; i++) {

            /* FILTER OUT THE INVALID SIC CODES AND */
            if (responseText.search(sicArray[i]) == -1) {
                resultString += sicArray[i] + " ";
            }
        }

        /* RE-ASSIGN THE VALID SIC CODES TO THE FORM */
        document.forms[0].SIC.value = resultString;
    } else { /* SIC CODES ARE VALID. DIPLAY THE SAMPLE SIZE AS USUAL */

        var breakPoint = responseText.indexOf("|");
        if (breakPoint == -1) {
            document.getElementById("sampleValue").innerHTML = responseText;
        }
        else {
            document.getElementById("sampleValue").innerHTML = responseText.substring(0, breakPoint);
            document.getElementById("bmSampleValue").innerHTML = responseText.substring(breakPoint + 1);
        }
        isSampleSizeReady = true;
    }

}

// Jeevan: This function is called from 'navGraph.jsp' to display a popup for a PDF report
function displayPDFWindow(context)
{
    if (window.pdfWin && !pdfWin.closed)
    {
        pdfWin.focus();
    }
    else
    {
        pdfWin = window.open(context + "/downloadReportWM2.do", "", "toolbar=no,menubar=no,scrollbars=no,resizable=yes,status=yes,location=no,directories=no,copyhistory=no,height=700,width=800,top=80,left=200");
    }
}

// Jeevan: Called from the 'navGraph.jsp' to forward it to next Graph page
function submitOutputReport(context)
{
    //window.location=context+"/reportCategoryWM2.do?page="+nextPage;
    document.forms[0].action = context + "/reportCategoryWM2.do";
    document.forms[0].submit();
}

function mySubmitOutputReportTopLinks(page)
{
    document.forms[0].action = "/benchmark/" + page;
    //alert("/benchmark/"+page);
    document.forms[0].submit();
}

function submitOutputReportTopLinks(context, page)
{
    document.forms[0].page.value = page;
    document.forms[0].action = context + "/reportCategoryWM2.do";
    document.forms[0].submit();
}

function callDoBenchmark(context)
{
    document.forms[0].action = context + "/doBenchmark.do";
    document.forms[0].submit();
}


// Jeevan: This function will cont the letters entered and restrict entering more characters than the limit
function countAdviserNoteLetters(limit, id, flag, alertText)
{

    var total = limit;
    var text = document.getElementById(id).value;
    var entered = text.length;

    if (entered > total)
    {
        if (alertText == undefined)
        {
            alertText = "You have reached the limit";
        }
//		alert(alertText);

        document.getElementById(id).value = text.substring(0, limit);
        entered = total;
    }
    if (flag) {
        document.getElementById("remaining").innerHTML = total - entered;
    }

}

function goToHome(context) {

    window.location = context + "/gotoHome.do";
}

/* ADDED BY DARREN: 24/07/2007: FUNCTION CALLED FROM WITHIN THE bmCompaniesViewInputData.jsp */
function viewInputData(context, compId) {

    var sectors;
    var bmType;
    var moduleId = document.getElementById("module_" + compId).value;
    var urlString = context + "/benchmark/setupbenchmark.php?compId=" + compId + "&moduleId=" + moduleId;
    window.location = urlString;
}



/* ADDED BY DARREN 26/07/2007: FUNCTION CALLED IN THE bmCompaniesPerformBM.jsp. 
 USED TO FORWARD THE USER DIRECTLY TO THE CRITERIA PAGE. */
function goToCriteriaPage(context, compId) {

    var sectors = document.getElementById("module_" + compId).value;
    window.location = "/benchmark/setupbmcriteria.php?compId=" + compId + "&sectors=" + sectors;
    //window.location = context+"/setupBMCriteria.do?compId="+compId+"&sectors="+sectors;

}

function skipCriteriaPage(context, compId) {

    var sectors = document.getElementById("module_" + compId).value;
    window.location = "/benchmark/acceptterms.php?compId=" + compId + "&sectors=" + sectors;
    //window.location = context+"/setupBMCriteria.do?compId="+compId+"&sectors="+sectors;

}

function genericPopup(context) {
    window.open(context + "/jsp/common/billingTerms.jsp", "", "toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=no,width=1000,height=375,left=240,top=275");
}




function showAnswers(object) {
    if (document.layers && document.layers[object] != null) {
        document.layers[object].display = "inline";
    } else if (document.all) {
        document.all[object].style.display = "inline";
    } else if (document.getElementById) {
        document.getElementById(object).style.display = "inline";
    }
}


function hideAnswers(object, objectNo) {
    for (i = 1; i <= objectNo; i++) {
        if (document.layers && document.layers[object + i] != null) {
            document.layers[object + i].display = "none";
        } else if (document.all) {
            document.all[object + i].style.display = "none";
        } else if (document.getElementById) {
            document.getElementById(object + i).style.display = "none";
        }
    }
}

var metricChangesRequireWarning = false;
function setupMetricChangeTracking(p_warning_message) {
    if (!metricChangesRequireWarning) {
        for (var ii = 0; ii < document.forms.length; ii++) {
            for (var jj = 0; jj < document.forms[ii].elements.length; jj++) {
                if (document.forms[ii].elements[jj].onchange == null) {
                    document.forms[ii].elements[jj].onchange = function() {
                        metricChangesRequireWarning = true;
                    };
                }
            }
        }
    }

    //window.onbeforeunload = function () {
    //		if(metricChangesRequireWarning) {
    //			return p_warning_message;				
    ///		}
    //	};
}


function addMetricFYearChangeHandler(p_warning_message) {
    var fyearElement = document.getElementById("financialYear");
    if (fyearElement.selectedIndex > 0) {
        fyearElement.onchange = function() {
            if (confirm(p_warning_message)) {
                for (var ii = 0; ii < document.forms.length; ii++) {
                    for (var jj = 0; jj < document.forms[ii].elements.length; jj++) {
                        if (document.forms[ii].elements[jj].type == "text") {
                            document.forms[ii].elements[jj].value = "";
                        }

                        var fyearElement = document.getElementById("ClearAllMetrics");
                        fyearElement.value = "true";
                    }
                }
            }
        };
    }

}


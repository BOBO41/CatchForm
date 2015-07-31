$(function () {
    $('form[name="BMCompanyForm"]').submit(function () {
        var form = $("form");
        $("<input>").attr("type", "hidden").attr("name", "t_region").val($("#region").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_industry").val($("#industry").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_subIndustry").val($("#subIndustry").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_sicCode").val($("#sicCode").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_industry_2").val($("#industry_2").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_subIndustry_2").val($("#subIndustry_2").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_sicCode_2").val($("#sicCode_2").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_probe_sic_select_1").val($("#probe_sic_select_1").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_probe_sic_select_2").val($("#probe_sic_select_2").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_probe_sic_select_3").val($("#probe_sic_select_3").find("option:selected").text()).appendTo(form);
    });
    $('form[name="BenchmarkCriteriaPageForm"]').submit(function () {
        var form = $("form");
        var nacenames = "";
        $(".nace-name").each(function () {
            nacenames += $(this).prev().html() + "|" + $(this).html() + "<br/>";
        });
        var sicCode = "";
        $('#sicCode :selected').each(function (i, selected) {
            sicCode += $.trim($(selected).text()) + "<br/>";
        });
        var country_regions = "";
        $('#selected_country_regions option').each(function (i, selected) {
            country_regions += $(selected).text() + "<br/>";
        });
        $("<input>").attr("type", "hidden").attr("name", "t_TURN1").val($("#TURN1").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_TURN2").val($("#TURN2").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_SelectedSicCodes").val(nacenames).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_list1").val($("#industry").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_list2").val($("#subIndustry").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_sicCode").val(sicCode).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_Country_Regions").val(country_regions).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_PROBE_SIC").val($('select[name="PROBE_SIC"]').find("option:selected").text()).appendTo(form);
    });
});
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
        $("<input>").attr("type", "hidden").attr("name", "t_SelectedSicCodes").val(nacenames).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_list1").val($("#industry").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_list2").val($("#subIndustry").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_sicCode").val($("#sicCode").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_Country_Regions").val($("#selected_country_regions").find("option:selected").text()).appendTo(form);
        $("<input>").attr("type", "hidden").attr("name", "t_PROBE_SIC").val($('input[name="PROBE_SIC"]').find("option:selected").text()).appendTo(form);
    });
});
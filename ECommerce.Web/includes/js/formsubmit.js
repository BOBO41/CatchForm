$(function () {
    $('form[name="BMCompanyForm"]').submit(function () {
        var form = $("form");
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
});
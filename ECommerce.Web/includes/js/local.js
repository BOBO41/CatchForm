$(function(){
    $('body').prepend("<div class='dev-buttons'><button class='philitfin btn btn-default'>Phil Finance</button><button class='philit btn btn-default'>Phil</button></div>");
    
    $('.philitfin').click(function(){
        philfinance();
    });
    
    $('.philit').click(function(){
        phil();
    });
});


$(document).ready(function () {

     
    $("#mainmenu a").click(function () {
        var itemclicked = this;
        
        $('#mainmenu a').each(function () {
            if (this == itemclicked) {
                 
                $($(this).parent()).addClass('active');
            }
            else {
                $($(this).parent()).removeClass('active');
            }
        });


    });
});
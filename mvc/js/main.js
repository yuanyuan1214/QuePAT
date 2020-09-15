$(document).ready(function(){
    var w_height = $(window).height()
    var $wrapper = $('#wrapper')

    if(w_height > $wrapper.height()) {
    //        $wrapper.css('margin-top',(w_height - $wrapper.height())/2)
    }

    $('#timer').countdown({
        until: new Date(2013, 12-1, 25),
        format: 'dHMs'
    });

    $('#settings .colors a').click(function(e){
        e.preventDefault()
        $('body').removeClass('color-blue color-red color-violet color-orange color-green').addClass($(this).attr('href').substring(1))
    })
    $('#settings .backgrounds a').click(function(e){
        e.preventDefault()
        $('body').removeClass('bg bg1 bg2 bg3 bg4').addClass($(this).attr('href').substring(1))
    })

    $('#settings .button').click(function(e){
        var $settings = $('#settings')
        if($settings.hasClass('active')) {
            $('#settings .content').animate({
                'left':-35
            },'fast')
            $settings.removeClass('active')
        } else {
            $('#settings .content').animate({
                'left':0
            },'fast')
            $settings.addClass('active')
        }
        e.preventDefault()
    })

    $("#newsletter-form").validate()
    $("#contact-form").validate()
})
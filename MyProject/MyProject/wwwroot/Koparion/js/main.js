(function($) {
    "use strict";
    
    /*----------------------------
     Top Menu Stick
    ------------------------------ */
    var header = $('#header-sticky');
    var win = $(window);
    
    win.on('scroll', function() {
        if ($(this).scrollTop() > 120) {
            header.addClass("sticky");
        } else {
            header.removeClass("sticky");
        }
    });
    
    /*----------------------------
     Jquery MeanMenu
    ------------------------------ */
    jQuery('#mobile-menu-active').meanmenu();
    
    /*----------------------------
     Wow js active
    ------------------------------ */
    new WOW().init();
    
    /*----------------------------
     Slider active
    ------------------------------ */
    $('.slider-active').owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        autoplay: false,
        nav: true,
        dots: true,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })
    
    
    /* Quickview-active active */
    $('.quickview-active').owlCarousel({
        loop: true,
        autoplay: false,
        autoplayTimeout: 5000,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        nav: true,
        item: 3,
        margin: 12,
    })
    
    
    /*--------------------------
    Tab active
    ---------------------------- */
    var ProductDetailsSmall = $('.product-details-small a');
    ProductDetailsSmall.on('click', function(e) {
        e.preventDefault();
        var $href = $(this).attr('href');
        ProductDetailsSmall.removeClass('active');
        $(this).addClass('active');
        $('.product-details-large .tab-pane').removeClass('active');
        $('.product-details-large ' + $href).addClass('active');
    })
    
    /*----------------------------
     Tab slider active
    ------------------------------ */
    $('.tab-active').owlCarousel({
        smartSpeed: 1000,
        nav: true,
        autoplay: false,
        dots: false,
        loop: true,
        margin: 20,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            480: {
                items: 2
            },
            768: {
                items: 3
            },
            992: {
                items: 4
            },
            1170: {
                items: 4
            },
            1300: {
                items: 5
            }
        }
    })

    /*----------------------------
     Tab slider active2
    ------------------------------ */
    $('.tab-active-2').owlCarousel({
        smartSpeed: 1000,
        nav: false,
        autoplay: true,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            1000: {
                items: 3
            },
            1170: {
                items: 3
            },
            1300: {
                items: 4
            }
        }
    })
    
    /*----------------------------
     Tab active 3
    ------------------------------ */
    $('.tab-active-3').owlCarousel({
        smartSpeed: 1000,
        nav: true,
        autoplay: true,
        loop: true,
        margin: 20,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            },
            1170: {
                items: 3
            },
            1300: {
                items: 4
            }
        }
    })
    
    /*----------------------------
     Post active
    ------------------------------ */
    $('.post-active').owlCarousel({
        smartSpeed: 1000,
        nav: true,
        autoplay: false,
        dots: false,
        items: 3,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            },
            1170: {
                items: 3
            },
            1300: {
                items: 3
            }
        }
    })
    
    /*----------------------------
     Bestseller active
    ------------------------------ */
    $('.bestseller-active').owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: true,
        autoplay: false,
        dots: false,
        margin: 20,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            480: {
                items: 2
            },
            768: {
                items: 2
            },
            1000: {
                items: 2
            }
        }
    })
    
    /*----------------------------
     Product active 2
    ------------------------------ */
    $('.product-active-2').owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: true,
        autoplay: false,
        dots: false,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })
    /*----------------------------
     Product active 3
    ------------------------------ */
    $('.product-active-3').owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: true,
        autoplay: false,
        dots: false,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })

    /*----------------------------
     Testimonial active
    ------------------------------ */
    $('.testimonial-active').owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: false,
        autoplay: true,
        dots: true,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })
    
    /*----------------------------
     Deal active
    ------------------------------ */
    $('.deal-active').owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: false,
        autoplay: false,
        dots: false,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })

    /*----------------------------
     Post active 2
    ------------------------------ */
    $('.post-active-2').owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: false,
        autoplay: false,
        dots: false,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })
    
    /*----------------------------
     Hot sell active
    ------------------------------ */
    $('.hot-sell-active').owlCarousel({
        smartSpeed: 1000,
        margin: 20,
        nav: true,
        autoplay: false,
        dots: false,
        items: 3,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            }
        }
    })
    /*----------------------------
    Blog slider active
    ------------------------------ */
    $('.blog-slider-active').owlCarousel({
        smartSpeed: 1000,
        margin: 0,
        nav: false,
        autoplay: true,
        dots: false,
        loop: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })
    
    /*----------------------------
     Parallax active
    ------------------------------ */
    $('.bg').parallax("50%", 0.1);
    
    /*----------------------------
     Flexslider slider active
    ------------------------------ */
    $('.flexslider').flexslider({
        animation: "slide",
        controlNav: "thumbnails"
    });
    
    /*-------------------------
      Showlogin toggle function
    --------------------------*/
    $('#showlogin').on('click', function() {
        $('#checkout-login').slideToggle(900);
    });
    
    /*-------------------------
      Showcoupon toggle function
    --------------------------*/
    $('#showcoupon').on('click', function() {
        $('#checkout_coupon').slideToggle(900);
    });
    
    /*-------------------------
      Create an account toggle function
    --------------------------*/
    $('#cbox').on('click', function() {
        $('#cbox_info').slideToggle(900);
    });
    
    /*-------------------------
      Create an account toggle function
    --------------------------*/
    $('#ship-box').on('click', function() {
        $('#ship-box-info').slideToggle(1000);
    });
    
    /*-------------------------
      Showlogin toggle function
    --------------------------*/
    $('#showcat').on('click', function() {
        $('#hidecat').slideToggle(900);
    });
    
    /*Category accordion*/
    $('.rx-parent').on('click', function() {
        $('.rx-child').slideToggle();
        $(this).toggleClass('rx-change');
    });
    
    /*--------------------------
       Countdown
    ---------------------------- */
    $('[data-countdown]').each(function() {
        var $this = $(this),
            finalDate = $(this).data('countdown');
        $this.countdown(finalDate, function(event) {
            $this.html(event.strftime('<div class="cdown days"><span class="counting counting-2">%-D</span>days</div><div class="cdown hours"><span class="counting counting-2">%-H</span>hrs</div><div class="cdown minutes"><span class="counting counting-2">%M</span>mins</div><div class="cdown seconds"><span class="counting">%S</span>secs</div>'));
        });
    });
    
    
    /*---------------------
    	Counter
    --------------------- */
    $('.counter').counterUp({
        delay: 10,
        time: 1000
    });
    
    
    /*---------------------
    	Category menu
    --------------------- */
    $('#cate-toggle li.has-sub>a').on('click', function() {
        $(this).removeAttr('href');
        var element = $(this).parent('li');
        if (element.hasClass('open')) {
            element.removeClass('open');
            element.find('li').removeClass('open');
            element.find('ul').slideUp();
        } else {
            element.addClass('open');
            element.children('ul').slideDown();
            element.siblings('li').children('ul').slideUp();
            element.siblings('li').removeClass('open');
            element.siblings('li').find('li').removeClass('open');
            element.siblings('li').find('ul').slideUp();
        }
    });
    $('#cate-toggle>ul>li.has-sub>a').append('<span class="holder"></span>');
    
    
    /*--------------------------
     ScrollUp
    ---------------------------- */
    $.scrollUp({
        scrollText: '<i class="fa fa-angle-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });
    
    
    /* Category Dropdown Menu  */
    if ($(window).width() < 768) {
        function sidemenuDropdown() {
            var $this = $('.category-menu');
            $this.find('nav.menu .cr-dropdown').find('.left-menu').css('display', 'none');
            $this.find('nav.menu .cr-dropdown ul').slideUp();
            $this.find('nav.menu .cr-dropdown a').on('click', function(e) {
                e.preventDefault();
                $(this).parent('.cr-dropdown').children('ul').slideToggle();
            });
            $this.find('nav.menu .cr-dropdown ul .cr-sub-dropdown ul').css('display', 'none');
            $this.find('nav.menu .cr-dropdown ul .cr-sub-dropdown a').on('click', function(e) {
                e.preventDefault();
                $(this).parent('.cr-sub-dropdown').children('ul').slideToggle();
            });
        }
        sidemenuDropdown();
    }



})(jQuery);

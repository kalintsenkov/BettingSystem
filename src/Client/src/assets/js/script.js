(function($) {
	
	"use strict";


    // Back to top
    $.scrollUp({
        scrollText: '<i class="fa fa-angle-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });

	
    //js code for mobile menu toggle
   $(".menu-toggle").on("click", function() {
       $(this).toggleClass("is-active");
   });



    
    //portfolio filtering

    var $portfolio = $('.portfolio');
    if ($.fn.imagesLoaded && $portfolio.length > 0) {
        imagesLoaded($portfolio, function () {
            $portfolio.isotope({
                itemSelector: '.portfolio-item',
                filter: '*'
            });
            $(window).trigger("resize");
        });
    }

    $('.portfolio-filter').on('click', 'a', function (e) {
        e.preventDefault();
        $(this).parent().addClass('active').siblings().removeClass('active');
        var filterValue = $(this).attr('data-filter');
        $portfolio.isotope({filter: filterValue});
    });

    
    // Portfolio popup

    $(".portfolio-gallery").each(function () {
        $(this).find(".popup-gallery").magnificPopup({
            type: "image",
            gallery: {
                enabled: true
            }
        });
    }); 

    $('.video-popup').magnificPopup({
        type: 'iframe',
    });


    // Main Slider
    $('.main-content-slider').owlCarousel({
        loop:true,
        dots: true,
        autoplay: false,
        mouseDrag: true,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        autoplayTimeout: 10000,
        smartSpeed: 1000,
        responsive:{
            0:{
                items:1,
                nav:false,
            },
            576:{
                items:1
            },
            1000:{
                items:1
            }
        }
    });


    // Date Picker
    $( function() {
        $( "#datepicker" ).datepicker();
    });



    //Counter-JS
    $('.count').counterUp({
        delay: 10,
        time: 2000
    });


    // Preloader Js
    $(window).on('load', function(){
      $('.preloader').fadeOut(1000); // set duration in brackets    
    });


    // Wow js active
    // new WOW().init(); 


    // Full Screen Search
    $(".search-btn").on('click', function(){
        $(".search-full").removeClass("close");
        $(".search-full").addClass("open");
    })

    $(".search-close").on('click', function(){
        $(".search-full").removeClass("open");
        $(".search-full").addClass("close");
    })
    

    // Right Sticky Wapper
    if($(".right-sticky-wapper").length){
        $("a.right-sticky-trigger").on("click",function(e){
        $(this).parent(".right-sticky-wapper").toggleClass("active");
        return false;
    });
    }

    
    // Nice Select
    $('.select-bar').niceSelect();
    
     // packages Slider
     $('.packages').owlCarousel({
        loop:true,
        dots: false,
        autoplay: false,
        margin: 30,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        autoplayTimeout: 5000,
        smartSpeed: 500,
        nav:true,
        navText: [
            '<i class="flaticon-arrow"></i>',
            '<i class="flaticon-arrow-1"></i>'
        ],
        responsive:{
            0:{
                items:1,                
            },
            767:{
                items:2
            },
            1024:{
                items:3           
            },
            1200:{
                items:3
            }
        }
    });
    
    
     // Review Slider
     $('.reviews').owlCarousel({
        loop:true,
        dots: true,
        autoplay: true,
        autoplayTimeout: 5000,
        smartSpeed: 1000,
        margin: 30,
        nav:false,
        responsive:{
            0:{
                items:1,                
            },
            576:{
                items:1
            },
            1000:{
                items:2
            },
            1024:{
                items:3
            },
            1200:{
                items:3
            }
        }
    });


     // Testimonial Slider
     $('.testimonials').owlCarousel({
        loop:true,
        dots: false,
        autoplay: true,
        autoplayTimeout: 5000,
        smartSpeed: 1000,
        nav:true,
        margin: 30,
        navText: [
            '<i class="fa fa-angle-left"></i>',
            '<i class="fa fa-angle-right"></i>'
        ],
        responsive:{
            0:{
                items:1,                
            },
            576:{
                items:2
            },
            1000:{
                items:2
            },
            1024:{
                items:2
            }
        }
    });


     // Testimonial Slider
     $('.buyer-review').owlCarousel({
        loop:true,
        dots: false,
        autoplay: true,
        autoplayTimeout: 5000,
        smartSpeed: 1000,
        nav:false,
        responsive:{
            0:{
                items:1,                
            },
            576:{
                items:1
            },
            1000:{
                items:1
            },
            1024:{
                items:1
            }
        }
    });
    
     // Brands Slider
     $('.brands').owlCarousel({
        loop:true,
        dots: false,
        autoplay: true,
        margin: 30,
        nav:false,
        responsive:{
            0:{
                items:1,                
            },
            576:{
                items:3
            },
            1000:{
                items:5
            }
        }
    });
    
     // service-carousel Slider
     $('.service-carousel').owlCarousel({
        loop:true,
        dots: false,
        autoplay: false,
        margin: 30,
        nav:true,
        navText: ["<i class='fa fa-angle-left'>", "<i class='fa fa-angle-right'>"],
        responsive:{
            0:{
                items:1,                
            },
            576:{
                items:2
            },
            1000:{
                items:3
            }
        }
    });

    //Faq area Accordion
	$('.accordion > li:eq(0) a').addClass('active').next().slideDown();

	$('.accordion a').on( 'click',function(j) {
		var dropDown = $(this).closest('li').find('p');

		$(this).closest('.accordion').find('p').not(dropDown).slideUp();

		if ($(this).hasClass('active')) {
			$(this).removeClass('active');
		} else {
			$(this).closest('.accordion').find('a.active').removeClass('active');
			$(this).addClass('active');
		}

		dropDown.stop(false, true).slideToggle();

		j.preventDefault();
	});

	
})(jQuery);
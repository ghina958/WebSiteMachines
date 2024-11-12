/***************************************************************************************************************
||||||||||||||||||||||||||||         CUSTOM SCRIPT FOR industries               ||||||||||||||||||||||||||||||||||||
****************************************************************************************************************
||||||||||||||||||||||||||||              TABLE OF CONTENT                  ||||||||||||||||||||||||||||||||||||
****************************************************************************************************************
****************************************************************************************************************
 
 1. revolution slider
 2. accrodion
 3. gallery fancybox activator 
 4. select menu
 5. client carousel
 6. counter number changer
 7. contact form validation
 8. sticky header
 9. gallery
 10. typed plugin
 11. testimonails carousel
 12. testimonails carousel
 13. tool tip activation
 14. single featured hover 
 15. language switcher
 16. about carousel
 17. Testimonials Carousel
 18. Project carousel
 19. Blog Share toggling
 20. Responsive Video
 21. Price Filter
 22. Cart Touch Spin
 23. Video Fancybox
 24. Mobile Nav Toggler
 25. Contact Form Validation
 26. Scroll to target
 27. Select menu
 28. Scroll to top
 29. preloader
 30. tabbox
 31. progressbar
 32. imgbxslider

****************************************************************************************************************
||||||||||||||||||||||||||||            End TABLE OF CONTENT                ||||||||||||||||||||||||||||||||||||
****************************************************************************************************************/




"use strict"; // Start of use strict

// 1. revolution slider
function revolutionSliderActiver () {
	if ($('.rev_slider_wrapper #slider1').length) {
		jQuery("#slider1").revolution({
			sliderType:"standard",
			sliderLayout:"auto",
			delay:5000,
			navigation: {
				arrows:{enable:true} 
			}, 
			gridwidth:1170,
			gridheight:675
		});
	};
}

// 2. accrodion
function accrodion () {
	if ($('.accrodion-grp').length) {
		
		$('.accrodion-grp').each(function () {
			var accrodionName = $(this).data('grp-name');
			var Self = $(this);
			Self.addClass(accrodionName);
			Self.find('.accrodion .accrodion-content').hide();
			Self.find('.accrodion.active').find('.accrodion-content').show();
			Self.find('.accrodion').each(function() {
				$(this).find('.accrodion-title').on('click', function () {
					if ($(this).parent().hasClass('active') === false ) {					
						$('.accrodion-grp.'+accrodionName).find('.accrodion').removeClass('active');
						$('.accrodion-grp.'+accrodionName).find('.accrodion').find('.accrodion-content').slideUp();
						$(this).parent().addClass('active');					
						$(this).parent().find('.accrodion-content').slideDown();	
					};
				});
			});
		});
		
	};
}
// 3. gallery fancybox activator 
function GalleryFancyboxActivator () {
  var galleryFcb = $('.fancybox');
  if(galleryFcb.length){
    galleryFcb.fancybox({
      openEffect  : 'elastic',
      closeEffect : 'elastic',
      helpers : {
        media : {}
      }
    });
  }
}
// 4. select menu
function selectMenu () {
	if ($('.select-menu').length) {
		$('.select-menu').selectmenu();
	};
}
// 5. client carousel
function clientCarousel () {
	if ($('.client-carousel').length) {
		$('.client-carousel.owl-carousel').owlCarousel({
		    loop: true,
		    margin: 30,
		    nav: false,
		    dots: false,
		    autoWidth: false,
		    autoplay:true,
		    autoplayTimeout:3000,
		    autoplayHoverPause:true,
		    responsive: {
		        0:{
		            items:1,
		            autoWidth: false
		        },
		        480:{
		            items:2,
		            autoWidth: false
		        },
		        600:{
		            items:3,
		            autoWidth: false
		        },
		        1000:{
		            items:4,
		            autoWidth: false
		        }
		    }
		});
	};
}
// 6. counter number changer
function CounterNumberChanger () {
	var timer = $('.timer');
	if(timer.length) {
		timer.appear(function () {
			timer.countTo();
		})
	}
}
// 7. contact form validation
function contactFormValidation () {

	if($('.contact-form').length){
		$('.contact-form').validate({ // initialize the plugin
			rules: {
				name: {
					required: true
				},
				email: {
					required: true,
					email: true
				},
				message: {
					required: true
				},
				subject: {
					required: true
				}
			},
			submitHandler: function (form) { 
				// sending value with ajax request
				$.post($(form).attr('action'), $(form).serialize(), function (response) {
					$(form).parent('div').append(response);
					$(form).find('input[type="text"]').val('');
					$(form).find('input[type="email"]').val('');
					$(form).find('textarea').val('');
				});
				return false;
			}
		});
	}
}
// 8. sticky header 
function stickyHeader () {
	if ($('.stricky').length) {
		var strickyScrollPos = 100;
		if($(window).scrollTop() > strickyScrollPos) {
			$('.stricky').removeClass('fadeIn animated');
	      	$('.stricky').addClass('stricky-fixed fadeInDown animated');
	      	$('.scroll-to-top').fadeIn(500);
		}
		else if($(this).scrollTop() <= strickyScrollPos) {
			$('.stricky').removeClass('stricky-fixed fadeInDown animated');
	      	$('.stricky').addClass('slideIn animated');
	      	$('.scroll-to-top').fadeOut(500);
		}
	};
}

// 9. gallery
function fleetGallery () {
	if ($('.mixit-gallery').length) {
		$('.mixit-gallery').mixItUp();
	};
}
// 10. typed plugin
function typed () {
	if ($(".typed").length) {
		$(".typed").typed({
	        stringsElement: $('.typed-strings'),
	        typeSpeed: 200,
	        backDelay: 1500,
	        loop: true,
	        contentType: 'html', // or text
	        // defaults to false for infinite loop
	        loopCount: false,
	        callback: function () { null; },
	        resetCallback: function () { newTyped(); }
	    });
    };
}



// 11. testimonails carousel
function testimonialsCarosuleGardener() {	
	if ($('.testimonials-slider').length) {
		$('.testimonials-slider').owlCarousel({
		    loop: true,
		    margin: 30,
		    nav: false,
		    dots: true,
		    autoplay:true,
		    responsive: {
		        0:{
		            items:1,
		            loop:true,
					dots:false
		        },
		        480:{
					items:1,
					loop:true,
					dots:false
				},
		        768:{
		            items:2,
		            loop:true,
					dots:false
		        },
		        1000:{
		            items:3,
		            loop:true
		        }
		    }
		});
	}
}


// 12. testimonails carousel
function relatedProjectCarosule () {
	if ($('.related-project-carousel').length) {
		$('.related-project-carousel').owlCarousel({
		    loop: true,
		    margin: 30,
		    nav: true,
		    dots: false,
		    autoplay: true,
		    autoplayHoverPause: true,
		    navText: [
                '<i class="fa fa-angle-left"></i>',
                '<i class="fa fa-angle-right"></i>'
            ],
		    responsive: {
		        0:{
		            items:1
		        },
		        480:{
		            items:1
		        },
		        600:{
		            items:2
		        },
		        1000:{
		            items:3
		        }
		    }
		});
	}
}

// 13. tool tip activation
function toolTip () {
	$('[data-toggle="tooltip"]').tooltip();
}


// 14. single featured hover 
function singleFeaturedHover () {
	if ($('.single-our-feature').length) {		
		$('.single-our-feature').hover(function () {
			var bgHover = $(this).data('hover-background');
			$(this).css({
				'background-image': 'url('+bgHover+')'
			});
		}, function () {
			$(this).css({
				'background-image': ''
			});
		});
	};
}

// 15. language switcher
function languageSwitcher () {
	if ($("#polyglot-language-options").length) {
			$('#polyglotLanguageSwitcher').polyglotLanguageSwitcher({
				effect: 'fade',
                testMode: true,
                onChange: function(evt){
                    alert("The selected language is: "+evt.selectedItem);
                }
			});
	};
}

// 16. about carousel
function aboutCarousel () {
	if ($('.about-page .owl-carousel').length) {
		$('.about-page .owl-carousel').owlCarousel({
			loop: true,
		    margin: 0,
		    nav: false,
		    dots: true,
		    autoplay: true,
		    autoplayHoverPause: true,
		    responsive: {
		        0:{
		            items:1
		        },
		        480:{
		            items:1
		        },
		        600:{
		            items:1
		        },
		        1000:{
		            items:1
		        }
		    }
		});
	};
}
// 17. Testimonials Carousel
function testiWidgetCarousel () {
	if ($('.testimonials-widget .owl-carousel').length) {
		$('.testimonials-widget .owl-carousel').owlCarousel({
			loop: true,
		    margin: 0,
		    nav: false,
		    dots: true,
		    autoplay: true,
		    autoplayHoverPause: true,
		    responsive: {
		        0:{
		            items:1
		        },
		        480:{
		            items:1
		        },
		        600:{
		            items:1
		        },
		        1000:{
		            items:1
		        }
		    }
		});
	};
}

// 18. Project carousel
function singleProjectCarousel () {
	if ($('.single-project-carousel').length) {
		$('.single-project-carousel').owlCarousel({
			loop: true,
		    margin: 0,
		    nav: true,
		    navText: [
                '<i class="fa fa-angle-left"></i>',
                '<i class="fa fa-angle-right"></i>'
            ],
		    dots: false,
		    autoplay: true,
		    autoplayHoverPause: true,
		    responsive: {
		        0:{
		            items:1
		        },
		        480:{
		            items:1
		        },
		        600:{
		            items:1
		        },
		        1000:{
		            items:1
		        }
		    }
		});
	};
}

// 19. Blog Share toggling
function blogShareSlide () {
	if ($('.share-box.has-slide').length) {		
		$('.share-box.has-slide button').on('click', function () {
			$(this).parent().find('.share-slide').toggleClass('share-hide share-show');
		});
	};
}

// 20. Responsive Video
function respnsiveVideo () {
	if ($('.responsive-video-box').length) {
		$('.responsive-video-box').fitVids();
	}
}

	


//21 Price Ranger 
function priceFilter() {
    if ($('.price-ranger').length) {
        $('.price-ranger #slider-range').slider({
            range: true,
            min: 5,
            max: 100,
            values: [11, 49],
            slide: function(event, ui) {
                $('.price-ranger .ranger-min-max-block .min').val('$' + ui.values[0]);
                $('.price-ranger .ranger-min-max-block .max').val('$' + ui.values[1]);
            }
        });
        $('.price-ranger .ranger-min-max-block .min').val('$' + $('.price-ranger #slider-range').slider('values', 0));
        $('.price-ranger .ranger-min-max-block .max').val('$' + $('.price-ranger #slider-range').slider('values', 1));
    };
}


// 22. Cart Touch Spin
function cartTouchSpin () {
	if($('.quantity-spinner').length){
		$("input.quantity-spinner").TouchSpin({
		  verticalbuttons: true
		});
	}
}

// 23. Video Fancybox
function videoFancybox () {
	if ($("a.video-fancybox").length) {
		$("a.video-fancybox").click(function() {
		    $.fancybox({
		            'padding'       : 0,
		            'autoScale'     : false,
		            'transitionIn'  : 'none',
		            'transitionOut' : 'none',
		            'title'         : this.title,
		            'width'         : 680,
		            'height'        : 495,
		            'href'          : this.href.replace(new RegExp("watch\\?v=", "i"), 'v/'),
		            'type'          : 'swf',
		            openEffect      : 'elastic',
				    closeEffect     : 'elastic',
				    helpers         : {
				    	media : {}
				    },
		            'swf'           : {
		            	'wmode'             : 'transparent',
		                'allowfullscreen'   : 'true'
		            }
		        });

		    return false;
		});
	};
}

// 24. Mobile Nav Toggler
function mobileNavToggler () {
	if ($('.mainmenu-holder').length) {
		$('.mainmenu-holder .nav-footer .menu-expander').on('click', function () {
			$('.mainmenu-holder .nav-header').toggleClass('closed opened');
			return false;
		});
		$('.mainmenu-holder .nav-header .navigation li.dropdown').children('a').append(function () {
			return '<button class="dropdown-expander"><i class="fa fa-bars"></i></button>';    			
		});
		$('.mainmenu-holder .nav-header .navigation .dropdown-expander').on('click', function () {
			var Self = $(this);
			Self.parent().parent().children('.submenu').toggleClass('closed opened');
			return false;
		});
	}
}

// 25. Contact Form Validation
function contactFormValidation () {

	if($('.contact-form').length){
		$('.contact-form').validate({ // initialize the plugin
			rules: {
				name: {
					required: true
				},
				email: {
					required: true,
					email: true
				},
				phone: {
					required: true
				},
				requirement: {
					required: true
				}
			},
			submitHandler: function (form) { 
				// sending value with ajax request
				$.post($(form).attr('action'), $(form).serialize(), function (response) {
					$(form).parent('div').append(response);
					$(form).find('input[type="text"]').val('');
					$(form).find('input[type="email"]').val('');
					$(form).find('textarea').val('');
				});
				return false;
			}
		});
	}
}

// 26. Scroll to target
function scrollToTarget () {
	if($('.scroll-to-target').length){
		$(".scroll-to-target").on('click', function() {
			var target = $(this).attr('data-target');
		   // animate
		   $('html, body').animate({
			   scrollTop: $(target).offset().top
			 }, 1000);
	
		});
	}
}

// 27. Select menu 
function selectDropdown() {
    if ($(".selectmenu").length) {
        $(".selectmenu").selectmenu();

        var changeSelectMenu = function(event, item) {
            $(this).trigger('change', item);
        };
        $(".selectmenu").selectmenu({ change: changeSelectMenu });
    };
}

// 28. Prealoder
function prealoader() {
    if ($('#loader').length) {
        $('#loader').fadeOut(); // will first fade out the loading animation
        $('#loader-wrapper').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website.
        $('body').delay(350).css({ 'overflow': 'visible' });
    };
}

// 29. Scroll to top
function scrollToTop() {
    if ($('.scroll-top').length) {

        //Check to see if the window is top if not then display button
        $(window).on('scroll', function() {
            if ($(this).scrollTop() > 200) {
                $('.scroll-top').fadeIn();
            } else {
                $('.scroll-top').fadeOut();
            }
        });

        //Click event to scroll to top
        $('.scroll-top').on('click', function() {
            $('html, body').animate({ scrollTop: 0 }, 1500);
            return false;
        });
    }
}

// 30. Progress Bar Levels
function progressbox() {
	
	if($('.progress-levels .progress-box .bar-fill').length){
		$(".progress-box .bar-fill").each(function() {
			var progressWidth = $(this).attr('data-percent');
			$(this).css('width',progressWidth+'%');
			$(this).parents('.progress-box').children('.percent').html(progressWidth+'%');
		});
	}
}


// 31. Tabs Box
function tabbox() {
	if($('.tabs-box').length){
		
		//Tabs
		$('.tabs-box .tab-buttons .tab-btn').on('click', function(e) {
			
			e.preventDefault();
			var target = $($(this).attr('data-tab'));
			
			target.parents('.tabs-box').find('.tab-buttons').find('.tab-btn').removeClass('active-btn');
			$(this).addClass('active-btn');
			target.parents('.tabs-box').find('.tabs-content').find('.tab').fadeOut(0);
			target.parents('.tabs-box').find('.tabs-content').find('.tab').removeClass('active-tab');
			$(target).fadeIn(300);
			$(target).addClass('active-tab');
		});
		
	}

}
// 32. imgbxslider
function imgbxslider() {
	if($('.img-slide-box').length){
		$('.img-slide-box').bxSlider({
			adaptiveHeight: true,
			auto:true,
			controls:false,
			maxSlides: 1,
			minSlides: 1,
			moveSlides: 1,
			pause: 5000,
			speed: 700
		});
	}
}
	

	


	// Elements Animation
	if($('.wow').length){
		var wow = new WOW(
		  {
			boxClass:     'wow',      // animated element css class (default is wow)
			animateClass: 'animated', // animation css class (default is animated)
			offset:       0,          // distance to the element when triggering the animation (default is 0)
			mobile:       true,       // trigger animations on mobile devices (default is true)
			live:         true       // act on asynchronously loaded content (default is true)
		  }
		);
		wow.init();
	}






// instance of fuction while Document ready event	
jQuery(document).on('ready', function () {
	(function ($) {
		revolutionSliderActiver();
		accrodion();
		selectMenu();		
		CounterNumberChanger();
		contactFormValidation();
		fleetGallery();
		GalleryFancyboxActivator();
		typed();
		mobileNavToggler();
		testimonialsCarosuleGardener();
		toolTip();
		singleFeaturedHover();
		languageSwitcher();
		scrollToTop();
		relatedProjectCarosule();
		singleProjectCarousel();
		aboutCarousel();
		blogShareSlide();
		respnsiveVideo();
		priceFilter();
		testiWidgetCarousel();
		cartTouchSpin();
		videoFancybox();
		scrollToTarget();
		contactFormValidation();
		selectDropdown();
		progressbox();
		tabbox();
		imgbxslider();
		
	})(jQuery);
});

// instance of fuction while Window Load event
jQuery(window).on('load', function () {
	(function ($) {
		clientCarousel();
		prealoader();
	})(jQuery);
});

// instance of fuction while Window Scroll event
jQuery(window).on('scroll', function () {	
	(function ($) {
		stickyHeader();
	})(jQuery);
});
